using System;
using System.Collections.Generic;
using System.Text;



namespace RS_7
{
    // Static params
    public enum SP : int
    {
        m1, m2, m3, m4, m5, m6,
        x14,
        y12, y13, y14, y45, y46,
        z12, z13, z14, z45, z46,
        l21, l22, l33, l34,
        l55, l56, l67, l68,
        s0,
        J1, J2, J3,
        zeta_a, zeta_c,
        eta_a, eta_c,
        xi_a, xi_c
    }

    // Dynamic params
    public enum DP : int
    {
        t,
        xi, xi_t,
        eta, eta_t,
        zeta, zeta_t,
        theta, theta_t,
        psi, psi_t,
        phi, phi_t,
        x12, x12_t,
        x13, x13_t,
        x45, x45_t,
        x46, x46_t
    }

    public enum DefParams
    {
        D1Zeta,
        D1Zeta_S,
        D2Zeta,
        D2Zeta_S,
        D3Zeta,
        D3Zeta_S,
        D4Zeta,
        D4Zeta_S,
        D5Zeta,
        D5Zeta_S,
        D6Zeta,
        D6Zeta_S,
        D7Zeta,
        D7Zeta_S,
        D8Zeta,
        D8Zeta_S,


        D1Xi,
        D1Xi_S,
        D2Xi,
        D2Xi_S,
        D3Xi,
        D3Xi_S,
        D4Xi,
        D4Xi_S,
        D5Xi,
        D5Xi_S,
        D6Xi,
        D6Xi_S,
        D7Xi,
        D7Xi_S,
        D8Xi,
        D8Xi_S,

        D1Eta,
        D1Eta_S,
        D2Eta,
        D2Eta_S,
        D3Eta,
        D3Eta_S,
        D4Eta,
        D4Eta_S,
        D5Eta,
        D5Eta_S,
        D6Eta,
        D6Eta_S,
        D7Eta,
        D7Eta_S,
        D8Eta,
        D8Eta_S

    }

    // Params history
    public enum HP : int
    {
        t,
        xi, xi_t, xi_tt,
        eta, eta_t, eta_tt,
        zeta, zeta_t, zeta_tt,
        theta, theta_t, theta_tt,
        psi, psi_t, psi_tt,
        phi, phi_t, phi_tt,
        x12, x12_t, x12_tt,
        x13, x13_t, x13_tt,
        x45, x45_t, x45_tt,
        x46, x46_t, x46_tt,

        N1Zeta,
        N1Eta,
        N1Xi,

        N2Zeta,
        N2Eta,
        N2Xi,

        N3Zeta,
        N3Eta,
        N3Xi,

        N4Zeta,
        N4Eta,
        N4Xi,

        N5Zeta,
        N5Eta,
        N5Xi,

        N6Zeta,
        N6Eta,
        N6Xi,

        N7Zeta,
        N7Eta,
        N7Xi,

        N8Zeta,
        N8Eta,
        N8Xi,

        S1, S1Diff,
        S2, S2Diff,
        S3, S3Diff,
        S4, S4Diff,
        S5, S5Diff,
        S6, S6Diff,
        S7, S7Diff,
        S8, S8Diff,

        F2, F3, F5, F6,

        ECount,

        xi_1,
        eta_1,
        zeta_1,

        xi_2,
        eta_2,
        zeta_2,

        xi_3,
        eta_3,
        zeta_3,

        xi_4,
        eta_4,
        zeta_4,

        xi_5,
        eta_5,
        zeta_5,

        xi_6,
        eta_6,
        zeta_6,

        xi_7,
        eta_7,
        zeta_7,

        xi_8,
        eta_8,
        zeta_8,

        D1Zeta,
        D1Zeta_S,
        D2Zeta,
        D2Zeta_S,
        D3Zeta,
        D3Zeta_S,
        D4Zeta,
        D4Zeta_S,
        D5Zeta,
        D5Zeta_S,
        D6Zeta,
        D6Zeta_S,
        D7Zeta,
        D7Zeta_S,
        D8Zeta,
        D8Zeta_S,


        D1Xi,
        D1Xi_S,
        D2Xi,
        D2Xi_S,
        D3Xi,
        D3Xi_S,
        D4Xi,
        D4Xi_S,
        D5Xi,
        D5Xi_S,
        D6Xi,
        D6Xi_S,
        D7Xi,
        D7Xi_S,
        D8Xi,
        D8Xi_S,

        D1Eta,
        D1Eta_S,
        D2Eta,
        D2Eta_S,
        D3Eta,
        D3Eta_S,
        D4Eta,
        D4Eta_S,
        D5Eta,
        D5Eta_S,
        D6Eta,
        D6Eta_S,
        D7Eta,
        D7Eta_S,
        D8Eta,
        D8Eta_S
    }

    class Program
    {
        static void Main(string[] args)
        {
            ModelSolver slv = new ModelSolver();
            slv.Solve();
        }
    }
}
