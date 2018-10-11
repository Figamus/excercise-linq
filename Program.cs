using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
    public class ReportItem
    {
        public string CustomerName { get; set; }
        public string BankName { get; set; }
    }
    class Program
    {
        static void Main (string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string> () { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            // Using a .StartWith method
            IEnumerable<string> LFruits = from fruit in fruits
            where fruit.StartsWith("L")
            select fruit;
            // Loops through and write each fruit
            foreach (string fruit in LFruits) {
                Console.WriteLine(fruit);
            }

            Console.WriteLine("--------------------------------------");

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>() {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};
            // Using a .Where method to find numbers that have remainder of 0 of 4 or 6
            IEnumerable<int> fourSixMultiples = numbers.Where((digit, index) => digit % 4 == 0 || digit % 6 == 0);
            // Console.WritingLine each result
            foreach (var num in fourSixMultiples) 
            { 
                Console.WriteLine($"{num} Is a multiple of 4 or 6"); 
            }

            Console.WriteLine("--------------------------------------");

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };
            // Using a order by descneding method
            var descend = names.OrderByDescending(a => a);
            // console writing each name by resulting order
            foreach (var name in descend) 
            { 
                Console.WriteLine(name); 
            }

            Console.WriteLine("--------------------------------------");

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            var ascend = numbers2.OrderBy(a => a);
            foreach (var num in ascend) 
            { 
                Console.WriteLine(num); 
            }

            Console.WriteLine("--------------------------------------");

            // Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            int totalcount = numbers3.Count();
            Console.WriteLine(totalcount);

            Console.WriteLine("--------------------------------------");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double purchasesTotal = purchases.Sum();
            Console.WriteLine(purchasesTotal);

            Console.WriteLine("--------------------------------------");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double highestPrice = prices.Max();
            Console.WriteLine(highestPrice);

            Console.WriteLine("--------------------------------------");

            /*
                Store each number in the following List until a perfect square
                is detected.
                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>() { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14};
            // TakeWhile means Take while the condition is true, NOT take until the condition is true.
            var squaredNum = wheresSquaredo.TakeWhile((num, index) => num % Math.Sqrt(num) != 0);
            foreach(var num in squaredNum) {
                Console.WriteLine(num);
            }

            Console.WriteLine("--------------------------------------");
            // Build a collection of customers who are millionaires
            /*
            Given the same customer set, display how many millionaires per bank.
            Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq
            Example Output:
            WF 2
            BOA 1
            FTB 1
            CITI 1
            */
            List<Customer> customers = new List<Customer>()
            {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
            var millionaires = customers.Where(c => c.Balance > 999999.00);

            var results = from customer in millionaires
                group customer.Balance by customer.Bank into g
                select new { BankId = g.Key, Balance = g.ToList() };

            foreach(var c in results){
                var balances = c.Balance.Count();
                Console.WriteLine($"{c.BankId}: {balances}");
            }
            /*
            TASK:
            As in the previous exercise, you're going to output the millionaires,
            but you will also display the full name of the bank. You also need
            to sort the millionaires' names, ascending by their LAST name.

            Example output:
                Tina Fey at Citibank
                Joe Landy at Wells Fargo
                Sarah Ng at First Tennessee
                Les Paul at Wells Fargo
                Peg Vale at Bank of America
            */
            List<Bank> banks = new List<Bank>()
            {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };
            /*
            You will need to use the `Where()`
            and `Select()` methods to generate
            instances of the following class.
            */

            // List<ReportItem> millionaireReport = ...
            // foreach (var item in millionaireReport)
            // {
            //     Console.WriteLine($"{item.CustomerName} at {item.BankName}");
            // }
        }
    }
}