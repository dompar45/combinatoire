
using combinate;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DocumentFormat.OpenXml.Drawing;
using lotocomb;


namespace TestDll
{
   
    internal class Program
    {
        static Dictionary<int, int> dizainesCount = new Dictionary<int, int>();
        static Dictionary<int, int> unitesCount = new Dictionary<int, int>();

        static void Main()
        {
            var tab = new List<int>() { 11, 19, 01, 47, 48, 2 };
            var tabDuos = new List<long>();
            var tabTrios = new List<long>();
            var tabQuart = new List<long>();
            var tabQuint = new List<long>();
            
            // Dictionnaires pour compter les dizaines et les unités
           
            
            traiteDizUnit(tab.ToArray());

            //return;
            

            loto.Combinaison calLoto = new(49, 6);
            var retour = calLoto.CalculCombinaison(tab);

            Console.WriteLine("6 Numéros ==> Combinaison = {0}/{1}", calLoto.CalculCombinaison(tab), calLoto.NumCombiMax(tab.Count));

            var duos = calLoto.Duos(tab);
            foreach (var duo in duos)
            {
                tabDuos.Add(calLoto.CalculCombinaison(duo.ToList()));
                Console.WriteLine("DUOS ==> Combinaison = [{0},{1}] , {2}/{3}", duo[0], duo[1], calLoto.CalculCombinaison(duo.ToList()), calLoto.NumCombiMax(duo.ToList().Distinct().Count()));
            }
            Console.WriteLine("Duos Min = {0}, Max = {1}", tabDuos.Min(), tabDuos.Max());

            var triplets = calLoto.Triplets(tab);
            foreach (var trio in triplets)
            {
                tabTrios.Add(calLoto.CalculCombinaison(trio.ToList()));
                Console.WriteLine("TRIOS ==> Combinaison = [{0},{1},{2}] , {3}/{4}", trio[0], trio[1], trio[2], calLoto.CalculCombinaison(trio.ToList()), calLoto.NumCombiMax(trio.ToList().Distinct().Count()));
            }
            Console.WriteLine("Trios Min = {0}, Max = {1}", tabTrios.Min(), tabTrios.Max());

            var quartets = calLoto.Quartets(tab);
            foreach (var quart in quartets)
            {

                tabQuart.Add(calLoto.CalculCombinaison(quart.ToList()));
                Console.WriteLine("Quartet ==> Combinaison = [{0},{1},{2},{3}] , {4}/{5}", quart[0], quart[1], quart[2], quart[3], calLoto.CalculCombinaison(quart.ToList()), calLoto.NumCombiMax(quart.ToList().Distinct().Count()));
            }
            Console.WriteLine("Quart Min = {0}, Max = {1}", tabQuart.Min(), tabQuart.Max());

            var quintets = calLoto.Quintets(tab);
            foreach (var quint in quintets)
            {
                tabQuint.Add(calLoto.CalculCombinaison(quint.ToList()));
                Console.WriteLine("Quintets ==> Combinaison = [{0},{1},{2},{3},{4}] , {5}/{6}", quint[0], quint[1], quint[2], quint[3], quint[4], calLoto.CalculCombinaison(quint.ToList()), calLoto.NumCombiMax(quint.ToList().Distinct().Count()));
            }
            Console.WriteLine("Quint Min = {0}, Max = {1}", tabQuint.Min(), tabQuint.Max());

            //
            // Calcul du nombre de duos/triplets/quartets/quintets possibles 
            // avec un tableau de 

            var result = Enumerable
               .Range(1, (1 << tab.Count) - 1)
               .Select(index => tab.Where((item, idx) => ((1 << idx) & index) != 0).ToList());

            var res2 = result.Where((item) => item.Count == 2);
            var res3 = result.Where((item) => item.Count == 3);
            var res4 = result.Where((item) => item.Count == 4);
            var res5 = result.Where((item) => item.Count == 5);
            var res6 = result.Where((item) => item.Count == 6);

            //var db = new SQLiteConnection("C:\\Users\\Dell 7490\\OneDrive\\Documents\\perso\\Loto\\loto.db3");
            //db.CreateTable<tirLoto>();
            //db.CreateTable<duos>();
            //db.CreateTable<tris>();
            //db.CreateTable<quarts>();
           

            Console.WriteLine("x1(6), x2({0}), x3({1}), x4({2}), x5({3}), x6({4})", res2.Count(), res3.Count(), res4.Count(), res5.Count(), res6.Count());
            Console.WriteLine("==================================");
            LectureExcel LectExc = new LectureExcel(); // = new LectureExcel(@"C:\Users\Dell 7490\Documents\perso\Loto\loto.db3");
            LectExc.LectureCsv(@"C:\Users\Dell 7490\Documents\perso\Loto\loto_201911.csv");

        }
        
        public static void traiteDizUnit( int[] numbers )
        {
           
            
            foreach (var number in numbers)
            {
                var dizaine = number / 10 % 10; // Calcul de la dizaine
                var unite = number % 10; // Calcul de l'unité

                // Compter les dizaines
                if (dizainesCount.ContainsKey(dizaine))
                    dizainesCount[dizaine]++;
                else
                    dizainesCount[dizaine] = 1;

                // Compter les unités
                if (unitesCount.ContainsKey(unite))
                    unitesCount[unite]++;
                else
                    unitesCount[unite] = 1;
            }

            // Afficher les résultats
            Console.WriteLine("Comptage des dizaines :");
            foreach (var kvp in dizainesCount) Console.WriteLine($"Dizaine {kvp.Key} : {kvp.Value} fois");

            Console.WriteLine("Comptage des unités :");
            foreach (var kvp in unitesCount) Console.WriteLine($"Unité {kvp.Key} : {kvp.Value} fois");
        }

    }
}
