using System;
using System.Collections.Generic;
using ATMConsole;
using Xunit;

namespace ATMTests
{
    public class UnitTest
    {
        [Fact]
        public void ATM_Withdrawal_Documentation_Example()
        {
            var atm = new ATM();
            var result1 = atm.Withdrawal(208);

            Assert.True(result1.Count == 3);
            Assert.True(result1.Find(bill => bill.BillDenomination == 100).TotalToWithdrawal == 2);
            Assert.True(result1.Find(bill => bill.BillDenomination == 5).TotalToWithdrawal == 1);
            Assert.True(result1.Find(bill => bill.BillDenomination == 1).TotalToWithdrawal == 3);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 8);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 7);

            var result2 = atm.Withdrawal(9);

            Assert.True(result2.Count == 2);
            Assert.True(result2.Find(bill => bill.BillDenomination == 5).TotalToWithdrawal == 1);
            Assert.True(result2.Find(bill => bill.BillDenomination == 1).TotalToWithdrawal == 4);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 8);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 8);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 3);

            try 
            {
                atm.Withdrawal(9);
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "Insufficient Funds.");
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 8);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 8);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 3);
            }
        }

        [Fact]
        public void ATM_Withdrawal_10_Returns_A_10_Dollar_Bill()
        {
            var atm = new ATM();
            var result = atm.Withdrawal(10);


            Assert.True(result.Count == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 10).TotalToWithdrawal == 1);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Withdrawal_60_Returns_A_50_And_10_Dollar_Bill()
        {
            var atm = new ATM();
            var result = atm.Withdrawal(60);

            Assert.True(result.Count == 2);
            Assert.True(result.Find(bill => bill.BillDenomination == 50).TotalToWithdrawal == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 10).TotalToWithdrawal == 1);


            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Withdrawal_187_Returns_Lots_Of_Bills()
        {
            var atm = new ATM();
            var result = atm.Withdrawal(187);

            Assert.True(result.Count == 6);
            Assert.True(result.Find(bill => bill.BillDenomination == 100).TotalToWithdrawal == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 50).TotalToWithdrawal == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 20).TotalToWithdrawal == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 10).TotalToWithdrawal == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 5).TotalToWithdrawal == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 1).TotalToWithdrawal == 2);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 8);
        }

        [Fact]
        public void ATM_Withdrawal_1600_Returns_10_100s_10_50s_And_5_20s_Dollar_Bill()
        {
            var atm = new ATM();
            var result = atm.Withdrawal(1600);

            Assert.True(result.Count == 3);
            Assert.True(result.Find(bill => bill.BillDenomination == 100).TotalToWithdrawal == 10);
            Assert.True(result.Find(bill => bill.BillDenomination == 50).TotalToWithdrawal == 10);
            Assert.True(result.Find(bill => bill.BillDenomination == 20).TotalToWithdrawal == 5);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 5);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Withdrawal_1600_Returns_10_100s_10_50s_And_5_20s_Dollar_Bill_And_Another_200_Gets_20s_And_10s()
        {
            var atm = new ATM();
            var result1 = atm.Withdrawal(1600);

            Assert.True(result1.Count == 3);
            Assert.True(result1.Find(bill => bill.BillDenomination == 100).TotalToWithdrawal == 10);
            Assert.True(result1.Find(bill => bill.BillDenomination == 50).TotalToWithdrawal == 10);
            Assert.True(result1.Find(bill => bill.BillDenomination == 20).TotalToWithdrawal == 5);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 5);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);

            var result2 = atm.Withdrawal(200);

            Assert.True(result2.Count == 2);
            Assert.True(result2.Find(bill => bill.BillDenomination == 20).TotalToWithdrawal == 5);
            Assert.True(result2.Find(bill => bill.BillDenomination == 10).TotalToWithdrawal == 10);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Withdrawal_5000_Returns_Insufficient_Funds()
        {
            var atm = new ATM();
            try 
            {
                atm.Withdrawal(5000);
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "Insufficient Funds.");
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
            }
        }

        [Fact]
        public void ATM_Withdrawal_0_Does_Not_Fail()
        {
            var atm = new ATM();
            try 
            {
                atm.Withdrawal(0);
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "You cannot withdrawal 0 dollars.");
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
            }
        }

        [Fact]
        public void ATM_Withdrawal_Negative_Does_Not_Fail()
        {
            var atm = new ATM();
            try 
            {
                atm.Withdrawal(-1);
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "You cannot withdrawal a negative amount.");
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
            }
        }

        [Fact]
        public void ATM_Withdrawal_Decimal_Does_Not_Fail()
        {
            var atm = new ATM();
            try 
            {
                atm.Withdrawal(0.1m);
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "This ATM does not support any coin currency.");
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
            }
        }

        [Fact]
        public void ATM_Withdrawal_Decimal_Does_Not_Fail_If_Configured_For_Coins()
        {
            var atm = new ATM{CoinCurrencyEnabled = true};
            try 
            {
                atm.Withdrawal(0.1m);
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "Insufficient Funds.");
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
            }
        }

        [Fact]
        public void ATM_Withdrawal_Decimal_Does_Not_Fail_If_Configured_For_Coins_And_Has_Coins()
        {
            var atm = new ATM(new List<Bill> {
                new Bill {
                    BillDenomination = 0.1m,
                    TotalInATM = 10
                }
            });
            atm.CoinCurrencyEnabled = true;
            
            var result = atm.Withdrawal(0.1m);


            Assert.True(result.Count == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 0.1m).TotalToWithdrawal == 1);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 0.1m).TotalInATM == 9);
        }

        [Fact]
        public void ATM_Restock_Works_When_Full()
        {
            var atm = new ATM();

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);

            atm.Restock();

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Restock_Works_After_Withdrawal()
        {
            var atm = new ATM();
            atm.Withdrawal(1600);

            atm.Restock();

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Withdrawal_All_50s_And_Still_Returns_50_In_Smaller_Bills()
        {
            var atm = new ATM();
            
            for (var ii = 0; ii < 10; ii++) 
            {
                atm.Withdrawal(50);
            }

            var result = atm.Withdrawal(50);

            Assert.True(result.Count == 2);
            Assert.True(result.Find(bill => bill.BillDenomination == 20).TotalToWithdrawal == 2);
            Assert.True(result.Find(bill => bill.BillDenomination == 10).TotalToWithdrawal == 1);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 8);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 9);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Withdrawal_All_50s_And_20s_And_Still_Returns_50_In_Smaller_Bills()
        {
            var atm = new ATM();
            
            for (var ii = 0; ii < 10; ii++) 
            {
                atm.Withdrawal(50);
            }

            for (var ii = 0; ii < 10; ii++) 
            {
                atm.Withdrawal(20);
            }

            var result = atm.Withdrawal(50);

            Assert.True(result.Count == 1);
            Assert.True(result.Find(bill => bill.BillDenomination == 10).TotalToWithdrawal == 5);

            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 0);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 5);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
            Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 10);
        }

        [Fact]
        public void ATM_Withdrawal_All_1s_Try_Once_More_Should_Fail_With_No_Funds()
        {
            var atm = new ATM();
            
            for (var ii = 0; ii < 10; ii++) 
            {
                atm.Withdrawal(1);
            }

            try 
            {
                atm.Withdrawal(1);
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "Insufficient Funds.");
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 100).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 50).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 20).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 10).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 5).TotalInATM == 10);
                Assert.True(atm.Bills.AvailableBills.Find(bill => bill.BillDenomination == 1).TotalInATM == 0);
            }
        }

        [Fact]
        public void Cannot_Create_A_Bill_With_Less_Than_0_Denomination()
        {
            try 
            {
                var bill1 = new Bill{
                    BillDenomination = -1
                };
                var bill2 = new Bill{
                    BillDenomination = 0
                };
                Assert.True(1 == 0); //Fail if we get this far
            }
            catch(Exception e) 
            {
                Assert.True(e.Message == "Only positive number allowed in property BillDenomination");
            }
        }

    }
}
