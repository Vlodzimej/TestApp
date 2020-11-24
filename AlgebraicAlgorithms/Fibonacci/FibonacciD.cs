using System;

namespace TestApp
{
    public class FibonacciD : ITask
    {
        public string Title { get => "2d. Через умножение матриц"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt32(data[0]);
            long[] Mpower = new long[] { 0, 1, 1, 1 };
            long[] Mresult = new long[] { 1, 0, 0, 1 };
            while (n > 0)
            {
                if ((n & 1) == 1) Mresult = Mul(Mresult, Mpower);
                Mresult = Mul(Mresult, Mresult);
                n >>= 1;
            };
            return Mresult[1].ToString();
        }

        private long[] Mul(long[] dest, long[] src)
        {
            long r0, r1, r2, r3;
            r0 = dest[0] * src[0] + dest[1] * src[2];
            r1 = dest[0] * src[1] + dest[1] * src[3];
            r2 = dest[2] * src[0] + dest[3] * src[2];
            r3 = dest[2] * src[1] + dest[3] * src[3];
            dest[0] = r0; dest[1] = r1;
            dest[2] = r2; dest[3] = r3;
            return dest;
        }
    }
}