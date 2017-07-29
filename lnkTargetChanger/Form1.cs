using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace lnkTargetChanger
{
    public partial class Form1 : Form
    {
        // Les variables globals au formulaire
        string appDataArterris = "";//c'est dans ce repertoire qu'on a les droits et qu'il convient d'écrire
        string appdata = "";//son ss rep.
        static configObject co = new configObject();

        public Form1()
        {
            InitializeComponent();
            appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataArterris = Path.Combine(appdata, "Arterris");
            XmlSerializer xs = new XmlSerializer(typeof(configObject));//pour serialiser en XML la config (sauvegarde des paths src et dst)
            co.ListRepertoire2Travail = new List<comboItem>();
            co.ListPatternARechercher = new List<comboItem>();
            co.listNouveauPrefix = new List<comboItem>();

            co.strRepertoire2Travail = "";
            co.strPatternARechercher = "";
            co.strNouveauPrefix = "";

            if (!Directory.Exists(appDataArterris))
                Directory.CreateDirectory(appDataArterris);

            if (!File.Exists(appDataArterris + "\\configLNK.xml"))//si le fichier n'existe pas on le cré avec init à "";
            {
                co.ListRepertoire2Travail.Add(new comboItem("1", @"c:\temp\lnk"));
                co.strRepertoire2Travail = "c:\\temp\\lnk";
                comboBoxWorkingDirectory.Text = co.strRepertoire2Travail;


                co.ListPatternARechercher.Add(new comboItem("1", @""));
                co.strPatternARechercher = "";
                comboBoxTxt2Change.Text = co.strPatternARechercher;

                co.listNouveauPrefix.Add(new comboItem("1", @"k:\"));
                co.strNouveauPrefix = @"k:\";
                comboBoxNouveauPrefix.Text = co.strNouveauPrefix;

                if (!File.Exists(appDataArterris + "\\configLNK.xml"))//si le fichier n'existe pas on le cré avec init à "";
                {

                    using (StreamWriter wr = new StreamWriter(appDataArterris + "\\configLNK.xml"))
                    {
                        xs.Serialize(wr, co);
                    }

                }

            }
          
            using (StreamReader rd = new StreamReader(appDataArterris + "\\configLNK.xml"))
            {
                co = xs.Deserialize(rd) as configObject;
            
            }

            remplirCombo();
        }

        public void remplirCombo()
        {
            
            co.ListRepertoire2Travail.ForEach(i => comboBoxWorkingDirectory.Items.Add(i));
            co.ListPatternARechercher.ForEach(i => comboBoxTxt2Change.Items.Add(i));
            co.listNouveauPrefix.ForEach(i => comboBoxNouveauPrefix.Items.Add(i));

            comboBoxWorkingDirectory.Text = co.strRepertoire2Travail;
            comboBoxTxt2Change.Text = co.strPatternARechercher;
            comboBoxNouveauPrefix.Text = co.strNouveauPrefix;

        }


       

        private void buttonExecuter_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(comboBoxWorkingDirectory.Text))
            {
                MessageBox.Show("Ce repertoire de travail n'existe pas : " + comboBoxWorkingDirectory.Text);
                return;
            }
            // recup de la liste des fichier .asc du repertoire de la combobox 
            string[] tabFiles = Directory.GetFileSystemEntries(comboBoxWorkingDirectory.Text, "*.lnk");

            if (tabFiles.Length < 1)
            {
                MessageBox.Show("Aucun fichier .lnk trouvé dans : " + comboBoxWorkingDirectory.Text);
                return;
            }

            if (checkBoxAffichageSeule.Checked == true)
            {

                FormAffichage fa = new FormAffichage();
                fa.textBox1.Font = new Font(fa.textBox1.Font, FontStyle.Bold);
                fa.textBox1.Text = "REPERTOIRE DE TRAVAIL: " + Path.GetDirectoryName(tabFiles[0]);
                fa.textBox1.Font = new Font(fa.textBox1.Font, FontStyle.Regular);

                for (int i = 0; i < tabFiles.Length; i++)
                {
                    traiterSimulationFichierEnCours(tabFiles[i], fa);
                }
                fa.Show();
            }
            else
            {
                for (int i = 0; i < tabFiles.Length; i++)
                {
                    traiterFichierEnCours(tabFiles[i]);
                }

                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", comboBoxWorkingDirectory.Text);
                }
                catch (Exception e2)
                {

                    MessageBox.Show(e2.StackTrace);
                }
            }

            
        }

        private void traiterFichierEnCours(String fichierLNK)
        {


            ChangeLinkTarget(fichierLNK);


            
        }

        private void traiterSimulationFichierEnCours(String shortcutFullPath, FormAffichage fa)
        {

            // Load the shortcut.
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(Path.GetDirectoryName(shortcutFullPath));
            Shell32.FolderItem folderItem = folder.Items().Item(Path.GetFileName(shortcutFullPath));
            Shell32.ShellLinkObject currentLink = (Shell32.ShellLinkObject)folderItem.GetLink;

           
            

            if (currentLink.Path.Contains(comboBoxTxt2Change.Text))
            {

                fa.textBox1.AppendText(Environment.NewLine);
                fa.textBox1.AppendText(currentLink.Path);
                             
                currentLink.Save();
               
            }




        }


        public void ChangeLinkTarget(string shortcutFullPath)
        {
            // ToDo verif combo pas vide si possible avant
            // ToDo sauver .lnk avant changement

            // Load the shortcut.
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(Path.GetDirectoryName(shortcutFullPath));
            Shell32.FolderItem folderItem = folder.Items().Item(Path.GetFileName(shortcutFullPath));
            Shell32.ShellLinkObject currentLink = (Shell32.ShellLinkObject)folderItem.GetLink;

            if (currentLink.Path.Contains(comboBoxTxt2Change.Text))
            {
                // ici creer repertoire sauvegarde selon etat marqeur ou test existance
                String sRepSauvegardeAncien = Path.Combine(comboBoxWorkingDirectory.Text, "sauveOldLNK");
                String sRepSauvegardeNouveau = Path.Combine(comboBoxWorkingDirectory.Text, "sauveNewLNK");
                String sNomFichier = Path.GetFileName(shortcutFullPath);
                String sDirectoryPath = Path.GetDirectoryName(shortcutFullPath);

                if (!Directory.Exists(sRepSauvegardeAncien))
                    Directory.CreateDirectory(sRepSauvegardeAncien);

                if (!Directory.Exists(sRepSauvegardeNouveau))
                    Directory.CreateDirectory(sRepSauvegardeNouveau);

                // sauvegarder le lnk

                File.Copy(shortcutFullPath, sRepSauvegardeAncien + "\\" + sNomFichier,true);
                //changer le repertoire de travail
                currentLink.WorkingDirectory = currentLink.WorkingDirectory.Replace(comboBoxTxt2Change.Text, comboBoxNouveauPrefix.Text);

                // Assign the new path here. This value is not read-only.
                currentLink.Path = currentLink.Path.Replace(comboBoxTxt2Change.Text, comboBoxNouveauPrefix.Text);
                // Save the link to commit the changes.
                currentLink.Save();
                File.Copy(shortcutFullPath, sRepSauvegardeNouveau + "\\" + sNomFichier,true);
            }

            //fermer le liens ? 
        }

        private void buttonPathSource_Click(object sender, EventArgs e)
        {
            
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = this.comboBoxWorkingDirectory.Text;

                DialogResult result = fbd.ShowDialog();

                if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    comboBoxWorkingDirectory.Text = fbd.SelectedPath.ToString();
                }

                ajouterWorkinglistCombo();
            
        }

        private void ajouterWorkinglistCombo()
        {
            if (!Directory.Exists(comboBoxWorkingDirectory.Text))
            {
                MessageBox.Show("Ce repertoire est introuvable : " + comboBoxWorkingDirectory.Text);
                return;
            }

            bool b = co.ListRepertoire2Travail.Any(tr => tr.myValue.Equals(comboBoxWorkingDirectory.Text, StringComparison.CurrentCultureIgnoreCase));
            if (!b)
            {
                //KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(((DicdepotDirectory.Count) + 1).ToString(), comboBoxDepot.Text);
                comboItem ci = new comboItem(((co.ListRepertoire2Travail.Count) + 1).ToString(), comboBoxWorkingDirectory.Text);
                co.ListRepertoire2Travail.Add(ci);
                comboBoxWorkingDirectory.Items.Add(ci);
                comboBoxWorkingDirectory.SelectedIndex = comboBoxWorkingDirectory.FindStringExact(ci.myValue);
            }
        }

        private void comboBoxWorkingDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ajouterWorkinglistCombo();
            }
        }

        private void ajouterPatternArechercherListCombo()
        {
           
            bool b = co.ListPatternARechercher.Any(tr => tr.myValue.Equals(comboBoxTxt2Change.Text, StringComparison.CurrentCultureIgnoreCase));
            if (!b)
            {
                //KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(((DicdepotDirectory.Count) + 1).ToString(), comboBoxDepot.Text);
                comboItem ci = new comboItem(((co.ListPatternARechercher.Count) + 1).ToString(), comboBoxTxt2Change.Text);
                co.ListPatternARechercher.Add(ci);
                comboBoxTxt2Change.Items.Add(ci);
                comboBoxTxt2Change.SelectedIndex = comboBoxTxt2Change.FindStringExact(ci.myValue);
            }
        }

        private void comboBoxTxt2Change_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ajouterPatternArechercherListCombo();
            }
        }

        private void ajouterNouveauPrefixListCombo()
        {

            bool b = co.listNouveauPrefix.Any(tr => tr.myValue.Equals(comboBoxNouveauPrefix.Text, StringComparison.CurrentCultureIgnoreCase));
            if (!b)
            {
                //KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(((DicdepotDirectory.Count) + 1).ToString(), comboBoxDepot.Text);
                comboItem ci = new comboItem(((co.listNouveauPrefix.Count) + 1).ToString(), comboBoxNouveauPrefix.Text);
                co.listNouveauPrefix.Add(ci);
                comboBoxNouveauPrefix.Items.Add(ci);
                comboBoxNouveauPrefix.SelectedIndex = comboBoxNouveauPrefix.FindStringExact(ci.myValue);
            }
        }

        private void comboBoxNouveauPrefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ajouterNouveauPrefixListCombo();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            creatXML();
        }

        public void creatXML()
        {

            if (co == null)//un min de verif qd mm
                return;

            try
            {

                XmlSerializer xs = new XmlSerializer(typeof(configObject));
                using (StreamWriter wr = new StreamWriter(appDataArterris + "\\configLNK.xml"))
                {
                    xs.Serialize(wr, co);
                }

                //MessageBox.Show("Enregitrement des paramétres bien effectué \n\r" + "Source: " + co.strSourcePath + "\n\r" + "Destination: " + co.strDestinationPath);

            }
            catch (Exception e)
            {

                MessageBox.Show("Erreur lors de la sauvegarde des paramètres: " + e.StackTrace.ToString());
            }

        }

        
    }




    public class configObject
    {

        public configObject()
        {

        }

        public String strRepertoire2Travail;
        public String strPatternARechercher;
        public String strNouveauPrefix;
        public List<comboItem> ListRepertoire2Travail;
        public List<comboItem> ListPatternARechercher;
        public List<comboItem> listNouveauPrefix;
    }

    [Serializable]
    public class comboItem
    {
        public comboItem()
        {

        }

        public comboItem(string k, string v)
        {
            myKey = k;
            myValue = v;
        }

        [XmlElement("StringElementKey")]
        public String myKey { get; set; }

        [XmlElement("StringElementValue")]
        public String myValue { get; set; }

        public override string ToString()
        {
            return myValue;
        }

    }
}
