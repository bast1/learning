using System;
using System.Threading;
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
                menge = mengeNeu;
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
            Artikel Apfel = new Artikel(001, 2, "Apfel");
            int ende = 0;

            while (ende != 1)
            {
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("Lagerverwaltung 0.0001 Alpha\n");
                Console.WriteLine("Nummer: {0} \nBezeichnung: {1} \nMenge: {2} \nPlatz {3}\n\n", Apfel.nummer, Apfel.bezeichnung, Apfel.Menge, Apfel.getPlatz());
                Console.WriteLine("Hauptmenü: \n1. Menge ändern \n2. Platz ändern \n9. Beenden");
                int Auswahl = Convert.ToInt32(Console.ReadLine());

                switch (Auswahl)
                {
                    case 1:
                        Console.WriteLine("\n\nNeue Menge: ");
                        double Menge = Convert.ToInt32(Console.ReadLine());
                        Apfel.mengeAendern(Menge);
                        break;
                    case 2:
                        Apfel.platzAendern();
                        Console.WriteLine("\n\nNeuer Platz geändert auf: {0}", Apfel.getPlatz());
                        break;
                    default:
                        Console.WriteLine("Ende gewählt");
                        ende = 1;
                        break;
                }
            }
        }
    }
}
