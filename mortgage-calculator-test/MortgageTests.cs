using System;
using Xunit;
using dnc100_mortgage_calculator;

namespace mortgage_calculator_test
{
    public class MortgageTests
    {
        double principal = 700000;
        double interest = 3.5;
        int term = 30;
        int period = 12;

        Mortgage mortgage = new Mortgage(principal,interest,term,period);
        Mortgage mortgage2 = new Mortgage(principle,interest,term,10);

        [Fact]
        public void MonthlyPaymentsTest() {
            double result = 3143.31;
            Assert.Equal(result, Math.Round(mortgage.Calculate(),2));
        }

        [Fact]
        public void MonthlyInterestRateTest() {
            double result = 0.00292;
            Assert.Equal(result, Math.Round(mortgage.MonthlyInterestRate(interest,period),5));
        }

        [Fact]
        public void NumberOfPaymentsTest() {
            int result = 360;
            Assert.Equal(result, mortgage.NumberOfPayments(term,period));
        }

        [Fact]
        public void CompoundedInterestRateTest() {
            double result = 2.85;
            double monthlyInterestRate = mortgage.MonthlyInterestRate(interest,period);
            int numPayments = mortgage.NumberOfPayments(term,period);
            Assert.Equal(result, Math.Round(mortgage.CompoundedInterestRate(monthlyInterestRate,numPayments),2));
        }

        [Fact]
        public void InterestQuotientTest() {
            double result = 0.00449;
            double monthlyInterestRate = mortgage.MonthlyInterestRate(interest,period);
            int numPayments = mortgage.NumberOfPayments(term,period);
            double compoundedRate = mortgage.CompoundedInterestRate(monthlyInterestRate,numPayments);
            Assert.Equal(result, Math.Round(mortgage.InterestQuotient(monthlyInterestRate,compoundedRate,numPayments),5));
        }

        [Fact]
        public void MonthlyInterestRatePeriodTest() {
            double result = 0.0035;
            Assert.Equal(result, Math.Round(mortgage2.MonthlyInterestRate(interest,10),4));
        }


    }
}
