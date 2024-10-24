using TechInnovate;
using Microsoft.VisualBasic;

namespace TechInnovate
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int selectedIndex = 0;
            bool salir = false;
            Console.CursorVisible = false;

            while (salir == false)
            {
                Console.Clear();
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("Bienvenido. Seleccione una opcion usando las flechas arriba o abajo");
                Console.WriteLine("-------------------------------------------------------------------\n");

                for (int i = 0; i < Constants.menuOptions.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write((char)2 + " ");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write("  ");
                    }

                    Console.WriteLine(Constants.menuOptions[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(Constants.menuOptions.Length - 1, selectedIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (selectedIndex == Constants.menuOptions.Length - 1)
                            salir = true;
                        else
                            HandleMenuOption(Constants.menuOptions[selectedIndex]);
                        break;
                }
            }
        }
        public static void MenuAsync(string userInput)
        {
            switch (userInput)
            {
                case "Agregar nuevo proyecto":

                    
                    Console.ReadKey();
                    break;
                case "Mostrar proyectos registrados":
                    

                    Console.ReadKey();
                    break;
                case "Modificar proyecto existente":

                    
                    Console.ReadKey();
                    break;
                case "Eliminar proyecto por su nombre":

                    
                    Console.ReadKey();
                    break;
            }
        }

        static void HandleMenuOption(string option)
        {
            Console.Clear();
            Console.WriteLine($"Seleccionaste la siguiente opcion: {option}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            MenuAsync(option);
        }
    }
}