using System.Collections.Generic;

namespace RS_7.Functions.InertiaMoments
{
    public class J1SummDiff
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            return 0;
        }
    }

    public class J2SummDiff
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J_t = 0
                + 2 * sp[(int)SP.m2] * dp[(int)DP.x12] * dp[(int)DP.x12_t]
                + 2 * sp[(int)SP.m3] * dp[(int)DP.x13] * dp[(int)DP.x13_t]
                + 2 * sp[(int)SP.m5] * (sp[(int)SP.x14] + dp[(int)DP.x45]) * dp[(int)DP.x45_t]
                + 2 * sp[(int)SP.m6] * (sp[(int)SP.x14] + dp[(int)DP.x46]) * dp[(int)DP.x46_t];

            return J_t;
        }
    }

    public class J3SummDiff
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J_t = 0
                + 2 * sp[(int)SP.m2] * dp[(int)DP.x12] * dp[(int)DP.x12_t]
                + 2 * sp[(int)SP.m3] * dp[(int)DP.x13] * dp[(int)DP.x13_t]
                + 2 * sp[(int)SP.m5] * (sp[(int)SP.x14] + dp[(int)DP.x45]) * dp[(int)DP.x45_t]
                + 2 * sp[(int)SP.m6] * (sp[(int)SP.x14] + dp[(int)DP.x46]) * dp[(int)DP.x46_t];

            return J_t;
        }
    }

    public class J1XYDiff
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J_t = 0
                + sp[(int)SP.m2] * sp[(int)SP.y12] * dp[(int)DP.x12_t]
                + sp[(int)SP.m3] * sp[(int)SP.y13] * dp[(int)DP.x13_t]
                + sp[(int)SP.m5] * sp[(int)SP.y45] * dp[(int)DP.x45_t]
                + sp[(int)SP.m6] * sp[(int)SP.y46] * dp[(int)DP.x46_t];

            return J_t;
        }
    }

    public class J1XZDiff
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            double J_t = 0
                + sp[(int)SP.m2] * sp[(int)SP.z12] * dp[(int)DP.x12_t]
                + sp[(int)SP.m3] * sp[(int)SP.z13] * dp[(int)DP.x13_t]
                + sp[(int)SP.m5] * (sp[(int)SP.z14] + sp[(int)SP.z45]) * dp[(int)DP.x45_t]
                + sp[(int)SP.m6] * (sp[(int)SP.z14] + sp[(int)SP.z46]) * dp[(int)DP.x46_t];

            return J_t;
        }
    }
}
