using System;
using calclotoDll;

namespace testCalcLoto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Traitements trt = new Traitements("\\\\Freebox_Server\\SSD_INTERNE_FREE\\BD\\loto.sqlite3", "D:\\Users\\dominique\\loto\\loto_201911.csv ");
            //trt.TraiteCsv();
        }
    }
}
