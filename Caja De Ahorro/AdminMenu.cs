using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caja_De_Ahorro
{
    class AdminMenu
    {
        public int menu()
        {
            int choice = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1.- Mostrar procesos del dia");
                Console.WriteLine("2.- Mostrar cuánto dinero en total tiene la caja en el momento");
                Console.Write("¿Qué número desea usted realizar?: ");
                int.TryParse(Console.ReadLine(), out choice);

            } while (choice < 1 || choice > 2);


            return choice;
        }

        public void showDayProccess(List<Transaction> transactions)
        {
            Console.WriteLine();
            Console.WriteLine("Total de transacciones en el dia: " + transactions.Count);

            foreach(Transaction transaction in transactions)
            {
                Console.WriteLine(transaction.ToString());
            }
        }
    }
}
