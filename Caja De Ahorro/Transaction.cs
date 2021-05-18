using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Caja_De_Ahorro
{
    class Transaction
    {
        private decimal amount;
        private string proccess;
        private string message;
        private DateTime date;
        private User user;

        public Transaction(User user, string proccess, decimal amount, string message, DateTime date)
        {
            this.user = user;
            this.proccess = proccess;
            this.message = message;
            this.date = date;
            this.amount = amount;
        }

        public User User
        {
            get { return user; }
        }

        public void SaveFile()
        {
            string output = ToString();
            FileStream fs;

            if (File.Exists("salida.txt"))
            {
                fs = new FileStream("operacionesdia.txt", FileMode.Append);
            }
            else
            {
                fs = new FileStream("operacionesdia.txt", FileMode.Create);
            }

            fs.Write(ASCIIEncoding.ASCII.GetBytes(output), 0, output.Length);
            fs.Close();

        }

        public override string ToString()
        {
            string output = "";
            output += user.Id + " | " + user.Name + " | ";
            output += proccess + " | ";
            output += amount + " | " + date.ToString("dddd, dd MMMM yyyy HH:mm:ss") + " | ";
            output += message;
            return output;
        }
    }
}
