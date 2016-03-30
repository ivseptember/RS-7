using System;
using System.Collections.Generic;

using RS_7.Functions.GroundReaction;

namespace RS_7.Functions
{
    public class MatrixCoeffB
    {
        public static double g = 9.80665;
        public static double mu = 0.60;

        public static double b1(IList<double> dp, IList<double> sp)
        {
            return N1Xi.calculate(dp, sp)
                + N2Xi.calculate(dp, sp)
                + N3Xi.calculate(dp, sp)
                + N4Xi.calculate(dp, sp)
                + N5Xi.calculate(dp, sp)
                + N6Xi.calculate(dp, sp)
                + N7Xi.calculate(dp, sp)
                + N8Xi.calculate(dp, sp)
                + MatrixCoeffA.a11(dp, sp) * g * Math.Sin(dp[(int)DP.psi]);
        }

        public static double b2(IList<double> dp, IList<double> sp)
        {
            double b = -2 
                * dp[(int)DP.phi_t] 
                * (sp[(int)SP.m2] * dp[(int)DP.x12_t]
                    + sp[(int)SP.m3] * dp[(int)DP.x13_t]
                    + sp[(int)SP.m5] * dp[(int)DP.x45_t]
                    + sp[(int)SP.m6] * dp[(int)DP.x46_t])
                + N1Eta.calculate(dp, sp)
                + N2Eta.calculate(dp, sp)
                + N3Eta.calculate(dp, sp)
                + N4Eta.calculate(dp, sp)
                + N5Eta.calculate(dp, sp)
                + N6Eta.calculate(dp, sp)
                + N7Eta.calculate(dp, sp)
                + N8Eta.calculate(dp, sp);

            return b;
        }

        public static double b3(IList<double> dp, IList<double> sp)
        {
            double b = 2
                * dp[(int)DP.psi_t]
                * (sp[(int)SP.m2] * dp[(int)DP.x12_t]
                    + sp[(int)SP.m3] * dp[(int)DP.x13_t]
                    + sp[(int)SP.m5] * dp[(int)DP.x45_t]
                    + sp[(int)SP.m6] * dp[(int)DP.x46_t])
                + N1Zeta.calculate(dp, sp)
                + N2Zeta.calculate(dp, sp)
                + N3Zeta.calculate(dp, sp)
                + N4Zeta.calculate(dp, sp)
                + N5Zeta.calculate(dp, sp)
                + N6Zeta.calculate(dp, sp)
                + N7Zeta.calculate(dp, sp)
                + N8Zeta.calculate(dp, sp)
                - MatrixCoeffA.a11(dp, sp) * g * Math.Cos(dp[(int)DP.psi]);

            return b;
        }

        public static double b4(IList<double> dp, IList<double> sp)
        {
            double first = 2 
                * sp[(int)SP.m2] 
                * dp[(int)DP.x12_t]
                * (sp[(int)SP.z12] * dp[(int)DP.phi_t] + sp[(int)SP.y12] * dp[(int)DP.psi_t]);

            double second = 2
                * sp[(int)SP.m3]
                * dp[(int)DP.x13_t]
                * (sp[(int)SP.z13] * dp[(int)DP.phi_t] + sp[(int)SP.y13] * dp[(int)DP.psi_t]);

            double third = 2
                * sp[(int)SP.m5]
                * dp[(int)DP.x45_t]
                * ((sp[(int)SP.z14] + sp[(int)SP.z45]) * dp[(int)DP.phi_t] + sp[(int)SP.y45] * dp[(int)DP.psi_t]);

            double fourth = 2
                * sp[(int)SP.m6]
                * dp[(int)DP.x46_t]
                * ((sp[(int)SP.z14] + sp[(int)SP.z46]) * dp[(int)DP.phi_t] + sp[(int)SP.y46] * dp[(int)DP.psi_t]);

            return first + second + third + fourth + InertiaMoments.Mx.calculate_MXi(dp, sp);
        }

        public static double b5(IList<double> dp, IList<double> sp)
        {
            double b = dp[(int)DP.theta_t] * InertiaMoments.J1XYDiff.calculate(dp, sp)
                - dp[(int)DP.psi_t] * InertiaMoments.J2SummDiff.calculate(dp, sp);

            return b + InertiaMoments.Mx.calculate_MEta(dp, sp);
        }

        public static double b6(IList<double> dp, IList<double> sp)
        {
            double b = -dp[(int)DP.phi_t] * InertiaMoments.J3SummDiff.calculate(dp, sp);

            return b + InertiaMoments.Mx.calculate_MZeta(dp, sp);
        }

        public static double b7(IList<double> dp, IList<double> sp)
        {
            double b = 0;
            b += -2 * sp[(int)SP.m2] * dp[(int)DP.x12_t] * (dp[(int)DP.phi] * dp[(int)DP.phi_t] + dp[(int)DP.psi] * dp[(int)DP.psi_t]);
            b += N1Xi.calculate(dp, sp);
            b += N2Xi.calculate(dp, sp);
            b += F2.calculate(dp[(int)DP.t]);
            b += sp[(int)SP.m2] * g * Math.Sin(dp[(int)DP.psi]);
            b -= sp[(int)SP.m2] * mu * dp[(int)DP.x12_t];

            return b;
        }

        public static double b8(IList<double> dp, IList<double> sp)
        {
            double b = 0;
            b += -2 * sp[(int)SP.m3] * dp[(int)DP.x13_t] * (dp[(int)DP.phi] * dp[(int)DP.phi_t] + dp[(int)DP.psi] * dp[(int)DP.psi_t]);
            b += N3Xi.calculate(dp, sp);
            b += N4Xi.calculate(dp, sp);
            b += F3.calculate(dp[(int)DP.t]);
            b += sp[(int)SP.m3] * g * Math.Sin(dp[(int)DP.psi]);
            b -= sp[(int)SP.m3] * mu * dp[(int)DP.x13_t];
            
            return b;
        }

        public static double b9(IList<double> dp, IList<double> sp)
        {
            double b = 0;
            b += -2 * sp[(int)SP.m5] * dp[(int)DP.x45_t] * (dp[(int)DP.phi] * dp[(int)DP.phi_t] + dp[(int)DP.psi] * dp[(int)DP.psi_t]);
            b += N5Xi.calculate(dp, sp);
            b += N6Xi.calculate(dp, sp);
            b += F5.calculate(dp[(int)DP.t]);
            b += sp[(int)SP.m5] * g * Math.Sin(dp[(int)DP.psi]);
            b -= sp[(int)SP.m5] * mu * dp[(int)DP.x45_t];
            
            return b;
        }

        public static double b0(IList<double> dp, IList<double> sp)
        {
            double b = 0;
            b += -2 * sp[(int)SP.m6] * dp[(int)DP.x46_t] * (dp[(int)DP.phi] * dp[(int)DP.phi_t] + dp[(int)DP.psi] * dp[(int)DP.psi_t]);
            b += N7Xi.calculate(dp, sp);
            b += N8Xi.calculate(dp, sp);
            b += F6.calculate(dp[(int)DP.t]);
            b += sp[(int)SP.m6] * g * Math.Sin(dp[(int)DP.psi]);
            b -= sp[(int)SP.m6] * mu * dp[(int)DP.x46_t];

            return b;
        }
    }
}
