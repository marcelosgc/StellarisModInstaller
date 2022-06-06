namespace InterfaceModInstaller.Constants;

public class Database
{
    public static string Folder = "DB";
    public static string DatabaseFile = "default.sqlite";
    public static string CreateTables = @"create table if not exists Mods
                                            (
                                                Id               integer
                                                    constraint Mods_pk
                                                        primary key,
                                                Name             text,
                                                Code             text,
                                                IsActive         integer,
                                                InstallationDate text,
                                                ModificationDate text
                                            );
                                            
                                            create unique index if not exists Mods_Id_uindex
                                                on Mods (Id);
                                            
                                            
                                            create table if not exists Directories
                                            (
                                                Id               integer
                                                    constraint Directories_pk
                                                        primary key autoincrement,
                                                Path             text,
                                                Name             text,
                                                CreationDate     text,
                                                ModificationDate text
                                            );
                                            
                                            create unique index if not exists Directories_Id_uindex
                                                on Directories (Id);

                                                        ";

    public static List<string> TablesToCheck = new(){"Mods","Directories"};
    
    
    
}