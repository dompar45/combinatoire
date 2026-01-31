using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace loto
{
    public class Combinaison
    {
        private int _nombreValeurs;
        private readonly int _nombreExtrait;
        //public long NumCombiMax { get; }

        public Combinaison(int nbVals, int nbExtr)
        {
            _nombreValeurs = nbVals;
            _nombreExtrait = nbExtr;
        }

        public long Factodep(long x, long y)
        {
            return x < y ? 1 : x * Factodep(x - 1, y);
        }
        public long Factosup(long x, long y)
        {
            return (Factodep(x, x - y + 1) / Factodep(y, 1));
        }

        public long CalculCombinaison(List<int> lst)
        {
            //Func<long, long, long> factosup = null; // Just so we can refer to it
            //Func<long, long, long> factodep = null; // Just so we can refer to it

            long combinum = 0;

            // Dédoublonnage
            HashSet<int> hashWithoutDuplicates = new HashSet<int>(lst);
            List<int> listWithoutDuplicates = hashWithoutDuplicates.ToList();
            if (listWithoutDuplicates.Count != lst.Count) return 0;

            lst.Sort((x, y) => x.CompareTo(y));

            //factodep = (x, y) => x < y ? 1 : x * factodep(x - 1, y);
            //factosup = (x, y) => (factodep(x, x - y + 1) / factodep(y, 1));

            if (lst.Distinct().Count() < 1 || lst.Distinct().Count() > _nombreExtrait || lst.Max() > _nombreValeurs || lst.Min() < 1) return 0;

            int[] arr = lst.Distinct().ToArray();
            Array.Sort(arr, (x, y) => x.CompareTo(y));

            int cptDistinct = lst.Distinct().Count();

            int cpt = cptDistinct;

            foreach (int num in arr) combinum += Factosup(_nombreValeurs - num, cpt--);

            // Calcul du nombre Max de combinaisons pour défalquer le calcul
            var nCbMax = Factodep(_nombreValeurs, (_nombreValeurs + 1) - cptDistinct) / Factodep(cptDistinct, 1);

            return nCbMax - combinum;
        }

        public long NumCombiMax(long nbNumeros) => Factodep(_nombreValeurs, (_nombreValeurs + 1) - nbNumeros) / Factodep(nbNumeros, 1);

        public IEnumerable<int[]> Duos(List<int> tab)
        {
            var arr = tab.Distinct().ToArray();

            return arr.SelectMany((prem, i) => arr.Skip(i + 1).Select(snd => new[] { prem, snd }));

        }
        public IEnumerable<int[]> Triplets(List<int> tab)
        {
            var arr = tab.Distinct().ToArray();

            return arr.SelectMany(a => arr.Where(b => (b > a)).
                       SelectMany(b => arr.Where(c => (c > b)).
                           Select(c => new[] { a, b, c })));
        }

        public IEnumerable<int[]> Quartets(List<int> tab)
        {
            var arr = tab.Distinct().ToArray();

            return arr.SelectMany(a => arr.Where(b => (b > a)).
                       SelectMany(b => arr.Where(c => (c > b)).
                       SelectMany(c => arr.Where(d => (d > c)).
                           Select(d => new[] { a, b, c, d }))));
        }

        public IEnumerable<int[]> Quintets(List<int> tab)
        {
            var arr = tab.Distinct().ToArray();

            return arr.SelectMany(a => arr.Where(b => (b > a)).
                       SelectMany(b => arr.Where(c => (c > b)).
                       SelectMany(c => arr.Where(d => (d > c)).
                       SelectMany(d => arr.Where(e => (e > d)).
                           Select(e => new[] { a, b, c, d, e })))));
        }
    }
}