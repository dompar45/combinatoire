﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;
using System.IO;
using loto;

namespace combinate
{
    public class LectureExcel
    {

        public void LectureCsv()
        {
            // Variables
            string[] Tligne = new string[100]; // tableau qui va contenir les sous-chaines extraites d'une ligne.
            char[] splitter = { ';' }; // délimiteur du fichier texte


            Dictionary<string, tirLoto> Tirages = new Dictionary<string, tirLoto>();

            string filename = @"C:\Users\Dell 7490\Documents\perso\Loto\loto_201911.csv";
            int ligne = -1;
            int datCol = 3, num1 = 5, num2 = 6, num3 = 7, num4 = 8, num5 = 9, /*num6 = 10,*/ numComp = 10;
            string keyDico;
            // Code
            if (File.Exists(filename))
            {
                var reader = new StreamReader(File.OpenRead(filename));
                // Lire les entetes
                //var entetes = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    ligne++;

                    if (ligne == 0) continue;
                    tirLoto tir = new tirLoto();

                    var values = line.Split(splitter);


                    tir.num1 = int.Parse(values[num1]);
                    tir.num2 = int.Parse(values[num2]);
                    tir.num3 = int.Parse(values[num3]);
                    tir.num4 = int.Parse(values[num4]);
                    tir.num5 = int.Parse(values[num5]);
                    //tir.nums[5] = int.Parse(values[num6]);
                    tir.complementaire = int.Parse(values[numComp]);
                    tir.jour_tirage = values[2];
                    tir.num_tirage = int.Parse(values[1]);

                    keyDico = values[datCol] + "-" + values[1] + "-" + values[2];
                    Tirages.Add(keyDico, tir);


                    if (ligne == 100 || reader.EndOfStream)
                    {
                        //break;
                        if (reader.EndOfStream) { break; }
                        ligne = 0;
                        Tirages.Clear();

                    }
                }
                reader.Close();
            } // Fin If (file.exists)
        }


        public void saveTirage(Dictionary<string, tirLoto> Tirages)
        {

            foreach (KeyValuePair<string, tirLoto> kvp in Tirages)
            {
                Combinaison comb = new (49, 5);
                
                var tab = new List<int>() { kvp.Value.num1, kvp.Value.num2, kvp.Value.num3, kvp.Value.num4, kvp.Value.num5 };     
                var duos = comb.Duos(tab);
                var tri = comb.Triplets(tab);
                var quart = comb.Quartets(tab);
                var numcomb = comb.CalculCombinaison(tab);

                var tabDuos = new List<long>();
                var tabTrios = new List<long>();
                var tabQuart = new List<long>();


            }
          

        }
    }
}
