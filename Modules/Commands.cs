using System;

namespace FileTool
{
    static public class Commands
    {
        public static string path { get; set; }
        public static string prefix { get; set; }
        public static string extension { get; set; }
        // Declare the path, prefix and extension

        static public void AwaitCommand(string[] args)
        // AwaitCommand takes a parameter, the args string array.
        {
            try
            // try statement prevents the program closing when an error is thrown
            {
                var command = args[0];
                // The first argument is the command, store to variable instead of referencing array multiple times

                if (command == "help")
                    // Help command shows documentation on how to use the program.
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Mass file renamer and sorter");
                    Console.WriteLine("Default file extenstion is 'png', dont pass -ex to leave as 'png'");
                    Console.Write("\nParameter List:\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\n-p FILE PATH\n-pr PREFIX\n-ex FILE EXTENSION\n\n");

                    WriteLog("Example Usage:", @"FILETOOL run -p C:\FilePath.Txt -pr PREFIX");
                    WriteLog("Example Usage:", @"FILETOOL run -p C:\FilePath.Txt -pr PREFIX -ex txt");
                }
                else if (command == "run")
                {
                    for (int i = 0; i < args.Length; i++)
                    // Iterate through all arguments
                    {
                        switch (args[i])
                        // Select the argument in the current iteration
                        {
                            case "-p": // If the argument is equal to "-p" set the path variable equal to the next argument
                                path = args[++i];
                                //Use "++i" instead of "i++" to increment I then set the variable, or path would be set and then "i" would be incremented.
                                break;
                            case "-pr": // If the argument is equal to "-pr" set the prefix variable equal to the next argument
                                prefix = args[++i];
                                break;
                            case "ex": // If the argument is equal to "-ex" set the file extension variable equal to the next argument
                                extension = args[++i];
                                break;
                        }
                    }

                    if (path is null || prefix is null) throw new Exception("prefix or path argument were not passed");
                    // If the path or prefix is null throw a new exception, (if there is no path or prefix set then go to catch() and throw an error)

                    IO.setFileNames(path, prefix, extension);
                    // Call the function "setFileNames" in the "IO" class passing 3 argument, path prefix and extension, this function is what renames the files.
                } else
                {
                    throw new Exception("Invalid command -- use help for a full list of commands");
                    // If the command is not in the if statement then throw an error and write to console that there is an invalid command.
                }
            } catch (Exception ex)
            // Declare ex as an Exception data type so we can access more information about our error.
            {
                Console.WriteLine("Exception passed '{0}'", ex.Message);
                // Output to console that an exception has been passed Concatenate the exception message as a string

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static public void WriteLog(string param01, string param02, ConsoleColor param02_colour = ConsoleColor.Cyan)
        // This function logs to the console and changes the colour of parameter 2
        {
            ConsoleColor old_colour = Console.ForegroundColor;

            Console.Write(param01 + " ");
            Console.ForegroundColor = param02_colour;
            Console.Write(param02 + " ");
            Console.Write(Environment.NewLine);

            Console.ForegroundColor = old_colour;
        }
    }
}
