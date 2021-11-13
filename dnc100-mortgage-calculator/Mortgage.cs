/**
 * Filename: Mortgage.cs
 * Authors: Kenneth David & SDCS
 * This file contains the Mortgage class, which will calculate a user's mortgage
 * given the principle, interest, term and period.
 */


using System;
using System.Collections.Generic;
using System.Text;

namespace dnc100_mortgage_calculator
{
    public class Mortgage
    {
        private double Principle; // This field defines the amount that the user owes 
        private double Interest; // This field defines the interest on the mortgage
        private int Term; // This field defines the loan term in years (15 or 20 years)
        private int Period; // This field defines the number of payments per year


        /**
         * Constructor that will set the properties of the mortgage: principle, interest, term and period
         */
        public Mortgage(double principle, double interest, int term, int period)
        {
            this.Principle = principle;
            this.Interest = interest;
            this.Term = term;
            this.Period = period;
        }

        /**
         * This method will calculate the user's mortgage payment given the required properties
         *
         * @return The user's mortgage payment
         */
        public double Calculate()
        {
            double monthlyInterestRate = this.MonthlyInterestRate(Interest, Period);
            int numberOfPayments = this.NumberOfPayments(Term, Period);
            double compoundedInterestRate = this.CompoundedInterestRate(monthlyInterestRate, numberOfPayments);
            double interestQuotient = this.InterestQuotient(monthlyInterestRate, compoundedInterestRate, numberOfPayments);
    
            return this.Principle * interestQuotient;
        }

        /**
         * This is a method that calculates the monthly interest rate
         *
         * @param interest: The interest on the loan
         * @param period: The amount of payments being made per year
         *
         * @return: The total monthly interest rate
         */
        public double MonthlyInterestRate(double interest, int period)
        {
            double interestRate = interest / 100; // First convert from percentage to decimal form
            return interestRate / period;
        }

        /**
         * This method determines the number of payments that will be made towards the mortgage
         *
         * @param term: The loan term
         * @param period: The amount of payments being made per year
         * @return The number of payments that will be made towards the mortgage
         */
        public int NumberOfPayments(int term, int period)
        {
            return term * period;
        }

        /**
         * This method will calculate the compounded interest rate
         * 
         * @param monthlyInterestRate: The monthly interest rate
         * @param numberOfPayments: The number of payments being made towards the mortgage
         * @return The compounded interest rate
         */
        public double CompoundedInterestRate(double monthlyInterestRate, int numberOfPayments)
        {
            return Math.Pow((1 + monthlyInterestRate), numberOfPayments);
        }

        /**
         * This method will calculate the interest quotient
         * (A helper method to calculate the overall mortgage)
         * 
         * @param monthlyInterestRate: The monthly interest rate
         * @param compoundedInterestRate: The compounded interest rate
         * @param numberOfPayments: The number of payments being made towards the mortgage
         * @return The interest quotient
         */
        public double InterestQuotient(double monthlyInterestRate, double compoundedInterestRate, int numberOfPayments)
        {
            double dividend = monthlyInterestRate * compoundedInterestRate;
            double divisor = compoundedInterestRate - 1;
            return dividend / divisor;
        }
    }
}
