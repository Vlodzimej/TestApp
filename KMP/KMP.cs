using System;
using System.Linq;

namespace TestApp
{
    public interface Finder
    {
        int Search(string text, string pattern);
    }
    public class KMP : ITask
    {
        public string Title { get => title; }
        private string title;
        private Finder finder;
        public string Run(string[] data)
        {
            var pattern = data[0];
            var text = data[1];

            var result = finder.Search(text, pattern);

            return result.ToString();
        }
        public KMP(Finder finder)
        {
            this.finder = finder;
            this.title = finder.GetType().ToString();

            //FindAutoKMP auto = new FindAutoKMP();
            //int p = new AutoFinder().Search("ABABABC", "ABABC");
            //int p = findAuto.Search("aaBaaBaaaBaaBaaaBaaB", "aaBaaaBaaB");
        }
    }

    public class AutoFinder : Finder
    {
        private string symbols;
        private bool onlyBuild;
        public AutoFinder(string symbols, bool onlyBuild = false)
        {
            this.symbols = symbols;
            this.onlyBuild = onlyBuild;
        }
        public int Search(string text, string pattern)
        {
            int[,] delta = ComputeDelta(pattern);

            if (onlyBuild)
            {
                return -1;
            }

            int q = 0;
            for (int i = 0; i < text.Length; i++)
            {
                q = delta[q, symbols.IndexOf(text[i])];
                if (q == pattern.Length)
                {
                    return i - pattern.Length + 1;
                }
            }

            return -1;
        }

        private int[,] ComputeDelta(string pattern)
        {

            int[,] delta = new int[pattern.Length, symbols.Length];
            for (int q = 0; q < pattern.Length; q++)
            {
                try
                {
                    foreach (char c in symbols)
                    {
                        string line = pattern.Left(q) + c;
                        int k = q + 1;
                        while (pattern.Left(k) != line.Right(k))
                        {
                            k--;
                        }
                        var test = symbols.IndexOf(c);

                        delta[q, symbols.IndexOf(c)] = k;
                    }
                }
                catch (Exception e)
                {
                    throw new ApplicationException(e.ToString());
                }
            }
            return delta;
        }

    }

    class AutoFinderKMP : Finder
    {
        private string piType;
        private bool onlyBuild;

        public AutoFinderKMP(string piType, bool onlyBuild = false)
        {
            this.piType = piType;
            this.onlyBuild = onlyBuild;
        }
        public int Search(string text, string pattern)
        {
            int[] pi = new int[pattern.Length];
            var searchString = onlyBuild ? pattern : $"{pattern}@{text}";

            switch (piType)
            {
                case "slow":
                    pi = CreatePiSlow(searchString);
                    break;
                case "fast":
                    pi = CreatePiFast(searchString);
                    break;

            }
            return Array.IndexOf(pi, pi.Max());
        }

        private int[] CreatePiSlow(string pattern)
        {
            int[] pi = new int[pattern.Length + 1];
            for (int q = 1; q <= pattern.Length; q++)
            {
                for (int i = 1; i < q; i++)
                {
                    if (pattern.Left(q).Left(i) == pattern.Left(q).Right(i))
                    {
                        pi[q] = i;
                    }
                }
            }
            return pi;
        }

        private int[] CreatePiFast(string pattern)
        {
            int[] pi = new int[pattern.Length];
            pi[0] = 0;
            for (int q = 1; q < pattern.Length; q++)
            {
                int i = pi[q - 1];

                while (i > 0 && pattern[i] != pattern[q])
                {
                    i = pi[i - 1];
                }

                if (pattern[i] == pattern[q])
                {
                    i++;
                }

                pi[q] = i;
            }
            return pi;
        }
    }
}