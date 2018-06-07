using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasseMensch
{
    public class Mensch
    {
        public int groesse { get; private set; }
        private double gewicht;
        public int position { get; private set; }
        private int energieReserven;

        private static double maxGewicht = 150.0;

        public double Gewicht
        {
            get
            {
                return gewicht;
            }
            private set
            {
                if (value > 0 && value <= Mensch.maxGewicht)
                {
                    gewicht = value;
                }
            }
        }

        public Mensch(int _groesse, double gewicht)
        {
            groesse = _groesse;
            Gewicht = gewicht;

            position = 0;

            energieReserven = 100;
        }

        public void Bewegung(int distanz)
        {
            if (energieReserven >= distanz)
            {
                position += distanz;
                energieReserven -= distanz;
            }
        }

        public void NehmeEineErfrischung()
        {
            energieReserven += 50;
        }

        public void Essen()
        {
            Gewicht += 0.5;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mensch erna = new Mensch(170, 55);

            Console.WriteLine("Erna Gewicht: " + erna.Gewicht);
            erna.Essen();

            Console.WriteLine("Erna Gewicht nach Essen: " + erna.Gewicht);

            erna.NehmeEineErfrischung();

        }
    }
}
