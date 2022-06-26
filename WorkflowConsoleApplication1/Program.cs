using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using UiPath;
using UiPath.Core;
using UiPath.Core.Activities;
using UiPath.Core.Activities.Design;
using UiPath.Studio.Workflow.Wizards.ViewModels;
using UiPath.UIAutomationNext;
using UiPath.UIAutomationNext.Activities;
using UiPath.UIAutomationNext.Activities.Design.ActivityFactory;
using Target = UiPath.UIAutomationNext.Target;

namespace UiPathCodingFramework
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {


            Console.WriteLine("Type !help or 0 for the list of commands.");
            Console.WriteLine(" ");


            NApplicationCard newApplicationCard = new NApplicationCard();

            NClickFactory nClick = new NClickFactory();


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
                    var Subsystem = myIndicatedElement.Selector.ToString().Split('>')[1].Split(' ')[0].Replace("<", "");
                    Console.WriteLine("The selector for this element is:");
                    Console.WriteLine(" ");
                    Console.WriteLine(myIndicatedElement.Selector.ToString());


                    ////////////////////////////////////
                    Console.WriteLine("");
                    Console.WriteLine("Do you want to see the attributes of this UiElement? Y/N");

                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        var index = 0;
                        var attributeList = new Dictionary<String, Object>();
                        foreach (var item in myIndicatedElement.Attributes)
                        {
                            var newAttribute =
                                new UCFGetAttributes().Run(myIndicatedElement.Selector.ToString(), item);


                            try
                            {
                                if (newAttribute.ElementAt(0).Value.ToString().Trim() != "")
                                {
                                    Console.WriteLine(index + ". " + item + " : " + newAttribute.ElementAt(0).Value);
                                    index += 1;
                                    attributeList.Add(item, newAttribute.ElementAt(0).Value);
                                }
                            }
                            catch (Exception e)
                            {

                            }
                        }

                        ////////////////////////////////////////
                        Console.WriteLine("");
                        Console.WriteLine("Do you want to extend your current selector with any of these attributes? Y/N");
                        Console.WriteLine("Subsystem detected is: " + Subsystem);
                        Console.WriteLine("");
                        var InitConsole = Console.ReadLine();
                        InitConsole = InitConsole.ToUpper();
                        while (InitConsole == "Y")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Press the numeric key related to your desired attribute.");
                            Console.WriteLine("");
                            var AttrIndex = Console.ReadLine();

                            if (AttrIndex.IsNumeric() == true)
                            {

                                Console.WriteLine("You have selected index #" + AttrIndex + " value: " + attributeList.ElementAt(Int32.Parse(AttrIndex)).Value);

                                myIndicatedElement.Selector.GetTag(myIndicatedElement.Selector.GetTagCount() - 1).AddAttribute(
                                    new SelectorAttribute(attributeList.ElementAt(Int32.Parse(AttrIndex)).Key,
                                        attributeList.ElementAt(Int32.Parse(AttrIndex)).Value.ToString()));

                                Console.WriteLine("");
                                Console.WriteLine("Your selector is now:");
                                Console.WriteLine("");
                                Console.WriteLine(myIndicatedElement.Selector.ToString());
                                Console.WriteLine("");

                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("The string you have provided does not resemble an integer.");
                                Console.WriteLine("");
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Continue adding more attributes? Y/N");
                            InitConsole = Console.ReadLine();
                            InitConsole = InitConsole.ToUpper();
                        }
                        ////////////////////////////////////////

                    }
                    //////////////////////////////////////


                    Clipboard.Clear();

                    String myString = char.Parse("\"") + myIndicatedElement.Selector.ToString() + char.Parse("\"");
                    Clipboard.SetDataObject(myString);

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
