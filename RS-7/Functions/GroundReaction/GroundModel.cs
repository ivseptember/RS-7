namespace RS_7.Functions.GroundReaction
{
    public enum CP
    {
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
    }

    public static class GroundModel
    {

        public static double[] cp; //contact point

        public static double getZetaAxis(double xi, double eta)
        {
            return 0.00;
        }
    }
}
