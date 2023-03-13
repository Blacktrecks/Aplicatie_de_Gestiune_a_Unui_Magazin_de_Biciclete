//Aplicatie de Gestiune a unui magazin online de Biciclete
//Realizat de Roman Petrica, Grupa 3122B
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



      //Testare Functionalitate CLient

      Bicicleta bicicleta1 = new Bicicleta("Mountain Bike", "Trek", 768.34, true); //initializeaza un obiect bicicleta1
      Bicicleta bicicleta2 = new Bicicleta("Road Bike", "Specialized", 921.34, true);

      // Cream un client nou si adaugam bicicleta in cos
      Client client1 = new Client("Alice Popescu", "alice.popescu@example.com", "+40756231456");
      client1.AddCos(bicicleta1);
      client1.AddCos(bicicleta2);

      // Afiseaza numele clientului /adresa de email /telefon
      Console.WriteLine($"Client:\n=========== \nNume Client: {client1.Nume}, \nAdresa Email: {client1.Email}, \nTelefon: {client1.Telefon}\n");

      // Afisare biciclete in cosul clientului
      Console.WriteLine("Cos CLient: \n==========");
      foreach (Bicicleta bicicleta in client1.Cos)
      {
         Console.WriteLine($"\n\tBicicleta:\nModel: {bicicleta.Brand} \nBrand: ({bicicleta.Model}), \nPret: {bicicleta.Pret} RON, \nDisponibilitate in stoc:{(bicicleta.Stoc ? "DA" : "NU")}");
      }

      //Creare a unui magazin de biciclete si adaugare de biciclete si a unui client
      //In constructie

      MagazinBicicleta magazin1 = new MagazinBicicleta();
      magazin1.AdaugaBicicleta(bicicleta1);
      magazin1.AdaugaBicicleta(bicicleta2);
      magazin1.AddClient(client1);

      //Afiseaza bicicleta in inventar

      Console.WriteLine("Inventar magazin:");
      foreach (Bicicleta bicicleta in magazin1.Inventar)
      {
         Console.WriteLine($"\n\tBicicleta:\nModel: {bicicleta.Brand} \nBrand: ({bicicleta.Model}), \nPret: {bicicleta.Pret} RON, \nDisponibilitate in stoc:{(bicicleta.Stoc ? "DA" : "NU")}");
      }

      // Afisare clienti in lista magazinului
      Console.WriteLine("Clienti magazin:");
      foreach (Client client in magazin.Clienti)
      {
         Console.WriteLine($"\n\tClient: \nNume Client: {client1.Nume}, \nAdresa Email: {client1.Email}, \nTelefon: {client1.Telefon}\n");
      }
   }
}
