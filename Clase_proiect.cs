using Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete
{
   //Clasa Bicicleta reprezinta bicicleta cu urmatoarele caracteristici: brand, model, pret si disponibilitate pe stoc
  //Adaugare enum in clasa bicicleta
   public enum Culoare
   {
      Verde,
      Albastru,
      Alb
   }

   [Flags]
   public enum Optiuni
   {
      None = 0,
      Electrica = 1,
      Pliabila = 2,
      Mini = 4
   }
   public class Bicicleta
   {
      public double Id { get; set; }
      public string Brand { get; set; }
      public string Model { get; set; }
      public double Pret { get; set; }
      public bool Stoc { get; set; }
      public Culoare Culoare { get; set; }
      public Optiuni Optiuni { get; set; }

      //Initializare constructor al clasei Bicicleta
      public Bicicleta(int id, string brand, string model, double pret, bool stoc, Culoare culoare, Optiuni optiuni)
      {
         Id = GenerateRandomId();
         Brand = brand;
         Model = model;
         Pret = pret;
         Stoc = stoc;
         Culoare = culoare;
         Optiuni = optiuni;
      }

      //Generare random id pentru fiecare bicicleta
      public double GenerateRandomId()
      {
         Random rnd = new Random();
         return rnd.Next(10000, 100000);
      }

      //Returnam variabilele clasei
      public override string ToString()
      {
         return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Pret: {Pret}RON, Disponibilitate: {(Stoc ? "DA" : "NU")}, Culoare: {Culoare}, Optiuni: {Optiuni}";
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
         //Returneaza pretul total al bicicletelor recent adaugate

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

         //Functie ce salveaza datele despre bicicleta int-un fisier text extern
         public void SalveazaBiciclete(string filePath)
         {
            try
            {
               using (StreamWriter sw = new StreamWriter("bicicleta.txt", true)) //il deschizi si suprascrii continut prin true
               {
                  foreach (Bicicleta bicicleta in _biciclete)
                  {
                     var id = new Random().Next(1000, 10000);
                     sw.WriteLine($"{bicicleta.Id},{bicicleta.Brand},{bicicleta.Model},{bicicleta.Pret},{bicicleta.Stoc}, {bicicleta.Culoare}, {bicicleta.Optiuni}");
                  }
               }
            }
            catch (Exception ex)
            {
               Console.WriteLine($"A aparut o eroare la salvarea fisierului: {ex.Message}");
            }
         }
         //Cautare biciclete
         public List<Bicicleta> SearchBiciclete(string criteria)
         {
            var bicicleteGasite = Inventar.Where(b =>
                b.Brand.ToLower().Contains(criteria.ToLower()) ||
                b.Model.ToLower().Contains(criteria.ToLower()) ||
                b.Pret.ToString().ToLower().Contains(criteria.ToLower())
            ).ToList();

            return bicicleteGasite;
         }

      }
   }

   /// <summary>
   /// Clasa Client initializata
   /// </summary>
   public class Client
   {
      private List<Client> _clienti = new List<Client>();

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

      //Functie de salvare a datelor preluate de la tastatura despre clienti intr-un fisier text
      public void SalveazaClienti(string filePath)
      {
         try
         {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
               foreach (Client client in _clienti)
               {
                  sw.WriteLine($"{client.Nume},{client.Email},{client.Telefon}");
               }
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine($"A aparut o eroare la salvarea fisierului: {ex.Message}");
         }
      }

      //Cauta clienti

      public void SearchClienti(string criteria)
      {
         var matchingClienti = _clienti.Where(client => client.Nume.Contains(criteria)).ToList();

         if (matchingClienti.Count > 0)
         {
            Console.WriteLine($"Am gasit {matchingClienti.Count} clienti care corespund criteriului de cautare '{criteria}':");
            foreach (var client in matchingClienti)
            {
               Console.WriteLine(client.ToString());
            }
         }
         else
         {
            Console.WriteLine($"Nu am gasit niciun client care corespunde criteriului de cautare '{criteria}'.");
         }
      }

      // Facem suprascrierea metodei ToString pentru afisarea datelor despre clienti int-un format citibil
      public override string ToString()
      {
         return $"Nume: {Nume}, Email: {Email}, Telefon: {Telefon}";
      }
   }

}

/// <summary>
/// Clasa de citire a datelor despre biciclete si clienti din fisier si afisarea acestora in consola si adaugarea de biciclete in cos
/// </summary>
public class DataReader
{
   private readonly string _bicycleFilePath;
   private readonly string _clientFilePath;

   public DataReader(string bicycleFilePath, string clientFilePath)
   {
      _bicycleFilePath = bicycleFilePath;
      _clientFilePath = clientFilePath;
   }

   //Afisare bicicleta si client
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
   //Citire biciclete din fisier
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

               if (bicycleData.Length < 7)
               {
                  Console.WriteLine($"Linia '{line}' din fisierul '{filePath}' nu contine suficiente campuri.");
                  continue; // Skip to next line in case of error
               }

               var id = new Random().Next(1000, 9999);
               var model = bicycleData[0];
               var brand = bicycleData[1];
               if (!double.TryParse(bicycleData[2], out double pret))
               {
                  Console.WriteLine($"Pretul nu este un numar valid pentru bicicleta {model} {brand}.");
                  continue; // Skip to next line in case of error
               }
               if (!bool.TryParse(bicycleData[3], out bool disponibilitate))
               {
                  Console.WriteLine($"Disponibilitatea nu este o valoare booleana valida pentru bicicleta {model} {brand}.");
                  continue; // Skip to next line in case of error
               }
               if (!Enum.TryParse(bicycleData[4], true, out Culoare culoare))
               {
                  Console.WriteLine($"Culoarea nu este o valoare valida pentru bicicleta {model} {brand}.");
                  continue; // Skip to next line in case of error
               }
               if (!Enum.TryParse(bicycleData[5], true, out Optiuni optiuni))
               {
                  Console.WriteLine($"Optiunile nu sunt o valoare valida pentru bicicleta {model} {brand}.");
                  continue; // Skip to next line in case of error
               }
               if (!int.TryParse(bicycleData[6], out int anFabricatie))
               {
                  Console.WriteLine($"Anul de fabricatie nu este un numar valid pentru bicicleta {model} {brand}.");
                  continue; // Skip to next line in case of error
               }

               var bicicleta = new Bicicleta(id, model, brand, pret, disponibilitate, culoare, optiuni);
               biciclete.Add(bicicleta);
            }
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"A aparut o eroare la citirea datelor despre biciclete din fisier!: {ex.Message}");
      }

      return biciclete;
   }

   //Citire clienti din fisier
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
               var clientData = line.Split(',');
               if (clientData.Length < 3)
               {
                  Console.WriteLine($"Date insuficiente, adaugati clienti!: {line}");
                  continue;
               }

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
                     if (bicycleData.Length >= 2)
                     {
                        int v = int.Parse(bicycleData[0]);
                        var bicycleId = v;
                        var bicycleQuantity = int.Parse(bicycleData[1]);
                        var bicicleta = ReadBicyclesFromFile(_bicycleFilePath).FirstOrDefault(b => b.Id == bicycleId);
                        if (bicicleta != null)
                        {
                           for (int j = 0; j < bicycleQuantity; j++)
                           {
                              cos.Add(bicicleta);
                           }
                        }
                     }
                  }
                  client.Cos = cos;
               }
            }
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"A aparut o eroare la citirea clientilor din fisier: {ex.Message}");
      }

      return clienti;
   }

   //Generarea Comenziii

   public void AddToCart(string clientEmail, int bicycleId)
   {
      var clienti = ReadClientsFromFile(_clientFilePath);
      var biciclete = ReadBicyclesFromFile(_bicycleFilePath);
      var client = clienti.FirstOrDefault(c => c.Email == clientEmail);
      var bicicleta = biciclete.FirstOrDefault(b => b.Id == bicycleId);
      if (client != null && bicicleta != null)
      {
         client.Cos.Add(bicicleta);
         UpdateComandaFile(clienti);
      }
   }

   //Adaugare date comanda intr-un fisier txt
   private void UpdateComandaFile(List<Client> clienti)
   {
      try
      {
         using (var writer = new StreamWriter("comanda.txt", true))
         {
            foreach (var client in clienti)
            {
               writer.WriteLine($"{client.Nume},{client.Email},{client.Telefon},{string.Join(",", client.Cos.Select(b => $"{b.Id},{b.Model},{b.Brand},{b.Pret}"))}");
            }
         }
         Console.WriteLine("Comanda a fost adaugata cu succes!");
      }
      catch (Exception ex)
      {
         Console.WriteLine($"A aparut o eroare la salvarea comenzii in fisier: {ex.Message}");
      }
   }

}
