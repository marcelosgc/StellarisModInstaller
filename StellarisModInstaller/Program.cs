using System;
using System.IO.Compression;
using System.IO.Enumeration;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using StellarisModInstaller.Model;

class Program
{
    static readonly Settings settings = MountSettings();

    static void Main(string[] args)
    {
        // GetFromZipFile(settings);
        GetFromDirectory();
    }

    private static void GetFromDirectory()
    {
        var scannedDir = Directory.GetDirectories(settings.SteamCmdDirMod);

        foreach (var dir in scannedDir)
        {
            string modFolderName = dir.Replace(settings.SteamCmdDirMod, string.Empty);
            if (CheckIfModAlreadyInstalled(modFolderName))
            {
                Console.WriteLine($"Mod {modFolderName} already installed");
                Console.WriteLine($" _-_-_-_-_-");
                continue;
            }

            Console.WriteLine($"Installing Mod {modFolderName} ... ");
            string newDirMod = settings.ExtractionDir + modFolderName;

            CopyModFolder(dir, newDirMod);
            
            
            ModifyModFile(newDirMod, modFolderName);
            Console.WriteLine($"Mod Installation {modFolderName} is done!  ");
            Console.WriteLine($" _-_-_-_-_-");
        }
    }

    private static void CopyModFolder(string downloadFolder, string newDirMod)
    {
        var directoryInfo = Directory.GetParent(downloadFolder);
        var target = Directory.GetParent(newDirMod);

        if (!Directory.Exists( newDirMod ))
            Directory.CreateDirectory( newDirMod );
        string[] files = Directory.GetFiles( downloadFolder );
        foreach (string file in files)
        {
            string name = Path.GetFileName( file );
            string dest = Path.Combine( newDirMod, name );
            File.Copy( file, dest );
        }
        string[] folders = Directory.GetDirectories( downloadFolder );
        foreach (string folder in folders)
        {
            string name = Path.GetFileName( folder );
            string dest = Path.Combine( newDirMod, name );
            CopyModFolder( folder, dest );
        }

    }

    private static bool CheckIfModAlreadyInstalled(string modFolderName)
    {
        string newDirMod = settings.ExtractionDir + modFolderName;

        return Directory.Exists(newDirMod);
    }

    public static Settings MountSettings()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var jSettings = config.GetSection("Settings");

        var settings = new Settings();

        settings.ExtractionDir = jSettings.GetSection("ExtractionDir").Value;
        settings.ModTypeDir = jSettings.GetSection("ModTypeDir").Value;
        settings.ModZipDir = jSettings.GetSection("ModZipDir").Value;
        settings.SteamCmdDirMod = jSettings.GetSection("SteamCmdDirMod").Value;

        return settings;
    }

    private static void GetFromZipFile(Settings settings)
    {
        var zipFilesMod = Directory.GetFiles(settings.ModZipDir, "*.zip", SearchOption.AllDirectories);

        foreach (var f in zipFilesMod)
        {
            string fileName = f.Replace($"{settings.ModZipDir}\\", "");
            Console.WriteLine($"File {fileName} is being processed ... ");
            var partName = fileName.Split("_");

            string newExtractPath = settings.ExtractionDir + partName[0];

            if (Directory.Exists(newExtractPath))
            {
                Console.WriteLine("Mod already installed");
                Console.WriteLine($" _-_-_-_-_-");
                continue;
            }

            ZipFile.ExtractToDirectory(f, newExtractPath);

            ModifyModFile(newExtractPath, partName[0]);

            Console.WriteLine($"File {fileName} finished ");
            Console.WriteLine($" _-_-_-_-_-");
        }
    }

    private static void ModifyModFile(string newExtractPath, string modId)
    {
        var modFile = Directory.GetFiles(newExtractPath, "*.mod", SearchOption.TopDirectoryOnly);

        RemovePathLine(modFile);

        //reloadfile
        modFile = Directory.GetFiles(newExtractPath, "*.mod", SearchOption.TopDirectoryOnly);

        var newFileMod = settings.ModTypeDir +
                         modFile[0].Replace(newExtractPath, "").Replace("descriptor", modId);

        if (!File.Exists(newFileMod))
        {
            File.Copy(modFile[0], newFileMod);

            string[] modFileContent = System.IO.File.ReadAllLines(newFileMod);

            var n = modFileContent.Append(Constant.NewPath.Replace("{id}", modId));

            File.WriteAllLines(newFileMod, n);
        }
    }

    private static void RemovePathLine(string[] modFile)
    {
        string[] modFileContent = System.IO.File.ReadAllLines(modFile[0]);

        if (modFileContent.Any(x => x.StartsWith("path")))
        {
            string[] newContent = modFileContent.Where(x => !x.StartsWith("path")).ToArray();
            File.WriteAllLines(modFile[0], newContent);
        }
    }
}