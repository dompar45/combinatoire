using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;


namespace factorielle
{
    internal static class Program
    {
        public static void Main()
        {
            
            string sSource = "Combinatoire";
            string sLog = "Application";
            string sMsg = "Erreur de tests";

            //if (!EventLog.SourceExists(sSource))
             //   EventLog.CreateEventSource(sSource, sLog);

            //EventLog.WriteEntry(sSource, sMsg, EventLogEntryType.Warning); 
            
            Func<long, long> factorial = null; // Just so we can refer to it
            Func<long, long, long> combi = null; // Just so we can refer to it
            Func<long, long, long> factosup= null; // Just so we can refer to it
            Func<long, long, long> factodep = null; // Just so we can refer to it
            Func<long, long, long> combinaison = null; // Just so we can refer to it
            Func<long, long, long> nsumm = null; // Just so we can refer to it
            Func<long, long> numCombiMax = null; 
            Func<long, long, long> reverseFactorial = null; // Just so we can refer to it
            /*
             *
               C(49-17, 5) => (32*31*30*29*28)/(5*4*3*2*1) = 201376
               C(49-27, 4) => (22*21*20*19)/(4*3*2*1) = 7315
               C(49-35, 3) => (14*13*12)/(3*2*1) = 364
               C(49-44, 2) => (5*4)/(2*1) = 10
               C(49-48, 1) => 1 = 1
             */
            //factorial = x => x <= 1 ? 1 : x * factorial(x-1);
            factorial = x => x > 1 ? x * factorial(x-1) : 1 ;
            
            factodep = ( x, y) => x < y ? 1 : x * factodep(x-1,y);
            numCombiMax = (x) => factodep(49,50-x)/factodep(x,1) ;
            
            factosup = (x, y) => ((factodep(x, x - y + 1 ) / factodep( y , 1))) ;
                
            combinaison = (x,y) => combi(x,x-y)/factorial(y);
            nsumm = (x, y) => (y - x + 1) * ((x + y) / 2);

            reverseFactorial = ( x, y) => x <= y ? 1 : x * reverseFactorial(x-1,y); 
            combinaison = (x,y) => reverseFactorial(x,x-y)/factorial(y);
            
            Console.WriteLine("Go");
            
            //long a1 = 49, b1 = 6;
             
            //var tab = new List<int>()  { 20, 31, 47, 09, 19  };

            var tab = new List<int>() { 45 , 46, 47, 48, 49 };

            //Array.Sort(tab.ToArray(), (x, y) => x.CompareTo(y));
            tab.Sort((x, y) => x.CompareTo(y));
         
            Console.WriteLine("Combinaison NumCombXs49 = {0}/{1}", NumCombXs49(tab),numCombiMax(tab.Distinct().Count()));

            var arr = tab.Distinct().ToArray();

            var duos = arr.SelectMany((prem, i) => arr.Skip(i + 1).Select(snd => new [] {prem, snd}));
            var triplets =  arr.SelectMany(a => arr.Where(b => (b > a)).
                                               SelectMany(b => arr.Where(c => (c > b)).
                                               Select(c => new [] {a,b,c})));
            
            var quartets = arr.SelectMany(a => arr.Where(b => (b > a)).
                                           SelectMany(b => arr.Where(c => (c > b)).
                                           SelectMany(c => arr.Where(d => (d > c)).
                                           Select(d => new [] {a,b,c,d}))));
            foreach (var duo in duos)
            {
                Console.WriteLine("DUOS ==> Combinaison NumCombXs49 = [{0},{1}] , {2}/{3}",duo[0],duo[1],NumCombXs49(duo.ToList()),numCombiMax(duo.ToList().Distinct().Count()));
            }

            foreach (var trio in triplets)
            {
                Console.WriteLine("TRIOS ==> Combinaison NumCombXs49 = [{0},{1},{2}] , {3}/{4}",trio[0],trio[1],trio[2],NumCombXs49(trio.ToList()),numCombiMax(trio.ToList().Distinct().Count()));
            }
            
            foreach (var quart in quartets)
            {
                Console.WriteLine("QUARTETS ==> Combinaison NumCombXs49 = [{0},{1},{2},{3}] , {4}/{5}",quart[0],quart[1],quart[2],quart[3],NumCombXs49(quart.ToList()),numCombiMax(quart.ToList().Distinct().Count()));
            }

          

            //return;

            foreach (var number in 5.Even(10)) Console.WriteLine("{0}", number);
            
            foreach (var num in Enumerable.Range(-43, 42).Reverse()) Console.WriteLine("Num = {0}",num*(-1)); 
            
            //return;
            
            var MonTableauTirage = new [] { 43, 34, 6,  13, 9, 5, 23 };            
            Array.Sort(MonTableauTirage, (x, y) => x.CompareTo(y));
            
            Console.WriteLine(String.Join(",",MonTableauTirage));

            Console.WriteLine("49 % 49 = {0}", 49 % 49);
            return;
            
            Console.WriteLine("============================= resultats via calculs combinatoires  =================================");

            Console.WriteLine(combinaison(7,1)+combinaison(7,2)+combinaison(7,3)+combinaison(7,4)+combinaison(7,5)+combinaison(7,6));

            Console.WriteLine(combinaison(49, 6));
            
            //List <String> list = new List<String> { "a", "b", "c" };

            var result = Enumerable
                .Range(1, (1 << MonTableauTirage.Length) - 1)
                .Select(index => MonTableauTirage.Where((item, idx) => ((1 << idx) & index) != 0).ToList());

            Console.WriteLine("============================== resultats via calculs sur tableau de numéros  =================================");
            
            Console.WriteLine("Nombre de combinaisons = {0}",result.Count());
            
            var res2 = result.Where((item) => item.Count() == 2);
            var res3 = result.Where((item) => item.Count() == 3);
            var res4 = result.Where((item) => item.Count() == 4);
            var res5 = result.Where((item) => item.Count() == 5);
            var res6 = result.Where((item) => item.Count() == 6);
            var res7 = result.Where((item) => item.Count() == 7);
            
            
            Console.WriteLine("x1(7), x2({0}), x3({1}),x4({2}),x5({3}),x6({4}),x7({5})",res2.Count(),res3.Count(),res4.Count(),res5.Count(),res6.Count(),res7.Count());
            Console.WriteLine("==================================");

            Console.WriteLine("{0},{1},{2},{3},{4},{5}",
                combinaison(7, 1) + combinaison(7, 2) + combinaison(7, 3) + combinaison(7, 4) + combinaison(7, 5) +
                combinaison(7, 6), combinaison(7, 2), combinaison(7, 3), combinaison(7, 4), combinaison(7, 5),
                combinaison(7, 6));
            // foreach (var ints in res2)
            // {
            //     Console.WriteLine("{0},{1}",ints[0],ints[1]);
            // }
            //
            // foreach (var ints in res3)
            // {
            //     Console.WriteLine("{0},{1},{2}",ints[0],ints[1],ints[2]);
            // }

            /*
            Console.WriteLine(String
                .Join(Environment.NewLine, result
                    .Select(line => String.Join(", ", line))));
          
            
            
            Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;

            //compile Expression using Compile method to invoke it as Delegate
            Func<Student, bool>  isTeenAger = isTeenAgerExpr.Compile();
               
            //Invoke
            bool res = isTeenAger(new Student(){ StudentID = 1, StudentName = "Steve", Age = 15});
            */

        }
        private static IEnumerable<T> TupleToEnumerable<T>(object tuple)
        {
            Type t = tuple.GetType();
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Tuple<,>))
            {
                var x = tuple as Tuple<T, T>;
                yield return x.Item1;
                yield return x.Item2;
            }

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Tuple<,,>))
            {
                var x = tuple as Tuple<T, T, T>;
                yield return x.Item1;
                yield return x.Item2;
                yield return x.Item3;
            }
        }
        
        public static long Facto_depO(long x, long y)
        {
            if (x < y) return x;
            var s = x * Facto_depO(x - 1, y);
            return s;
            
        }

        public static long Facto(long s1, long depth)
        {
            //factodep = ( x, y) => x < x-y ? 1 : x * x-1;  
            // 47,3  
            if (s1 < depth ) return 1;
            else return s1*Facto(s1 - 1, depth);

        }
        
        public static long Factor(int nb) 
        {
            // factorial = x => x > 1 ? x * factorial(x-1) : x ;
            return nb > 1 ? nb * Factor(nb - 1) : nb; 
        }

        public static IEnumerable<int> Even(this int start, int count)
        {
            // validation skipped e.g. count should always be more than 0
            // I'll leave it as an exercise for you

            // if start is odd number then increment it
            // so the first number is always even
            if (start % 2 == 1)
            {
                start++;
            }

            int counter = 0;
            while (counter < count)
            {
                yield return start;
                counter++;
                start += 2;
            }
        }
        
        public static IEnumerable<int> Calc(this int start, int count)
        {
            // validation skipped e.g. count should always be more than 0
            // I'll leave it as an exercise for you

            // if start is odd number then increment it
            // so the first number is always even
            if (start % 2 == 1)
            {
                start++;
            }

            int counter = 0;
            while (counter < count)
            {
                yield return start;
                counter++;
                start += 2;
            }
        }
        
        public static int SumInterval(this int start,int end)
        {
            return start == 0 ? 1 : Enumerable.Range(start, end).Aggregate((i, j) => i+j);
        }
        
        public static int SumInterval49(this int start, int end)
        {
            return start == 0 ? 1 : (Enumerable.Range(-50+start, end).Reverse().Aggregate((i, j) => i+j)*(-1))-1;
        }
        
        public static int Factorial(this int count)
        {
            return count == 0 ? 1 : Enumerable.Range(1, count).Aggregate((i, j) => i*j);
        }
        
        public static long NumCombinaison(List<int> lst, int NMax)
        {
            Array.Sort(lst.ToArray(), (x, y) => x.CompareTo(y));
            var baseCalc = new List<int>();
            var UpperCalc = new List<int>();
             
            for (int r = 1; r <= NMax; r++) UpperCalc.Add(0);
            for (int s = 1; s <= lst.Count(); s++) baseCalc.Add(s);
            Array.Sort(baseCalc.ToArray(), (x, y) => y.CompareTo(x));
            
            Console.WriteLine(String.Join(",",baseCalc));
            
            return 0;
        }
        
        
        public static long NumCombXs49(List<int> lst)
        {
            Func<long, long, long> factosup = null; // Just so we can refer to it
            Func<long, long, long> factodep = null; // Just so we can refer to it
            long combinum = 0;
            
             
            factodep = ( x, y) => x < y ? 1 : x * factodep(x-1,y);
            factosup = (x, y) => (factodep(x, x - y + 1) / factodep(y, 1));

            if (lst.Distinct().Count() < 1 || lst.Distinct().Count() > 5 || lst.Max() > 49 || lst.Min() < 1 ) return 0;
            
            int[] arr = lst.Distinct().ToArray();
            Array.Sort(arr, (x, y) => x.CompareTo(y));
            int cptDistinct = lst.Distinct().Count();
            int cpt = cptDistinct;

            foreach (int num in arr) combinum += factosup(49-num, cpt--);
            
            var numCombiMax = factodep(49,50-cptDistinct)/factodep(cptDistinct,1) ;
            
            return numCombiMax - combinum;

        }
        
    }
}
