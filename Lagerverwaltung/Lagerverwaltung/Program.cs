using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung
{
    public class Artikel
    {
        public int nummer { get; private set; }
        private double menge;
        public string bezeichnung { get; private set; }
        private int platz;

        public double Menge
        {
            get
            {
                return menge;
            }
            private set
            {
                menge = value;
            }
        }

        public Artikel(int _nummer, double _menge, string Bezeichnung, int _platz = 0)
        {
            menge = _menge;
            bezeichnung = Bezeichnung;
            nummer = _nummer;
            platz = _platz;
        }

        public void mengeAendern(double mengeNeu)
        {
                menge += mengeNeu;
        }

        public int getPlatz()
        {
            return platz;
        }

        public void platzAendern()
        {
            if (platz > 4)
            {
                platz = 0;
            }
            else
            {
                platz += 1;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lagerverwaltung 0.0001 Alpha");
            Artikel Apfel = new Artikel(001, 2, "Apfel");
            int Auswahl = Convert.ToInt32(Console.ReadLine());
            
        }
    }
}
