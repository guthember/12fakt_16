using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sms
{
  class Program
  {
    static List<String> kodok = new List<String>();
    static List<int> egyformak = new List<int>();
    static String[] szavak = new String[600];
    static int darab;

    static String SzobolSzamok(String szo)
    {
      String temp = "";
      for (int i = 0; i < szo.Length; i++)
      {
        temp += Konverzio(szo[i].ToString());
      }
      return temp;
    }

    static char Konverzio(String betu) 
    {
      String abc = "abcdefghijklmnopqrstuvwxyz";
      String kod = "22233344455566677778889999";

      int hol = abc.IndexOf(betu);
      return kod[hol];
    }

    static void Elso()
    {
      Console.WriteLine("1. feladat");
      Console.Write("Kérek egy betűt: ");
      String ch = Console.ReadLine();

      Console.WriteLine(Konverzio(ch));
    }

    static void Masodik()
    {
      Console.WriteLine("\n2. feladat");
      Console.Write("Kérek egy szót: ");
      String szo = Console.ReadLine();

      Console.WriteLine(SzobolSzamok(szo));
    }

    static void Harmadik()
    {
      Console.WriteLine("\n3. feladat");
      Console.WriteLine("Adatok beolvasása...");
      StreamReader file = new StreamReader("szavak.txt");

      darab = 0;
      while (!file.EndOfStream)
      {
        szavak[darab++] = file.ReadLine();
      }

      file.Close();
    }

    static void Negyedik()
    {
      Console.WriteLine("\n4. feladat");
      Console.WriteLine("Leghosszabb szó: ");

      //int max = szavak[0].Length;
      //String szo = szavak[0];
      int max = 0;

      for (int i = 0; i < darab; i++)
      {
        if (szavak[i].Length > szavak[max].Length)
        {
          max = i;
        }
      }
      Console.WriteLine("{0} -- {1} karakter hosszú",szavak[max],
        szavak[max].Length);
    }

    static void Otodik() 
    {
      Console.WriteLine("\n5. feladat");
      int mennyi = 0;
      for (int i = 0; i < darab; i++)
      {
        if (szavak[i].Length <= 5) 
        {
          mennyi++;
        }
      }
      Console.WriteLine("{0} darab rövid szó van.",mennyi);
    }

    static void Hatodik()
    {
      Console.WriteLine("\n6. feladat");
      Console.WriteLine("\"kodok.txt\" fájl létrehozása");
      StreamWriter ki = new StreamWriter("kodok.txt");

      for (int i = 0; i < darab; i++)
      {
        String kod = SzobolSzamok(szavak[i]);
        ki.WriteLine(kod);
        kodok.Add(kod);
      }

      ki.Close();
    }

    static void Hetedik()
    {
      Console.WriteLine("\n7. feladat");
      Console.Write("Kérek egy számsort: ");
      String kodok = Console.ReadLine();
      Console.WriteLine("Lehetséges szavak:");
      bool van = false;
      
      for (int i = 0; i < darab; i++)
      {
        if (kodok.Length == szavak[i].Length && kodok == SzobolSzamok(szavak[i]))
        {
          Console.WriteLine(szavak[i]);
          van = true;
        }
      }

      if (!van)
      {
        Console.WriteLine("Nincs megfelelő szó");
      }

    }

    static void Nyolcadik()
    {
      Console.WriteLine("\n8. feladat");
      

      for (int i = 0; i < darab - 1; i++)
      {
        if (!egyformak.Contains(i))
        {
          egyformak.Add(i);
          bool tobb = false;
          for (int j = i + 1; j < darab; j++)
          {
            if (kodok[i] == kodok[j])
            {
              tobb = true;
              egyformak.Add(j);
            }
          }

          if (!tobb)
          {
            egyformak.RemoveAt(egyformak.Count - 1);
          }
        }
      }

      for (int i = 0; i < egyformak.Count; i++)
      {
        if (i != 0 & i % 5 == 0)
        {
          Console.WriteLine();
        }
        Console.Write("{0} : {1}; ",szavak[egyformak[i]], kodok[egyformak[i]]);
      }
    }

    static void Kilencedik()
    {
      Console.WriteLine("\n\n9. feladat");
      List<string> egyfKodok = new List<string>();

      for (int i = 0; i < egyformak.Count; i++)
      {
        egyfKodok.Add(kodok[egyformak[i]]);
      }

      int max = 0;
      String melyik = "";
      int j = 0;
      while (j < egyfKodok.Count)
      {
        String mit = egyfKodok[j];
        int db = 0;

        while (j < egyfKodok.Count && egyfKodok[j] == mit)
        {
          j++;
          db++;
        }

        if (max < db)
        {
          max = db;
          melyik = mit;
        }

      }

      Console.WriteLine(melyik);
      for (int i = 0; i < egyformak.Count; i++)
      {
        if (kodok[egyformak[i]] == melyik)
        {
          Console.WriteLine(szavak[egyformak[i]]);
        }
      }

    }

    static void Main(string[] args)
    {
      Elso();
      Masodik();
      Harmadik();
      Negyedik();
      Otodik();
      Hatodik();
      Hetedik();
      Nyolcadik();
      Kilencedik();

      Console.ReadLine();
    }
  }
}
