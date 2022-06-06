using System.Data.SQLite;
using InterfaceModInstaller.Model;

namespace InterfaceModInstaller.Repository;

public class Database
{
    public void CreateDatabase()
    {
        string dbFolder = $"{Environment.CurrentDirectory}\\{Constants.Database.Folder}";

        if (!Directory.Exists(dbFolder))
        {
            Directory.CreateDirectory(dbFolder);
        }

        string currentDbFilePath = $"{Environment.CurrentDirectory}\\{Constants.Database.DatabaseFile}";
        string newDbFilePath = $"{dbFolder}\\{Constants.Database.DatabaseFile}";

        GenerateDbFile(newDbFilePath, currentDbFilePath);

        CreateTablesForDatabase();
    }

    public List<Mod> LoadInstalledMods()
    {
        List<Mod> installedMods = new List<Mod>();
        string conn = $"{Constants.Database.Folder}\\{Constants.Database.DatabaseFile}";
        SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={conn};Version=3;");
        m_dbConnection.Open();

        SQLiteCommand commandReturnMods =
            new SQLiteCommand(@"select Id, Name, Code, IsActive, InstallationDate, ModificationDate from Mods;",
                m_dbConnection);

        using (SQLiteDataReader read = commandReturnMods.ExecuteReader())
        {
            while (read.Read())
            {
                installedMods.Add(new Mod()
                {
                    Id = Convert.ToInt32(read["Id"]),
                    Name = read["Name"].ToString(),
                    Code = read["Code"].ToString(),
                    IsActive = Convert.ToBoolean(read["IsActive"]),
                    InstallationDate = !string.IsNullOrWhiteSpace(read["InstallationDate"].ToString())
                        ? Convert.ToDateTime(read["InstallationDate"])
                        : null,
                    ModificationDate = !string.IsNullOrWhiteSpace(read["ModificationDate"].ToString())
                        ? Convert.ToDateTime(read["ModificationDate"])
                        : null
                });
            }
        }

        return installedMods;
    }

    private void CreateTablesForDatabase()
    {
        string conn = $"{Constants.Database.Folder}\\{Constants.Database.DatabaseFile}";
        SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={conn};Version=3;");
        m_dbConnection.Open();

        SQLiteCommand commandValidateTables =
            new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table';", m_dbConnection);

        var resultValidateTables = commandValidateTables.ExecuteReader();
        List<string> tables = new List<string>();

        while (resultValidateTables.Read())
        {
            tables.Add(resultValidateTables["name"].ToString() ?? string.Empty);
        }

        if (!ValidateTables(tables))
        {
            SQLiteCommand command = new SQLiteCommand(Constants.Database.CreateTables, m_dbConnection);
            command.ExecuteNonQuery();
        }

        m_dbConnection.Close();
    }

    private bool ValidateTables(List<string> tables)
    {
        foreach (var t in Constants.Database.TablesToCheck)
        {
            if (!tables.Contains(t))
            {
                return false;
            }
        }

        return true;
    }

    private static void GenerateDbFile(string newDbFilePath, string currentDbFilePath)
    {
        if (!File.Exists(newDbFilePath))
        {
            if (File.Exists(currentDbFilePath))
            {
                File.Move(currentDbFilePath, newDbFilePath);
            }
            else
            {
                SQLiteConnection.CreateFile(Constants.Database.DatabaseFile);

                if (!File.Exists(currentDbFilePath))
                {
                    throw new Exception(
                        "Could not be possible create database | File not found after creation method ");
                }

                File.Move(currentDbFilePath, newDbFilePath);
            }
        }
    }

    public void InsertSteamCmdModsPath(string selectedPath)
    {
        string conn = $"{Constants.Database.Folder}\\{Constants.Database.DatabaseFile}";
        SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={conn};Version=3;");
        m_dbConnection.Open();

        SQLiteCommand commandValidateTables =
            new SQLiteCommand(
                @$"insert into Directories (Path, Name, CreationDate, ModificationDate)
                                    values ('{selectedPath}','SteamCmd','{DateTime.Now.ToString()}',null);",
                m_dbConnection);

        commandValidateTables.ExecuteNonQuery();
        
        m_dbConnection.Close();
    }

    public void InsertZipModPath(string selectedPath)
    {
        string conn = $"{Constants.Database.Folder}\\{Constants.Database.DatabaseFile}";
        SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={conn};Version=3;");
        m_dbConnection.Open();

        SQLiteCommand commandValidateTables =
            new SQLiteCommand(
                @$"insert into Directories (Path, Name, CreationDate, ModificationDate)
                                    values ('{selectedPath}','Zip','{DateTime.Now.ToString()}',null);",
                m_dbConnection);

        commandValidateTables.ExecuteNonQuery();
        
        m_dbConnection.Close();
    }
}