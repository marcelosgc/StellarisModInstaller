using System;
using System.IO.Compression;
using System.IO.Enumeration;
using Microsoft.Extensions.Configuration;
using StellarisModInstaller.Model;

class Program
{
    static void Main(string[] args)
    {
        var settings = MountSettings();

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

            var modFile = Directory.GetFiles(newExtractPath, "*.mod", SearchOption.TopDirectoryOnly);

            RemovePathLine(modFile);

            //reloadfile
            modFile = Directory.GetFiles(newExtractPath, "*.mod", SearchOption.TopDirectoryOnly);

            var newFileMod = settings.ModTypeDir +
                             modFile[0].Replace(newExtractPath, "").Replace("descriptor", partName[0]);

            if (!File.Exists(newFileMod))
            {
                File.Copy(modFile[0], newFileMod);

                string[] modFileContent = System.IO.File.ReadAllLines(newFileMod);
                
                var n = modFileContent.Append(Constant.NewPath.Replace("{id}", partName[0]));
                
                File.WriteAllLines(newFileMod, n);
            }

            Console.WriteLine($"File {fileName} finished ");
            Console.WriteLine($" _-_-_-_-_-");
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

        return settings;
    }
}