using System.Linq;
using static System.Console;

namespace ConsoleApp1
{
    public struct Data
    {
        public int X;
        public int Y;
        public string[] Names;
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(new ExampleOfFP_OOP_Decomposition().Run());
            Data d;
            d.X = 10;
            d.Y = 20;
            d.Names = new[] { "Gio", "Saba" };

            var d1 = MutateData(d);
            var d2 = MutateData(d1);

            WriteLine(DataView(d));
            WriteLine(DataView(d1));
            WriteLine(DataView(d2));

            ReadLine();
        }

        public static string DataView(Data d)
        {
            return $"{XYView(d)}\n{NamesView(d.Names)}";
        }

        public static string XYView(Data d)
        {
            return $"X: {d.X}; Y: {d.Y};";
        }

        public static string NamesView(string[] names)
        {
            return names.Aggregate("Names: ", (acc, next) => acc + next + "; ");
        }

        public static Data MutateData(Data d)
        {
            var mutatedD = MutateXY(d);
            mutatedD.Names = MutateNames(mutatedD.Names);
            return mutatedD;
        }

        public static Data MutateXY(Data d)
        {
            d.X++;
            d.Y++;
            return d;
        }

        public static string[] MutateNames(string[] names)
        {
            
            return names.Select(n => n.ToUpper()).ToArray();
        }
    }


}