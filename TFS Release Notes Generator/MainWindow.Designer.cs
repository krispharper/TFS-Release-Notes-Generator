namespace TfsReleaseNotesGenerator
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControls = new System.Windows.Forms.Panel();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.comboBoxIteration = new System.Windows.Forms.ComboBox();
            this.labelIteration = new System.Windows.Forms.Label();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
            this.labelProject = new System.Windows.Forms.Label();
            this.labelCollection = new System.Windows.Forms.Label();
            this.comboBoxCollection = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.browserContent = new System.Windows.Forms.WebBrowser();
            this.panelControls.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Controls.Add(this.buttonGenerate);
            this.panelControls.Controls.Add(this.comboBoxIteration);
            this.panelControls.Controls.Add(this.labelIteration);
            this.panelControls.Controls.Add(this.comboBoxProject);
            this.panelControls.Controls.Add(this.labelProject);
            this.panelControls.Controls.Add(this.labelCollection);
            this.panelControls.Controls.Add(this.comboBoxCollection);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(863, 63);
            this.panelControls.TabIndex = 1;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Location = new System.Drawing.Point(766, 26);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 4;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // comboBoxIteration
            // 
            this.comboBoxIteration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIteration.FormattingEnabled = true;
            this.comboBoxIteration.Location = new System.Drawing.Point(441, 29);
            this.comboBoxIteration.Name = "comboBoxIteration";
            this.comboBoxIteration.Size = new System.Drawing.Size(282, 21);
            this.comboBoxIteration.TabIndex = 3;
            this.comboBoxIteration.SelectedIndexChanged += new System.EventHandler(this.comboBoxIteration_SelectedIndexChanged);
            // 
            // labelIteration
            // 
            this.labelIteration.AutoSize = true;
            this.labelIteration.Location = new System.Drawing.Point(438, 13);
            this.labelIteration.Name = "labelIteration";
            this.labelIteration.Size = new System.Drawing.Size(45, 13);
            this.labelIteration.TabIndex = 4;
            this.labelIteration.Text = "Iteration";
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Location = new System.Drawing.Point(248, 29);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(160, 21);
            this.comboBoxProject.TabIndex = 2;
            this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxProject_SelectedIndexChanged);
            // 
            // labelProject
            // 
            this.labelProject.AutoSize = true;
            this.labelProject.Location = new System.Drawing.Point(245, 13);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(40, 13);
            this.labelProject.TabIndex = 2;
            this.labelProject.Text = "Project";
            // 
            // labelCollection
            // 
            this.labelCollection.AutoSize = true;
            this.labelCollection.Location = new System.Drawing.Point(13, 13);
            this.labelCollection.Name = "labelCollection";
            this.labelCollection.Size = new System.Drawing.Size(53, 13);
            this.labelCollection.TabIndex = 1;
            this.labelCollection.Text = "Collection";
            // 
            // comboBoxCollection
            // 
            this.comboBoxCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCollection.FormattingEnabled = true;
            this.comboBoxCollection.Location = new System.Drawing.Point(12, 29);
            this.comboBoxCollection.Name = "comboBoxCollection";
            this.comboBoxCollection.Size = new System.Drawing.Size(194, 21);
            this.comboBoxCollection.TabIndex = 0;
            this.comboBoxCollection.SelectedIndexChanged += new System.EventHandler(this.comboBoxCollection_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.browserContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 434);
            this.panel1.TabIndex = 2;
            // 
            // browserContent
            // 
            this.browserContent.AllowNavigation = false;
            this.browserContent.AllowWebBrowserDrop = false;
            this.browserContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserContent.IsWebBrowserContextMenuEnabled = false;
            this.browserContent.Location = new System.Drawing.Point(0, 0);
            this.browserContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserContent.Name = "browserContent";
            this.browserContent.Size = new System.Drawing.Size(863, 434);
            this.browserContent.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AcceptButton = this.buttonGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControls);
            this.MinimumSize = new System.Drawing.Size(879, 163);
            this.Name = "MainWindow";
            this.Text = "TFS Release Notes Generator";
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label labelCollection;
        private System.Windows.Forms.ComboBox comboBoxCollection;
        private System.Windows.Forms.ComboBox comboBoxProject;
        private System.Windows.Forms.Label labelProject;
        private System.Windows.Forms.ComboBox comboBoxIteration;
        private System.Windows.Forms.Label labelIteration;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser browserContent;
    }
}

