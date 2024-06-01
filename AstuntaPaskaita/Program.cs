using AstuntaPaskaita.Models;
using AstuntaPaskaita.Services;
using System;

namespace AstuntaPaskaita
{
    public class Program
    {
        /*Sukurkite automobilių nuomos sistemą.*/

        static void Main(string[] args)
        {
            AutoParkas autoParkas = new AutoParkas();
            Nuoma nuoma = new Nuoma();

            while (true)
            {
                Console.WriteLine("Pasirinkite veiksma:");
                Console.WriteLine("0. Prideti automobili");
                Console.WriteLine("1. Perziureti autoparka");
                Console.WriteLine("2. Isnuomoti automobili");
                Console.WriteLine("3. Grazinti automobili");
                Console.WriteLine("4. Perziureti isnuomotus automobilius");
                Console.WriteLine("5. Iseiti");

                int pasirinkimas = int.Parse(Console.ReadLine());

                switch (pasirinkimas)
                {
                    case 0:
                        PridetiAutomobili(autoParkas);
                        break;
                    case 1:
                        autoParkas.RodytiVisusAutomobilius();
                        break;
                    case 2:
                        autoParkas.RodytiVisusAutomobilius();
                        Console.Write("Iveskite automobilio numeri, kuri norite isnuomoti: ");
                        int autoNumeris = int.Parse(Console.ReadLine());
                        Automobilis pasirinktasAuto = autoParkas.GautiAutomobiliPagalNumeri(autoNumeris);
                        if (pasirinktasAuto != null)
                        {
                            Console.Write("Iveskite nuomos dienu skaiciu: ");
                            int dienuSkaicius = int.Parse(Console.ReadLine());
                            nuoma.IsnuomotiAuto(pasirinktasAuto, dienuSkaicius);
                            double kaina = nuoma.SkaiciuotiNuomosKaina(pasirinktasAuto, dienuSkaicius);
                            Console.WriteLine($"Nuomos kaina: {kaina} EUR");
                        }
                        else if (autoNumeris != 0)
                        {
                            Console.WriteLine("Neteisingas pasirinkimas.");
                        }
                        break;
                    case 3:
                        nuoma.RodytiIsnuomotusAutomobilius();
                        Console.Write("Iveskite automobilio numeri, kuri norite grazinti: ");
                        int grazinamasNumeris = int.Parse(Console.ReadLine());

                        Automobilis grazinamasAuto = null; // Start with null

                        foreach (Automobilis auto in nuoma.isnuomotiAutomobiliai)
                        {
                            if (auto == autoParkas.GautiAutomobiliPagalNumeri(grazinamasNumeris))
                            {
                                grazinamasAuto = auto;
                                break;
                            }
                        }

                        if (grazinamasAuto != null)
                        {
                            nuoma.GrazintiAuto(grazinamasAuto);
                        }
                        else if (grazinamasNumeris != 0)
                        {
                            Console.WriteLine("Neteisingas pasirinkimas.");
                        }
                        break;
                    case 4:
                        nuoma.RodytiIsnuomotusAutomobilius();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas.");
                        break;

                }
            }
        }
        static void PridetiAutomobili(AutoParkas autoParkas)
        {
            Console.Write("Iveskite marke: ");
            string marke = Console.ReadLine();
            Console.Write("Iveskite modeli: ");
            string modelis = Console.ReadLine();
            Console.Write("Iveskite metus: ");
            int metai = int.Parse(Console.ReadLine());
            Console.Write("Iveskite kaina uz diena: ");
            double kaina = double.Parse(Console.ReadLine());
            Console.Write("Kuro tipas (Nafta/Elektra): ");
            string kuroTipas = Console.ReadLine().ToLower();

            Automobilis naujasAutomobilis;

            if (kuroTipas == "nafta")
            {
                Console.Write("Iveskite degalu sanaudas (l/100km): ");
                double sanaudos = double.Parse(Console.ReadLine());
                naujasAutomobilis = new NaftosKuroAutomobilis(marke, modelis, metai, kaina, sanaudos);
            }
            else if (kuroTipas == "elektra")
            {
                Console.Write("Iveskite baterijos talpa (kWh): ");
                double talpa = double.Parse(Console.ReadLine());
                naujasAutomobilis = new ElektrinisAutomobilis(marke, modelis, metai, kaina, talpa);
            }
            else
            {
                Console.WriteLine("Netinkamas kuro tipas.");
                return;
            }

            autoParkas.PridetiAutomobili(naujasAutomobilis);
            Console.WriteLine("Automobilis sekmingai pridetas i autoparka.");
        }

    }
}
