using System;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace SkalProj_Datastrukturer_Minne
{
    static class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>

        //static Action<string> optionInstructions = (optionName) => DisplayInstructions(optionName);
        static readonly string ListLabel = "List";
        static readonly string QueueLabel = "Queue";
        static readonly string StackLabel = "Stack";
        static readonly string CheckParenthesisLabel = "Check Parenthesis";
        static void Main()
        {
            //var Log = (string message) => Console.WriteLine($"{message}");


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4 ,5 , 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Reverse a Stack"
                    + "\n5. CheckParenthesis"
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
                        ReverseStack();
                        break;
                    case '5':
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
            List<string> theList = new();
            while (true)
            {
                ListLabel.DisplayInstructions();
                var input = Console.ReadLine().StringValidation();
                if (input.HasExited())
                    break;
                input.SwitchCases(AddToList, RemoveFromList, theList);
            }

            /* 
                2.       När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
                         När man lägger till ett element och det inte finns tillräckligt med plats i den underliggande arrayen.

                3.       Med hur mycket ökar kapaciteten? 
                         kapaciteten ökar från 4  till 8 , från 8 till 16, från 16 till 32 osv.

                4.       Varför ökar inte listans kapacitet i samma takt som element läggs till? 
                         för bättre prestanda

                5.       Minskar kapaciteten när element tas bort ur listan? 
                        Nej

                6.       När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                        När man vet exakt hur många element som behövs  
            */
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
            Queue<string> theQueue = new();
            while (true)
            {
                QueueLabel.DisplayInstructions();
                var input = Console.ReadLine().StringValidation();
                if (input.HasExited())
                    break;
                input.SwitchCases(Enqueue, Dequeue, theQueue);
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

            Stack<string> theStack = new();
            while (true)
            {
                StackLabel.DisplayInstructions();
                var input = Console.ReadLine().StringValidation();
                if (input.HasExited())
                    break;
                input.SwitchCases(Push, Pop, theStack);
            }

            /*
             *  Varför är det inte så smart att använda en stack i det här fallet? 
             *  Eftersom en stack är LIFO (Last In, First Out) passar den inte för en kö på ICA,
             *  där den som ställt sig först i kön ska få lämna först – inte den som kom sist.
             */
        }

        static void ReverseStack()
        {
            Stack<char> theStack = new();
            while (true)
            {
                "----------StackReverse---------".Log();
                "Please enter a string to reverse it. Enter '0' to Exit".Log();
                var input = Console.ReadLine().StringValidation();
                if (input.HasExited())
                    break;
                foreach (var letter in input)
                {
                    theStack.Push(letter);
                }
                foreach (var letter in input)
                {
                    Console.Write(theStack.Pop());
                }
                "".Log();
            }
        }
        private static void Pop(string input, Stack<string> stack)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (stack.Count != 0) $"{stack.Pop()} is served and leave".Log();
                StackLabel.DisplayCountAndCapacity(stack);
            }
            else "Please enter - for destacking".Log();
            //QueueLabel.DisplayCountAndCapacity(stack);
        }

        private static void Push(string input, Stack<string> stack)
        {
            if (!string.IsNullOrEmpty(input))
            {
                $"{input} joins the {StackLabel}".Log();
                stack.Push(input.ToLower());
            }
            else
            {
                $"the {StackLabel} is empty.".Log();
            }
            StackLabel.DisplayCountAndCapacity(stack);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            while (true)
            {
                $"-------{CheckParenthesisLabel}------".Log();
                "Please enter a string to check if the parenthesis are correct or incorrect.".Log();
                var input = Console.ReadLine().StringValidation();
                if (input.HasExited())
                    break;

                if (input.isCorrect()) "The parenthesis are correct.".Log();
                else "The parenthesis are incorrect.".Log();
            }
            /* 
             * Vilken datastruktur använder du?
             * Jag använder en stack, eftersom den följer principen LIFO (Last In, First Out),
             * och vi vill stänga den senast öppnade parentesen först.
             */
        }

        private static bool isCorrect(this string input)
        {
            Stack<char> stack = new();
            foreach (var letter in input)
            {
                if (letter is '(' or '{' or '[') stack.Push(letter);

                if (letter is ')' or '}' or ']')
                {
                    char pairLetter = letter switch
                    {
                        ')' => '(',
                        '}' => '{',
                        ']' => '['
                    };
                    if (stack.TryPop(out char result))
                    {
                        if (pairLetter == result) continue;
                        else return false;
                    }
                    else return false;
                }
            }
            return true;
        }

        private static void DisplayInstructions(this string optionName)
        {
            $"------{optionName}------".Log();
            ($"Please enter a command (+ or -) followed by a name to add or remove from {optionName}"
                + "\nTo exit this menu, please enter '0'").Log();
        }
        private static void Log(this string message)
        {
            Console.WriteLine(message);
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
                input = Console.ReadLine().Trim();
            }
                ;
            return input;
        }

        private static void DisplayCountAndCapacity<T>(this string optionName, T collection)
        {
            if (collection is List<string> list)
            {
                var listCount = list.Count;
                $"The {optionName} now contains {list.Count} items:".Log();
                for (var i = 0; i < listCount; i++)
                {
                    $"{i + 1}.{list.ElementAtOrDefault(i)}".Log();
                }
                $"The {optionName} has a capacity of {list.Capacity}.".Log();
            }
            else if (collection is Queue<string> queue)
            {
                var queueCount = queue.Count;
                $"The {optionName} now contains {queue.Count} items:".Log();
                for (var i = 0; i < queueCount; i++)
                {
                    $"{i + 1}.{queue.ElementAtOrDefault(i)}".Log();
                }
            }
            else if (collection is Stack<string> stack)
            {
                var stackCount = stack.Count;
                $"The {optionName} now contains {stack.Count} items:".Log();
                for (var i = 0; i < stackCount; i++)
                {
                    $"{i + 1}.{stack.ElementAtOrDefault(i)}".Log();
                }
            }
        }

        private static string SwitchCases<T>(
            this string input,
            Action<string, T> addElement,
            Action<string, T> removeElement,
            T collection
            )
        {
            char nav = input[0];
            string value = input.Substring(1);
            switch (nav)
            {
                case '+':
                    addElement(value, collection);
                    break;
                case '-':
                    if (collection is List<string>)
                    {
                        removeElement(value, collection);
                        break;
                    }
                    else if (collection is Queue<string>)
                    {
                        removeElement(input, collection);
                        break;
                    }
                    else if (collection is Stack<string>)
                    {
                        removeElement(input, collection);
                        break;
                    }
                    break;
                default:
                    "Invalid command.".Log();
                    //input = Console.ReadLine().StringValidation();
                    break;
            }
            return value;
        }
        private static void AddToList(this string input, List<string> list)
        {
            if (!string.IsNullOrEmpty(input))
            {
                list.Add(input.ToLower());
                ListLabel.DisplayCountAndCapacity(list);
            }
        }

        private static void RemoveFromList(this string input, List<string> list)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (!list.Contains(input.ToLower()))
                {
                    $"'{input}' is not in the list!".Log();
                    DisplayInstructions(ListLabel);
                    input = Console.ReadLine().StringValidation();
                    input = input.SwitchCases(AddToList, RemoveFromList, list);
                }
                else
                {
                    list.Remove(input.ToLower());
                    ListLabel.DisplayCountAndCapacity(list);
                }
            }

        }

        private static void Enqueue(this string input, Queue<string> queue)
        {
            if (!string.IsNullOrEmpty(input))
            {
                $"{input} joins the queue".Log();
                queue.Enqueue(input.ToLower());
            }
            else
            {
                "the queue is empty.".Log();
            }
            QueueLabel.DisplayCountAndCapacity(queue);
        }
        private static void Dequeue(this string input, Queue<string> queue)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (queue.Count != 0) $"{queue.Dequeue()} is served and leave".Log();

                QueueLabel.DisplayCountAndCapacity(queue);
            }
            else "Please enter - for dequeuing".Log();
            //QueueLabel.DisplayCountAndCapacity(queue);
        }

    }
}

