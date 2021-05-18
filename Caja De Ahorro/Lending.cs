using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caja_De_Ahorro
{
    class Lending
    {
        private decimal amount;
        private int months;
        private User user;

        public Lending(User user, decimal amount, int months)
        {
            this.user = user;
            this.amount = amount;
            this.months = months;
        }

        public decimal Amount
        {
            get { return amount; }
        }

        public void DepositLending(decimal amount)
        {
            this.amount -= amount;
        }


        public User User
        {
            get { return user; }
        }
    }
}
