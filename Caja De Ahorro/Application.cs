using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Caja_De_Ahorro
{
    public class Application
    {
        private User userSelected;
        private SystemSave systemSave;
        private decimal initAmount;
        private string passwordAdmin;
        private decimal lendingAmount;
        private MainMenu mainMenu;
        private UserMenu menuUser;
        private AdminMenu adminMenu;

        public Application()
        {
            lendingAmount = 0;
            systemSave = new SystemSave();
            mainMenu = new MainMenu();
            menuUser = new UserMenu();
            adminMenu = new AdminMenu();
        }
        public void init()
        {
            int choice = 0;

            OpenFileSavingBank();

            do {

                choice = mainMenu.menu(userSelected);

                switch (choice)
                {
                    case 1: this.userSelected = menuUser.NewUser();
                        systemSave.AddUser(userSelected);
                        break;

                    case 2: 
                        if (systemSave.Users.Count > 0)
                        {
                            if (this.userSelected == null)
                                Console.WriteLine("Escoja un usuario");
                            else
                            {
                                if(systemSave.RemoveUser(userSelected))
                                    userSelected = null;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay usuarios registrados");
                        }

                        break;

                    case 3:
                        if (userSelected == null)
                            userSelected = menuUser.ChoiceUser(systemSave.Users);

                        decimal contribucion = menuUser.getContribution();
                        DateTime date = menuUser.getDate();

                        systemSave.Contributions(userSelected, contribucion, date);

                        initAmount += contribucion;

                        break;

                    case 4:
                        if (userSelected == null)
                            userSelected = menuUser.ChoiceUser(systemSave.Users);

                        decimal deposit = menuUser.getDeposit();

                        initAmount += deposit;

                        systemSave.DepositAcount(userSelected, deposit);

                        break;

                    case 5:
                        if (userSelected == null)
                            Console.WriteLine("Escoja un usuario");
                        else
                        {
                            decimal remove = menuUser.getRemove();



                            if (initAmount < remove)
                            {
                                Console.WriteLine("No disponemos de la cantidad requerida");
                            }
                            else
                            {
                                if (!systemSave.RemoveAcount(userSelected, remove))
                                {
                                    Console.WriteLine("No dispone de dinero suficiente");
                                }

                                initAmount -= remove;
                            }
                        }
                        break;

                    case 6:
                        if (userSelected == null)
                            Console.WriteLine("Escoja un usuario");
                        else
                        {
                            decimal lending = menuUser.getLending();
                            decimal interest = menuUser.getInterest();
                            int months = menuUser.getMonths();

                            if (initAmount < lending)
                            {
                                Console.WriteLine("No disponemos de la cantidad requerida");
                            }
                            else
                            {
                                if (!systemSave.addLending(userSelected, lending, months, interest))
                                {
                                    Console.WriteLine("No se realizo su prestamo");
                                }
                                else
                                {
                                    initAmount -= lending;
                                    lendingAmount += lending;
                                }
                            }
                        }
                        break;

                    case 7:
                        userSelected = menuUser.ChoiceUser(systemSave.Users);
                        break;

                    case 8:
                        if (userSelected == null)
                            Console.WriteLine("Escoje un usuario");
                        else
                        {
                            menuUser.ShowTransactions(systemSave.getTransactionsByUser(userSelected));
                        }

                        break;

                    case 9:
                        Console.Write("Inserte la contraseña: ");
                        if(Console.ReadLine() == passwordAdmin)
                        {
                            int adminChoice = adminMenu.menu();

                            if (adminChoice == 1)
                            {
                                adminMenu.showDayProccess(systemSave.Transactions);
                            }
                            else
                            {
                                Console.WriteLine("Dinero en caja: ", initAmount);
                                Console.WriteLine("Dinero en prestamos: ", lendingAmount);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Contraseña incorrecta");
                        }
                        

                        break;

                }

            }
            while (choice != 10);

            saveFileSavingBank();
        }

        private void OpenFileSavingBank()
        {
            string output = ToString();
            

            if (File.Exists("cajaahorro.properties"))
            {
                StreamReader sr = new System.IO.StreamReader("cajaahorro.properties");
                initAmount = Convert.ToDecimal(sr.ReadLine());
                passwordAdmin = sr.ReadLine();

                sr.Close();

            }
            else
            {
                initAmount = 10000;
                passwordAdmin = "secreto";
            }

        }

        private void saveFileSavingBank()
        {
            FileStream fs = new FileStream("cajaahorro.properties", FileMode.Create);

            string output = "";

            output += initAmount + "\n";
            output += passwordAdmin + "\n";

            fs.Write(ASCIIEncoding.ASCII.GetBytes(output), 0, output.Length);
            fs.Close();
        }
    }
}
