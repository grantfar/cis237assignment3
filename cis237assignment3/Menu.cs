using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    class Menu
    {
        private droidModelPrice[] listOfPrices;
        private List<Droid> Inventory, soldDroids;
        public Menu()
        {
            soldDroids = new List<Droid>();
            Inventory = new List<Droid>();
            listOfPrices = new droidModelPrice[] { new droidModelPrice("astromech", 1100m), new droidModelPrice("protocol", 1500m), new droidModelPrice("janitor", 1000m), new droidModelPrice("utility", 800m) };
        }
        public void DisplayUI()
        {
            Console.WriteLine("1: Add Droid" + Environment.NewLine +
                "2: Remove Droid" + Environment.NewLine +
                "3: Sell Droid" + Environment.NewLine +
                "4: Display Invitory" + Environment.NewLine +
                "5: Display Sold Droids" + Environment.NewLine +
                "6: Return Droid" + Environment.NewLine +
                "7: Exit");
            string inputString = Console.ReadLine();
            int inputInt;
            if (!int.TryParse(inputString, out inputInt))
                Console.WriteLine("invalid Input, {0}", inputString);
            else
                decision(inputInt);
        }
        /// <summary>
        /// Takes the input from the Ui and decides 
        /// What methiod to run
        /// </summary>
        /// <param name="inputInt"></param>
        private void decision(int inputInt)
        {
            Console.Clear();
            switch(inputInt)
            {
                case 1:
                    addDroid();
                    break;
                case 2:
                    removeDroid();
                    break;
                case 3:
                    sellDroid();
                    break;
                case 4:
                    displayInvitory();
                    break;
                case 5:
                    displaySold();
                    break;
                case 6:
                    returnDroid();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("invalid Input: " + inputInt + Environment.NewLine);
                    break;
            }
            
        }
        /// <summary>
        /// adds a droid to the inventory
        /// </summary>
        private void addDroid()
        {
            Console.WriteLine("please choose a droid type:");
            for(int i = 0; i < listOfPrices.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + listOfPrices[i].model);
            }
            String selection = Console.ReadLine();
            int selectionInt;
            Console.Clear();
            if (int.TryParse(selection, out selectionInt) && selectionInt <= listOfPrices.Length)
            {
                Console.WriteLine(listOfPrices[selectionInt -1].model + Environment.NewLine);
                switch (listOfPrices[selectionInt -1].model)
                {
                    case "astromech":
                        Inventory.Add(AstromechDroid.CreateDroid());
                        break;
                    case "protocol":
                        Inventory.Add(ProtocolDroid.CreateDroid());
                        break;
                    case "janitor":
                        Inventory.Add(JanitorDroid.CreateDroid());
                        break;
                    case "utility":
                        Inventory.Add(UtilityDroid.CreateDroid());
                        break;
                    default:
                        Console.WriteLine("Error, unknown droid type");
                        break;
                }
                Console.Clear();
            }
            else
                Console.WriteLine("invalid Input, {0}", selection);
        }
        /// <summary>
        /// moves a droid to the sold droid list from the inventory
        /// </summary>
        private void sellDroid()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("No droids to sell" + Environment.NewLine);
                return;
            }
            int selectionInt;
            decimal priceDecimal;
            Droid tmpDroid;
            Console.WriteLine("Which droid? or e to escape");
            displayInvitory();

            String inputString = Console.ReadLine();
            Console.Clear();
            if (int.TryParse(inputString, out selectionInt) && selectionInt <= Inventory.Count)
            {
                Console.WriteLine("At what price?");
                while (!decimal.TryParse(Console.ReadLine(), out priceDecimal))
                {
                    int currentLineInt = Console.CursorTop - 1;
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineInt);
                }
                tmpDroid = Inventory[selectionInt - 1];
                Inventory.RemoveAt(selectionInt - 1);
                tmpDroid.TotalCost = priceDecimal;
                soldDroids.Add(tmpDroid);
                Console.Clear();
            }
            else if (inputString.Equals("e") || inputString.Equals("E"))
            {
                return;
            }
            else
            {
                Console.WriteLine("invalid input: " + inputString + Environment.NewLine);
            }
        }
        /// <summary>
        /// returns a sold droid to the inventory
        /// </summary>
        private void returnDroid()
        {
            if (soldDroids.Count == 0)
            {
                Console.WriteLine("No droids to return" + Environment.NewLine);
                return;
            }
            int selectionInt;
            Droid tmpDroid;
            Console.WriteLine("Which droid? or e for Escape");
            displaySold();

            String inputString = Console.ReadLine();
            Console.Clear();
            if (int.TryParse(inputString, out selectionInt) && selectionInt <= soldDroids.Count)
            {
                tmpDroid = soldDroids[selectionInt - 1];
                soldDroids.RemoveAt(selectionInt - 1);
                tmpDroid.CalculateTotalCost();
                soldDroids.Add(tmpDroid);
            }
            else if (inputString.Equals("e") || inputString.Equals("E"))
            {
                return;
            }
            else
            {
                Console.WriteLine("invalid input: " + inputString + Environment.NewLine);
            }            
        }

        /// <summary>
        /// removes a droid from the Inventory
        /// </summary>
        private void removeDroid()
        {
            if(Inventory.Count == 0)
            {
                Console.WriteLine("No droids to remove" + Environment.NewLine);
                return;
            }
            int selectionInt;
            Console.WriteLine("Which droid? or e for Escape");
            //displays all of the inventory
            displayInvitory();
            String inputString = Console.ReadLine();
            Console.Clear();
            //trys to convert the user input into 
            if (int.TryParse(inputString, out selectionInt) && selectionInt <= Inventory.Count)
            {
                Inventory.RemoveAt(selectionInt - 1);
            }
            else if (inputString.Equals("e") || inputString.Equals("E"))
            {
                return;
            }
            else
            {
                Console.WriteLine("invalid input: " + inputString + Environment.NewLine);
            }
        }
        /// <summary>
        /// displays all the Droids in the Inventory
        /// </summary>
        private void displayInvitory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("No droids to display" + Environment.NewLine);
                return;
            }
            int listInt = 1;
            foreach (Droid d in Inventory)
            {
                Console.WriteLine(listInt + ": " + d.ToString());
                listInt++;
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// displays all the sold droids
        /// </summary>
        private void displaySold()
        {
            if (soldDroids.Count == 0)
            {
                Console.WriteLine("No droids sold" + Environment.NewLine);
                return;
            }
            int listInt = 1;
            foreach (Droid d in soldDroids)
            {
                Console.WriteLine(listInt + ": " + d.ToString());
                listInt++;
            }
        }

    }
}
