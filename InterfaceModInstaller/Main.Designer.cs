namespace InterfaceModInstaller;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.lblSteamCmd = new System.Windows.Forms.Label();
            this.btnSteamCmdDir = new System.Windows.Forms.Button();
            this.btnZipModDir = new System.Windows.Forms.Button();
            this.lblZip = new System.Windows.Forms.Label();
            this.folderSteamCmdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.folderZipModPath = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSteamCmdPath = new System.Windows.Forms.Label();
            this.lblZipPath = new System.Windows.Forms.Label();
            this.databaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridMods = new System.Windows.Forms.DataGridView();
            this.modName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modIsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modInstallationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modModificationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMods)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSteamCmd
            // 
            this.lblSteamCmd.AutoSize = true;
            this.lblSteamCmd.Location = new System.Drawing.Point(31, 78);
            this.lblSteamCmd.Name = "lblSteamCmd";
            this.lblSteamCmd.Size = new System.Drawing.Size(217, 15);
            this.lblSteamCmd.TabIndex = 0;
            this.lblSteamCmd.Text = "Set SteamCMD downloaded mod folder";
            // 
            // btnSteamCmdDir
            // 
            this.btnSteamCmdDir.Location = new System.Drawing.Point(31, 96);
            this.btnSteamCmdDir.Name = "btnSteamCmdDir";
            this.btnSteamCmdDir.Size = new System.Drawing.Size(87, 25);
            this.btnSteamCmdDir.TabIndex = 1;
            this.btnSteamCmdDir.Text = "Select";
            this.btnSteamCmdDir.UseVisualStyleBackColor = true;
            this.btnSteamCmdDir.Click += new System.EventHandler(this.btnSteamCmdDir_Click);
            // 
            // btnZipModDir
            // 
            this.btnZipModDir.Location = new System.Drawing.Point(31, 175);
            this.btnZipModDir.Name = "btnZipModDir";
            this.btnZipModDir.Size = new System.Drawing.Size(87, 25);
            this.btnZipModDir.TabIndex = 6;
            this.btnZipModDir.Text = "Select";
            this.btnZipModDir.UseVisualStyleBackColor = true;
            this.btnZipModDir.Click += new System.EventHandler(this.btnZipModDir_Click);
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(31, 157);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(174, 15);
            this.lblZip.TabIndex = 5;
            this.lblZip.Text = "Set Zip downloaded mod folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Import mods";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblSteamCmdPath
            // 
            this.lblSteamCmdPath.AutoSize = true;
            this.lblSteamCmdPath.Location = new System.Drawing.Point(30, 124);
            this.lblSteamCmdPath.Name = "lblSteamCmdPath";
            this.lblSteamCmdPath.Size = new System.Drawing.Size(88, 15);
            this.lblSteamCmdPath.TabIndex = 8;
            this.lblSteamCmdPath.Text = "*Selected Path*";
            // 
            // lblZipPath
            // 
            this.lblZipPath.AutoSize = true;
            this.lblZipPath.Location = new System.Drawing.Point(30, 203);
            this.lblZipPath.Name = "lblZipPath";
            this.lblZipPath.Size = new System.Drawing.Size(88, 15);
            this.lblZipPath.TabIndex = 9;
            this.lblZipPath.Text = "*Selected Path*";
            // 
            // databaseBindingSource
            // 
            this.databaseBindingSource.DataSource = typeof(InterfaceModInstaller.Constants.Database);
            // 
            // dataGridMods
            // 
            this.dataGridMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modName,
            this.modCode,
            this.modIsActive,
            this.modInstallationDate,
            this.modModificationDate});
            this.dataGridMods.Location = new System.Drawing.Point(31, 316);
            this.dataGridMods.Name = "dataGridMods";
            this.dataGridMods.RowTemplate.Height = 25;
            this.dataGridMods.Size = new System.Drawing.Size(874, 200);
            this.dataGridMods.TabIndex = 10;
            // 
            // modName
            // 
            this.modName.HeaderText = "Name";
            this.modName.Name = "modName";
            this.modName.ReadOnly = true;
            // 
            // modCode
            // 
            this.modCode.HeaderText = "Code";
            this.modCode.Name = "modCode";
            this.modCode.ReadOnly = true;
            // 
            // modIsActive
            // 
            this.modIsActive.HeaderText = "Is Active?";
            this.modIsActive.Name = "modIsActive";
            this.modIsActive.ReadOnly = true;
            // 
            // modInstallationDate
            // 
            this.modInstallationDate.HeaderText = "Installation Date";
            this.modInstallationDate.Name = "modInstallationDate";
            this.modInstallationDate.ReadOnly = true;
            // 
            // modModificationDate
            // 
            this.modModificationDate.HeaderText = "Modification Date";
            this.modModificationDate.Name = "modModificationDate";
            this.modModificationDate.ReadOnly = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(154, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(186, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Move mods to installer folder?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 543);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridMods);
            this.Controls.Add(this.lblZipPath);
            this.Controls.Add(this.lblSteamCmdPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnZipModDir);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.btnSteamCmdDir);
            this.Controls.Add(this.lblSteamCmd);
            this.Name = "MainForm";
            this.Text = "Instellaris Mod Installer";
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label lblSteamCmd;
    private Button btnSteamCmdDir;
    private Button btnZipModDir;
    private Label lblZip;
    private FolderBrowserDialog folderSteamCmdPath;
    private FolderBrowserDialog folderZipModPath;
    private Button button1;
    private Label lblSteamCmdPath;
    private Label lblZipPath;
    private BindingSource databaseBindingSource;
    private DataGridView dataGridMods;
    private DataGridViewTextBoxColumn modName;
    private DataGridViewTextBoxColumn modCode;
    private DataGridViewTextBoxColumn modIsActive;
    private DataGridViewTextBoxColumn modInstallationDate;
    private DataGridViewTextBoxColumn modModificationDate;
    private CheckBox checkBox1;
}