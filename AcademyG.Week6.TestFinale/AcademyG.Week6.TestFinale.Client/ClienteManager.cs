using AcademyG.Week6.TestFinale.Core.EF;
using AcademyG.Week6.TestFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.TestFinale.Client
{
    public class ClienteManager
    {
        public static void ElencoClienti()
        {
            GestionaleContext ctx = new GestionaleContext();

            Console.WriteLine("{0,5}{1,20}{2,20}{3,20}",
                "Id", "Codice Cliente",
                "Nome", "Cognome");
            Console.WriteLine(new String('-', 65));
            foreach (var c in ctx.Clienti)
            {
                Console.WriteLine($"[{c.Id,5}]{c.CodiceCliente,20}{c.FirstName,20}{c.LastName,20}");
            }
            Console.WriteLine(new String('-', 65));
        }

        public static void NuovoCliente()
        {
            GestionaleContext ctx = new GestionaleContext();

            try
            {
                Cliente cliente = AcquisizioneDatiCliente();

                ctx.Clienti.Add(cliente);
                ctx.SaveChanges();

                Console.WriteLine("\nInserimento avvenuto con successo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Cliente AcquisizioneDatiCliente()
        {

            Console.Write("Codice Cliente: ");
            string codiceCliente = Console.ReadLine();
            while (string.IsNullOrEmpty(codiceCliente))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Codice Cliente: ");
                codiceCliente = Console.ReadLine();
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Nome: ");
                nome = Console.ReadLine();
            }

            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            while (string.IsNullOrEmpty(cognome))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Cognome: ");
                cognome = Console.ReadLine();
            }


            Cliente cliente = new Cliente()
            {
                CodiceCliente = codiceCliente,
                FirstName = nome,
                LastName = cognome
            };

            return cliente;
        }

        internal static void EliminaCliente()
        {
            GestionaleContext ctx = new GestionaleContext();

            ElencoClienti();

            Console.Write("\nId Cliente da cancellare: ");
            int id = int.Parse(Console.ReadLine());
            var cliente = ctx.Clienti.Find(id);
            if (cliente != null)
            {
                ctx.Clienti.Remove(cliente);
                ctx.SaveChanges();
                Console.WriteLine("Eliminazione avvunuta con successo");
            }
            else Console.WriteLine("Ooops.. Eliminazione non riuscita");
        }

        internal static void ModificaCliente()
        {
            GestionaleContext ctx = new GestionaleContext();

            ElencoClienti();

            
            Console.Write("\nId Cliente da modificare: ");
            int id = int.Parse(Console.ReadLine());
            var cliente = ctx.Clienti.Find(id);
            if (cliente != null)
            {
                ctx.Clienti.Remove(cliente);
                cliente = AcquisizioneDatiCliente();
                ctx.Clienti.Add(cliente);
                ctx.SaveChanges();
                Console.WriteLine("Modifica avvunuta con successo");
            }
            else Console.WriteLine("Ooops.. Modifica non riuscita");
        }
    }
}
