using System.Collections.Generic;
using RS_7.Functions.GroundReaction;
using RS_7.Functions.Drives;

namespace RS_7.Functions.InertiaMoments
{
    // Вспомогательный класс для расчета момента инерции M по каждой из осей (xi, eta, zeta)
    // Методы calculate_M* возвращают значения соответствующего момента инерции для указанного состояния робота
    public class Mx
    {
        public static double g = 9.80665;

        public static double calculate_MXi(IList<double> dp, IList<double> sp)
        {
            double MXi = 0;

            MXi += getPart1(dp, sp, DP.xi);
            MXi += getPart2(dp, sp, DP.xi);
            MXi += getPart3(dp, sp, DP.xi);
            MXi += getPart4(dp, sp, DP.xi);
            MXi += getPart5(dp, sp, DP.xi);
            MXi += getPart6(dp, sp, DP.xi);
            MXi += getPart7(dp, sp, DP.xi);
            MXi += getPart8(dp, sp, DP.xi);

            double yr2 = sp[(int)SP.y12] + dp[(int)DP.phi] * dp[(int)DP.x12] - dp[(int)DP.theta] * sp[(int)SP.z12];
            double yr3 = sp[(int)SP.y13] + dp[(int)DP.phi] * dp[(int)DP.x13] - dp[(int)DP.theta] * sp[(int)SP.z13];
            double yr5 = sp[(int)SP.y45] + dp[(int)DP.phi] * dp[(int)DP.x45] - dp[(int)DP.theta] * (sp[(int)SP.z45] + sp[(int)SP.z14]);
            double yr6 = sp[(int)SP.y46] + dp[(int)DP.phi] * dp[(int)DP.x46] - dp[(int)DP.theta] * (sp[(int)SP.z46] + sp[(int)SP.z14]);

            MXi -= sp[(int)SP.m2] * g * (yr2);
            MXi -= sp[(int)SP.m3] * g * (yr3);
            MXi -= sp[(int)SP.m5] * g * (yr5);
            MXi -= sp[(int)SP.m6] * g * (yr6);

            return MXi;
        }

        public static double calculate_MEta(IList<double> dp, IList<double> sp)
        {
            double MEta = 0;

            MEta += getPart1(dp, sp, DP.eta);
            MEta += getPart2(dp, sp, DP.eta);
            MEta += getPart3(dp, sp, DP.eta);
            MEta += getPart4(dp, sp, DP.eta);
            MEta += getPart5(dp, sp, DP.eta);
            MEta += getPart6(dp, sp, DP.eta);
            MEta += getPart7(dp, sp, DP.eta);
            MEta += getPart8(dp, sp, DP.eta);

            double xr2 = dp[(int)DP.x12] - dp[(int)DP.phi] * sp[(int)SP.y12] + dp[(int)DP.psi] * sp[(int)SP.z12];
            double xr3 = dp[(int)DP.x13] - dp[(int)DP.phi] * sp[(int)SP.y13] + dp[(int)DP.psi] * sp[(int)SP.z13];
            double xr5 = dp[(int)DP.x45] - dp[(int)DP.phi] * sp[(int)SP.y45] + dp[(int)DP.psi] * (sp[(int)SP.z45] + sp[(int)SP.z14]);
            double xr6 = dp[(int)DP.x46] - dp[(int)DP.phi] * sp[(int)SP.y46] + dp[(int)DP.psi] * (sp[(int)SP.z46] + sp[(int)SP.z14]);

            MEta += sp[(int)SP.m2] * g * xr2;
            MEta += sp[(int)SP.m3] * g * xr3;
            MEta += sp[(int)SP.m5] * g * xr5;
            MEta += sp[(int)SP.m6] * g * xr6;

            return MEta;
        }

        public static double calculate_MZeta(IList<double> dp, IList<double> sp)
        {
            double MZeta = 0;

            MZeta += getPart1(dp, sp, DP.zeta);
            MZeta += getPart2(dp, sp, DP.zeta);
            MZeta += getPart3(dp, sp, DP.zeta);
            MZeta += getPart4(dp, sp, DP.zeta);
            MZeta += getPart5(dp, sp, DP.zeta);
            MZeta += getPart6(dp, sp, DP.zeta);
            MZeta += getPart7(dp, sp, DP.zeta);
            MZeta += getPart8(dp, sp, DP.zeta);
                                                  
            return MZeta;
        }

        public static double getPart1(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x12] + sp[(int)SP.l21]
                - dp[(int)DP.phi] * sp[(int)SP.y12]
                + dp[(int)DP.psi] * (sp[(int)SP.z12] - sp[(int)SP.s0] - S1.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x12] + sp[(int)SP.l21])
                + sp[(int)SP.y12]
                - dp[(int)DP.theta] * (sp[(int)SP.z12] - sp[(int)SP.s0] - S1.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x12] + sp[(int)SP.l21])
                + dp[(int)DP.theta] * sp[(int)SP.y12]
                + sp[(int)SP.z12] - sp[(int)SP.s0] - S1.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N1Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta]) 
                         - N1Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N1Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N1Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N1Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N1Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

        public static double getPart2(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x12] + sp[(int)SP.l22]
                - dp[(int)DP.phi] * sp[(int)SP.y12]
                + dp[(int)DP.psi] * (sp[(int)SP.z12] - sp[(int)SP.s0] - S2.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x12] + sp[(int)SP.l22])
                + sp[(int)SP.y12]
                - dp[(int)DP.theta] * (sp[(int)SP.z12] - sp[(int)SP.s0] - S2.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x12] + sp[(int)SP.l22])
                + dp[(int)DP.theta] * sp[(int)SP.y12]
                + sp[(int)SP.z12] - sp[(int)SP.s0] - S2.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N2Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                         - N2Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N2Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N2Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N2Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N2Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

        public static double getPart3(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x13] + sp[(int)SP.l33]
                - dp[(int)DP.phi] * sp[(int)SP.y13]
                + dp[(int)DP.psi] * (sp[(int)SP.z13] - sp[(int)SP.s0] - S3.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x13] + sp[(int)SP.l33])
                + sp[(int)SP.y13]
                - dp[(int)DP.theta] * (sp[(int)SP.z13] - sp[(int)SP.s0] - S3.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x13] + sp[(int)SP.l33])
                + dp[(int)DP.theta] * sp[(int)SP.y13]
                + sp[(int)SP.z13] - sp[(int)SP.s0] - S3.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N3Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                         - N3Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N3Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N3Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N3Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N3Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

        public static double getPart4(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x13] + sp[(int)SP.l34]
                - dp[(int)DP.phi] * sp[(int)SP.y13]
                + dp[(int)DP.psi] * (sp[(int)SP.z13] - sp[(int)SP.s0] - S4.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x13] + sp[(int)SP.l34])
                + sp[(int)SP.y13]
                - dp[(int)DP.theta] * (sp[(int)SP.z13] - sp[(int)SP.s0] - S4.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x13] + sp[(int)SP.l34])
                + dp[(int)DP.theta] * sp[(int)SP.y13]
                + sp[(int)SP.z13] - sp[(int)SP.s0] - S4.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N4Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                         - N4Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N4Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N4Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N4Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N4Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

        public static double getPart5(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x45] + sp[(int)SP.l55]
                - dp[(int)DP.phi] * sp[(int)SP.y45]
                + dp[(int)DP.psi] * (sp[(int)SP.z45] - sp[(int)SP.s0] - S5.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x45] + sp[(int)SP.l55])
                + sp[(int)SP.y45]
                - dp[(int)DP.theta] * (sp[(int)SP.z45] - sp[(int)SP.s0] - S5.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x45] + sp[(int)SP.l55])
                + dp[(int)DP.theta] * sp[(int)SP.y45]
                + sp[(int)SP.z45] - sp[(int)SP.s0] - S5.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N5Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                         - N5Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N5Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N5Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N5Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N5Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

        public static double getPart6(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x45] + sp[(int)SP.l56]
                - dp[(int)DP.phi] * sp[(int)SP.y45]
                + dp[(int)DP.psi] * (sp[(int)SP.z45] - sp[(int)SP.s0] - S6.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x45] + sp[(int)SP.l56])
                + sp[(int)SP.y45]
                - dp[(int)DP.theta] * (sp[(int)SP.z45] - sp[(int)SP.s0] - S6.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x45] + sp[(int)SP.l56])
                + dp[(int)DP.theta] * sp[(int)SP.y45]
                + sp[(int)SP.z45] - sp[(int)SP.s0] - S6.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N6Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                         - N6Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N6Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N6Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N6Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N6Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

        public static double getPart7(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x46] + sp[(int)SP.l67]
                - dp[(int)DP.phi] * sp[(int)SP.y46]
                + dp[(int)DP.psi] * (sp[(int)SP.z46] - sp[(int)SP.s0] - S7.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x46] + sp[(int)SP.l67])
                + sp[(int)SP.y46]
                - dp[(int)DP.theta] * (sp[(int)SP.z46] - sp[(int)SP.s0] - S7.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x46] + sp[(int)SP.l67])
                + dp[(int)DP.theta] * sp[(int)SP.y46]
                + sp[(int)SP.z46] - sp[(int)SP.s0] - S7.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N7Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                         - N7Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N7Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N7Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N7Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N7Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

        public static double getPart8(IList<double> dp, IList<double> sp, DP axis)
        {
            double xi = dp[(int)DP.xi]
                + dp[(int)DP.x46] + sp[(int)SP.l68]
                - dp[(int)DP.phi] * sp[(int)SP.y46]
                + dp[(int)DP.psi] * (sp[(int)SP.z46] - sp[(int)SP.s0] - S8.calculate(dp[(int)DP.t]));

            double eta = dp[(int)DP.eta]
                + dp[(int)DP.phi] * (dp[(int)DP.x46] + sp[(int)SP.l68])
                + sp[(int)SP.y46]
                - dp[(int)DP.theta] * (sp[(int)SP.z46] - sp[(int)SP.s0] - S8.calculate(dp[(int)DP.t]));

            double zeta = dp[(int)DP.zeta]
                - dp[(int)DP.psi] * (dp[(int)DP.x46] + sp[(int)SP.l68])
                + dp[(int)DP.theta] * sp[(int)SP.y46]
                + sp[(int)SP.z46] - sp[(int)SP.s0] - S8.calculate(dp[(int)DP.t]);

            switch (axis)
            {
                case DP.xi:
                    return N8Zeta.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                         - N8Eta.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.eta:
                    return -N8Zeta.calculate(dp, sp) * (xi - dp[(int)DP.xi])
                          + N8Xi.calculate(dp, sp) * (zeta - dp[(int)DP.zeta]);
                case DP.zeta:
                    return -N8Xi.calculate(dp, sp) * (eta - dp[(int)DP.eta])
                          + N8Eta.calculate(dp, sp) * (xi - dp[(int)DP.xi]);
                default:
                    return 0;
            }
        }

    }
    
}
