
using Microsoft.VisualBasic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Homework
{
    class Homework
{
        class Ex1
        {
            string text;
            string path = "text.txt";
            string url = "https://www.gutenberg.org/cache/epub/70424/pg70424.txt";
            FileStream file;
            HttpClient httpClient;
           public Ex1()
            {
                text = "";
            }
            Ex1(string text, string path, string url)
            {
                this.text = text;
                this.path = path;
                this.url = url;
            }
            public async Task FetchText()
            {
                if (File.Exists(path))
                {
                    file = File.OpenRead(path);
                    
                        byte[] b = new byte[1024];
                        UTF7Encoding temp = new UTF7Encoding(true);
                        int readLen;
                        while ((readLen = file.Read(b, 0, b.Length)) > 0)
                        {
                            
                        this.text+=temp.GetString(b, 0, readLen) + "\n";
                        }
                   
                    //File.Delete(path);
                }
                else
                {
                   
                    file = File.Create(this.path);
                    try
                    {
                        httpClient = new HttpClient();
                        using HttpResponseMessage response = await this.httpClient.GetAsync(this.url);
                        
                        response.EnsureSuccessStatusCode();
                        

                        string responseBody = await response.Content.ReadAsStringAsync();
                        AddText(file, responseBody);
                        this.text = responseBody;
                        
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("\nException Caught!");
                        Console.WriteLine("Message :{0} ", e.Message);
                    }
                }
                file.Close();
            }
            private static void AddText(FileStream fs, string value)
            {
                byte[] info = new UTF7Encoding(true).GetBytes(value);
                fs.Write(info, 0, info.Length);
            }
            public string Text
            {
                get { return this.text; }
                set { text = value; }
            }

        }
        public static int[] SearchString(string str, string pat)
        {
            List<int> retVal = new List<int>();
            int m = pat.Length;
            int n = str.Length;

            int[] badChar = new int[512];

            BadCharHeuristic(pat, m, ref badChar);
            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && pat[j] == str[s + j])
                    --j;
                if (j < 0)
                {
                    retVal.Add(s);
                    s += (s + m < n) ? m - badChar[str[s + m]] : 1;
                }
                else
                {
                    s += Math.Max(1, j - badChar[str[s + j]]);
                }
            }

            return retVal.ToArray();
        }

        private static void BadCharHeuristic(string str, int size, ref int[] badChar)
        {
            int i;

            for (i = 0; i < 512; i++)
                badChar[i] = -1;

            for (i = 0; i < size; i++)
                badChar[(int)str[i]] = i;
        }
        static StringBuilder gen50Thus()
        {
            StringBuilder text=new StringBuilder("");
            for (int i = 1; i <= 50000; i++)
                text.Append('a');
            
            return text;
        }
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

            string text1 = "";

            text1 = gen50Thus().Append('b').ToString();

            Console.WriteLine($"Execution Time for Boyer–Moore: {test1(text1, "b")} ms");

            Console.WriteLine($"Execution Time for  text.IndexOf(\"dog\"): {test2(text1, "b")} ms");

            Console.WriteLine("Test 3 between 50");

            string text2 = text1;

            text2 += gen50Thus();

            Console.WriteLine($"Execution Time for Boyer–Moore: {test1(text2, "b")} ms");

            Console.WriteLine($"Execution Time for  text.IndexOf(\"dog\"): {test2(text2, "b")} ms");

            Console.WriteLine("--------------------------------------------------------------------------");

            tests(test.Text, "from internet",5);

            tests(text1, "second",5);

            tests(text2, "last", 5);

            // Comment for Github
            //////
        }

}

}
