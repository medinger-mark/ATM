using System.Collections.Generic;
using ATMConsole;
using Xunit;

namespace ATMTests
{
    public class UnilTest
    {
        
        [Fact]
        public void GetNumberFromText()
        {
            var textTests = new Dictionary<string, string>{
                {"w10", "10"},
                {"W10", "10"},
                {"w$20", "20"},
                {"W$20", "20"},
                {"w $145", "145"},
                {"W $145", "145"},
                {"w10.0.0.0", "10.0"}, 
                {"W10.0.0.0", "10.0"},
                {"w10.10.0.0", "10.10"}, 
                {"W10.10.0.0", "10.10"},
                {"w $125.0 Enter", "125.0"},
                {"W $125.0 Enter", "125.0"},
                {"w $125.0 Enter 1opieudp89wehf", "125.0"},
                {"W $125.0 Enter 1opieudp89wehf", "125.0"},
                {"    w help 10", "10"},
                {"    W help 10", "10"},
                {"    w-10", "10"},
                {"    W-10", "10"}
            };

            foreach(var item in textTests)
            {
                var result = Utils.GetDollarAmountFromString(item.Key);

                Assert.True(result == item.Value);
            }
        }

    }
}
