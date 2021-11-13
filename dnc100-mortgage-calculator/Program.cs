/**
 * Filename: Program.cs
 * Authors: Kenneth David and SDCS
 * This file contains the Program class which will serve as the interactive piece of 
 * the mortgage class. It will prompt the user to enter in the required mortgage
 * properties and use the Mortgage class to calcualte the user's mortgage.
 */
using System;

namespace dnc100_mortgage_calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mortgage mortgage;
            double principal, interestRate, monthlyPayment;
            int term, period;

            // Use .WriteLine to greet the user
            Console.WriteLine("Hello, Welcome to the Mortgage Calculator! Let's get started.\r\n");

            // Use a mix of WriteLine and ReadLine to obtain the mortgage attributes (Making sure to typecast)
            Console.WriteLine("Enter the principal (This is the total amount of the loan without interest):\r\n");
            principal = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the interest rate (In percent):\r\n");
            interestRate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the loan term (in years):\r\n");
            term = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the loan period (1 - monthly, 2 - bimonthly, etc.):\r\n");
            period = Convert.ToInt32(Console.ReadLine());


            // Create a new Mortgage with the given attributes;
            mortgage = new Mortgage(principal, interestRate, term, period);

            // Use the Mortgage functions to calculate the monthly payment
            monthlyPayment = mortgage.Calculate();

            // Use WriteLine to output the monthly payment
            Console.WriteLine("Your total monthly payment would be: " + monthlyPayment + " dollars");

        }
    }
}
