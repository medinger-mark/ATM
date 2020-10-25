using System.ComponentModel.DataAnnotations;

namespace ATMConsole
{
    public class Bill
    {
        //[Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed in property BillDenomination")]
        // Normally I would use this in a web api instead of changing the setter    
        private decimal _billDenomination;
        public decimal BillDenomination { 
            get
            {
                return _billDenomination;
            }

            set
            {
                if (value <= 0) {
                    throw new System.Exception("Only positive number allowed in property BillDenomination");
                } 
                _billDenomination = value;
            } 
        }
        public int TotalInATM { get; set; }
        public int TotalToWithdrawal { get; set; }

    }
}