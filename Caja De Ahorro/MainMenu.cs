using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caja_De_Ahorro
{
    class MainMenu
    {
        public int menu(User user)
        {
            int choice = 0;

            do
            {
                
                Console.WriteLine();

                if(user != null)
                {
                    Console.WriteLine("Usuario: {0}", user.Name);
                }


                Console.WriteLine("1.- Dar de alta un usuario");
                Console.WriteLine("2.- Dar de baja un usuario");
                Console.WriteLine("3.- Aportacion de usuario");
                Console.WriteLine("4.- Deposito de usuario");
                Console.WriteLine("5.- Retiro de usuario");
                Console.WriteLine("6.- Prestamo a usuario");
                Console.WriteLine("7.- Escoger usuario");
                Console.WriteLine("8.- Mi caja");
                Console.WriteLine("9.- Administrador");
                Console.WriteLine("10.- Salir");
                Console.Write("¿Qué número desea usted realizar?: ");
                int.TryParse(Console.ReadLine(), out choice);

            } while (choice < 1 || choice > 10);


            return choice;
        }
    }
}
