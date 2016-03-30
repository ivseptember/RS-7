using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS_7.Functions.Drives
{
    public class S1Diff
    {
        public static double calculate(double t)
        {
            if (t >= 3 && t < 3.5) return -0.3;
            else if (t >= 3.5 && t <= 4.5) return -0.05;
            else if (t >= 17 && t < 18) return +0.05;
            else if (t >= 18 && t <= 18.5) return +0.3;
            else
                return 0;

            //if (t >= 3 && t < 3.5) return - 0.3;
            //else if (t >= 3.5 && t <= 4) return - 0.1;
            //else if (t >= 17 && t < 17.5) return + 0.1;
            //else if (t >= 17.5 && t <= 18) return + 0.3;
            //else
            //    return 0;

            //if (t >= 3 && t <= 4) return -0.174;
            //else if (t >= 17 && t <= 18) return +0.174;
            //else
            //    return 0;
        }
    }

    public class S2Diff
    {
        public static double calculate(double t)
        {
            return S1Diff.calculate(t);
        }
    }

    public class S3Diff
    {
        public static double calculate(double t)
        {
            return S1Diff.calculate(t);
        }
    }

    public class S4Diff
    {
        public static double calculate(double t)
        {
            return S1Diff.calculate(t);
        }
    }

    public class S5Diff
    {
        public static double calculate(double t)
        {
            if (t >= 19 && t < 19.5) return -0.3;
            else if (t >= 19.5 && t <= 20.5) return -0.05;
            else if (t >= 32 && t < 33) return +0.05;
            else if (t >= 33 && t <= 33.5) return +0.3;
            else
                return 0;

            //if (t >= 19 && t < 19.5) return - 0.3;
            //else if (t >= 19.5 && t <= 20) return - 0.1;
            //else if (t >= 32 && t < 32.5) return + 0.1;
            //else if (t >= 32.5 && t <= 33) return + 0.3;
            //else
            //    return 0;

            //if (t >= 19 && t <= 20) return -0.174;
            //else if (t >= 32 && t <= 33) return +0.174;
            //else
            //    return 0;
        }
    }

    public class S6Diff
    {
        public static double calculate(double t)
        {
            return S5Diff.calculate(t);
        }
    }

    public class S7Diff
    {
        public static double calculate(double t)
        {
            return S5Diff.calculate(t);
        }
    }

    public class S8Diff
    {
        public static double calculate(double t)
        {
            return S5Diff.calculate(t);
        }
    }
}
