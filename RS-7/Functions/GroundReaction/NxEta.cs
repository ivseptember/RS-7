using System.Collections.Generic;
using RS_7.Functions.Drives;

namespace RS_7.Functions.GroundReaction
{
    public class N1Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x12];
            p.x_ij_t = dp[(int)DP.x12_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y12];
            p.z_ij = sp[(int)SP.z12];
            p.l = sp[(int)SP.l21];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S1.calculate(dp[(int)DP.t]);
            p.sX_t = S1Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_1;
            p.cp_eta = (int)CP.eta_1;
            p.cp_zeta = (int)CP.zeta_1;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D1Eta], out Deformations.defs[(int)DefParams.D1Eta_S]);
        }
    }

    public class N2Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x12];
            p.x_ij_t = dp[(int)DP.x12_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y12];
            p.z_ij = sp[(int)SP.z12];
            p.l = sp[(int)SP.l22];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S2.calculate(dp[(int)DP.t]);
            p.sX_t = S2Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_2;
            p.cp_eta = (int)CP.eta_2;
            p.cp_zeta = (int)CP.zeta_2;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D2Eta], out Deformations.defs[(int)DefParams.D2Eta_S]);
        }
    }

    public class N3Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x13];
            p.x_ij_t = dp[(int)DP.x13_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y13];
            p.z_ij = sp[(int)SP.z13];
            p.l = sp[(int)SP.l33];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S3.calculate(dp[(int)DP.t]);
            p.sX_t = S3Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_3;
            p.cp_eta = (int)CP.eta_3;
            p.cp_zeta = (int)CP.zeta_3;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D3Eta], out Deformations.defs[(int)DefParams.D3Eta_S]);
        }
    }

    public class N4Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x13];
            p.x_ij_t = dp[(int)DP.x13_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y13];
            p.z_ij = sp[(int)SP.z13];
            p.l = sp[(int)SP.l34];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S4.calculate(dp[(int)DP.t]);
            p.sX_t = S4Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_4;
            p.cp_eta = (int)CP.eta_4;
            p.cp_zeta = (int)CP.zeta_4;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D4Eta], out Deformations.defs[(int)DefParams.D4Eta_S]);
        }
    }

    public class N5Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x45];
            p.x_ij_t = dp[(int)DP.x45_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y45];
            p.z_ij = sp[(int)SP.z45];
            p.l = sp[(int)SP.l55];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S5.calculate(dp[(int)DP.t]);
            p.sX_t = S5Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_5;
            p.cp_eta = (int)CP.eta_5;
            p.cp_zeta = (int)CP.zeta_5;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D5Eta], out Deformations.defs[(int)DefParams.D5Eta_S]);
        }
    }

    public class N6Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x45];
            p.x_ij_t = dp[(int)DP.x45_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y45];
            p.z_ij = sp[(int)SP.z45];
            p.l = sp[(int)SP.l56];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S6.calculate(dp[(int)DP.t]);
            p.sX_t = S6Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_6;
            p.cp_eta = (int)CP.eta_6;
            p.cp_zeta = (int)CP.zeta_6;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D6Eta], out Deformations.defs[(int)DefParams.D6Eta_S]);
        }
    }

    public class N7Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x46];
            p.x_ij_t = dp[(int)DP.x46_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y46];
            p.z_ij = sp[(int)SP.z46];
            p.l = sp[(int)SP.l67];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S7.calculate(dp[(int)DP.t]);
            p.sX_t = S7Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_7;
            p.cp_eta = (int)CP.eta_7;
            p.cp_zeta = (int)CP.zeta_7;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D7Eta], out Deformations.defs[(int)DefParams.D7Eta_S]);
        }
    }

    public class N8Eta
    {
        public static double calculate(IList<double> dp, IList<double> sp)
        {
            NxParameter p = new NxParameter();

            p.xi = dp[(int)DP.xi];
            p.eta = dp[(int)DP.eta];
            p.zeta = dp[(int)DP.zeta];

            p.axis_t = dp[(int)DP.eta_t];

            p.x_ij = dp[(int)DP.x46];
            p.x_ij_t = dp[(int)DP.x46_t];

            p.theta = dp[(int)DP.theta];
            p.phi = dp[(int)DP.phi];
            p.psi = dp[(int)DP.psi];
            p.theta_t = dp[(int)DP.theta_t];
            p.phi_t = dp[(int)DP.phi_t];
            p.psi_t = dp[(int)DP.psi_t];

            p.y_ij = sp[(int)SP.y46];
            p.z_ij = sp[(int)SP.z46];
            p.l = sp[(int)SP.l68];

            p.ground_c = sp[(int)SP.eta_c];
            p.ground_a = sp[(int)SP.eta_a];

            p.s0 = sp[(int)SP.s0];
            p.sX = S8.calculate(dp[(int)DP.t]);
            p.sX_t = S8Diff.calculate(dp[(int)DP.t]);

            p.cp_xi = (int)CP.xi_8;
            p.cp_eta = (int)CP.eta_8;
            p.cp_zeta = (int)CP.zeta_8;

            p.t = dp[(int)DP.t];

            return NxEta.calculate(p, out Deformations.defs[(int)DefParams.D8Eta], out Deformations.defs[(int)DefParams.D8Eta_S]);
        }
    }
}
