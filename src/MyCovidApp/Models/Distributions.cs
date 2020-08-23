using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCovidApp.Models
{
    public static class Distributions
    {
        private static Dictionary<int, double> s_LogFactorials = new Dictionary<int, double>();

        static Distributions()
        {
            long p = 1;
            s_LogFactorials.Add(0, 0);

            for (int i = 1; i <= 20; ++i)
                s_LogFactorials.Add(i, Math.Log(p *= i));
        }

        private static double LogFactorial(int value)
        {
            if (s_LogFactorials.TryGetValue(value, out double result))
                return result;

            return Math.Log(2 * Math.PI * value) / 2 +
                   value * Math.Log(value) -
                   value +
                   Math.Log(1 + 1 / 12.0 / value);
        }

        public static double dbinom(int k, int n, double p)
        {
            if (p < 0)
                throw new ArgumentOutOfRangeException(nameof(p));
            else if (p > 1)
                throw new ArgumentOutOfRangeException(nameof(p));

            if (k < 0 || n < 0 || k > n)
                return 0.0;
            else if (p == 0 || p == 1.0)
                return 0.0;

            double logResult = LogFactorial(n) - LogFactorial(k) - LogFactorial(n - k) +
                               k * Math.Log(p) + (n - k) * Math.Log(1 - p);

            return Math.Exp(logResult);
        }
    }
}
