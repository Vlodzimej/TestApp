namespace TestApp
{
    static class Ext
    {
        public static string Left(this string line, int x) => line.Substring(0, x);
        public static string Right(this string line, int x) => line.Substring(line.Length - x);
    }
}