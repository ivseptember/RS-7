// Файл содержит вспомогательные классы для расчета соответствующих коэффициентов инерции
// Подробнее об их использовании см. в MatrixCoeffA.cs

using System;
using System.Collections.Generic;

namespace RS_7.Functions.InertiaMoments
{
    public class J1Summ
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J = sp[(int)SP.J1]
                + sp[(int)SP.m2] * Math.Pow(sp[(int)SP.z12], 2)
                + sp[(int)SP.m2] * Math.Pow(sp[(int)SP.z13], 2)
                + sp[(int)SP.m4] * Math.Pow(sp[(int)SP.z14], 2)
                + sp[(int)SP.m5] * Math.Pow(sp[(int)SP.z14] + sp[(int)SP.z45], 2)
                + sp[(int)SP.m6] * Math.Pow(sp[(int)SP.z14] + sp[(int)SP.z46], 2)
                + sp[(int)SP.m2] * Math.Pow(sp[(int)SP.y12], 2)
                + sp[(int)SP.m3] * Math.Pow(sp[(int)SP.y13], 2)
                + sp[(int)SP.m5] * Math.Pow(sp[(int)SP.y45], 2)
                + sp[(int)SP.m6] * Math.Pow(sp[(int)SP.y46], 2);

            return J;
        }
    }

    public class J2Summ
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J = sp[(int)SP.J2]
                + sp[(int)SP.m2] * Math.Pow(sp[(int)SP.z12], 2)
                + sp[(int)SP.m2] * Math.Pow(sp[(int)SP.z13], 2)
                + sp[(int)SP.m4] * Math.Pow(sp[(int)SP.z14], 2)
                + sp[(int)SP.m5] * Math.Pow(sp[(int)SP.z14] + sp[(int)SP.z45], 2)
                + sp[(int)SP.m6] * Math.Pow(sp[(int)SP.z14] + sp[(int)SP.z46], 2)
                + sp[(int)SP.m2] * Math.Pow(dp[(int)DP.x12], 2)
                + sp[(int)SP.m3] * Math.Pow(dp[(int)DP.x13], 2)
                + sp[(int)SP.m4] * Math.Pow(sp[(int)SP.x14], 2)
                + sp[(int)SP.m5] * Math.Pow(sp[(int)SP.x14] + dp[(int)DP.x45], 2)
                + sp[(int)SP.m6] * Math.Pow(sp[(int)SP.x14] + dp[(int)DP.x46], 2);

            return J;
        }
    }

    public class J3Summ
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J = sp[(int)SP.J3]
                + sp[(int)SP.m2] * Math.Pow(dp[(int)DP.x12], 2)
                + sp[(int)SP.m3] * Math.Pow(dp[(int)DP.x13], 2)
                + sp[(int)SP.m4] * Math.Pow(sp[(int)SP.x14], 2)
                + sp[(int)SP.m5] * Math.Pow(sp[(int)SP.x14] + dp[(int)DP.x45], 2)
                + sp[(int)SP.m6] * Math.Pow(sp[(int)SP.x14] + dp[(int)DP.x46], 2)
                + sp[(int)SP.m2] * Math.Pow(sp[(int)SP.y12], 2)
                + sp[(int)SP.m3] * Math.Pow(sp[(int)SP.y13], 2)
                + sp[(int)SP.m5] * Math.Pow(sp[(int)SP.y45], 2) // really?
                + sp[(int)SP.m6] * Math.Pow(sp[(int)SP.y46], 2);

            return J;
        }
    }
}
