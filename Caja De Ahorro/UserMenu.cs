using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caja_De_Ahorro
{
    class UserMenu 
    {
        public User NewUser()
        {
            string name = "";

            do
            {
                Console.Write("Escriba el nombre del usuario: ");
                name = Console.ReadLine();
            }
            while (name == "");
            

            return new User(0, name);
        }


        public User ChoiceUser(List<User> users)
        {
            int counter;
            int choice = 0;

            if(users.Count == 0)
            {
                Console.WriteLine("Cree un nuevo usuario");
                return NewUser();
            }
            else
            {
                do {
                    counter = 1;
                    foreach(User user in users){
                        Console.WriteLine("{0}.- {1}", counter, user.Name);
                        counter++;
                    }

                    Console.Write("Escoja un usuario: ");
                    int.TryParse(Console.ReadLine(), out choice);

                } while (choice < 1 || choice > users.Count);

                return users[(choice - 1)];
            }
        }

        public decimal getContribution()
        {
            decimal contribution = 0;
            do { 
                Console.Write("Escriba la aportacion: ");
                Decimal.TryParse(Console.ReadLine(), out contribution);

            } while (contribution <= 0);

            return contribution;
        }

        public decimal getDeposit()
        {
            decimal deposit = 0;
            do
            {
                Console.Write("Escriba el deposito: ");
                Decimal.TryParse(Console.ReadLine(), out deposit);

            } while (deposit <= 0);

            return deposit;
        }

        public decimal getRemove()
        {
            decimal remove = 0;
            do
            {
                Console.Write("Escriba el retiro: ");
                Decimal.TryParse(Console.ReadLine(), out remove);

            } while (remove <= 0);

            return remove;
        }

        public decimal getLending()
        {
            decimal lending = 0;
            do
            {
                Console.Write("Escriba la cantidad del prestamo: ");
                Decimal.TryParse(Console.ReadLine(), out lending);

            } while (lending <= 0);

            return lending;
        }

        public decimal getInterest()
        {
            decimal interest = 0;
            do
            {
                Console.Write("Escriba el interes: ");
                Decimal.TryParse(Console.ReadLine(), out interest);

            } while (interest <= 0);

            return interest;
        }

        public int getMonths()
        {
            int months = 0;

            do
            {
                Console.Write("Escriba los meses: ");
                int.TryParse(Console.ReadLine(), out months);

            } while (months <= 0);

            return months;
        }

        public DateTime getDate()
        {
            DateTime date;
            bool dateRight;

            do
            {
                Console.Write("Escriba la fecha: ");
                dateRight = DateTime.TryParse(Console.ReadLine(), out date);

            } while (dateRight == false);

            return date;
        }

        public void ShowTransactions(List<Transaction> transactions)
        {
            Console.WriteLine();

            foreach(Transaction transaction in transactions)
            {
                Console.WriteLine(transaction.ToString());
            }
        }
    }
}
