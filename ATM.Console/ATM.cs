using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMConsole
{
    public class ATM {
        public Bills Bills { get; set; }

        public Bills DefaultAmounts { get; set; }
        public Boolean CoinCurrencyEnabled { get; set; }

        public ATM () {
            Bills = new Bills();
            DefaultAmounts = new Bills();
            CoinCurrencyEnabled = false; //By default this is turned off
        }

        public ATM (List<Bill> defaults) {
            Bills = new Bills(defaults);
            DefaultAmounts = new Bills(defaults);
            CoinCurrencyEnabled = false; //By default this is turned off
        }

        public void Restock () {
            Bills = new Bills(DefaultAmounts.AvailableBills);
        }

        public List<Bill> Withdrawal (decimal withdrawalAmount) {

            if (withdrawalAmount == 0) 
            {
                throw new Exception("You cannot withdrawal 0 dollars.");
            } 
            else if (withdrawalAmount < 0) 
            {
                throw new Exception("You cannot withdrawal a negative amount.");
            }

            if (withdrawalAmount % 1 > 0 && !CoinCurrencyEnabled) 
            {
                throw new Exception("This ATM does not support any coin currency.");
            }

            var withdrawalBills = new List<Bill>();
            var amountLeft = withdrawalAmount;

            Bills.AvailableBills.OrderByDescending(bill => bill.BillDenomination).ToList().ForEach(bill => {
                int amountOfBillsNeeded = Decimal.ToInt32(amountLeft/bill.BillDenomination);
                if (amountOfBillsNeeded > 0 && bill.TotalInATM > 0)
                {
                    var totalToWithdrawal = amountOfBillsNeeded;

                    if (bill.TotalInATM < totalToWithdrawal) 
                    {
                        totalToWithdrawal = bill.TotalInATM;
                    }

                    withdrawalBills.Add(new Bill{
                        TotalToWithdrawal = totalToWithdrawal,
                        BillDenomination = bill.BillDenomination
                    });

                    amountLeft -= totalToWithdrawal * bill.BillDenomination;
                }
            });

            if (amountLeft == 0){
                withdrawalBills.ForEach(withdrawalBill => {
                    Bills.AvailableBills.Find(bill => bill.BillDenomination == withdrawalBill.BillDenomination).TotalInATM -= withdrawalBill.TotalToWithdrawal;
                });
                
                return withdrawalBills;
            }

            throw new Exception("Insufficient Funds.");
        }

    }
}