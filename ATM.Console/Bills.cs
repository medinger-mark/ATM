using System.Collections.Generic;

namespace ATMConsole
{
    public class Bills
    {
        public Bills () {
            AvailableBills = new List<Bill> {
                new Bill {
                    BillDenomination = 1,
                    TotalInATM = 10
                },
                new Bill {
                    BillDenomination = 5,
                    TotalInATM = 10
                },
                new Bill {
                    BillDenomination = 10,
                    TotalInATM = 10
                },
                new Bill {
                    BillDenomination = 20,
                    TotalInATM = 10
                },
                new Bill {
                    BillDenomination = 50,
                    TotalInATM = 10
                },
                new Bill {
                    BillDenomination = 100,
                    TotalInATM = 10
                }
            };
        }

        public Bills (List<Bill> availableBills) {
            AvailableBills = availableBills;
        }

        public List<Bill> AvailableBills { get; set; }
    }
}