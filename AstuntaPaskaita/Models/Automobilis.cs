using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AstuntaPaskaita.Models
{
    /*Jums reikės sukurti pagrindinę klasę Automobilis, kuri turės šiuos atributus: marke, modelis, metai ir kaina už dieną.
         *
* Sukurkite reikiamus getterius ir setterius, taip pat konstruktorių, leidžiantį sukurti automobilio objektą su nurodytais atributais.

Toliau sukurti dvi subklases, NaftosKuroAutomobilis ir ElektrinisAutomobilis.
        Kiekviena subklasė turi papildomą atributą, pavyzdžiui, degalų suvartojimas 100 km atstumu arba baterijos krovimo laikas.
        Taip pat, kiekviena subklasė turi turėti savo konstruktorių, kuris prideda šiuos papildomus atributus, ir tinkamus getterius ir setterius.*/

    public class Automobilis
    {
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public int Metai { get; set; }
        public double KainaUzDiena { get; set; }

        public Automobilis(string marke, string modelis, int metai, double kainaUzDiena)
        {
            Marke = marke;
            Modelis = modelis;
            Metai = metai;
            KainaUzDiena = kainaUzDiena;
        }

        public override string ToString()
        {
            return $"Marke: {Marke}, Modelis: {Modelis}, Metai: {Metai}, Kaina už dieną: {KainaUzDiena}";
        }

    }

    public class NaftosKuroAutomobilis : Automobilis
    {
        public double DegaluSuvartojimas { get; set; }

        public NaftosKuroAutomobilis(string marke, string modelis, int metai, double kainaUzDiena, double degaluSuvartojimas) : base(marke, modelis, metai, kainaUzDiena)
        {
            DegaluSuvartojimas = degaluSuvartojimas;
        }

        public override string ToString()
        {
            return base.ToString() + $", Degalu sanaudos: {DegaluSuvartojimas} l/100km";
        }

    }

    public class ElektrinisAutomobilis : Automobilis
    {
        public double BaterijosTalpa { get; set; }

        public ElektrinisAutomobilis(string marke, string modelis, int metai, double kainaUzDiena, double baterijosTalpa)
            : base(marke, modelis, metai, kainaUzDiena)
        {
            BaterijosTalpa = baterijosTalpa;
        }

        public override string ToString()
        {
            return base.ToString() + $", Baterijos talpa: {BaterijosTalpa}";
        }
    }
}
