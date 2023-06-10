using System;
using InterfacApplication.Entities;

namespace InterfacApplication.Service
{
    class ContractService
    {
        private ITOnlinePaymentService _onlinePaymentService;

        public ContractService(ITOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double quota = contract.TotalValue / months;
            for(int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = quota + _onlinePaymentService.Interest(quota, i);
                double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
