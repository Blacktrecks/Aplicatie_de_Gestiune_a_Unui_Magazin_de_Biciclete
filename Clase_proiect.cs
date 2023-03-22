using Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete;
using System;
using System.Collections.Generic;
using System.IO;


namespace Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete
{
   //Clasa Bicicleta reprezinta bicicleta cu urmatoarele caracteristici: brand, model, pret si disponibilitate pe stoc

  public class Bicicleta
   {
      public string Brand { get; set; }
      public string Model { get; set; }
      public double Pret { get; set; }
      public bool Stoc { get; set; }

      //Initializare constructor al clasei Bicicleta
      public Bicicleta(string brand, string model, double pret, bool stoc)
      {
         Brand = brand;
         Model = model;
         Pret = pret;
         Stoc = stoc;
      }

      //Supradefinim si returnam variabilele clasei
      public override string ToString()
      {
         return $"Brand: {Brand}, Model: {Model}, Pret: {Pret}RON, Disponibilitate: {(Stoc ? "DA" : "NU")}";
      }

      // Clasa MagazinBicicleta reprezinta un magazin online ce vinde biciclete

      public class MagazinBicicleta
      {
         private List<Bicicleta> _biciclete = new List<Bicicleta>(); //declaram o noua lista privata ce va contine bicicletele
         public List<Bicicleta> Inventar { get; set; }
         public List<Client> Clienti { get; set; }

         public MagazinBicicleta()
         { 
               Inventar = new List<Bicicleta>();
               Clienti = new List<Client>();
            
         }

         //Adauga bicicleta 
         public void AdaugaBicicleta(Bicicleta bicicleta)
         {
            _biciclete.Add(bicicleta);
         }

         //Afisare lista biciclete din magazin
         public List<Bicicleta> GetBicicleta()
         {
            return _biciclete;
         }

         //Afisare stoc in magazinul de biciclete
         public List<Bicicleta> GetBicicleteDisponibile()
         {
            List<Bicicleta> bicicleteDisponibile = new List<Bicicleta>();

            foreach (Bicicleta bicicleta in _biciclete)
            {
               if (bicicleta.Stoc)
               {
                  bicicleteDisponibile.Add(bicicleta);
               }
            }
            return bicicleteDisponibile.Count > 0 ? bicicleteDisponibile : new List<Bicicleta>();

         }

         //adauga bicicleta in magazin
         public void AddBicicleta(Bicicleta bicicleta)
         {
            Inventar.Add(bicicleta);
         }

         //sterge bicicleta din magazin
         public void StergeBicicleta(Bicicleta bicicleta)
         {
            Inventar.Remove(bicicleta);
         }

         //Adauga client in magazin
         public void AddClient(Client client)
         {
            Clienti.Add(client);
         }

         //Sterge client din magazin
         public void StergeClient(Client client)
         {
            Clienti.Remove(client);
         }

         //Procesare comanda in Magazin

         //Procesarea comenziii clientului
         public void ProceseazaComanda(Client clientComanda, Bicicleta bicicletaComanda)
         {
            bicicletaComanda.Stoc = false;
            clientComanda.AddCos(bicicletaComanda);
         }


         //Pretul tuturor bicicletelor in magazin
         //In constructie

         public double GetPretTotal()
         {
            double pretTotal = 0;
            foreach (Bicicleta bicicleta in Inventar)
            {
               pretTotal += bicicleta.Pret;
            }
            return pretTotal;
         }

         internal double GetPretTotalBiciclete()
         {
            double pretTotal = 0;

            foreach (Bicicleta bicicleta in Inventar)
            {
               if (bicicleta.Stoc)
               {
                  pretTotal += bicicleta.Pret;
               }
            }
            
            return pretTotal;
         }

      }
   }

   /// <summary>
   /// Clasa Client initializata
   /// </summary>
   public class Client
   {
      public string Nume { get; set; }
      public string Email { get; set; }
      public string Telefon { get; set; }
      public List<Bicicleta> Cos { get; set; }


      //Initializare constructor pentru clasa client
      public Client(string nume, string email, string telefon)
      {
         Nume = nume;
         Email = email;
         Telefon = telefon;
         Cos = new List<Bicicleta>();
      }

      //Adaugare bicicleta in cos
      public void AddCos(Bicicleta bicicleta)
      {
         Cos.Add(bicicleta);
      }

      //Stergere bicicleta din cos
      public void StergeCos(Bicicleta bicicleta)
      {
         Cos.Remove(bicicleta);
      }

      public void Checkout()
      {
         // verifica cosul
      }
   }
}


public class DataReader
{
   private readonly string _bicycleFilePath;
   private readonly string _clientFilePath;

   public DataReader(string bicycleFilePath, string clientFilePath)
   {
      _bicycleFilePath = bicycleFilePath;
      _clientFilePath = clientFilePath;
   }

   public void PrintBicyclesAndClients()
   {
      var biciclete = ReadBicyclesFromFile(_bicycleFilePath);
      var clienti = ReadClientsFromFile(_clientFilePath);
      Console.WriteLine("Biciclete:");
      foreach (var bicicleta in biciclete)
      {
         Console.WriteLine(bicicleta.ToString());
      }

      Console.WriteLine();

      Console.WriteLine("Clienti:");
      foreach (var client in clienti)
      {
      
       Console.WriteLine($"Nume: {client.Nume}, Email: {client.Email}, Telefon: {client.Telefon}");
         Console.WriteLine("Cos:");
         foreach (var bicicleta in client.Cos)
         {
            Console.WriteLine(bicicleta.ToString());
         }

         Console.WriteLine();
      }
   }

   private List<Bicicleta> ReadBicyclesFromFile(string filePath)
   {
      var biciclete = new List<Bicicleta>();

      try
      {
         using (var reader = new StreamReader(filePath))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               var bicycleData = line.Split(',');

               var id = int.Parse(bicycleData[0]);
               var model = bicycleData[1];
               var brand = bicycleData[2];
               var pret =  int.Parse(bicycleData[3]);
               var disponibilitate =bool.Parse( bicycleData[4]);
               

               var bicicleta = new Bicicleta(model, brand,pret, disponibilitate);
               biciclete.Add(bicicleta);
            }
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"An error occurred while reading bicycles from file: {ex.Message}");
      }

      return biciclete;
   }

   private List<Client> ReadClientsFromFile(string filePath)
   {
      var clienti = new List<Client>();

      try
      {
         using (var reader = new StreamReader(filePath))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               var clientData = line.Split(';');

               var nume = clientData[0];
               var email = clientData[1];
               var telefon = clientData[2];

               var client = new Client(nume, email, telefon);
               clienti.Add(client);

               if (clientData.Length > 3)
               {
                  var cos = new List<Bicicleta>();
                  for (int i = 3; i < clientData.Length; i++)
                  {
                     var bicycleData = clientData[i].Split(',');
                     var bicycleId = int.Parse(bicycleData[0]);
                     var bicycleQuantity = int.Parse(bicycleData[1]);

                     //reminder nu functioneaza citirea clientilor din fisier
                  }
               }
            }
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"An error occurred while reading clients from file: {ex.Message}");
      }

      return clienti;
   }
}

