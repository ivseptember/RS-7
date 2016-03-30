using System.Collections.Generic;

namespace RS_7.Functions
{
    public class MatrixCoeffA
    {
        public static double axx(IList<double> dp, IList<double> sp)
        {
            return 0;
        }

        public static double a11(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m1]
                + sp[(int)SP.m2]
                + sp[(int)SP.m3]
                + sp[(int)SP.m4]
                + sp[(int)SP.m5]
                + sp[(int)SP.m6];
        }

        public static double a22(IList<double> dp, IList<double> sp)
        {
            return a11(dp, sp);
        }

        public static double a33(IList<double> dp, IList<double> sp)
        {
            return a11(dp, sp);
        }

        public static double a44(IList<double> dp, IList<double> sp)
        {
            return InertiaMoments.J1Summ.calculate(dp, sp);
        }

        public static double a55(IList<double> dp, IList<double> sp)
        {
            return InertiaMoments.J2Summ.calculate(dp, sp);
        }

        public static double a66(IList<double> dp, IList<double> sp)
        {
            return InertiaMoments.J3Summ.calculate(dp, sp);
        }

        public static double a77(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m2];
        }

        public static double a88(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m3];
        }

        public static double a99(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m5];
        }

        public static double a00(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m6];
        }

        public static double a15(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m2] * (sp[(int)SP.z12] + sp[(int)SP.z13])
                + sp[(int)SP.z14] * (sp[(int)SP.m4] + sp[(int)SP.m5] * 2)
                + sp[(int)SP.m5]  * (sp[(int)SP.z45] + sp[(int)SP.z46]);
        }

        public static double a17(IList<double> dp, IList<double> sp)
        {
            return a77(dp, sp);
        }

        public static double a18(IList<double> dp, IList<double> sp)
        {
            return a88(dp, sp);
        }

        public static double a19(IList<double> dp, IList<double> sp)
        {
            return a99(dp, sp);
        }

        public static double a10(IList<double> dp, IList<double> sp)
        {
            return a00(dp, sp);
        }

        public static double a24(IList<double> dp, IList<double> sp)
        {
            return -a15(dp, sp);
        }

        public static double a26(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m2] * (dp[(int)DP.x12] + dp[(int)DP.x13])
                + sp[(int)SP.x14] * (sp[(int)SP.m4] + sp[(int)SP.m5] * 2)
                + sp[(int)SP.m5] * (dp[(int)DP.x45] + dp[(int)DP.x46]);
        }

        public static double a27(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m2] * dp[(int)DP.phi];
        }

        public static double a28(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m3] * dp[(int)DP.phi];
        }

        public static double a29(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m5] * dp[(int)DP.phi];
        }

        public static double a20(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m6] * dp[(int)DP.phi];
        }

        public static double a35(IList<double> dp, IList<double> sp)
        {
            return -a26(dp, sp);
        }

        public static double a37(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m2] * dp[(int)DP.psi];
        }

        public static double a38(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m3] * dp[(int)DP.psi];
        }

        public static double a39(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m5] * dp[(int)DP.psi];
        }

        public static double a30(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m6] * dp[(int)DP.psi];
        }

        public static double a42(IList<double> dp, IList<double> sp)
        {
            return -a15(dp, sp);
        }

        public static double a45(IList<double> dp, IList<double> sp)
        {
            return -InertiaMoments.J1XY.calculate(dp, sp);
        }

        public static double a46(IList<double> dp, IList<double> sp)
        {
            return -InertiaMoments.J1XZ.calculate(dp, sp);
        }

        public static double a47(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m2] 
                * (sp[(int)SP.z12] * dp[(int)DP.phi] + sp[(int)SP.y12] * dp[(int)DP.psi]);
        }

        public static double a48(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m3] 
                * (sp[(int)SP.z13] * dp[(int)DP.phi] + sp[(int)SP.y13] * dp[(int)DP.psi]);
        }

        public static double a49(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m5] 
                * ((sp[(int)SP.z14] + sp[(int)SP.z45]) * dp[(int)DP.phi] + sp[(int)SP.y45] * dp[(int)DP.psi]);
        }

        public static double a40(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m6]
                * ((sp[(int)SP.z14] + sp[(int)SP.z46]) * dp[(int)DP.phi] + sp[(int)SP.y46] * dp[(int)DP.psi]);
        }

        public static double a51(IList<double> dp, IList<double> sp)
        {
            return a15(dp, sp);
        }

        public static double a53(IList<double> dp, IList<double> sp)
        {
            return a35(dp, sp);
        }

        public static double a54(IList<double> dp, IList<double> sp)
        {
            return a45(dp, sp);
        }

        public static double a57(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m2]
                * (sp[(int)SP.z12] + dp[(int)DP.x12] * dp[(int)DP.psi]);
        }

        public static double a58(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m3]
                * (sp[(int)SP.z13] + dp[(int)DP.x13] * dp[(int)DP.psi]);
        }

        public static double a59(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m5]
                * ((sp[(int)SP.z14] + sp[(int)SP.z45]) + (dp[(int)DP.x45] + sp[(int)SP.x14]) * dp[(int)DP.psi]);
        }

        public static double a50(IList<double> dp, IList<double> sp)
        {
            return sp[(int)SP.m6]
                * ((sp[(int)SP.z14] + sp[(int)SP.z46]) + (dp[(int)DP.x46] + sp[(int)SP.x14]) * dp[(int)DP.psi]);
        }

        public static double a62(IList<double> dp, IList<double> sp)
        {
            return a26(dp, sp);
        }

        public static double a64(IList<double> dp, IList<double> sp)
        {
            return a46(dp, sp);
        }

        public static double a67(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m2]
                * (sp[(int)SP.y12] - dp[(int)DP.x12] * dp[(int)DP.phi]);
        }

        public static double a68(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m3]
                * (sp[(int)SP.y13] - dp[(int)DP.x13] * dp[(int)DP.phi]);
        }

        public static double a69(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m5]
                * (sp[(int)SP.y45] - (dp[(int)DP.x45] + sp[(int)SP.x14]) * dp[(int)DP.phi]);
        }

        public static double a60(IList<double> dp, IList<double> sp)
        {
            return -sp[(int)SP.m6]
                * (sp[(int)SP.y46] - (dp[(int)DP.x46] + sp[(int)SP.x14]) * dp[(int)DP.phi]);
        }

        public static double a71(IList<double> dp, IList<double> sp)
        {
            return a17(dp, sp);
        }
        public static double a72(IList<double> dp, IList<double> sp)
        {
            return a27(dp, sp);
        }

        public static double a73(IList<double> dp, IList<double> sp)
        {
            return a37(dp, sp);
        }

        public static double a74(IList<double> dp, IList<double> sp)
        {
            return a47(dp, sp);
        }

        public static double a75(IList<double> dp, IList<double> sp)
        {
            return a57(dp, sp);
        }

        public static double a76(IList<double> dp, IList<double> sp)
        {
            return a67(dp, sp);
        }

        public static double a81(IList<double> dp, IList<double> sp)
        {
            return a18(dp, sp);
        }
        public static double a82(IList<double> dp, IList<double> sp)
        {
            return a28(dp, sp);
        }

        public static double a83(IList<double> dp, IList<double> sp)
        {
            return a38(dp, sp);
        }

        public static double a84(IList<double> dp, IList<double> sp)
        {
            return a48(dp, sp);
        }

        public static double a85(IList<double> dp, IList<double> sp)
        {
            return a58(dp, sp);
        }

        public static double a86(IList<double> dp, IList<double> sp)
        {
            return a68(dp, sp);
        }

        public static double a91(IList<double> dp, IList<double> sp)
        {
            return a19(dp, sp);
        }
        public static double a92(IList<double> dp, IList<double> sp)
        {
            return a29(dp, sp);
        }

        public static double a93(IList<double> dp, IList<double> sp)
        {
            return a39(dp, sp);
        }

        public static double a94(IList<double> dp, IList<double> sp)
        {
            return a49(dp, sp);
        }

        public static double a95(IList<double> dp, IList<double> sp)
        {
            return a59(dp, sp);
        }

        public static double a96(IList<double> dp, IList<double> sp)
        {
            return a69(dp, sp);
        }

        public static double a01(IList<double> dp, IList<double> sp)
        {
            return a10(dp, sp);
        }
        public static double a02(IList<double> dp, IList<double> sp)
        {
            return a20(dp, sp);
        }

        public static double a03(IList<double> dp, IList<double> sp)
        {
            return a30(dp, sp);
        }

        public static double a04(IList<double> dp, IList<double> sp)
        {
            return a40(dp, sp);
        }

        public static double a05(IList<double> dp, IList<double> sp)
        {
            return a50(dp, sp);
        }

        public static double a06(IList<double> dp, IList<double> sp)
        {
            return a60(dp, sp);
        }

    }
}
