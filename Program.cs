using System;
using System.IO;

class Program
{
    static void Main()
    {
        string rootFolder = @"C:\Chemin\Vers\Votre\Application";

        // Vous pouvez ajuster le chemin du dossier racine en fonction de votre application.
        List<string> urls = GetAllUrls(rootFolder);

        foreach (var url in urls)
        {
            Console.WriteLine(url);
        }
    }

    static List<string> GetAllUrls(string folder)
    {
        List<string> urls = new List<string>();

        foreach (string file in Directory.GetFiles(folder, "*.aspx"))
        {
            string relativePath = GetRelativePath(file, folder);
            string url = "/" + relativePath.Replace('\\', '/');
            urls.Add(url);
        }

        foreach (string subfolder in Directory.GetDirectories(folder))
        {
            urls.AddRange(GetAllUrls(subfolder));
        }

        return urls;
    }

    static string GetRelativePath(string file, string folder)
    {
        return file.Substring(folder.Length);
    }
}
