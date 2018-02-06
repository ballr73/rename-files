using System;
using System.IO;

namespace rename_files
{
    
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length!= 4) {
                Console.WriteLine("Invalid Arguments");
                Console.WriteLine("Usage: rename-files <folder> <target> <desination> <pattern>");
                Console.WriteLine("i.e. rename-files /files javascript typescript *.png");
                return;
            }
            var folder = args[0]; // folder
            var target = args[1]; // 
            var destination = args[2];
            var pattern = args[3];

            var files = Directory.GetFiles(folder, pattern, SearchOption.AllDirectories);
            foreach(var file in files) 
            {
                if(file.Contains(target))
                {
                    var output = file.Replace(target, destination);
                    Console.WriteLine(string.Format("{0} -> {1}", file, output));
                    try
                    {
                        File.Copy(file, output);
                    }
                    catch
                    {
                        Console.WriteLine("{0} skipped", file);
                    }
                    
                }
            }

            Console.WriteLine("Please any key to exit.");
            Console.ReadLine();
        }
    }
}
