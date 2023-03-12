using Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete;
using System;
using System.Collections.Generic;
using static Aplicatie_de_Gestiune_a_Unui_Magazin_de_Biciclete.Bicicleta;


  class Program
{
   static void Main()
   {
      MagazinBicicleta magazin = new MagazinBicicleta();

      // Adaugare biciclete in magazin
      magazin.AdaugaBicicleta(new Bicicleta("Montaje", "X3", 1899.99, true));
      magazin.AdaugaBicicleta(new Bicicleta("Rampage", "Escape 5", 3450.99, false));
      magazin.AdaugaBicicleta(new Bicicleta("Tokida", "Supreme JA", 6784.99, true));
      

      // Afisare biciclete din magazin

      Console.WriteLine("Toate Bicicletele sunt:");
      List<Bicicleta> biciclete = magazin.GetBicicleta();
      foreach (Bicicleta bicicleta in biciclete)
      {
         Console.WriteLine(bicicleta);
      }
      Console.WriteLine();

      //Afisare biciclete disponibile pe stoc.

      Console.WriteLine("Biciclete Disponibile:");
      List<Bicicleta> bicicleteDisponibile = magazin.GetBicicleteDisponibile();
      foreach (Bicicleta bicicleta in bicicleteDisponibile)
      {
         Console.WriteLine(bicicleta);
      }
      Console.WriteLine();

      // Afisare pret total biciclete
     // Console.WriteLine($"Pretul Total: {magazin.GetPretTotal():C}");
   }
}
