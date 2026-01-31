using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combinate
{
    public class tirLoto
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public int num_tirage { get; set; }
        public string jour_tirage { get; set; }
        public long num_combi { get; set; }
        public int ordre { get; set; }
        public string date_tirage { get; set; }
        public int num1  { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int num4 { get; set; }
        public int num5 { get; set; }
        public int compl { get; set; }
   
    }


    public class duos
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public int num_tirage { get; set; }
        public string jour_tirage { get; set; }
        public long num_combi_tirage { get; set; }
        public long num_combi { get; set; }
        public int ordre { get; set; }
        public string date_tirage { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int compl { get; set; }

    }

    public class tris
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public int num_tirage { get; set; }
        public string jour_tirage { get; set; }
        public long num_combi_tirage { get; set; }
        public long num_combi { get; set; }
        public int ordre { get; set; }
        public string date_tirage { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int compl { get; set; }

    }
    public class quarts
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public int num_tirage { get; set; }
        public string jour_tirage { get; set; }
        public long num_combi_tirage { get; set; }
        public long num_combi { get; set; }
        public int ordre { get; set; }
        public string date_tirage { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int num4 { get; set; }
        public int compl { get; set; }

    }
}
