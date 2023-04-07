
using Microsoft.VisualBasic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Homework
{
    class Homework
{
      
        static int test1(string str,string pat)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            SearchString(str, pat);

            watch.Stop();

            return Convert.ToInt16(watch.ElapsedMilliseconds);

        }
        static int test2(string str, string pat)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            int pos=str.IndexOf(pat);

            watch.Stop();

            return Convert.ToInt16(watch.ElapsedMilliseconds);

        }
        static void AverageT(List<int> set)
        {
            Console.WriteLine("5 values of tests: ");
            foreach (var x in set)
            {
                Console.Write(x.ToString() + " ");
            }

            Console.WriteLine("\n Max: " + set.Max());
            Console.WriteLine("Min: " + set.Min());

            set.Remove(set.Max());
            set.Remove(set.Min());

            Console.WriteLine("Average: " + set.Average());

           
        }

        static void tests(string text,string orderOfstring,int numOfTest)
        {
            List<int> test1t = new List<int>();
            List<int> test2t = new List<int>();

            for (int i = 0; i < numOfTest; i++)
            {
                test1t.Add(test1(text, "b"));
                test2t.Add(test2(text, "b"));
            }
            Console.WriteLine("Boyer–Moore " + orderOfstring);
            AverageT(test1t);
            Console.WriteLine("Indexof " + orderOfstring);
            AverageT(test2t);
        }

        static async Task Main()
        {
           // Console.WriteLine(gen50Thus().ToString());
            Console.WriteLine("Homework 3");
            Ex1 test = new Ex1();
            await test.FetchText();
            
            
            Console.WriteLine("Test 1 from internet");

            Console.WriteLine($"Execution Time for Boyer–Moore: {test1(test.Text, "MILNER")} ms");

            Console.WriteLine($"Execution Time for  text.IndexOf(\"dog\"): {test2(test.Text, "MILNER")} ms");
            
            Console.WriteLine("Test 2 after 50");

            ----------------------------------------------------------------------------------------------------------

            Console.WriteLine($"Execution Time for Boyer–Moore: {test1(text1, "b")} ms");

            Console.WriteLine($"Execution Time for  text.IndexOf(\"dog\"): {test2(text1, "b")} ms");

            Console.WriteLine("Test 3 between 50");

            ----------------------------------------------------------------------------------------------------------

            Console.WriteLine($"Execution Time for Boyer–Moore: {test1(text2, "b")} ms");

            Console.WriteLine($"Execution Time for  text.IndexOf(\"dog\"): {test2(text2, "b")} ms");

            Console.WriteLine("--------------------------------------------------------------------------");

            tests(test.Text, "from internet",5);

            tests(text1, "second",5);

            tests(text2, "last", 5);
            
        }

}

}
