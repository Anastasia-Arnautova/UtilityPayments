using UtilityPayments.Calculator;

namespace UtilityPayments
{
    public class Program
    {
        public static float gasBill;
        public static float waterBill;
        public static float electricityBill;
        public static float totalBill;

        public static void Main(string[] args)
        {
            PaymentCalculator paymentCalculator = new PaymentCalculator();
            paymentCalculator.Calculate();

            gasBill         = paymentCalculator.gasBill;
            waterBill       = paymentCalculator.waterBill;
            electricityBill = paymentCalculator.electricityBill;
            totalBill       = paymentCalculator.totalBill;
        }
    }
}

