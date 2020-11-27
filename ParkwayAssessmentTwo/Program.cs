using ConsoleTables;
using System;

namespace ParkwayAssessmentTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please Enter Amount:   ");
            try
            {
                long amount = Int64.Parse(Console.ReadLine());
                AdviceTransaction compute = new AdviceTransaction();
                var charge = compute.ComputeAdvice(amount);
                if (charge.Charge < 1)
                {
                    Console.WriteLine($"There is currently no charge for this amount {amount}");
                }
                var table = new ConsoleTable("Amount", "Transfer Amount", "Charge", "DebitAmount(Transfer Amount + Charge)");
                table.AddRow(charge.Amount, charge.TransferAmount, charge.Charge, charge.DebitAmount);
                     
                Console.WriteLine("Hello World!");
                Console.WriteLine(table);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Kindly input a number. Thanks");
                Main(args);
            }

            
            Console.ReadKey();
        }
    }
}
