using System;
using System.IO;

namespace rename_files
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length!= 3) {
                Console.Write("Invalid Arguments");
                return;
            }
            var folder = args[0];
            var source = args[1];
            var target = args[2];
            var files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            foreach(var file in files) 
            {
                var output = file.Replace(source, target);
                Console.WriteLine(string.Format("{0} -> {1}", file, output));
                File.Copy(file, output);
            }

            Console.WriteLine("Please any key to exit.");
            Console.ReadLine();
        }
    }
}
