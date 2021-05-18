using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caja_De_Ahorro
{
    class User
    {
        private int id;
        private string name;
        private decimal acount;
        private decimal available;

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.acount = 0;
            this.available = 0;
        }

        public User(int id, string name, decimal acount)
        {
            this.id = id;
            this.name = name;
            this.acount = acount;
            this.available = acount;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public decimal Acount
        {
            get { return acount; }
        }

        public decimal Available
        {
            get { return available; }
            set { available = value; }
        }

        public void Contribution(decimal amount, DateTime fecha)
        {
            this.acount += amount;
            this.available += amount;
        }

        public void DepositAcount(decimal amount)
        {
            this.acount += amount;
            this.available += amount;
        }


        public void RemoveAcount(decimal amount)
        {
            this.acount -= amount;
            this.available -= amount;
        }
    }
}
