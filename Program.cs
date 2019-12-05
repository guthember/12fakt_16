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

    static void Main(string[] args)
    {
      Elso();
      Masodik();
      Harmadik();
      Negyedik();
      Otodik();

      Console.ReadLine();
    }
  }
}
