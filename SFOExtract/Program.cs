using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using ConsoleApplication1;

namespace SFOExtract
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string alwaysshow = "SFO Extract by xXx The Darkprogramer xXx For jjkkyu";
            //if (args.Length == 0 )
            //{
            //    Console.WriteLine(alwaysshow);
            //    Console.WriteLine(" ");
            //    Console.WriteLine("Usage : <input pkg> <output path>"); // Check for null array
            //}
            //else
            {
                Console.WriteLine(alwaysshow);
                Console.WriteLine(" ");
                Console.WriteLine("Decopiling PKG to get SFO...");
                scan_files();
               

           }
            Console.ReadLine();
        }


        private static void pkg2sfo(string infile)
        {
            String strAppDir = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetName().CodeBase);
            string path = strAppDir.Replace("file:\\", "");
            string sourceDirectory = path;
            string FileNamed = infile;
            string OutputFile = "";
            string outFile = null;
            pkg2sfo instance = new pkg2sfo();
            outFile = instance.DecryptPKGFile(infile);
            if (outFile.EndsWith(".SFO"))
            {
                Console.WriteLine("Created " + outFile);
                File.Move(outFile, path);
            }
        }

        private static void scan_files()
        {
            String strAppDir = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetName().CodeBase);
            string path = strAppDir.Replace("file:\\", "");
            string sourceDirectory = path;

            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.pkg", SearchOption.AllDirectories);

                foreach (string currentFile in txtFiles)
                {

                    Console.WriteLine(currentFile);
                    pkg2sfo(currentFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void sfo2edat(string infile)
        {
            string outFile = null;
            C00EDAT instance = new C00EDAT();
            outFile = instance.makeedat(infile, outFile);
            if (Directory.Exists("temp"))
            {
                Directory.Delete("temp", true);
            }
            if (outFile.EndsWith(".edat"))
            {
                Console.WriteLine("Created " + outFile);
            }
        }
    }
}
