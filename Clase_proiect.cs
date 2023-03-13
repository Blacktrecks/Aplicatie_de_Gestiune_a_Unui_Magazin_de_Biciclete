using System;
using System.Collections.Generic;



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
         public void ProcesareComanda(Client client)
         {
            // Procesare client
         }



         //Pretul tuturor bicicletelor in magazin
         //In constructie

         public double GetPretTotal()
         {
            return 0;
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
