using AstuntaPaskaita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstuntaPaskaita.Services
{
    /*Pridėti viso autoparko atspausdinimą. Susikūrus klasę autoparkas prisidėti sąrašą automobilių.*/
    public class AutoParkas
    {
        public List<Automobilis> automobiliai = new List<Automobilis>();

        public void PridetiAutomobili(Automobilis automobilis)
        {
            automobiliai.Add(automobilis);
        }

        public void RodytiVisusAutomobilius()
        {
            if (automobiliai.Count == 0)
            {
                Console.WriteLine("Autoparkas tuscias.");
                return;
            }

            Console.WriteLine("Automobiliai autoparke:");
            for (int i = 0; i < automobiliai.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {automobiliai[i]}");
            }
        }

        public Automobilis GautiAutomobiliPagalNumeri(int numeris)
        {
            if (numeris >= 1 && numeris <= automobiliai.Count)
            {
                return automobiliai[numeris - 1];
            }
            else
            {
                return null;
            }
        }
    }
}
