
namespace InterfacApplication.Service
{
    interface ITOnlinePaymentService
    {
        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}
