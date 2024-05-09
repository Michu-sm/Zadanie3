using System;
using System.IO;

using KolejkaFIFO;

namespace Zadanie3
{
    class Program
    {
        static char Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tA - Dodaj napis do kolejki");
            Console.WriteLine("\n\t\tB - Usuń napis z kolejki");
            Console.WriteLine("\n\t\tC - Podaj liczbę elementów w kolejce");
            Console.WriteLine("\n\t\tD - Wyczyść kolejkę");
            Console.WriteLine("\n\t\tK - Koniec");
            return Console.ReadKey(true).KeyChar;
        }

        static void Main(string[] args)
        {
            Kolejka mojaKolejka = new Kolejka();
            mojaKolejka.Utworz(10);
            string tmp;
            char c;

            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        Console.Write("Podaj napis który ma być dodany do kolejki: ");
                        tmp = Console.ReadLine();
                        mojaKolejka.DodajDoKolejki(tmp);
                        mojaKolejka.Log($"Dodano napis do kolejki: {tmp}");
                        break;
                    case 'b':
                    case 'B':
                        tmp = mojaKolejka.UsunZKolejki();
                        Console.WriteLine("Napis wyjęty z kolejki: {0}", tmp);
                        mojaKolejka.Log($"Usunięto napis z kolejki: {tmp}");
                        break;
                    case 'c':
                    case 'C':
                        Console.WriteLine("Liczba elementów w kolejce wynosi: {0}",
                            mojaKolejka.PobierzLiczbeElementow());
                        Console.ReadKey();
                        break;
                    case 'd':
                    case 'D':
                        mojaKolejka.Wyczysc();
                        Console.WriteLine("Kolejka wyczyszczona!!!");
                        mojaKolejka.Log("Wyczyszczono kolejkę");
                        break;
                }
            } while (!(c == 'k' || c == 'K'));

            mojaKolejka.CloseLog();
        }
    }
}
