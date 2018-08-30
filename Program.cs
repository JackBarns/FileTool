using FileTool.Modules;
//Import the "FileTool.Modules" namespace containing the "Commands" class

namespace FileTool
{
    public class Program
    {
        static void Main(string[] args) => Commands.AwaitCommand(args);
        /*
         Main() is the function that is run on program execution, just redirect and execute the function AwaitCommand
         and pass the arguments from console to the function
         */
    }

    // Different classes are used to store the code in a more organised manner
}
