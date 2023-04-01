
﻿using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete.Bicicleta;

namespace Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete
{
   class Program
   {
      static void Main()
      { 
         //INCERCARE CITIRE FISIER CA ARGUMENT IN LINIIA DE COMANDA
     /* static void Main(string[] args)
      {
         if (args.Length == 0)
         {
            Console.WriteLine("Nu s-a specificat niciun fișier.");
            return;
         }

         string fileName = args[0];
         Console.WriteLine("Numele fișierului: " + fileName);

         // Deschide fișierul și citeste-l.
         using (StreamReader reader = new StreamReader(fileName))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               Console.WriteLine(line);
            }
         }
*/
         MagazinBicicleta magazin = new MagazinBicicleta();


         while (true)
         {
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      MENIU PRINCIPAL                     ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   1  - Adauga bicicleta                                  ║");
            Console.WriteLine("║   2  - Sterge bicicleta                                  ║");
            Console.WriteLine("║   3  - Afiseaza lista biciclete                          ║");
            Console.WriteLine("║   4  - Afiseaza stocul bicicletelor                      ║");
            Console.WriteLine("║   5  - Adauga client                                     ║");
            Console.WriteLine("║   6  - Sterge client                                     ║");
            Console.WriteLine("║   7  - Proceseaza comanda                                ║");
            Console.WriteLine("║   8  - Afiseaza pretul total al bicicletelor din magazin ║");
            Console.WriteLine("║   9  - Citire si afisare date din fisier                 ║");
            Console.WriteLine("║   10 - Efectuare comanda client                          ║");
            Console.WriteLine("║   11 - Cautare                                           ║");
            Console.WriteLine("║   12 - Cautare Clienti                                   ║");
            Console.WriteLine("║   13 - Iesire                                            ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║Selectati o optiune:                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
               case 1:
                  //Adaugare bicicleta
                  Console.WriteLine("\nIntroduceti informatiile pentru bicicleta:");
                  Console.Write("Model: ");
                  string model = Console.ReadLine();
                  Console.Write("Brand: ");
                  string brand = Console.ReadLine();
                  Console.Write("Pret: ");
                  double pret = double.Parse(Console.ReadLine());
                  Console.Write("Disponibilitate (DA/NU): ");
                  bool stoc = Console.ReadLine().ToLower() == "da" ? true : false;
                  //introducem enumerarea
                  Console.Write("Culoare (Rosu/Alb/Negru): ");
                  Culoare culoare = (Culoare)Enum.Parse(typeof(Culoare), Console.ReadLine(), true);
                  Console.Write("Opțiuni (Electrica/Pliabila/Mini): ");
                  Optiuni optiuni = (Optiuni)Enum.Parse(typeof(Optiuni), Console.ReadLine(), true);
                  int id = new Random().Next(1000, 9999);
                  Bicicleta bicicleta = new Bicicleta(id,brand, model, pret, stoc,culoare,optiuni);
                  magazin.AddBicicleta(bicicleta);

                  //Salvare bicicleta in fisier txt
                  using (StreamWriter sw = new StreamWriter("bicicleta.txt", true))
                  {
                     sw.WriteLine($"{model},{brand},{pret},{stoc}");
                  }


                  Console.WriteLine("\nBicicleta a fost adaugata in magazin!");
                  Console.WriteLine(bicicleta.ToString());
                  break;

               case 2:
                  //Stergere bicicleta
                  Console.WriteLine("\nIntroduceti informatiile pentru bicicleta de sters:");
                  Console.Write("Id: ");
                  double idToDelete = double.Parse(Console.ReadLine());
                  Console.Write("Brand: ");
                  string brandToDelete = Console.ReadLine();
                  Console.Write("Model: ");
                  string modelToDelete = Console.ReadLine();

                  Bicicleta bicicletaToDelete = magazin.Inventar.Find(b => b.Brand == brandToDelete && b.Model == modelToDelete);
                  magazin.StergeBicicleta(bicicletaToDelete);

                  Console.WriteLine("\nBicicleta a fost stearsa din magazin!");
                  break;

               case 3:
                  Console.WriteLine("\nLista biciclete din magazin:");
                  foreach (Bicicleta b in magazin.Inventar)
                  {
                     Console.WriteLine(b.ToString());
                  }
                  break;

               case 4:
                  Console.WriteLine("\nBicicletele disponibile din magazin:");
                  foreach (Bicicleta b in magazin.GetBicicleteDisponibile())
                  {
                     Console.WriteLine(b.ToString());
                  }
                  break;

               case 5:
                  Console.WriteLine("\nIntroduceti informatiile pentru client:");
                  Console.Write("Nume: ");
                  string nume = Console.ReadLine();
                  Console.Write("Email: ");
                  string email = Console.ReadLine();
                  Console.Write("Telefon: ");
                  string telefon = Console.ReadLine();

                  Client client = new Client(nume, email, telefon);
                  magazin.AddClient(client);

                  //Adaugare clienti cititi de la tastatura in fisier
                  using (StreamWriter sw = new StreamWriter("client.txt", true))
                  {
                     sw.WriteLine($"{nume}, {email},{telefon}");
                  }
                  Console.WriteLine("\nClientul a fost adaugat in magazin!");
                  Console.WriteLine(client.ToString());
                  break;

               case 6:
                  //Stergere client
                  Console.WriteLine("\nIntroduceti informatiile pentru clientul de sters:");
                  Console.Write("Nume: ");
                  string numeClient = Console.ReadLine();
                  Console.Write("Email: ");
                  string emailClient = Console.ReadLine();
                  Console.Write("Telefon: ");
                  string telefonClient = Console.ReadLine();

                  Client clientToDelete = magazin.Clienti.Find(c => c.Nume == numeClient && c.Email == emailClient && c.Telefon == telefonClient);
                  magazin.StergeClient(clientToDelete);

                  Console.WriteLine("\nClientul a fost sters din magazin!");
                  break;

               case 7:
                  //Initializare comanda
                  Console.WriteLine("\nIntroduceti informatiile pentru comanda:");
                  Console.Write("Nume client: ");
                  string numeClientComanda = Console.ReadLine();
                  Console.Write("Email cilient: ");
                  string emailClientComanda = Console.ReadLine();
                  Console.Write("Telefon client: ");
                  string telefonClientComanda = Console.ReadLine();
                  Console.Write("Brand bicicleta: ");
                  string brandBicicletaComanda = Console.ReadLine();
                  Console.Write("Model bicicleta: ");
                  string modelBicicletaComanda = Console.ReadLine();

                  Client clientComanda = magazin.Clienti.Find(c => c.Nume == numeClientComanda && c.Email == emailClientComanda && c.Telefon == telefonClientComanda);
                  Bicicleta bicicletaComanda = magazin.Inventar.Find(b => b.Brand == brandBicicletaComanda && b.Model == modelBicicletaComanda);

                  if (clientComanda == null)
                  {
                     Console.WriteLine("\nClientul nu exista in magazin!");
                  }
                  else if (bicicletaComanda == null)
                  {
                     Console.WriteLine("\nBicicleta nu exista in magazin!");
                  }
                  else
                  {
                     magazin.ProceseazaComanda(clientComanda, bicicletaComanda);
                     Console.WriteLine("\nComanda a fost procesata!");
                  }
                  break;

               case 8:
                  //Pretul total al bicicletelor din magazin
                  Console.WriteLine($"\nPretul total al bicicletelor din magazin este: {magazin.GetPretTotalBiciclete()} RON");
                  break;
               case 9:
                  //Afisare biciclete si clienti din fisier
                  var dataReader = new DataReader("bicicleta.txt", "client.txt");
                  dataReader.PrintBicyclesAndClients();
                  break;
               case 10:
                  //Scrie in fisier comanda.txt - nu functioneaza
                  Console.WriteLine("Introduceti adresa de email a clientului:");
                  var clientEmail = Console.ReadLine();
                  Console.WriteLine("Introduceti id-ul bicicletei:");
                  var bicycleId = int.Parse(Console.ReadLine());

                  
                  //Magazin.AddToCart(clientEmail, bicycleId);
                  Console.WriteLine("Bicicleta a fost adaugata in cosul clientului cu succes!");
                  break;
               case 11:
                  //Cautare biciclete dupa criterii
                  Console.WriteLine("Introduceti criteriul de cautare(id,model,brand):");
                  string criteria = Console.ReadLine();

                  // Cautare biciclete
                  var bicicleteGasite = magazin.SearchBiciclete(criteria);

                  // Afisare rezultate
                  if (bicicleteGasite.Count > 0)
                  {
                     Console.WriteLine("\nBiciclete gasite:\n");
                     foreach (Bicicleta b in bicicleteGasite)
                     {
                        Console.WriteLine(b.ToString());
                     }
                  }
                  else
                  {
                     Console.WriteLine("\nNu s-au gasit biciclete care sa corespunda criteriilor de cautare.");
                  }
                  break;
               case 12:
                  //Cautare clienti in magazin
                  Console.WriteLine("\nIntroduceti numele clientului pentru cautare:");
                  string numeCautare = Console.ReadLine();

                  Client foundClient = null; // initializare variabila client

                  try
                  {
                     foundClient = magazin.Clienti.Find(c => c.Nume.ToLower() == numeCautare.ToLower()); // assign a value to the client variable
                     Console.WriteLine(foundClient.ToString());
                  }
                  catch (Exception ex)
                  {
                     Console.WriteLine("Eroare: " + ex.Message);
                  }

                  if (foundClient == null)
                  {
                     Console.WriteLine("Clientul nu a fost gasit!");
                  }

                  break;


               case 13:
                  //Iesire din program
                  Console.WriteLine("\nLa revedere!");
                  return;
            }
         }
      }
   }
}
