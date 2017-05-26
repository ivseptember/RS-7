namespace RS_7.Functions.GroundReaction
{
    // Перечисление координат точек контакта для каждой из опор
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

    // Класс обеспечивает моделирование грунта
    public static class GroundModel
    {
        // Последние рассчитанные точки контакта опор робота
        public static double[] cp;

        // Возвращает текущее значение высоты грунта на основе координат на плоскости
        public static double getZetaAxis(double xi, double eta)
        {
            return 0.00;
        }
    }
}
