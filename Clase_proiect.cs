using System;
using System.Collections.Generic;



namespace Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete
{
   //Clasa Bicicleta reprezinta bicicleta cu urmatoarele caracteristici: brand, model, pret si disponibilitate pe stoc

   class Bicicleta
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
         return $"Brand: {Brand}, Model: {Model}, Pret: {Pret:C}, Available: {(Stoc ? "DA" : "NU")}";
      }

      // Clasa MagazinBicicleta reprezinta un magazin online ce vinde biciclete

      public class MagazinBicicleta
      {
         private List<Bicicleta> _biciclete = new List<Bicicleta>(); //declaram o noua lista privata ce va contine bicicletele

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
         //Pretul tuturor bicicletelor in magazin
         //In constructie

         public double GetPretTotal()
         { 
           return 0;
         }
      }
   }
}
