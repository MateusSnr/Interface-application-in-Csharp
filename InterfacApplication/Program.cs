using System;
using System.Globalization;
using InterfacApplication.Entities;
using InterfacApplication.Service;

namespace InterfaceApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("ENTER CONTRACT DATA");

                Console.Write("Number: ");
                int contractNumber = int.Parse(Console.ReadLine());

                Console.Write("Date (dd/MM/yyyy): ");
                DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Console.Write("Contract value: ");
                double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Enter the number of installments: ");
                int months = int.Parse(Console.ReadLine());

                Contract contract = new Contract(contractNumber,contractDate,contractValue);

                ContractService contractService = new ContractService(new PayPalService());
                contractService.ProcessContract(contract, months);

                Console.WriteLine("INSTALLMENTS: ");
                foreach(Installment installment in contract.Installments)
                {
                    Console.WriteLine(installment);
                }

            }
            catch (Exception e) 
            {
                Console.WriteLine("Erro !");
                Console.WriteLine(e.Message);
            }
        }
    }
}