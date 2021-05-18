using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caja_De_Ahorro
{
    class SystemSave
    {
        private List<User> users;
        private List<Lending> lendings;
        private List<Transaction> transactions;
        private int counterUsers;
        public SystemSave()
        {
            this.users = new List<User>();
            this.lendings = new List<Lending>();
            this.transactions = new List<Transaction>();
            this.counterUsers = 0;
        }

        public List<User> Users
        {
            get { return users; }
        }

        public List<Transaction> Transactions
        {
            get { return transactions;  }
        }

        public bool AddUser(User user)
        {
            counterUsers++;
            user.Id = counterUsers;
            this.users.Add(user);
            return true;
        }

        public bool RemoveUser(User user)
        {
            var containsUser = lendings.FirstOrDefault(x => x.User.Id == user.Id);

            if (containsUser != null)
            {
                users.Remove(user);
                return true;
            }

            return false;
        }

        public bool DepositAcount(User user, decimal amount)
        {
            var userChoice = users.FirstOrDefault(x => x.Id == user.Id);
            Transaction transaction;

            if (userChoice != null)
            {
                transaction = new Transaction(userChoice, "Deposito", amount, "SUCCESS", DateTime.Now);
                transaction.SaveFile();
                transactions.Add(transaction);
                userChoice.DepositAcount(amount);
                return true;
            }

            transaction = new Transaction(userChoice, "Deposito", amount, "ERROR", DateTime.Now);
            transaction.SaveFile();
            transactions.Add(transaction);

            return false;
        }

        public bool RemoveAcount(User user, decimal amount)
        {
            var userChoice = users.FirstOrDefault(x => x.Id == user.Id);
            Transaction transaction;

            if (userChoice != null)
            {
                if(userChoice.Available >= amount)
                {
                    transaction = new Transaction(userChoice, "Retiro", amount, "SUCCESS", DateTime.Now);
                    transaction.SaveFile();
                    transactions.Add(transaction);
                    userChoice.RemoveAcount(amount);
                    return true;
                }
            }

            transaction = new Transaction(userChoice, "Retiro", amount, "ERROR", DateTime.Now);
            transaction.SaveFile();
            transactions.Add(transaction);

            return false;
        }

        public bool Contributions(User user, decimal amount, DateTime date)
        {
            var userChoice = users.FirstOrDefault(x => x.Id == user.Id);
            Transaction transaction;

            if (userChoice != null)
            {
                transaction = new Transaction(userChoice, "Aportacion", amount, "SUCCESS", DateTime.Now);
                transaction.SaveFile();
                transactions.Add(transaction);
                userChoice.Contribution(amount ,date);
                return true;
            }

            transaction = new Transaction(userChoice, "Aportacion", amount, "ERROR", DateTime.Now);
            transaction.SaveFile();
            transactions.Add(transaction);

            return false;
        }

        public bool ExistUser(int id)
        {
            return this.users.FirstOrDefault(x => x.Id == id) != null;
        }

        public bool PayLending(User user, decimal amount)
        {
            var lending = lendings.FirstOrDefault(x => x.User.Id == user.Id);
            Transaction transaction;

            if (lending != null)
            {
                if(lending.Amount > amount)
                {
                    lending.DepositLending(amount);
                }
                else
                {
                    lendings.Remove(lending);
                    DepositAcount(lending.User, (amount - lending.Amount));
                }

                transaction = new Transaction(lending.User, "Pago", amount, "SUCCESS", DateTime.Now);
                transaction.SaveFile();
                transactions.Add(transaction);

                return true;
            }


            transaction = new Transaction(lending.User, "Pago", amount, "ERROR", DateTime.Now);
            transaction.SaveFile();
            transactions.Add(transaction);

            return false;
        }

        public List<Transaction> getTransactionsByUser(User user)
        {
            return transactions.Where(x => x.User.Id == user.Id).ToList();
        }

        public bool addLending(User user, decimal amount, int months, decimal interest)
        {
            decimal tenPercentage = amount / 10;
            Transaction transaction;

            if (user.Available >= tenPercentage)
            {
                Lending lending = new Lending(user, amount, months);
                this.lendings.Add(lending);

                transaction = new Transaction(user, "Prestamo", amount, "SUCCESS", DateTime.Now);
                transaction.SaveFile();
                transactions.Add(transaction);

                reduceAvailable(user, amount);

                return true;
            }
            else if (user.Acount > user.Available)
            {
                transaction = new Transaction(user, "Prestamo", amount, "ya no los puede usar(retiro o otro préstamo)", DateTime.Now);
                transaction.SaveFile();
                transactions.Add(transaction);

                return false;
            }

            transaction = new Transaction(user, "Prestamo", amount, "No tiene dinero suficiente para pedir prestamo", DateTime.Now);
            transaction.SaveFile();
            transactions.Add(transaction);

            return false;
        }

        public void reduceAvailable(User user, decimal amount)
        {
            User userChoice = this.users.FirstOrDefault(x => x.Id == user.Id);

            userChoice.Available -= amount;
        }

        public User getUser(int id)
        {
            return this.users.FirstOrDefault(x => x.Id == id);
        }


    }
}
