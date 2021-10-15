using AcademyG.Week6.TestFinale.Core.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.TestFinale.Client
{
    public class Menu
    {

        public static void Start()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU PRINCIPALE\n");
                Console.WriteLine("[1] Gestione Clienti\n" +
                    "[2] Gestione Ordini\n" +
                    "[3] Report\n" +
                    "[4] Esci dal menu\n");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int index);
                while (!isInt)
                {
                    Console.WriteLine("Inserimento non valido");
                    Console.Write(">> ");
                }
                switch (index)
                {
                    case 1:
                        Console.Clear();
                        Clienti();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Ordini();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Report();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta non valida");
                        Console.WriteLine("Premi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                }
            } while (!quit);
        }

        public static void Clienti()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU CLIENTI\n");
                Console.WriteLine("[1] Vedi Elenco Clienti\n" +
                    "[2] Aggiungi Cliente\n" +
                    "[3] Modifica Cliente\n" +
                    "[4] Elimina Cliente\n" +
                    "[5] Esci dal menu\n");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int index);
                while (!isInt)
                {
                    Console.WriteLine("Inserimento non valido");
                    Console.Write(">> ");
                }
                switch (index)
                {
                    case 1:
                        Console.Clear();
                        ClienteManager.ElencoClienti();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        ClienteManager.NuovoCliente();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        ClienteManager.ModificaCliente();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        ClienteManager.EliminaCliente();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 5:
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta non valida");
                        Console.WriteLine("Premi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                }
            } while (!quit);

        }

        public static void Ordini()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU ORDINI\n");
                Console.WriteLine("[1] Vedi Elenco Ordini\n" +
                    "[2] Aggiungi Ordine\n" +
                    "[3] Modifica Ordine\n" +
                    "[4] Elimina Ordine\n" +
                    "[5] Esci dal menu\n");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int index);
                while (!isInt)
                {
                    Console.WriteLine("Inserimento non valido");
                    Console.Write(">> ");
                }
                switch (index)
                {
                    case 1:
                        Console.Clear();
                        
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();

                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 5:
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta non valida");
                        Console.WriteLine("Premi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                }
            } while (!quit);

        }

        public static void Report()
        {

        }
            

    }
}
