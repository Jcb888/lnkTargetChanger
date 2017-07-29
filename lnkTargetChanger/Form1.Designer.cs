namespace lnkTargetChanger
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxTxt2Change = new System.Windows.Forms.ComboBox();
            this.comboBoxNouveauPrefix = new System.Windows.Forms.ComboBox();
            this.buttonExecuter = new System.Windows.Forms.Button();
            this.buttonOuvrirPath = new System.Windows.Forms.Button();
            this.comboBoxWorkingDirectory = new System.Windows.Forms.ComboBox();
            this.buttonPathSource = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelStr2Replace = new System.Windows.Forms.Label();
            this.labelNouveauPrefixPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAffichageSeule = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxTxt2Change
            // 
            this.comboBoxTxt2Change.FormattingEnabled = true;
            this.comboBoxTxt2Change.Location = new System.Drawing.Point(12, 113);
            this.comboBoxTxt2Change.Name = "comboBoxTxt2Change";
            this.comboBoxTxt2Change.Size = new System.Drawing.Size(332, 21);
            this.comboBoxTxt2Change.TabIndex = 0;
            this.comboBoxTxt2Change.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxTxt2Change_KeyDown);
            // 
            // comboBoxNouveauPrefix
            // 
            this.comboBoxNouveauPrefix.FormattingEnabled = true;
            this.comboBoxNouveauPrefix.Location = new System.Drawing.Point(12, 165);
            this.comboBoxNouveauPrefix.Name = "comboBoxNouveauPrefix";
            this.comboBoxNouveauPrefix.Size = new System.Drawing.Size(332, 21);
            this.comboBoxNouveauPrefix.TabIndex = 1;
            this.comboBoxNouveauPrefix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxNouveauPrefix_KeyDown);
            // 
            // buttonExecuter
            // 
            this.buttonExecuter.Location = new System.Drawing.Point(15, 204);
            this.buttonExecuter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonExecuter.Name = "buttonExecuter";
            this.buttonExecuter.Size = new System.Drawing.Size(86, 23);
            this.buttonExecuter.TabIndex = 2;
            this.buttonExecuter.Text = "Executer";
            this.buttonExecuter.UseVisualStyleBackColor = true;
            this.buttonExecuter.Click += new System.EventHandler(this.buttonExecuter_Click);
            // 
            // buttonOuvrirPath
            // 
            this.buttonOuvrirPath.Location = new System.Drawing.Point(127, 202);
            this.buttonOuvrirPath.Name = "buttonOuvrirPath";
            this.buttonOuvrirPath.Size = new System.Drawing.Size(122, 25);
            this.buttonOuvrirPath.TabIndex = 6;
            this.buttonOuvrirPath.Text = "OuvrirPathDestination";
            this.buttonOuvrirPath.UseVisualStyleBackColor = true;
            // 
            // comboBoxWorkingDirectory
            // 
            this.comboBoxWorkingDirectory.FormattingEnabled = true;
            this.comboBoxWorkingDirectory.Location = new System.Drawing.Point(12, 67);
            this.comboBoxWorkingDirectory.Name = "comboBoxWorkingDirectory";
            this.comboBoxWorkingDirectory.Size = new System.Drawing.Size(332, 21);
            this.comboBoxWorkingDirectory.TabIndex = 10;
            this.comboBoxWorkingDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxWorkingDirectory_KeyDown);
            // 
            // buttonPathSource
            // 
            this.buttonPathSource.Location = new System.Drawing.Point(350, 65);
            this.buttonPathSource.Name = "buttonPathSource";
            this.buttonPathSource.Size = new System.Drawing.Size(30, 23);
            this.buttonPathSource.TabIndex = 11;
            this.buttonPathSource.Tag = resources.GetString("buttonPathSource.Tag");
            this.buttonPathSource.Text = "...";
            this.buttonPathSource.UseVisualStyleBackColor = true;
            this.buttonPathSource.Click += new System.EventHandler(this.buttonPathSource_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(9, 43);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(54, 13);
            this.labelPath.TabIndex = 12;
            this.labelPath.Text = "PathDeW";
            // 
            // labelStr2Replace
            // 
            this.labelStr2Replace.AutoSize = true;
            this.labelStr2Replace.Location = new System.Drawing.Point(12, 97);
            this.labelStr2Replace.Name = "labelStr2Replace";
            this.labelStr2Replace.Size = new System.Drawing.Size(93, 13);
            this.labelStr2Replace.TabIndex = 13;
            this.labelStr2Replace.Text = "ChaineAremplacer";
            // 
            // labelNouveauPrefixPath
            // 
            this.labelNouveauPrefixPath.AutoSize = true;
            this.labelNouveauPrefixPath.Location = new System.Drawing.Point(12, 149);
            this.labelNouveauPrefixPath.Name = "labelNouveauPrefixPath";
            this.labelNouveauPrefixPath.Size = new System.Drawing.Size(110, 13);
            this.labelNouveauPrefixPath.TabIndex = 14;
            this.labelNouveauPrefixPath.Text = "ChaineNouveauPrefix";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "[enter] pour sauvegarder nouvelle chaine";
            // 
            // checkBoxAffichageSeule
            // 
            this.checkBoxAffichageSeule.AutoSize = true;
            this.checkBoxAffichageSeule.Location = new System.Drawing.Point(228, 12);
            this.checkBoxAffichageSeule.Name = "checkBoxAffichageSeule";
            this.checkBoxAffichageSeule.Size = new System.Drawing.Size(152, 17);
            this.checkBoxAffichageSeule.TabIndex = 16;
            this.checkBoxAffichageSeule.Text = "Simulation avec  Affichage";
            this.checkBoxAffichageSeule.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 255);
            this.Controls.Add(this.checkBoxAffichageSeule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNouveauPrefixPath);
            this.Controls.Add(this.labelStr2Replace);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.buttonPathSource);
            this.Controls.Add(this.comboBoxWorkingDirectory);
            this.Controls.Add(this.buttonOuvrirPath);
            this.Controls.Add(this.buttonExecuter);
            this.Controls.Add(this.comboBoxNouveauPrefix);
            this.Controls.Add(this.comboBoxTxt2Change);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTxt2Change;
        private System.Windows.Forms.ComboBox comboBoxNouveauPrefix;
        private System.Windows.Forms.Button buttonExecuter;
        private System.Windows.Forms.Button buttonOuvrirPath;
        private System.Windows.Forms.ComboBox comboBoxWorkingDirectory;
        private System.Windows.Forms.Button buttonPathSource;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelStr2Replace;
        private System.Windows.Forms.Label labelNouveauPrefixPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAffichageSeule;
    }
}

