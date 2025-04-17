using System;
using System.Runtime.CompilerServices;

namespace SkalProj_Datastrukturer_Minne
{
     static class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static List<string> theList = new List<string>();
        
        static void Main()
        {
            //var Log = (string message) => Console.WriteLine($"{message}");


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            
            while (true)
            {
                "------List------".Log();
                DisplayInstructions();
                var input = StringValidation(Console.ReadLine());
                if (input.HasExited())
                    break;
                SwitchCases(input, AddToList, RemoveFromList);
            }

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            while (true)
            {
                "------Queue------".Log();
                DisplayInstructions();
                var input = Console.ReadLine().StringValidation();
                if (input.HasExited())
                    break;
                Action<string> switchFromQueue = (input) => input.SwitchCases(Enqueue, Dequeue);
                input.SwitchCases(Enqueue, Dequeue);
            }

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            var DisplayInstructions = () =>
            {
                ("" +
                "\n").Log();
            };
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            

        }

        private static void DisplayInstructions()
        {
            ("Please enter a command (+ or -) followed by a name to add or remove from the list" 
                + "\nTo exit this menu, please enter '0'").Log();
        }
        private static void Log(this string message)
        {
            Console.WriteLine($"{message}");
        }

        private static bool HasExited(this string input)
        {
            return input.StartsWith('0');
        }
        private static string StringValidation(this string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                "Invalid entry, try again: ".Log();
                input = Console.ReadLine();
            }
                ;
            return input;
        }

        private static void DisplayCountAndCapacity()
        {
            $"The list now contains {theList.Count} items.".Log();
            $"The list has a capacity of {theList.Capacity}.".Log();
        }

        private static void SwitchCases( this string input, Action<string> addElement, Action<string> removeElement)
        {
            char nav = input[0];
            string value = input.Substring(1);
            switch (nav)
            {
                case '+':
                    addElement(value);
                    break;
                case '-':
                    removeElement(value);
                    break;
                default:
                    "Invalid command. Please use + or -.".Log();
                    input = Console.ReadLine().StringValidation();
                    break;
            }
        }
        private static void AddToList(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                theList.Add(input.ToLower());
            }
            DisplayCountAndCapacity();
        }

        private static void RemoveFromList(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                while (!theList.Contains(input.ToLower()))
                {
                    $"'{input}' is not in the list!".Log();
                    input = Console.ReadLine().StringValidation();
                    input.SwitchCases(AddToList, RemoveFromList);
                }
                theList.Remove(input.ToLower());
            }
            DisplayCountAndCapacity();
        }

        private static void Enqueue(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                $"{input} joins the queue".Log();
                theList.Insert(0,input.ToLower());
            }else
            {
                "ICA opens, the queue is empty.".Log();
            }
                DisplayCountAndCapacity();
        }
        private static void Dequeue(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                //theList.Remove(input.ToLower());
                
                while (!theList.Last().Contains(input.ToLower()))
                {
                    $"'{input}' is not in the queue!".Log();
                    input = Console.ReadLine().StringValidation();
                    input.SwitchCases(Enqueue, Dequeue);
                }
                $"{theList.Last()} is served and leave".Log();
                theList.RemoveAt(theList.Count - 1);
            }
            DisplayCountAndCapacity();
        }

    }
}

