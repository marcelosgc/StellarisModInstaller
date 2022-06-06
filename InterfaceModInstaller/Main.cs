using InterfaceModInstaller.Repository;

namespace InterfaceModInstaller;

public partial class MainForm : Form
{
    Database db = new Database();

    public MainForm()
    {
        db.CreateDatabase();
        var mods = db.LoadInstalledMods();
        InitializeComponent();

        foreach (var m in mods)
        {
            dataGridMods.Rows.Add(new object[]
            {
                m.Name,
                m.Code,
                m.IsActive,
                m.InstallationDate,
                m.ModificationDate
            });
        }
    }

    private void btnSteamCmdDir_Click(object sender, EventArgs e)
    {
        var selected = folderSteamCmdPath.ShowDialog();

        if (selected == DialogResult.OK)
        {
            db.InsertSteamCmdModsPath(folderSteamCmdPath.SelectedPath);
            lblSteamCmdPath.Text = folderSteamCmdPath.SelectedPath;
        }
    }

    private void btnZipModDir_Click(object sender, EventArgs e)
    {
        var selected = folderZipModPath.ShowDialog();

        if (selected == DialogResult.OK)
        {
            db.InsertZipModPath(folderZipModPath.SelectedPath);
            lblZipPath.Text = folderZipModPath.SelectedPath;
        }
    }
}