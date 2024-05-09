using System;
using System.Collections.Generic;
using System.IO;

namespace KolejkaFIFO
{
    public class Kolejka
    {
        private string[] Elementy;
        private int Pierwszy;
        private int Ostatni;

        private StreamWriter writer;

        public void Utworz(int liczbaElementow)
        {
            Pierwszy = Ostatni = -1;
            Elementy = new string[liczbaElementow];

            writer = new StreamWriter("log.txt", true);
        }

        public void Log(string message)
        {
            writer.WriteLine(message);
        }

        public void CloseLog()
        {
            writer.Close();
        }

        public bool CzyPelna()
        {
            return ((Pierwszy == 0 && Ostatni == Elementy.Length - 1) || Pierwszy == Ostatni + 1);               
        }

        public void DodajDoKolejki(string element)
        {
            if (CzyPelna())
                throw new InvalidOperationException("Kolejka jest pe³na");
            if (Ostatni == Elementy.Length - 1 || Ostatni == -1)
            {
                Elementy[0] = element;
                Ostatni = 0;
                if (Pierwszy == -1)
                    Pierwszy = 0;
            }
            else
                Elementy[++Ostatni] = element;
        }

        public bool CzyPusta()
        {
            return Pierwszy == -1;
        }

        public string UsunZKolejki()
        {
            if (CzyPusta())
                throw new InvalidOperationException("Kolejka jest pusta");
            string tmp;
            tmp = Elementy[Pierwszy];
            if (Pierwszy == Ostatni)
                Ostatni = Pierwszy = -1;
            else
                if (Pierwszy == Elementy.Length - 1)
                    Pierwszy = 0;
                else
                    Pierwszy++;
            return tmp;
        }

        public void Wyczysc()
        {
            Utworz(Elementy.Length);
        }

        public string SprawdzElement()
        {
            if (CzyPusta())
                throw new InvalidOperationException("Kolejka jest pusta");
            return Elementy[Pierwszy];
        }

        public int PobierzLiczbeElementow()
        {
            if(Pierwszy == -1)
                return 0;
            if (Pierwszy <= Ostatni)
                return Ostatni - Pierwszy + 1;
            return Elementy.Length - Pierwszy + Ostatni + 1;
        }
    }
}
