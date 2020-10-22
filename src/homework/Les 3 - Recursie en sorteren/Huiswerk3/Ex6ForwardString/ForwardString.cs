using System.Collections.Generic;

namespace AD
{
    public class Opgave6
    {
        public static string ForwardString(List<int> list, int from)
        {
            if (list.Count == 0) return "";
            if (from + 1 > list.Count) return "";
            return list[from] + " " + ForwardString(list, from + 1);
        }
        
        public static string BackwardString(List<int> list, int to)
        {
            if (list.Count == 0) return "";
            if (to >= list.Count) return "";
            if (to <= 0) to = 0;
            if (to == list.Count - 1) return list[to].ToString();
            
            return BackwardString(list, to + 1) + " " + list[to];
        }

        public static void Run()
        {
            List<int> list = new List<int>(new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11});

            System.Console.WriteLine(ForwardString(list, 3));
            System.Console.WriteLine(ForwardString(list, 7));
            System.Console.WriteLine(BackwardString(list, 3));
            System.Console.WriteLine(BackwardString(list, 7));
        }
    }
}
