using System;
using System.Activities;
using System.Activities.Statements;
using System.Linq;
using System.Windows;
using UiPath.Core;
using UiPath.Core.Activities;
using UiPath.UIAutomationNext.Activities;

namespace UiPathCodingFramework
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Console.WriteLine("Type !help or 0 for the list of commands.");
            Console.WriteLine(" ");

            String Line = null;

            while (Line != "3")
            {
                if (Line == "IndicateOnScreen" || Line == "1")
                {

                    var IndicateOnScreen = new UCFIndicateOnScreen().Run
                    (
                        ContinueOnError: false
                    );
                    DateTime myTime = DateTime.Now;
                    Console.WriteLine("Started: " + myTime.ToString());
                    UiElement myIndicatedElement = (UiElement)IndicateOnScreen.Values.ElementAt(0);
                    Console.WriteLine("The selector for this element is:");
                    Console.WriteLine(" ");
                    Console.WriteLine(myIndicatedElement.Selector.ToString());

                    Clipboard.Clear();
                    Clipboard.SetDataObject(char.Parse("\"") + myIndicatedElement.Selector.ToString() + char.Parse("\""));

                    Console.WriteLine(" ");
                    Console.WriteLine("The selector has been copied to the clipboard..");
                    DateTime myFinishDateTime = DateTime.Now;
                    Console.WriteLine("Finished: " + myFinishDateTime.ToString());
                    Console.WriteLine(" ");

                }

                if (Line == "!help" || Line == "0")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Command list:");
                    Console.WriteLine("1. IndicateOnScreen");
                    Console.WriteLine("2. Clear Console");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine(" ");
                }

                if (Line == "2" || Line == "Clear Console")
                {
                    Console.Clear();
                    Console.WriteLine("Type !help or 0 for the list of commands.");
                    Console.WriteLine(" ");
                }

                Line = Console.ReadLine();
            }

        }

    }

}
