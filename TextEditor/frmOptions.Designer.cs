namespace TextEditor
{
    partial class frmOptions
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbcOptions = new System.Windows.Forms.TabControl();
            this.tbpNewDocument = new System.Windows.Forms.TabPage();
            this.lnkDefaultFont = new System.Windows.Forms.LinkLabel();
            this.lblDefaultFont = new System.Windows.Forms.Label();
            this.tbpOpen = new System.Windows.Forms.TabPage();
            this.chkReloadLastDocument = new System.Windows.Forms.CheckBox();
            this.tbpSave = new System.Windows.Forms.TabPage();
            this.lblDefaultFolder = new System.Windows.Forms.Label();
            this.txtDefaultFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dlgFont = new System.Windows.Forms.FontDialog();
            this.dlgBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.erpOptions = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbcOptions.SuspendLayout();
            this.tbpNewDocument.SuspendLayout();
            this.tbpOpen.SuspendLayout();
            this.tbpSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(292, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 20);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Saglabāt";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(361, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 20);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "At&celt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbcOptions
            // 
            this.tbcOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcOptions.Controls.Add(this.tbpNewDocument);
            this.tbcOptions.Controls.Add(this.tbpOpen);
            this.tbcOptions.Controls.Add(this.tbpSave);
            this.tbcOptions.Location = new System.Drawing.Point(10, 10);
            this.tbcOptions.Name = "tbcOptions";
            this.tbcOptions.SelectedIndex = 0;
            this.tbcOptions.Size = new System.Drawing.Size(421, 77);
            this.tbcOptions.TabIndex = 1;
            // 
            // tbpNewDocument
            // 
            this.tbpNewDocument.Controls.Add(this.lnkDefaultFont);
            this.tbpNewDocument.Controls.Add(this.lblDefaultFont);
            this.tbpNewDocument.Location = new System.Drawing.Point(4, 22);
            this.tbpNewDocument.Name = "tbpNewDocument";
            this.tbpNewDocument.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNewDocument.Size = new System.Drawing.Size(413, 51);
            this.tbpNewDocument.TabIndex = 0;
            this.tbpNewDocument.Text = "Jauns dokuments";
            this.tbpNewDocument.UseVisualStyleBackColor = true;
            // 
            // lnkDefaultFont
            // 
            this.lnkDefaultFont.AutoSize = true;
            this.lnkDefaultFont.Location = new System.Drawing.Point(90, 10);
            this.lnkDefaultFont.Name = "lnkDefaultFont";
            this.lnkDefaultFont.Size = new System.Drawing.Size(88, 13);
            this.lnkDefaultFont.TabIndex = 1;
            this.lnkDefaultFont.TabStop = true;
            this.lnkDefaultFont.Text = "Noklusētais fonts";
            this.lnkDefaultFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefaultFont_LinkClicked);
            // 
            // lblDefaultFont
            // 
            this.lblDefaultFont.AutoSize = true;
            this.lblDefaultFont.Location = new System.Drawing.Point(10, 10);
            this.lblDefaultFont.Name = "lblDefaultFont";
            this.lblDefaultFont.Size = new System.Drawing.Size(91, 13);
            this.lblDefaultFont.TabIndex = 0;
            this.lblDefaultFont.Text = "Noklusētais fonts:";
            // 
            // tbpOpen
            // 
            this.tbpOpen.Controls.Add(this.chkReloadLastDocument);
            this.tbpOpen.Location = new System.Drawing.Point(4, 22);
            this.tbpOpen.Name = "tbpOpen";
            this.tbpOpen.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOpen.Size = new System.Drawing.Size(413, 51);
            this.tbpOpen.TabIndex = 1;
            this.tbpOpen.Text = "Atvēršana";
            this.tbpOpen.UseVisualStyleBackColor = true;
            // 
            // chkReloadLastDocument
            // 
            this.chkReloadLastDocument.Checked = global::TextEditor.Properties.Settings.Default.ReloadLastDocument;
            this.chkReloadLastDocument.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TextEditor.Properties.Settings.Default, "ReloadLastDocument", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReloadLastDocument.Location = new System.Drawing.Point(10, 10);
            this.chkReloadLastDocument.Name = "chkReloadLastDocument";
            this.chkReloadLastDocument.Size = new System.Drawing.Size(333, 21);
            this.chkReloadLastDocument.TabIndex = 0;
            this.chkReloadLastDocument.Text = "Atverot teksta redaktoru, ielādēt pēdējo dokumentu\r\n";
            this.chkReloadLastDocument.UseVisualStyleBackColor = true;
            // 
            // tbpSave
            // 
            this.tbpSave.Controls.Add(this.btnBrowse);
            this.tbpSave.Controls.Add(this.txtDefaultFolder);
            this.tbpSave.Controls.Add(this.lblDefaultFolder);
            this.tbpSave.Location = new System.Drawing.Point(4, 22);
            this.tbpSave.Name = "tbpSave";
            this.tbpSave.Size = new System.Drawing.Size(413, 51);
            this.tbpSave.TabIndex = 2;
            this.tbpSave.Text = "Saglabāšana";
            this.tbpSave.UseVisualStyleBackColor = true;
            // 
            // lblDefaultFolder
            // 
            this.lblDefaultFolder.AutoSize = true;
            this.lblDefaultFolder.Location = new System.Drawing.Point(12, 12);
            this.lblDefaultFolder.Name = "lblDefaultFolder";
            this.lblDefaultFolder.Size = new System.Drawing.Size(140, 13);
            this.lblDefaultFolder.TabIndex = 0;
            this.lblDefaultFolder.Text = "Pēc noklusēšanas saglabāt:";
            // 
            // txtDefaultFolder
            // 
            this.txtDefaultFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TextEditor.Properties.Settings.Default, "DefaultFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDefaultFolder.Location = new System.Drawing.Point(158, 9);
            this.txtDefaultFolder.Name = "txtDefaultFolder";
            this.txtDefaultFolder.Size = new System.Drawing.Size(144, 20);
            this.txtDefaultFolder.TabIndex = 1;
            this.txtDefaultFolder.Text = global::TextEditor.Properties.Settings.Default.DefaultFolder;
            this.txtDefaultFolder.Validating += new System.ComponentModel.CancelEventHandler(this.txtDefaultFolder_Validating);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(330, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Pārlūkot...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dlgFont
            // 
            this.dlgFont.Font = global::TextEditor.Properties.Settings.Default.DefaultFont;
            // 
            // dlgBrowser
            // 
            this.dlgBrowser.SelectedPath = global::TextEditor.Properties.Settings.Default.DefaultFolder;
            // 
            // erpOptions
            // 
            this.erpOptions.ContainerControl = this;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(429, 117);
            this.Controls.Add(this.tbcOptions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opcijas";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.tbcOptions.ResumeLayout(false);
            this.tbpNewDocument.ResumeLayout(false);
            this.tbpNewDocument.PerformLayout();
            this.tbpOpen.ResumeLayout(false);
            this.tbpSave.ResumeLayout(false);
            this.tbpSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpOptions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tbcOptions;
        private System.Windows.Forms.TabPage tbpNewDocument;
        private System.Windows.Forms.LinkLabel lnkDefaultFont;
        private System.Windows.Forms.Label lblDefaultFont;
        private System.Windows.Forms.TabPage tbpOpen;
        private System.Windows.Forms.CheckBox chkReloadLastDocument;
        private System.Windows.Forms.TabPage tbpSave;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDefaultFolder;
        private System.Windows.Forms.Label lblDefaultFolder;
        private System.Windows.Forms.FontDialog dlgFont;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowser;
        private System.Windows.Forms.ErrorProvider erpOptions;
    }
}