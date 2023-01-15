using static System.Linq.Enumerable;
using static System.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        var nums = Range(-10000, 20001).Reverse().ToList();
        // Console.WriteLine(string.Join("\n", nums));
        Action task1 = () => WriteLine(nums.Sum());
        Action task2 = () =>
        {
            nums.Sort();
            WriteLine(nums.Sum());
        };
        Action task3 = () => WriteLine(nums.OrderBy(x => x).Sum());

        Parallel.Invoke(task1, task2);
        Parallel.Invoke(task1, task3);
        multiplyArraysMembersBy3();
        sortAndFilter();

    }

    private static void sortAndFilter()
    {
        Func<int, bool> isOdd = x => x % 2 == 1;
        int[] original = { 7, 6, 1, 5 };

        var sorted = original.OrderBy(x => -x).ToArray();
        var filtered = original.Where(isOdd);
        WriteLine("#####SORTED####");

        WriteLine(string.Join("\n", sorted));
        WriteLine("#####FILTERED####");

        WriteLine(string.Join("\n", filtered));
    }

    private static void multiplyArraysMembersBy3()
    {
        Func<int, int> triple = x => x * 3;
        var range = Enumerable.Range(1, 3);
        var triples = range.Select(triple);
        var triplet = range.Select(i => i * 3);
        WriteLine("####TRIPLES#####");
        WriteLine(string.Join("\n", triples));
        WriteLine("####TRIPLET#####");
        WriteLine(string.Join("\n", triplet));
    }
}

