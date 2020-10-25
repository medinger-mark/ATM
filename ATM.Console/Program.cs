using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace ATMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent("ATM").ToString())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            
            var appName = config["AppName"] ?? "Money Grows on Tree Bank";
            var catchPhrase = config["CatchPhrase"] ?? "-- No Account Number? No Problem! --";

            //This class has a constructor that can accept a config file or from a database so we can configure the ATMs available denominations 
            // and how many bills the atm can store of each
            var atm = new ATM(); 

            atm.CoinCurrencyEnabled = Boolean.Parse(config["CoinCurrencyEnabled"] ?? "false");

            Spacer();
            Console.WriteLine($"Welcome to the {appName} ATM");
            Console.WriteLine($"{catchPhrase}");
            Spacer();
            StartMessage();

            string line;

            do
            {
                line = Console.ReadLine().Trim().ToLower();

                Console.WriteLine();
                Console.WriteLine();

                if (line == "r") // TODO: We should ask if this should only be availble if user has the correct access
                {
                    atm.Restock();
                    Console.WriteLine("Success: Cash has been restocked!");
                    Spacer();
                } 
                else if (line == "q") 
                {
                    Spacer();
                    Console.WriteLine("Thank you for using our ATM and goodbye now!");
                }
                else if (line.StartsWith("w"))
                {
                    var value = Utils.GetDollarAmountFromString(line);
                    List<Bill> dispensedBills = null;
                    if (!string.IsNullOrEmpty(value) && decimal.TryParse(value, out var result)) 
                    {
                        try 
                        {
                            dispensedBills = atm.Withdrawal(result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Failure: {e.Message}");
                            Spacer();
                        }
                    }
                    else 
                    {   
                        Console.WriteLine("Failure: Invalid Command.");
                        Spacer();
                    }

                    if (dispensedBills?.Count > 0)
                    {
                        var total = dispensedBills.Sum(bill => bill.TotalToWithdrawal * bill.BillDenomination);
                        Console.WriteLine($"Success: Thank you for your withdrawal of ${total}!");
                        dispensedBills.ForEach(bill => Console.WriteLine($"${bill.BillDenomination} - Total dispensed: {bill.TotalToWithdrawal}"));
                        Spacer();
                    }
                } 
                else if (line.StartsWith("i")) // TODO: We should ask if this should only be availble if user has the correct access
                {
                    var numbers = Utils.GetDollarAmountsFromString(line.Trim());
                    var bills = new HashSet<Bill>();

                    atm.Bills.AvailableBills.ForEach(bill => {
                        var foundNumber = numbers.ToList().Find(number => {
                                decimal.TryParse(number, out var parsedNumber);
                                return parsedNumber == bill.BillDenomination;
                            });
                        if (foundNumber != null) {
                            bills.Add(bill);
                        }
                    });

                    if (bills.Count() > 0 )
                    {
                        bills.ToList().ForEach(bill => Console.WriteLine($"Success: ${bill.BillDenomination} - {bill.TotalInATM}"));
                    }
                    else
                    {
                        Console.WriteLine("Failure: Unable to find any denomination(s) you requested.");
                    }
                }
                else 
                {
                    Console.WriteLine("Failure: Invalid Command.");
                }

                if (line != "q") {
                    Console.WriteLine();
                    MachineBalance(atm);
                    Spacer();
                    StartMessage();
                }
            } while (line != "q");

        }

        public static void Spacer() {
            Console.WriteLine();
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("_____________________________________________");
        }

        public static void StartMessage() {
            Console.WriteLine();
            Console.WriteLine("To make a withdrawal please type in W followed by the amount you would like to withdrawal and hit enter.\nType in Q and hit enter to Quit.");
        }

        public static void MachineBalance(ATM atm) {
            Console.WriteLine("Machine balance:");
            atm.Bills.AvailableBills.OrderByDescending(bill => bill.BillDenomination).ToList()
                    .ForEach(bill => Console.WriteLine($"${bill.BillDenomination} - {bill.TotalInATM}"));
        }
    }
}
