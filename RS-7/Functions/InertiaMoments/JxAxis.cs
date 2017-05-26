// Файл содержит вспомогательные классы для расчета соответствующих коэффициентов инерции
// Подробнее об их использовании см. в MatrixCoeffA.cs

using System.Collections.Generic;

namespace RS_7.Functions.InertiaMoments
{
    public class J1XY
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J = 0
                + sp[(int)SP.m2] * sp[(int)SP.y12] * dp[(int)DP.x12]
                + sp[(int)SP.m3] * sp[(int)SP.y13] * dp[(int)DP.x13]
                + sp[(int)SP.m5] * sp[(int)SP.y45] * dp[(int)DP.x45]
                + sp[(int)SP.m6] * sp[(int)SP.y46] * dp[(int)DP.x46];

            return J;
        }
    }

    public class J1XZ
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J = 0
                + sp[(int)SP.m2] * sp[(int)SP.z12] * dp[(int)DP.x12]
                + sp[(int)SP.m3] * sp[(int)SP.z13] * dp[(int)DP.x13]
                + sp[(int)SP.m5] * (sp[(int)SP.z14] + sp[(int)SP.z45]) * dp[(int)DP.x45]
                + sp[(int)SP.m6] * (sp[(int)SP.z14] + sp[(int)SP.z46]) * dp[(int)DP.x46];

            return J;
        }
    }
}
