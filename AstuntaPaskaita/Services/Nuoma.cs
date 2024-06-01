using AstuntaPaskaita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstuntaPaskaita.Services
{
    /*Galų gale, parašykite klasę Nuoma, kurioje yra sąrašas su turimais automobiliais.
       Sukurti metodus, kurie leistų pridėti naujus automobilius į sąrašą, pasiimti automobilį iš sąrašo ir apskaičiuoti nuomos kainą už nurodytą dienų skaičių.*/

    public class Nuoma
    {
        public List<Automobilis> isnuomotiAutomobiliai = new List<Automobilis>();

        public void IsnuomotiAuto(Automobilis automobilis, int dienuSkaicius)
        {
            isnuomotiAutomobiliai.Add(automobilis);
            Console.WriteLine($"Automobilis {automobilis.Marke} {automobilis.Modelis} isnuomotas {dienuSkaicius} dienoms.");
        }

        public void GrazintiAuto(Automobilis automobilis)
        {
            isnuomotiAutomobiliai.Remove(automobilis);
            Console.WriteLine($"Automobilis {automobilis.Marke} {automobilis.Modelis} grazintas.");
        }

        public double SkaiciuotiNuomosKaina(Automobilis automobilis, int dienuSkaicius)
        {
            return automobilis.KainaUzDiena * dienuSkaicius;
        }

        public void RodytiIsnuomotusAutomobilius()
        {
            if (isnuomotiAutomobiliai.Count == 0)
            {
                Console.WriteLine("Nera isnuomotu automobiliu.");
                return;
            }

            Console.WriteLine("\nIsnuomoti automobiliai:");
            foreach (var auto in isnuomotiAutomobiliai)
            {
                Console.WriteLine(auto);
            }
        }
    }
}
