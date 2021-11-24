using System;
using System.IO;
using System.Text.Json.Node;


namespace test_projet
{
    class Program
    {

        public static void Main()
        {

            //DECLARATION VARIABLE GLOBAL
            //GLOBAL VARIABLE DECLARATION
            string nom; //name
            string source;
            string desti; //destination
            string sourceFile;
            string destFile;
            long length;


            //CHOIX DE LA LANGUE
            //CHOICE OF LANGUAGE
            Console.WriteLine("Taper FR pour français. Type EN for english.");
            string langue = Console.ReadLine(); //language

            //ENTREES INTERFACE
            //INTERFACE ENTRY
            if (langue == "FR")
            {
                Console.WriteLine("Entrer le nom du fichier avec son extension exemple : test.txt");
                nom = Console.ReadLine();
                Console.WriteLine("Entrer le chemin du fichier source");
                source = Console.ReadLine();
                Console.WriteLine("Entrer le chemin du fichier de destination");
                desti = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Type the file's name with his extension example : test.txt");
                nom = Console.ReadLine();
                Console.WriteLine("Type the source file's path");
                source = Console.ReadLine();
                Console.WriteLine("Type the destination file's path");
                desti = Console.ReadLine();
            }


            string fileName = nom;
            string sourcePath = @source;
            string targetPath = @desti;

            if (fileName == null || fileName == "")
            {
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, desti), true);
                }

            }
            else
            {
                //COMBINAISON CHEMIN + FICHIER
                //FUSION PATH + FILE
                sourceFile = Path.Combine(sourcePath, fileName);
                destFile = Path.Combine(targetPath, fileName);
                File.Copy(sourceFile, destFile, true);

                //Afficher la taille d'un fichier
                //Print file's lenght
                FileInfo f = new FileInfo(sourceFile);
                length = f.Length;

            }


            //Récupèrer la date et heure actuelle
            //Get current date and hour
            DateTime dt = DateTime.Now;
            string date = dt.ToString("dd/MM/yyyy HH:mm");

            //Création log.json
            //Create log.json
            string path = desti + "/log.json";

            string path = @"C:\log.json";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                var log = new JsonObject
                {
                    ["Logfile"] = new JsonArray(
                    ("Name : ", nom),
                    ("FileSource : ", source),
                    ("FileTarget : "),
                    ("destPath : "),
                    ("Filesize : ", lenght),
                    ("FileTransfertTime : "),
                    ("time : ", date))
                };
            }
            // Create a file to write to.

        }
    }

            // Le Text est ajouté petit à petit si il n'est pas supprimé
            // This text is always added, making the file longer over time if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write("Name : ");
                sw.WriteLine(nom);
                sw.Write("FileSource : ");
                sw.WriteLine(source);
                sw.Write("FileTarget : ");
                sw.WriteLine(desti);
                sw.WriteLine("destPath : ");
                sw.Write("Filesize : ");
                sw.WriteLine(length);
                sw.WriteLine("FileTransfertTime : ");
                sw.Write("time : ");
                sw.WriteLine(date);
            }

// Ouvre le fichier lu
// Open the file to read from.
using (StreamReader sr = File.OpenText(path))
{
    string s = "";
    while ((s = sr.ReadLine()) != null)
    {
        Console.WriteLine(s);
    }



}

        }
    }
}