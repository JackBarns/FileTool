using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileTool.Modules;

namespace FileTool.Modules
{
    class IO
    {
        static public void setFileNames(string path, string prefix, string fileType = "png") // This function renames all files in the selected directory "path"
        {
            if (fileType == "" || fileType is null) fileType = "png";
            
            ConsoleColor current_colour = Console.ForegroundColor;
            DirectoryInfo d = new DirectoryInfo(path);
            // DirectoryInfo object is required to access the DirectoryINfo.GetFiles() function.

            List<FileInfo> files = d.GetFiles($"*.{fileType}").OrderBy(f => f.Name).ToList();
            // Uses LINQ to get all files from the selected directory using the selected file type and sorts them into alphabetical order

            for (int x = 0; x < files.Count; x++)
            //This for loop iterates through every file in the list of file info called "files", which is the list of files in our selected directory
            {
                string newFileName = $"{files[x].FullName.Substring(0, files[x].FullName.Length - files[x].Name.Length)}{prefix}{x + 1}.{fileType}";
                //Sets new file name equal to the inputted prefix plus the file number. Sets the file type equal to the selected file type

                File.Move(files[x].FullName, newFileName);
                //Instead of renaming files move the file to the same directory and setting it's name to the new file name.

                //Logging system writes to console when a file has been renamed, with the file path in a different colour (cyan)
                Console.Write("File named ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(files[x].FullName);
                Console.ForegroundColor = current_colour;
                Console.Write(" to ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(newFileName + Environment.NewLine);
                Console.ForegroundColor = current_colour;
            }
        }
    }
}
