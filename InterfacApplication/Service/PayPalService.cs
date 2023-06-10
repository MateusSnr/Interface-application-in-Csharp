
namespace InterfacApplication.Service
{
    class PayPalService : ITOnlinePaymentService
    {
        private double MonthlySimpleInterest = 0.01;
        private double PaymentFeeTax = 0.02;

        public double PaymentFee(double amount)
        {
            return amount * PaymentFeeTax;
        }

        public double Interest(double amount, int months)
        {
            return amount * months * MonthlySimpleInterest;
        }

    }
}
