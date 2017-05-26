using Mathematics;
using RS_7.Functions;
using RS_7.Functions.GroundReaction;
using System;
using System.Collections.Generic;

namespace RS_7
{
    public class ModelSolver
    {
        // Поля для хранения истории текущего расчета
        public double[,] params_history;
        public int iteration_count;
        public int last_equations_count;

        // Поля для хранения динамических параметров (4 для использования в методе РК 4-го порядка)
        public double[] dp_1;
        public double[] dp_2;
        public double[] dp_3;
        public double[] dp_4;
        
        // Флаги перехода между базовыми состояниями робота
        bool I = false;
        bool IV = false;
        bool V = false;
        bool VIII = false;

        // Поля для хранения управления горизонтальным перемещением
        double x1N_base = -1;   // базовое положение нижней рамы
        double x4N_base = -1;   // базовое положение верхней рамы
        double xi_base = -1;    // базовое положение робота
        double xNN_delta = 0.2; // прирост расстояния за этап расчета

        // Период работы приводов при горизонтальном перемещении
        double t_force_period = 4;

        // Набор коэффициентов для использования в методе РК 4-го порядка
        public double[] coeff_1;
        public double[] coeff_2;
        public double[] coeff_3;
        public double[] coeff_4;

        // Статические параметры модели робота
        public double[] sp_1;

        // Матрицы математической модели
        public double[,] aMatrix;
        public double[] bVector;
        public double[] xVector;

        // Максимальное время моделирования
        public double time_limit = 35.2;

        // Шаг моделирования
        public double delta_limit = 0.001;

        // Максимальный размах рам робота (возможно, стоит внести в стат. параметры)
        public double MAX_REL_DISTANCE_2_3 = 0.375;
        public double MAX_REL_DISTANCE_5_6 = 0.425;

        // Метод выполняет инициализацию процесса расчета
        public ModelSolver()
        {
            // Создание необходимых массивов
            int dp_len = Enum.GetNames(typeof(DP)).Length;
            int sp_len = Enum.GetNames(typeof(SP)).Length;
            int cp_len = Enum.GetNames(typeof(CP)).Length;

            dp_1 = new double[dp_len];
            dp_2 = new double[dp_len];
            dp_3 = new double[dp_len];
            dp_4 = new double[dp_len];

            coeff_1 = new double[dp_len];
            coeff_2 = new double[dp_len];
            coeff_3 = new double[dp_len];
            coeff_4 = new double[dp_len];

            sp_1 = new double[sp_len];

            // Инициализация модели грунта
            GroundModel.cp = new double[cp_len];
            for (int i = 0; i < GroundModel.cp.Length; ++i)
                GroundModel.cp[i] = double.NaN;

            #region Old static parameters
            //// weight
            //sp_1[(int)SP.m1] = 70;
            //sp_1[(int)SP.m4] = 50;
            //sp_1[(int)SP.m2] = 17.5;
            //sp_1[(int)SP.m3] = 17.5;
            //sp_1[(int)SP.m5] = 22.5;
            //sp_1[(int)SP.m6] = 22.5;

            //// shifts
            //sp_1[(int)SP.x14] = 0;
            //sp_1[(int)SP.y12] = 0.3;
            //sp_1[(int)SP.y13] = -0.3;
            //sp_1[(int)SP.y14] = 0;
            //sp_1[(int)SP.y45] = 0.4;
            //sp_1[(int)SP.y46] = -0.4;
            //sp_1[(int)SP.z12] = 0;
            //sp_1[(int)SP.z13] = 0;
            //sp_1[(int)SP.z14] = 0.15;
            //sp_1[(int)SP.z45] = 0;
            //sp_1[(int)SP.z46] = 0;

            //// dimensions
            //sp_1[(int)SP.l21] = +0.6;
            //sp_1[(int)SP.l22] = -0.6;
            //sp_1[(int)SP.l33] = -0.6;
            //sp_1[(int)SP.l34] = +0.6;
            //sp_1[(int)SP.l55] = +0.6;
            //sp_1[(int)SP.l56] = -0.6;
            //sp_1[(int)SP.l67] = -0.6;
            //sp_1[(int)SP.l68] = +0.6;

            //// actuator
            //sp_1[(int)SP.s0] = 0.19;

            //// inertia
            //sp_1[(int)SP.J1] = 1.6965;// *1.5;
            //sp_1[(int)SP.J2] = 8.5175;// *1.5;
            //sp_1[(int)SP.J3] = 8.6385;// *1.5;

            //// ground coefficients
            //sp_1[(int)SP.zeta_c] = -10000;
            //sp_1[(int)SP.eta_c] = -7000;
            //sp_1[(int)SP.xi_c] = -7000;

            //sp_1[(int)SP.zeta_a] = 450;
            //sp_1[(int)SP.eta_a] = 250;
            //sp_1[(int)SP.xi_a] = 250;
            #endregion

            //=====================================

            // Установка начального момента времени
            dp_1[(int)DP.t] = 0;

            // Задание начального положения робота
            #region Normal
            dp_1[(int)DP.xi] = 0;
            dp_1[(int)DP.xi_t] = 0;
            dp_1[(int)DP.eta] = 0;
            dp_1[(int)DP.eta_t] = 0;
            dp_1[(int)DP.zeta] = 0.65;
            dp_1[(int)DP.zeta_t] = 0;
            dp_1[(int)DP.theta] = 0;
            dp_1[(int)DP.theta_t] = 0;
            dp_1[(int)DP.psi] = 0;
            dp_1[(int)DP.psi_t] = 0;
            dp_1[(int)DP.phi] = 0;
            dp_1[(int)DP.phi_t] = 0;
            dp_1[(int)DP.x12] = -0.2;
            dp_1[(int)DP.x12_t] = 0;
            dp_1[(int)DP.x13] = -0.2;
            dp_1[(int)DP.x13_t] = 0;
            dp_1[(int)DP.x45] = 0.2;
            dp_1[(int)DP.x45_t] = 0;
            dp_1[(int)DP.x46] = 0.2;
            dp_1[(int)DP.x46_t] = 0;
            #endregion

            #region Experimental
            //dp_1[(int)DP.xi] = -0.005;
            //dp_1[(int)DP.xi_t] = 0.002;
            //dp_1[(int)DP.eta] = 0;
            //dp_1[(int)DP.eta_t] = 0;
            //dp_1[(int)DP.zeta] = 0.614;
            //dp_1[(int)DP.zeta_t] = 0;
            //dp_1[(int)DP.theta] = 0;
            //dp_1[(int)DP.theta_t] = 0;
            //dp_1[(int)DP.psi] = -0.008;
            //dp_1[(int)DP.psi_t] = 0.002;
            //dp_1[(int)DP.phi] = 0;
            //dp_1[(int)DP.phi_t] = 0;
            //dp_1[(int)DP.x12] = 0.375;
            //dp_1[(int)DP.x12_t] = 0.073;
            //dp_1[(int)DP.x13] = 0.375;
            //dp_1[(int)DP.x13_t] = 0.073;
            //dp_1[(int)DP.x45] = 0;
            //dp_1[(int)DP.x45_t] = 0;
            //dp_1[(int)DP.x46] = 0;
            //dp_1[(int)DP.x46_t] = 0;

            //GroundModel.cp[0] = 0.97625173464845849;
            //GroundModel.cp[1] = 0.3;
            //GroundModel.cp[2] = 0;
            //GroundModel.cp[3] = -0.22164264078647447;
            //GroundModel.cp[4] = 0.3;
            //GroundModel.cp[5] = 0;
            //GroundModel.cp[6] = -0.22164264078647447;
            //GroundModel.cp[7] = -0.3;
            //GroundModel.cp[8] = 0;
            //GroundModel.cp[9] = 0.97625173464845849;
            //GroundModel.cp[10] = -0.3;
            //GroundModel.cp[11] = 0;
            //GroundModel.cp[12] = 0.6;
            //GroundModel.cp[13] = 0.4;
            //GroundModel.cp[14] = 0;
            //GroundModel.cp[15] = -0.6;
            //GroundModel.cp[16] = 0.4;
            //GroundModel.cp[17] = 0;
            //GroundModel.cp[18] = -0.6;
            //GroundModel.cp[19] = -0.4;
            //GroundModel.cp[20] = 0;
            //GroundModel.cp[21] = 0.6;
            //GroundModel.cp[22] = -0.4;
            //GroundModel.cp[23] = 0;
            #endregion

            //=====================================

            // Инициализация массивов для записи истории расчета
            params_history = new double[(int)(time_limit / delta_limit + 1), Enum.GetNames(typeof(HP)).Length];
            Deformations.defs = new double[Enum.GetValues(typeof(DefParams)).Length];
        }

        // Метод выполняет моделирование движения робота
        public void Solve()
        {
            // Выставляем номер итерации
            iteration_count = 0;

            // Запускаем расчет
            for (double timer = 0; timer < time_limit; timer += delta_limit)
            {
                #region DebugPrint_Reactions
                ////Отладочная печать силы реакции опоры N1
                //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\september\Desktop\Result.csv", true))
                //{
                //    file.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",//;{10};{11};{12};{13}", 
                //        dp_1[(int)DP.t], 
                //        Functions.GroundReaction.N1Zeta.calculate(dp_1, sp_1),
                //        Functions.GroundReaction.N5Zeta.calculate(dp_1, sp_1),
                //        Functions.GroundReaction.N1Eta.calculate(dp_1, sp_1),
                //        Functions.GroundReaction.N5Eta.calculate(dp_1, sp_1),
                //        Functions.GroundReaction.N1Xi.calculate(dp_1, sp_1),
                //        Functions.GroundReaction.N5Xi.calculate(dp_1, sp_1),
                //        dp_1[(int)DP.psi],
                //        dp_1[(int)DP.phi],
                //        dp_1[(int)DP.theta]
                //        );
                //}
                #endregion

                // Инициализируем массивы коэффициентов
                int dp_len = Enum.GetNames(typeof(DP)).Length;

                coeff_1 = new double[dp_len];
                coeff_2 = new double[dp_len];
                coeff_3 = new double[dp_len];
                coeff_4 = new double[dp_len];

                // Считаем первый коэффициент
                CalcContactPoint(dp_1, sp_1);

                if (dp_1[(int)DP.t] >= 6.82)
                {
                    double t = delta_limit;
                }

                CalcAnyCoeff(dp_1, sp_1, coeff_1, 1);

                // Сохраняем значение параметров
                SaveCurrentIteration();

                // Собираем набор переменных для второго коэффициента
                dp_2 = (double[])dp_1.Clone();
                dp_2[(int)DP.t] += delta_limit / 2;
                for (int i = 1; i <= (int)DP.x46_t; i++)
                {
                    dp_2[i] += coeff_1[i] * delta_limit / 2;

                    CorrectHorizontalMove(dp_2, coeff_1);
                }
                // Считаем второй
                CalcContactPoint(dp_2, sp_1);
                CalcAnyCoeff(dp_2, sp_1, coeff_2, 2);

                // Собираем набор переменных для третьего коэффициента
                dp_3 = (double[])dp_1.Clone();
                dp_3[(int)DP.t] += delta_limit / 2;
                for (int i = 1; i <= (int)DP.x46_t; i++)
                {
                    dp_3[i] += coeff_2[i] * delta_limit / 2;

                    CorrectHorizontalMove(dp_3, coeff_2);
                }
                // Считаем третий
                CalcContactPoint(dp_3, sp_1);
                CalcAnyCoeff(dp_3, sp_1, coeff_3, 3);

                // Собираем набор переменных для третьего коэффициента
                dp_4 = (double[])dp_1.Clone();
                dp_4[(int)DP.t] += delta_limit;
                for (int i = 1; i <= (int)DP.x46_t; i++)
                {
                    dp_4[i] += coeff_3[i] * delta_limit;

                    CorrectHorizontalMove(dp_4, coeff_3);
                }
                // Считаем четвертый
                CalcContactPoint(dp_4, sp_1);
                CalcAnyCoeff(dp_4, sp_1, coeff_4, 4);

                // Возвращаемся (получаем расчетное значение параметра)
                dp_1[(int)DP.t] += delta_limit;
                for (int i = 1; i <= (int)DP.x46_t; i++)
                {
                    dp_1[i] += (coeff_1[i] + 2 * coeff_2[i] + 2 * coeff_3[i] + coeff_4[i]) * delta_limit / 6;

                    CorrectHorizontalMove(dp_1, null);
                }

                // Делаем магию (?)
                if (dp_1[(int)DP.t] > 8)
                {
                    ++iteration_count;
                    --iteration_count;
                }

                // Увеличиваем номер итерации
                iteration_count++;
            }
        }

        // Метод выполняет расчет коэффициента для метода РК 4-го порядка
        private void CalcAnyCoeff(IList<double> dp, IList<double> sp, IList<double> coeff, int number)
        {
            // Собираем набор переменных для первого коэффициента
            int equations_count = CreateMatrix(dp, sp);
            last_equations_count = equations_count;

            #region DebugPrint_Matrix

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\september\Desktop\Matrix.txt", true))
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        for (int j = 0; j < 10; j++)
            //            file.Write("{0}\t", aMatrix[i, j]);
            //        file.WriteLine();
            //    }
            //    file.WriteLine();
            //    file.WriteLine();
            //}

            #endregion

            // Решаем систему уравнений
            LinearEquationSolverStatus stat = LinearEquationSolver.Solve(equations_count, aMatrix, bVector, xVector);

            // Разбираем результаты расчета
            if (stat == LinearEquationSolverStatus.Success)
            {
                coeff[(int)DP.xi_t] = xVector[0];
                coeff[(int)DP.eta_t] = xVector[1];
                coeff[(int)DP.zeta_t] = xVector[2];
                coeff[(int)DP.theta_t] = xVector[3];
                coeff[(int)DP.psi_t] = xVector[4];
                coeff[(int)DP.phi_t] = xVector[5];

                #region Dynamic Equations
                //if (dynamic_equations.ContainsKey((int)DP.x12_t))
                //{
                //    coeff[(int)DP.x12_t] = xVector[dynamic_equations[(int)DP.x12_t]];
                //    coeff[(int)DP.x12] = dp[(int)DP.x12_t];
                //}

                //if (dynamic_equations.ContainsKey((int)DP.x13_t))
                //{
                //    coeff[(int)DP.x13_t] = xVector[dynamic_equations[(int)DP.x13_t]];
                //    coeff[(int)DP.x13] = dp[(int)DP.x13_t];
                //}

                //if (dynamic_equations.ContainsKey((int)DP.x45_t))
                //{
                //    coeff[(int)DP.x45_t] = xVector[dynamic_equations[(int)DP.x45_t]];
                //    coeff[(int)DP.x45] = dp[(int)DP.x45_t];
                //}

                //if (dynamic_equations.ContainsKey((int)DP.x46_t))
                //{
                //    coeff[(int)DP.x46_t] = xVector[dynamic_equations[(int)DP.x46_t]];
                //    coeff[(int)DP.x46] = dp[(int)DP.x46_t];
                //}
                #endregion

                coeff[(int)DP.xi] = dp[(int)DP.xi_t];
                coeff[(int)DP.eta] = dp[(int)DP.eta_t];
                coeff[(int)DP.zeta] = dp[(int)DP.zeta_t];
                coeff[(int)DP.theta] = dp[(int)DP.theta_t];
                coeff[(int)DP.psi] = dp[(int)DP.psi_t];
                coeff[(int)DP.phi] = dp[(int)DP.phi_t];
            }
            else
            {
                throw new NotFiniteNumberException(String.Format("time = {0}", dp[0]));
            }
        }

        // Метод формирует расчетные матрицы для решения уравнений
        private int CreateMatrix(IList<double> dp, IList<double> sp)
        {
            // Задаем кол-во уравнений
            int equations_count = 6;

            // Получаем относительное положение рам робота для текущего момента времени
            GenerateRelativeDistances(dp, sp);

            // Формируем матрицы
            FillStaticPart(dp, sp);

            #region Dynamic Equations
            //dynamic_equations = new Dictionary<int, int>();

            //if (dp[(int)DP.x12_t] != 0 || F2.calculate(dp[(int)DP.t]) != 0)
            //{
            //    bVector[equations_count] = MatrixCoeffB.b7(dp, sp);

            //    aMatrix[equations_count, 0] = MatrixCoeffA.a71(dp, sp);
            //    aMatrix[equations_count, 1] = MatrixCoeffA.a72(dp, sp);
            //    aMatrix[equations_count, 2] = MatrixCoeffA.a73(dp, sp);
            //    aMatrix[equations_count, 3] = MatrixCoeffA.a74(dp, sp);
            //    aMatrix[equations_count, 4] = MatrixCoeffA.a75(dp, sp);
            //    aMatrix[equations_count, 5] = MatrixCoeffA.a76(dp, sp);
            //    aMatrix[equations_count, 6] = MatrixCoeffA.a77(dp, sp);

            //    dynamic_equations[(int)DP.x12_t] = equations_count;
            //    equations_count++;
            //}

            //if (dp[(int)DP.x13_t] != 0 || F3.calculate(dp[(int)DP.t]) != 0)
            //{
            //    bVector[equations_count] = MatrixCoeffB.b8(dp, sp);

            //    aMatrix[equations_count, 0] = MatrixCoeffA.a81(dp, sp);
            //    aMatrix[equations_count, 1] = MatrixCoeffA.a82(dp, sp);
            //    aMatrix[equations_count, 2] = MatrixCoeffA.a83(dp, sp);
            //    aMatrix[equations_count, 3] = MatrixCoeffA.a84(dp, sp);
            //    aMatrix[equations_count, 4] = MatrixCoeffA.a85(dp, sp);
            //    aMatrix[equations_count, 5] = MatrixCoeffA.a86(dp, sp);
            //    aMatrix[equations_count, 7] = MatrixCoeffA.a88(dp, sp);

            //    dynamic_equations[(int)DP.x13_t] = equations_count;

            //    equations_count++;
            //}

            //if (dp[(int)DP.x45_t] != 0 || F5.calculate(dp[(int)DP.t]) != 0)
            //{
            //    bVector[equations_count] = MatrixCoeffB.b9(dp, sp);

            //    aMatrix[equations_count, 0] = MatrixCoeffA.a91(dp, sp);
            //    aMatrix[equations_count, 1] = MatrixCoeffA.a92(dp, sp);
            //    aMatrix[equations_count, 2] = MatrixCoeffA.a93(dp, sp);
            //    aMatrix[equations_count, 3] = MatrixCoeffA.a94(dp, sp);
            //    aMatrix[equations_count, 4] = MatrixCoeffA.a95(dp, sp);
            //    aMatrix[equations_count, 5] = MatrixCoeffA.a96(dp, sp);
            //    aMatrix[equations_count, 8] = MatrixCoeffA.a99(dp, sp);

            //    dynamic_equations[(int)DP.x45_t] = equations_count;

            //    equations_count++;
            //}

            //if (dp[(int)DP.x46_t] != 0 || F6.calculate(dp[(int)DP.t]) != 0)
            //{
            //    bVector[equations_count] = MatrixCoeffB.b0(dp, sp);

            //    aMatrix[equations_count, 0] = MatrixCoeffA.a01(dp, sp);
            //    aMatrix[equations_count, 1] = MatrixCoeffA.a02(dp, sp);
            //    aMatrix[equations_count, 2] = MatrixCoeffA.a03(dp, sp);
            //    aMatrix[equations_count, 3] = MatrixCoeffA.a04(dp, sp);
            //    aMatrix[equations_count, 4] = MatrixCoeffA.a05(dp, sp);
            //    aMatrix[equations_count, 5] = MatrixCoeffA.a06(dp, sp);
            //    aMatrix[equations_count, 9] = MatrixCoeffA.a00(dp, sp);

            //    dynamic_equations[(int)DP.x46_t] = equations_count;

            //    equations_count++;
            //}
            #endregion

            return equations_count;
        }

        // Метод рассчитывает относительные координаты рам робота для текущего момента времени
        private void GenerateRelativeDistances(IList<double> dp, IList<double> sp)
        {
            // Режимы движения: x12 и x13 сдвигаются с 6 до 10 секунд
            //                  корпус сдвигается с 12 до 16 секунд
            //                  x45 и x46 сдвигаются с 21 до 25 секунд
            //                  корпус сдвигается с 27 до 31 секунд

            double t = dp[(int)DP.t] - 6.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                // При переходе на этот этап движения выставляем текущие параметры
                if (!I)
                {
                    xNN_delta = 0.40;
                    xi_base = dp[(int)DP.xi];
                    x1N_base = dp[(int)DP.x12];
                    x4N_base = dp[(int)DP.x45];
                    I = true;
                }

                // Рассчитываем положение рам и скорости для текущего момента времени
                dp[(int)DP.x12] = x1N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x13] = x1N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x12_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
                dp[(int)DP.x13_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
            }

            t = dp[(int)DP.t] - 12.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                if (!IV)
                {
                    xNN_delta = -0.40;
                    xi_base = dp[(int)DP.xi];
                    x1N_base = dp[(int)DP.x12];
                    x4N_base = dp[(int)DP.x45];
                    IV = true;
                }

                dp[(int)DP.x45] = x4N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x46] = x4N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x45_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
                dp[(int)DP.x46_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
            }

            t = dp[(int)DP.t] - 21.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                if (!V)
                {
                    xNN_delta = 0.40;
                    xi_base = dp[(int)DP.xi];
                    x1N_base = dp[(int)DP.x12];
                    x4N_base = dp[(int)DP.x45];
                    V = true;
                }

                dp[(int)DP.x45] = x4N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x46] = x4N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x45_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
                dp[(int)DP.x46_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
            }

            t = dp[(int)DP.t] - 27.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                if (!VIII)
                {
                    xNN_delta = -0.40;
                    xi_base = dp[(int)DP.xi];
                    x1N_base = dp[(int)DP.x12];
                    x4N_base = dp[(int)DP.x45];
                    VIII = true;
                }

                dp[(int)DP.x12] = x1N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x13] = x1N_base + xNN_delta * (t / t_force_period - Math.Sin((Math.PI * 2 * t) / t_force_period) / (Math.PI * 2));
                dp[(int)DP.x12_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
                dp[(int)DP.x13_t] = xNN_delta * (1 / t_force_period - Math.Cos((Math.PI * 2 * t) / t_force_period) / (t_force_period));
            }
        }

        // Метод формирует расчетные матрицы
        private void FillStaticPart(IList<double> dp, IList<double> sp)
        {
            aMatrix = new double[10, 10];
            bVector = new double[10];
            xVector = new double[10];

            // Вектор B
            bVector[0] = MatrixCoeffB.b1(dp, sp);
            bVector[1] = MatrixCoeffB.b2(dp, sp);
            bVector[2] = MatrixCoeffB.b3(dp, sp);
            bVector[3] = MatrixCoeffB.b4(dp, sp);
            bVector[4] = MatrixCoeffB.b5(dp, sp);
            bVector[5] = MatrixCoeffB.b6(dp, sp);

            // Матрица А
            aMatrix[0, 0] = MatrixCoeffA.a11(dp, sp);
            aMatrix[0, 4] = MatrixCoeffA.a15(dp, sp);
            aMatrix[0, 6] = MatrixCoeffA.a17(dp, sp);
            aMatrix[0, 7] = MatrixCoeffA.a18(dp, sp);
            aMatrix[0, 8] = MatrixCoeffA.a19(dp, sp);
            aMatrix[0, 9] = MatrixCoeffA.a10(dp, sp);

            aMatrix[1, 1] = MatrixCoeffA.a22(dp, sp);
            aMatrix[1, 3] = MatrixCoeffA.a24(dp, sp);
            aMatrix[1, 5] = MatrixCoeffA.a26(dp, sp);
            aMatrix[1, 6] = MatrixCoeffA.a27(dp, sp);
            aMatrix[1, 8] = MatrixCoeffA.a29(dp, sp);
            aMatrix[1, 9] = MatrixCoeffA.a20(dp, sp);

            aMatrix[2, 2] = MatrixCoeffA.a33(dp, sp);
            aMatrix[2, 4] = MatrixCoeffA.a35(dp, sp);
            aMatrix[2, 6] = MatrixCoeffA.a37(dp, sp);
            aMatrix[2, 7] = MatrixCoeffA.a38(dp, sp);
            aMatrix[2, 8] = MatrixCoeffA.a39(dp, sp);
            aMatrix[2, 9] = MatrixCoeffA.a30(dp, sp);

            aMatrix[3, 1] = MatrixCoeffA.a42(dp, sp);
            aMatrix[3, 3] = MatrixCoeffA.a44(dp, sp);
            aMatrix[3, 4] = MatrixCoeffA.a45(dp, sp);
            aMatrix[3, 5] = MatrixCoeffA.a46(dp, sp);
            aMatrix[3, 6] = MatrixCoeffA.a47(dp, sp);
            aMatrix[3, 7] = MatrixCoeffA.a48(dp, sp);
            aMatrix[3, 8] = MatrixCoeffA.a49(dp, sp);
            aMatrix[3, 9] = MatrixCoeffA.a40(dp, sp);

            aMatrix[4, 0] = MatrixCoeffA.a51(dp, sp);
            aMatrix[4, 2] = MatrixCoeffA.a53(dp, sp);
            aMatrix[4, 3] = MatrixCoeffA.a54(dp, sp);
            aMatrix[4, 4] = MatrixCoeffA.a55(dp, sp);
            aMatrix[4, 6] = MatrixCoeffA.a57(dp, sp);
            aMatrix[4, 7] = MatrixCoeffA.a58(dp, sp);
            aMatrix[4, 8] = MatrixCoeffA.a59(dp, sp);
            aMatrix[4, 9] = MatrixCoeffA.a50(dp, sp);

            aMatrix[5, 1] = MatrixCoeffA.a62(dp, sp);
            aMatrix[5, 3] = MatrixCoeffA.a64(dp, sp);
            aMatrix[5, 5] = MatrixCoeffA.a66(dp, sp);
            aMatrix[5, 6] = MatrixCoeffA.a67(dp, sp);
            aMatrix[5, 7] = MatrixCoeffA.a68(dp, sp);
            aMatrix[5, 8] = MatrixCoeffA.a69(dp, sp);
            aMatrix[5, 9] = MatrixCoeffA.a60(dp, sp);
        }

        // Метод рассчитывает текущие значения сил реакции опоры
        private void CalcContactPoint(IList<double> dp, IList<double> sp)
        {
            Functions.GroundReaction.N1Zeta.calculate(dp, sp);
            Functions.GroundReaction.N2Zeta.calculate(dp, sp);
            Functions.GroundReaction.N3Zeta.calculate(dp, sp);
            Functions.GroundReaction.N4Zeta.calculate(dp, sp);
            Functions.GroundReaction.N5Zeta.calculate(dp, sp);
            Functions.GroundReaction.N6Zeta.calculate(dp, sp);
            Functions.GroundReaction.N7Zeta.calculate(dp, sp);
            Functions.GroundReaction.N8Zeta.calculate(dp, sp);
        }

        // Метод выполняет запись всех параметров текущей итерации в массив истории
        private void SaveCurrentIteration()
        {
            double t = 0;

            params_history[iteration_count, (int)HP.t] = dp_1[(int)DP.t];

            params_history[iteration_count, (int)HP.xi] = dp_1[(int)DP.xi];
            params_history[iteration_count, (int)HP.eta] = dp_1[(int)DP.eta];
            params_history[iteration_count, (int)HP.zeta] = dp_1[(int)DP.zeta];
            params_history[iteration_count, (int)HP.theta] = dp_1[(int)DP.theta];
            params_history[iteration_count, (int)HP.psi] = dp_1[(int)DP.psi];
            params_history[iteration_count, (int)HP.phi] = dp_1[(int)DP.phi];
            params_history[iteration_count, (int)HP.x12] = dp_1[(int)DP.x12];
            params_history[iteration_count, (int)HP.x13] = dp_1[(int)DP.x13];
            params_history[iteration_count, (int)HP.x45] = dp_1[(int)DP.x45];
            params_history[iteration_count, (int)HP.x46] = dp_1[(int)DP.x46];

            params_history[iteration_count, (int)HP.xi_t] = dp_1[(int)DP.xi_t];
            params_history[iteration_count, (int)HP.eta_t] = dp_1[(int)DP.eta_t];
            params_history[iteration_count, (int)HP.zeta_t] = dp_1[(int)DP.zeta_t];
            params_history[iteration_count, (int)HP.theta_t] = dp_1[(int)DP.theta_t];
            params_history[iteration_count, (int)HP.psi_t] = dp_1[(int)DP.psi_t];
            params_history[iteration_count, (int)HP.phi_t] = dp_1[(int)DP.phi_t];
            params_history[iteration_count, (int)HP.x12_t] = dp_1[(int)DP.x12_t];
            params_history[iteration_count, (int)HP.x13_t] = dp_1[(int)DP.x13_t];
            params_history[iteration_count, (int)HP.x45_t] = dp_1[(int)DP.x45_t];
            params_history[iteration_count, (int)HP.x46_t] = dp_1[(int)DP.x46_t];

            params_history[iteration_count, (int)HP.xi_tt] = xVector[0];
            params_history[iteration_count, (int)HP.eta_tt] = xVector[1];
            params_history[iteration_count, (int)HP.zeta_tt] = xVector[2];
            params_history[iteration_count, (int)HP.theta_tt] = xVector[3];
            params_history[iteration_count, (int)HP.psi_tt] = xVector[4];
            params_history[iteration_count, (int)HP.phi_tt] = xVector[5];

            t = dp_1[(int)DP.t] - 6.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                params_history[iteration_count, (int)HP.x12_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.x13_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.F2] = sp_1[(int)SP.m2] * params_history[iteration_count, (int)HP.x12_tt];
                params_history[iteration_count, (int)HP.F3] = sp_1[(int)SP.m3] * params_history[iteration_count, (int)HP.x13_tt];
            }

            t = dp_1[(int)DP.t] - 12.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                params_history[iteration_count, (int)HP.x45_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.x46_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.F5] = sp_1[(int)SP.m5] * params_history[iteration_count, (int)HP.x45_tt];
                params_history[iteration_count, (int)HP.F6] = sp_1[(int)SP.m6] * params_history[iteration_count, (int)HP.x46_tt];
            }

            t = dp_1[(int)DP.t] - 21.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                params_history[iteration_count, (int)HP.x45_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.x46_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.F5] = sp_1[(int)SP.m5] * params_history[iteration_count, (int)HP.x45_tt];
                params_history[iteration_count, (int)HP.F6] = sp_1[(int)SP.m6] * params_history[iteration_count, (int)HP.x46_tt];
            }

            t = dp_1[(int)DP.t] - 27.0;
            if (t >= 0.0 && t <= t_force_period)
            {
                params_history[iteration_count, (int)HP.x12_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.x13_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
                params_history[iteration_count, (int)HP.F2] = sp_1[(int)SP.m2] * params_history[iteration_count, (int)HP.x12_tt];
                params_history[iteration_count, (int)HP.F3] = sp_1[(int)SP.m3] * params_history[iteration_count, (int)HP.x13_tt];
            }

            //t = dp_1[(int)DP.t] - t_x1N_base;
            //if (t >= 0.0 && t <= t_force_period)
            //{
            //    params_history[iteration_count, (int)HP.x12_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.x13_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.F2] = sp_1[(int)SP.m2] * params_history[iteration_count, (int)HP.x12_tt];
            //    params_history[iteration_count, (int)HP.F3] = sp_1[(int)SP.m3] * params_history[iteration_count, (int)HP.x13_tt];
            //}

            //t = dp_1[(int)DP.t] - t_x4N_base;
            //if (t >= 0.0 && t <= t_force_period)
            //{
            //    params_history[iteration_count, (int)HP.x45_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.x46_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.F5] = sp_1[(int)SP.m5] * params_history[iteration_count, (int)HP.x45_tt];
            //    params_history[iteration_count, (int)HP.F6] = sp_1[(int)SP.m6] * params_history[iteration_count, (int)HP.x46_tt];
            //}

            //t = dp_1[(int)DP.t] - t_xi_base;
            //if (t >= 0.0 && t <= t_force_period)
            //{
            //    params_history[iteration_count, (int)HP.x12_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.x13_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.F2] = sp_1[(int)SP.m2] * params_history[iteration_count, (int)HP.x12_tt];
            //    params_history[iteration_count, (int)HP.F3] = sp_1[(int)SP.m3] * params_history[iteration_count, (int)HP.x13_tt];

            //    params_history[iteration_count, (int)HP.x45_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.x46_tt] = (xNN_delta * (Math.PI * 2) * Math.Sin((Math.PI * 2 * t) / t_force_period)) / (t_force_period * t_force_period);
            //    params_history[iteration_count, (int)HP.F5] = sp_1[(int)SP.m5] * params_history[iteration_count, (int)HP.x45_tt];
            //    params_history[iteration_count, (int)HP.F6] = sp_1[(int)SP.m6] * params_history[iteration_count, (int)HP.x46_tt];

            //}
            //}



            params_history[iteration_count, (int)HP.N1Zeta] = Functions.GroundReaction.N1Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N1Eta] = Functions.GroundReaction.N1Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N1Xi] = Functions.GroundReaction.N1Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.N2Zeta] = Functions.GroundReaction.N2Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N2Eta] = Functions.GroundReaction.N2Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N2Xi] = Functions.GroundReaction.N2Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.N3Zeta] = Functions.GroundReaction.N3Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N3Eta] = Functions.GroundReaction.N3Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N3Xi] = Functions.GroundReaction.N3Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.N4Zeta] = Functions.GroundReaction.N4Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N4Eta] = Functions.GroundReaction.N4Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N4Xi] = Functions.GroundReaction.N4Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.N5Zeta] = Functions.GroundReaction.N5Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N5Eta] = Functions.GroundReaction.N5Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N5Xi] = Functions.GroundReaction.N5Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.N6Zeta] = Functions.GroundReaction.N6Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N6Eta] = Functions.GroundReaction.N6Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N6Xi] = Functions.GroundReaction.N6Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.N7Zeta] = Functions.GroundReaction.N7Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N7Eta] = Functions.GroundReaction.N7Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N7Xi] = Functions.GroundReaction.N7Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.N8Zeta] = Functions.GroundReaction.N8Zeta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N8Eta] = Functions.GroundReaction.N8Eta.calculate(dp_1, sp_1);
            params_history[iteration_count, (int)HP.N8Xi] = Functions.GroundReaction.N8Xi.calculate(dp_1, sp_1);

            params_history[iteration_count, (int)HP.D1Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D1Zeta];
            params_history[iteration_count, (int)HP.D1Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D1Zeta_S];
            params_history[iteration_count, (int)HP.D2Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D2Zeta];
            params_history[iteration_count, (int)HP.D2Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D2Zeta_S];
            params_history[iteration_count, (int)HP.D3Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D3Zeta];
            params_history[iteration_count, (int)HP.D3Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D3Zeta_S];
            params_history[iteration_count, (int)HP.D4Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D4Zeta];
            params_history[iteration_count, (int)HP.D4Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D4Zeta_S];
            params_history[iteration_count, (int)HP.D5Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D5Zeta];
            params_history[iteration_count, (int)HP.D5Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D5Zeta_S];
            params_history[iteration_count, (int)HP.D6Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D6Zeta];
            params_history[iteration_count, (int)HP.D6Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D6Zeta_S];
            params_history[iteration_count, (int)HP.D7Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D7Zeta];
            params_history[iteration_count, (int)HP.D7Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D7Zeta_S];
            params_history[iteration_count, (int)HP.D8Zeta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D8Zeta];
            params_history[iteration_count, (int)HP.D8Zeta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D8Zeta_S];

            params_history[iteration_count, (int)HP.D1Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D1Xi];
            params_history[iteration_count, (int)HP.D1Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D1Xi_S];
            params_history[iteration_count, (int)HP.D2Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D2Xi];
            params_history[iteration_count, (int)HP.D2Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D2Xi_S];
            params_history[iteration_count, (int)HP.D3Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D3Xi];
            params_history[iteration_count, (int)HP.D3Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D3Xi_S];
            params_history[iteration_count, (int)HP.D4Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D4Xi];
            params_history[iteration_count, (int)HP.D4Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D4Xi_S];
            params_history[iteration_count, (int)HP.D5Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D5Xi];
            params_history[iteration_count, (int)HP.D5Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D5Xi_S];
            params_history[iteration_count, (int)HP.D6Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D6Xi];
            params_history[iteration_count, (int)HP.D6Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D6Xi_S];
            params_history[iteration_count, (int)HP.D7Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D7Xi];
            params_history[iteration_count, (int)HP.D7Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D7Xi_S];
            params_history[iteration_count, (int)HP.D8Xi] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D8Xi];
            params_history[iteration_count, (int)HP.D8Xi_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D8Xi_S];

            params_history[iteration_count, (int)HP.D1Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D1Eta];
            params_history[iteration_count, (int)HP.D1Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D1Eta_S];
            params_history[iteration_count, (int)HP.D2Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D2Eta];
            params_history[iteration_count, (int)HP.D2Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D2Eta_S];
            params_history[iteration_count, (int)HP.D3Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D3Eta];
            params_history[iteration_count, (int)HP.D3Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D3Eta_S];
            params_history[iteration_count, (int)HP.D4Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D4Eta];
            params_history[iteration_count, (int)HP.D4Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D4Eta_S];
            params_history[iteration_count, (int)HP.D5Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D5Eta];
            params_history[iteration_count, (int)HP.D5Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D5Eta_S];
            params_history[iteration_count, (int)HP.D6Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D6Eta];
            params_history[iteration_count, (int)HP.D6Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D6Eta_S];
            params_history[iteration_count, (int)HP.D7Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D7Eta];
            params_history[iteration_count, (int)HP.D7Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D7Eta_S];
            params_history[iteration_count, (int)HP.D8Eta] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D8Eta];
            params_history[iteration_count, (int)HP.D8Eta_S] = Functions.GroundReaction.Deformations.defs[(int)DefParams.D8Eta_S];

            params_history[iteration_count, (int)HP.S1] = Functions.Drives.S1.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S2] = Functions.Drives.S2.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S3] = Functions.Drives.S3.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S4] = Functions.Drives.S4.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S5] = Functions.Drives.S5.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S6] = Functions.Drives.S6.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S7] = Functions.Drives.S7.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S8] = Functions.Drives.S8.calculate(dp_1[0]);

            params_history[iteration_count, (int)HP.S1Diff] = Functions.Drives.S1Diff.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S2Diff] = Functions.Drives.S2Diff.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S3Diff] = Functions.Drives.S3Diff.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S4Diff] = Functions.Drives.S4Diff.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S5Diff] = Functions.Drives.S5Diff.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S6Diff] = Functions.Drives.S6Diff.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S7Diff] = Functions.Drives.S7Diff.calculate(dp_1[0]);
            params_history[iteration_count, (int)HP.S8Diff] = Functions.Drives.S8Diff.calculate(dp_1[0]);

            //params_history[iteration_count, (int)HP.ECount] = last_equations_count;
            if (dp_1[(int)DP.t] > 19.029)
                params_history[iteration_count, (int)HP.ECount] = dp_1[(int)DP.zeta] - 0.02;
            else
                params_history[iteration_count, (int)HP.ECount] = dp_1[(int)DP.zeta];

            params_history[iteration_count, (int)HP.xi_1] = GroundModel.cp[0];
            params_history[iteration_count, (int)HP.eta_1] = GroundModel.cp[1];
            params_history[iteration_count, (int)HP.zeta_1] = GroundModel.cp[2];
            params_history[iteration_count, (int)HP.xi_2] = GroundModel.cp[3];
            params_history[iteration_count, (int)HP.eta_2] = GroundModel.cp[4];
            params_history[iteration_count, (int)HP.zeta_2] = GroundModel.cp[5];
            params_history[iteration_count, (int)HP.xi_3] = GroundModel.cp[6];
            params_history[iteration_count, (int)HP.eta_3] = GroundModel.cp[7];
            params_history[iteration_count, (int)HP.zeta_3] = GroundModel.cp[8];
            params_history[iteration_count, (int)HP.xi_4] = GroundModel.cp[9];
            params_history[iteration_count, (int)HP.eta_4] = GroundModel.cp[10];
            params_history[iteration_count, (int)HP.zeta_4] = GroundModel.cp[11];
            params_history[iteration_count, (int)HP.xi_5] = GroundModel.cp[12];
            params_history[iteration_count, (int)HP.eta_5] = GroundModel.cp[13];
            params_history[iteration_count, (int)HP.zeta_5] = GroundModel.cp[14];
            params_history[iteration_count, (int)HP.xi_6] = GroundModel.cp[15];
            params_history[iteration_count, (int)HP.eta_6] = GroundModel.cp[16];
            params_history[iteration_count, (int)HP.zeta_6] = GroundModel.cp[17];
            params_history[iteration_count, (int)HP.xi_7] = GroundModel.cp[18];
            params_history[iteration_count, (int)HP.eta_7] = GroundModel.cp[19];
            params_history[iteration_count, (int)HP.zeta_7] = GroundModel.cp[20];
            params_history[iteration_count, (int)HP.xi_8] = GroundModel.cp[21];
            params_history[iteration_count, (int)HP.eta_8] = GroundModel.cp[22];
            params_history[iteration_count, (int)HP.zeta_8] = GroundModel.cp[23];

            for (int i = (int)HP.xi_1; i <= (int)HP.zeta_8; ++i)
            {
                if (Double.IsNaN(params_history[iteration_count, i]))
                    params_history[iteration_count, i] = 0;
            }
        }

        // Метод возвращает историю итераций
        public int GetHistory(out double[,] history)
        {
            history = params_history.Clone() as double[,];
            return iteration_count;
        }

        // Метод выполняет коррекцию горизонтального движения:
        // Ограничивает максимальный размых рам робота, для избежания повреждений механизмов
        private void CorrectHorizontalMove(double[] dp, double[] coeff)
        {
            // Проверить для каждой направляющей текущее расстояние до корпуса
            if (Math.Abs(dp[(int)DP.x12]) >= MAX_REL_DISTANCE_2_3)
            {
                // Выставить нулевые параметры для скорости выбранной рамы и зафиксировать координату
                dp[(int)DP.x12] = MAX_REL_DISTANCE_2_3 * Math.Sign(dp[(int)DP.x12]);
                dp[(int)DP.x12_t] = 0;
                if (null != coeff)
                {
                    coeff[(int)DP.x12] = 0;
                    coeff[(int)DP.x12_t] = 0;
                }
            }

            if (Math.Abs(dp[(int)DP.x13]) >= MAX_REL_DISTANCE_2_3)
            {
                dp[(int)DP.x13] = MAX_REL_DISTANCE_2_3 * Math.Sign(dp[(int)DP.x13]);
                dp[(int)DP.x13_t] = 0;
                if (null != coeff)
                {
                    coeff[(int)DP.x13] = 0;
                    coeff[(int)DP.x13_t] = 0;
                }
            }

            if (Math.Abs(dp[(int)DP.x45]) >= MAX_REL_DISTANCE_5_6)
            {
                dp[(int)DP.x45] = MAX_REL_DISTANCE_5_6 * Math.Sign(dp[(int)DP.x45]);
                dp[(int)DP.x45_t] = 0;
                if (null != coeff)
                {
                    coeff[(int)DP.x45] = 0;
                    coeff[(int)DP.x45_t] = 0;
                }
            }

            if (Math.Abs(dp[(int)DP.x46]) >= MAX_REL_DISTANCE_5_6)
            {
                dp[(int)DP.x46] = MAX_REL_DISTANCE_5_6 * Math.Sign(dp[(int)DP.x46]);
                dp[(int)DP.x46_t] = 0;
                if (null != coeff)
                {
                    coeff[(int)DP.x46] = 0;
                    coeff[(int)DP.x46_t] = 0;
                }
            }
        }

    }
}

