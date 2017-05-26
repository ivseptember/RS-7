namespace RS_7.Functions.Drives
{
    // Классы Sx служат для расчета значения высоты соответствующей ноги
    // Метод calculate возвращает значение высоты в заданный момент времени
    public class S1
    {
        public static double calculate(double t)
        {
            if (t >= 3 && t < 3.5) return 0.45 - 0.3 * (t - 3.0);
            else if (t >= 3.5 && t <= 4.5) return 0.3 - 0.05 * (t - 3.5);
            else if (t > 4.5 && t < 17) return 0.45 - 0.2;
            else if (t >= 17 && t < 18) return 0.45 - 0.2 + 0.05 * (t - 17.0);
            else if (t >= 18 && t <= 18.5) return 0.45 - 0.2 + 0.05 + 0.3 * (t - 18.0);
            else
                return 0.45;

            //if (t >= 3 && t < 3.5) return 0.45 - 0.3 * (t - 3.0);
            //else if (t >= 3.5 && t <= 4) return 0.3 - 0.1 * (t - 3.5);
            //else if (t > 4 && t < 17) return 0.45 - 0.2;
            //else if (t >= 17 && t < 17.5) return 0.45 - 0.2 + 0.1 * (t - 17.0);
            //else if (t >= 17.5 && t <= 18) return 0.45 - 0.2 + 0.05 + 0.3 * (t - 17.5);
            //else
            //    return 0.45;

            //if (t >= 3 && t <= 4) return 0.45 - 0.174 * (t - 3.0);
            //else if (t > 4 && t < 17) return 0.45 - 0.174;
            //else if (t >= 17 && t <= 18) return 0.45 - 0.174 + 0.174 * (t - 17.0);
            //else
            //    return 0.45;
        }
    }
    
    public class S2
    {
        public static double calculate(double t)
        {
            return S1.calculate(t);
        }
    }

    public class S3
    {
        public static double calculate(double t)
        {
            return S1.calculate(t);
        }
    }

    public class S4
    {
        public static double calculate(double t)
        {
            return S1.calculate(t);
        }
    }

    public class S5
    {
        public static double calculate(double t)
        {
            if (t >= 19 && t < 19.5) return 0.45 - 0.3 * (t - 19.0);
            else if (t >= 19.5 && t <= 20.5) return 0.45 - 0.15 - 0.05 * (t - 19.5);
            else if (t > 20 && t < 32) return 0.45 - 0.2;
            else if (t >= 32 && t < 33) return 0.45 - 0.2 + 0.05 * (t - 32.0);
            else if (t >= 33 && t <= 33.5) return 0.45 - 0.2 + 0.05 + 0.3 * (t - 33.0);
            else
                return 0.45;

            //if (t >= 19 && t < 19.5) return 0.45 - 0.3 * (t - 19.0);
            //else if (t >= 19.5 && t <= 20) return 0.45 - 0.15 - 0.1 * (t - 19.5);
            //else if (t > 20 && t < 32) return 0.45 - 0.2;
            //else if (t >= 32 && t < 32.5) return 0.45 - 0.2 + 0.1 * (t - 32.0);
            //else if (t >= 32.5 && t <= 33) return 0.45 - 0.2 + 0.05 + 0.3 * (t - 32.5);
            //else
            //    return 0.45;

            //if (t >= 19 && t <= 20) return 0.45 - 0.174 * (t - 19.0);
            //else if (t > 20 && t < 32) return 0.45 - 0.174;
            //else if (t >= 32 && t <= 33) return 0.45 - 0.174 + 0.174 * (t - 32.0);
            //else
            //    return 0.45;
        }
    }

    public class S6
    {
        public static double calculate(double t)
        {
            return S5.calculate(t);
        }
    }

    public class S7
    {
        public static double calculate(double t)
        {
            return S5.calculate(t);
        }
    }

    public class S8
    {
        public static double calculate(double t)
        {
            return S5.calculate(t);
        }
    }
}
