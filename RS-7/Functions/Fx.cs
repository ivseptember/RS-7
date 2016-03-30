using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS_7.Functions.GroundReaction;

namespace RS_7.Functions
{
    public class FConst
    {
        public const double FLow = 5.49779;
        public const double FHigh = 7.06858;

        public const double FBody = - 37.69911 / 4.0;
        public const double t_start = 20;
        public const double delta = 0.2;
    }

    public class F2
    {
        public static double calculate(double t)
        {
            if (t > 6 && t < 8)
                return FConst.FBody * Math.Sin(2 * Math.PI / 2 * (t - 6));
            else if (t - FConst.t_start >= 0 && t - FConst.t_start <= 2)
                return -120 * 2.0 * Math.PI * FConst.delta * Math.Sin(2.0 * Math.PI * (t - FConst.t_start) / 2.0) / (4 * 4);
            else
                return 0;
        }
    }

    public class F3
    {
        public static double calculate(double t)
        {
            return F2.calculate(t);
        }
    }

    public class F5
    {
        public static double calculate(double t)
        {
            if (t > 15 && t < 17)
                return FConst.FBody * Math.Sin(2 * Math.PI / 2 * (t - 6));
            else if (t - FConst.t_start >= 0 && t - FConst.t_start <= 2)
                return -120 * 2.0 * Math.PI * FConst.delta * Math.Sin(2.0 * Math.PI * (t - FConst.t_start) / 2.0) / (4 * 4);
            else
                return 0;
        }
    }

    public class F6
    {
        public static double calculate(double t)
        {
            return F5.calculate(t);
        }
    }
}
