using System;

namespace Метод_Варнсдорфа
{
    class Program
    {
        //метод, находящий ход с наименьшим колчиеством потенциальных ходов
        static int MinN(int input1, int input2, int input3, int input4, int input5, int input6, int input7, int input8)
        {
            int c1; int c2; int c3; int c4; int c5; int c6; int c7; int c8;

            if (!(input1 == 0)) c1 = input1; else c1 = 100000;
            if (!(input2 == 0)) c2 = input2; else c2 = 100000;
            if (!(input3 == 0)) c3 = input3; else c3 = 100000;
            if (!(input4 == 0)) c4 = input4; else c4 = 100000;
            if (!(input5 == 0)) c5 = input5; else c5 = 100000;
            if (!(input6 == 0)) c6 = input6; else c6 = 100000;
            if (!(input7 == 0)) c7 = input7; else c7 = 100000;
            if (!(input8 == 0)) c8 = input8; else c8 = 100000;

            int output = Math.Min(c1, Math.Min(c2, Math.Min(c3, Math.Min(c4, Math.Min(c5,
                Math.Min(c6, Math.Min(c7, c8)))))));

            return output;
        }


        static void Main(string[] args)
        {
            //Сделать консоль зелёной, чтобы было классно как в матрице
            Console.ForegroundColor = ConsoleColor.Green;

            //Вывод приветствия и разъяснения
            Console.WriteLine("\"Ход конём\":" + Environment.NewLine +
                "Данная программа решает задачу \"Ход конём\" через" + Environment.NewLine +
                "метод Варнсдорфа исходя из начальной точки, заданной пользователем." +
                Environment.NewLine + Environment.NewLine + Environment.NewLine +
                "Нажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.WriteLine(Environment.NewLine);

            //переменные начальной точки хода коня, задаются пользователем
            Console.Write("Введите координату X начала = ");
            int x = Convert.ToInt32(Console.ReadLine()) + 45; //+45 для правильного отображения, т.к. пользователь вводит координаты плоскости, которая находится в центре другой плоскости
            Console.Write("Введите координату Y начала = ");
            int y = Convert.ToInt32(Console.ReadLine()) + 45;
            Console.WriteLine(Environment.NewLine);


            ///СОЗДАНИЕ МАССИВОВ
            ///они условно накладываются друг на друга
            ///для удобства понимания работы программы

            //двоичный массив условия был ли конь на клетке
            bool[,] bool_field = new bool[100, 100];
            //массив вывода позиций коня
            int[,] answer_field = new int[100, 100];

            //присваивание всем клеткам поля условия, что конь на них был,
            //а также огромной величины, чтобы избежать случайных ошибок при расчётах
            for (int t = 0; t < 100; t++)
            {
                for (int z = 0; z < 100; z++)
                {
                    bool_field[z, t] = true;
                    answer_field[z, t] = 1000;
                }
            }

            //присваивание всем клеткам внутри поля 8 на 8 условия что конь на них не был
            //и величины 64, чтобы в конце, всё отображалось правильно
            for (int t = 46; t < 54; t++)
            {
                for (int z = 46; z < 54; z++)
                {
                    bool_field[z, t] = false;
                    answer_field[z, t] = 64;
                }
            }

            ///данная операция с присваиванием true/false
            ///нужна для того чтобы внутри поля 100 на 100
            ///было выделено игровое поле 8 на 8
            ///чтобы программа исправно работала при попытках
            ///выйти за пределы поля 8 на 8


            //присваивание первой клетке условия, что конь был на ней
            bool_field[x, y] = true;

            //присваивание первой клетке значения 1
            answer_field[x, y] = 1;

            //создаём переменные используемые для просчёта путей
            int X1 = 0; int X1_1 = 0; int X1_2 = 0; int X1_3 = 0; int X1_4 = 0; int X1_5 = 0; int X1_6 = 0; int X1_7 = 0; int X1_8 = 0; int n1 = 0;
            int X2 = 0; int X2_1 = 0; int X2_2 = 0; int X2_3 = 0; int X2_4 = 0; int X2_5 = 0; int X2_6 = 0; int X2_7 = 0; int X2_8 = 0; int n2 = 0;
            int X3 = 0; int X3_1 = 0; int X3_2 = 0; int X3_3 = 0; int X3_4 = 0; int X3_5 = 0; int X3_6 = 0; int X3_7 = 0; int X3_8 = 0; int n3 = 0;
            int X4 = 0; int X4_1 = 0; int X4_2 = 0; int X4_3 = 0; int X4_4 = 0; int X4_5 = 0; int X4_6 = 0; int X4_7 = 0; int X4_8 = 0; int n4 = 0;
            int X5 = 0; int X5_1 = 0; int X5_2 = 0; int X5_3 = 0; int X5_4 = 0; int X5_5 = 0; int X5_6 = 0; int X5_7 = 0; int X5_8 = 0; int n5 = 0;
            int X6 = 0; int X6_1 = 0; int X6_2 = 0; int X6_3 = 0; int X6_4 = 0; int X6_5 = 0; int X6_6 = 0; int X6_7 = 0; int X6_8 = 0; int n6 = 0;
            int X7 = 0; int X7_1 = 0; int X7_2 = 0; int X7_3 = 0; int X7_4 = 0; int X7_5 = 0; int X7_6 = 0; int X7_7 = 0; int X7_8 = 0; int n7 = 0;
            int X8 = 0; int X8_1 = 0; int X8_2 = 0; int X8_3 = 0; int X8_4 = 0; int X8_5 = 0; int X8_6 = 0; int X8_7 = 0; int X8_8 = 0; int n8 = 0;

            int Y1 = 0; int Y1_1 = 0; int Y1_2 = 0; int Y1_3 = 0; int Y1_4 = 0; int Y1_5 = 0; int Y1_6 = 0; int Y1_7 = 0; int Y1_8 = 0; 
            int Y2 = 0; int Y2_1 = 0; int Y2_2 = 0; int Y2_3 = 0; int Y2_4 = 0; int Y2_5 = 0; int Y2_6 = 0; int Y2_7 = 0; int Y2_8 = 0; 
            int Y3 = 0; int Y3_1 = 0; int Y3_2 = 0; int Y3_3 = 0; int Y3_4 = 0; int Y3_5 = 0; int Y3_6 = 0; int Y3_7 = 0; int Y3_8 = 0; 
            int Y4 = 0; int Y4_1 = 0; int Y4_2 = 0; int Y4_3 = 0; int Y4_4 = 0; int Y4_5 = 0; int Y4_6 = 0; int Y4_7 = 0; int Y4_8 = 0; 
            int Y5 = 0; int Y5_1 = 0; int Y5_2 = 0; int Y5_3 = 0; int Y5_4 = 0; int Y5_5 = 0; int Y5_6 = 0; int Y5_7 = 0; int Y5_8 = 0; 
            int Y6 = 0; int Y6_1 = 0; int Y6_2 = 0; int Y6_3 = 0; int Y6_4 = 0; int Y6_5 = 0; int Y6_6 = 0; int Y6_7 = 0; int Y6_8 = 0; 
            int Y7 = 0; int Y7_1 = 0; int Y7_2 = 0; int Y7_3 = 0; int Y7_4 = 0; int Y7_5 = 0; int Y7_6 = 0; int Y7_7 = 0; int Y7_8 = 0;
            int Y8 = 0; int Y8_1 = 0; int Y8_2 = 0; int Y8_3 = 0; int Y8_4 = 0; int Y8_5 = 0; int Y8_6 = 0; int Y8_7 = 0; int Y8_8 = 0;

            //переменная-счётчик, отображающая номер хода
            int i = 1;

            do 
            {
                i++;
                n1 = 0; n2 = 0; n3 = 0; n4 = 0; n5 = 0; n6 = 0; n7 = 0; n8 = 0;
                //задаём координаты всех возможных путей
                /////////////////////////////////////////////////////////////////////////////////
                if (bool_field[x + 1, y + 2] == false)
                {
                    X1 = x + 1; Y1 = y + 2;
                    //
                    X1_1 = X1 + 1; Y1_1 = Y1 + 2;
                    if (bool_field[X1_1, Y1_1] == false)
                    {
                        n1 += 1;
                    }

                    X1_2 = X1 - 1; Y1_2 = Y1 + 2;
                    if (bool_field[X1_2, Y1_2] == false)
                    {
                        n1 += 1;
                    }

                    X1_3 = X1 + 2; Y1_3 = Y1 - 1;
                    if (bool_field[X1_3, Y1_3] == false)
                    {
                        n1 += 1;
                    }

                    X1_4 = X1 + 2; Y1_4 = Y1 + 1;
                    if (bool_field[X1_4, Y1_4] == false)
                    {
                        n1 += 1;
                    }

                    X1_5 = X1 - 1; Y1_5 = Y1 - 2;
                    if (bool_field[X1_5, Y1_5] == false)
                    {
                        n1 += 1;
                    }

                    X1_6 = X1 + 1; Y1_6 = Y1 - 2;
                    if (bool_field[X1_6, Y1_6] == false)
                    {
                        n1 += 1;
                    }

                    X1_7 = X1 - 2; Y1_7 = Y1 - 1;
                    if (bool_field[X1_7, Y1_7] == false)
                    {
                        n1 += 1;
                    }

                    X1_8 = X1 - 2; Y1_8 = Y1 + 1;
                    if (bool_field[X1_8, Y1_8] == false)
                    {
                        n1 += 1;
                    }
                    //

                }

                if (bool_field[x - 1, y + 2] == false)
                {
                    X2 = x - 1; Y2 = y + 2;
                    //
                    X2_1 = X2 + 1; Y2_1 = Y2 + 2;
                    if (bool_field[X2_1, Y2_1] == false)
                    {
                        n2 += 1;
                    }

                    X2_2 = X2 - 1; Y2_2 = Y2 + 2;
                    if (bool_field[X2_2, Y2_2] == false)
                    {
                        n2 += 1;
                    }

                    X2_3 = X2 + 2; Y2_3 = Y2 - 1;
                    if (bool_field[X2_3, Y2_3] == false)
                    {
                        n2 += 1;
                    }

                    X2_4 = X2 + 2; Y2_4 = Y2 + 1;
                    if (bool_field[X2_4, Y2_4] == false)
                    {
                        n2 += 1;
                    }

                    X2_5 = X2 - 1; Y2_5 = Y2 - 2;
                    if (bool_field[X2_5, Y2_5] == false)
                    {
                        n2 += 1;
                    }

                    X2_6 = X2 + 1; Y2_6 = Y2 - 2;
                    if (bool_field[X2_6, Y2_6] == false)
                    {
                        n2 += 1;
                    }

                    X2_7 = X2 - 2; Y2_7 = Y2 - 1;
                    if (bool_field[X2_7, Y2_7] == false)
                    {
                        n2 += 1;
                    }

                    X2_8 = X2 - 2; Y2_8 = Y2 + 1;
                    if (bool_field[X2_8, Y2_8] == false)
                    {
                        n2 += 1;
                    }
                    //
                }

                if (bool_field[x + 2, y - 1] == false)
                {
                    X3 = x + 2; Y3 = y - 1;
                    //
                    X3_1 = X3 + 1; Y3_1 = Y3 + 2;
                    if (bool_field[X3_1, Y3_1] == false)
                    {
                        n3 += 1;
                    }

                    X3_2 = X3 - 1; Y3_2 = Y3 + 2;
                    if (bool_field[X3_2, Y3_2] == false)
                    {
                        n3 += 1;
                    }

                    X3_3 = X3 + 2; Y3_3 = Y3 - 1;
                    if (bool_field[X3_3, Y3_3] == false)
                    {
                        n3 += 1;
                    }

                    X3_4 = X3 + 2; Y3_4 = Y3 + 1;
                    if (bool_field[X3_4, Y3_4] == false)
                    {
                        n3 += 1;
                    }

                    X3_5 = X3 - 1; Y3_5 = Y3 - 2;
                    if (bool_field[X3_5, Y3_5] == false)
                    {
                        n3 += 1;
                    }

                    X3_6 = X3 + 1; Y3_6 = Y3 - 2;
                    if (bool_field[X3_6, Y3_6] == false)
                    {
                        n3 += 1;
                    }

                    X3_7 = X3 - 2; Y3_7 = Y3 - 1;
                    if (bool_field[X3_7, Y3_7] == false)
                    {
                        n3 += 1;
                    }

                    X3_8 = X3 - 2; Y3_8 = Y3 + 1;
                    if (bool_field[X3_8, Y3_8] == false)
                    {
                        n3 += 1;
                    }
                    //
                }

                if (bool_field[x + 2, y + 1] == false)
                {
                    X4 = x + 2; Y4 = y + 1;
                    //
                    X4_1 = X4 + 1; Y4_1 = Y4 + 2;
                    if (bool_field[X4_1, Y4_1] == false)
                    {
                        n4 += 1;
                    }

                    X4_2 = X4 - 1; Y4_2 = Y4 + 2;
                    if (bool_field[X4_2, Y4_2] == false)
                    {
                        n4 += 1;
                    }

                    X4_3 = X4 + 2; Y4_3 = Y4 - 1;
                    if (bool_field[X4_3, Y4_3] == false)
                    {
                        n4 += 1;
                    }

                    X4_4 = X4 + 2; Y4_4 = Y4 + 1;
                    if (bool_field[X4_4, Y4_4] == false)
                    {
                        n4 += 1;
                    }

                    X4_5 = X4 - 1; Y4_5 = Y4 - 2;
                    if (bool_field[X4_5, Y4_5] == false)
                    {
                        n4 += 1;
                    }

                    X4_6 = X4 + 1; Y4_6 = Y4 - 2;
                    if (bool_field[X4_6, Y4_6] == false)
                    {
                        n4 += 1;
                    }

                    X4_7 = X4 - 2; Y4_7 = Y4 - 1;
                    if (bool_field[X4_7, Y4_7] == false)
                    {
                        n4 += 1;
                    }

                    X4_8 = X4 - 2; Y4_8 = Y4 + 1;
                    if (bool_field[X4_8, Y4_8] == false)
                    {
                        n4 += 1;
                    }
                    //
                }

                if (bool_field[x - 1, y - 2] == false)
                {
                    X5 = x - 1; Y5 = y - 2;
                    //
                    X5_1 = X5 + 1; Y5_1 = Y5 + 2;
                    if (bool_field[X5_1, Y5_1] == false)
                    {
                        n5 += 1;
                    }

                    X5_2 = X5 - 1; Y5_2 = Y5 + 2;
                    if (bool_field[X5_2, Y5_2] == false)
                    {
                        n5 += 1;
                    }

                    X5_3 = X5 + 2; Y5_3 = Y5 - 1;
                    if (bool_field[X5_3, Y5_3] == false)
                    {
                        n5 += 1;
                    }

                    X5_4 = X5 + 2; Y5_4 = Y5 + 1;
                    if (bool_field[X5_4, Y5_4] == false)
                    {
                        n5 += 1;
                    }

                    X5_5 = X5 - 1; Y5_5 = Y5 - 2;
                    if (bool_field[X5_5, Y5_5] == false)
                    {
                        n5 += 1;
                    }

                    X5_6 = X5 + 1; Y5_6 = Y5 - 2;
                    if (bool_field[X5_6, Y5_6] == false)
                    {
                        n5 += 1;
                    }

                    X5_7 = X5 - 2; Y5_7 = Y5 - 1;
                    if (bool_field[X5_7, Y5_7] == false)
                    {
                        n5 += 1;
                    }

                    X5_8 = X5 - 2; Y5_8 = Y5 + 1;
                    if (bool_field[X5_8, Y5_8] == false)
                    {
                        n5 += 1;
                    }
                    //
                }

                if (bool_field[x + 1, y - 2] == false)
                {
                    X6 = x + 1; Y6 = y - 2;
                    //
                    X6_1 = X6 + 1; Y6_1 = Y6 + 2;
                    if (bool_field[X6_1, Y6_1] == false)
                    {
                        n6 += 1;
                    }

                    X6_2 = X6 - 1; Y6_2 = Y6 + 2;
                    if (bool_field[X6_2, Y6_2] == false)
                    {
                        n6 += 1;
                    }

                    X6_3 = X6 + 2; Y6_3 = Y6 - 1;
                    if (bool_field[X6_3, Y6_3] == false)
                    {
                        n6 += 1;
                    }

                    X6_4 = X6 + 2; Y6_4 = Y6 + 1;
                    if (bool_field[X6_4, Y6_4] == false)
                    {
                        n6 += 1;
                    }

                    X6_5 = X6 - 1; Y6_5 = Y6 - 2;
                    if (bool_field[X6_5, Y6_5] == false)
                    {
                        n6 += 1;
                    }

                    X6_6 = X6 + 1; Y6_6 = Y6 - 2;
                    if (bool_field[X6_6, Y6_6] == false)
                    {
                        n6 += 1;
                    }

                    X6_7 = X6 - 2; Y6_7 = Y6 - 1;
                    if (bool_field[X6_7, Y6_7] == false)
                    {
                        n6 += 1;
                    }

                    X6_8 = X6 - 2; Y6_8 = Y6 + 1;
                    if (bool_field[X6_8, Y6_8] == false)
                    {
                        n6 += 1;
                    }
                    //
                }

                if (bool_field[x - 2, y - 1] == false)
                {
                    X7 = x - 2; Y7 = y - 1;
                    //
                    X7_1 = X7 + 1; Y7_1 = Y7 + 2;
                    if (bool_field[X7_1, Y7_1] == false)
                    {
                        n7 += 1;
                    }

                    X7_2 = X7 - 1; Y7_2 = Y7 + 2;
                    if (bool_field[X7_2, Y7_2] == false)
                    {
                        n7 += 1;
                    }

                    X7_3 = X7 + 2; Y7_3 = Y7 - 1;
                    if (bool_field[X7_3, Y7_3] == false)
                    {
                        n7 += 1;
                    }

                    X7_4 = X7 + 2; Y7_4 = Y7 + 1;
                    if (bool_field[X7_4, Y7_4] == false)
                    {
                        n7 += 1;
                    }

                    X7_5 = X7 - 1; Y7_5 = Y7 - 2;
                    if (bool_field[X7_5, Y7_5] == false)
                    {
                        n7 += 1;
                    }

                    X7_6 = X7 + 1; Y7_6 = Y7 - 2;
                    if (bool_field[X7_6, Y7_6] == false)
                    {
                        n7 += 1;
                    }

                    X7_7 = X7 - 2; Y7_7 = Y7 - 1;
                    if (bool_field[X7_7, Y7_7] == false)
                    {
                        n7 += 1;
                    }

                    X7_8 = X7 - 2; Y7_8 = Y7 + 1;
                    if (bool_field[X7_8, Y7_8] == false)
                    {
                        n7 += 1;
                    }
                    //
                }

                if (bool_field[x - 2, y + 1] == false)
                {
                    X8 = x - 2; Y8 = y + 1;
                    //
                    X8_1 = X8 + 1; Y8_1 = Y8 + 2;
                    if (bool_field[X8_1, Y8_1] == false)
                    {
                        n8 += 1;
                    }

                    X8_2 = X8 - 1; Y8_2 = Y8 + 2;
                    if (bool_field[X8_2, Y8_2] == false)
                    {
                        n8 += 1;
                    }


                    X8_3 = X8 + 2; Y8_3 = Y8 - 1;
                    if (bool_field[X8_3, Y8_3] == false)
                    {
                        n8 += 1;
                    }

                    X8_4 = X8 + 2; Y8_4 = Y8 + 1;
                    if (bool_field[X8_4, Y8_4] == false)
                    {
                        n8 += 1;
                    }

                    X8_5 = X8 - 1; Y8_5 = Y8 - 2;
                    if (bool_field[X8_5, Y8_5] == false)
                    {
                        n8 += 1;
                    }

                    X8_6 = X8 + 1; Y8_6 = Y8 - 2;
                    if (bool_field[X8_6, Y8_6] == false)
                    {
                        n8 += 1;
                    }

                    X8_7 = X8 - 2; Y8_7 = Y8 - 1;
                    if (bool_field[X8_7, Y8_7] == false)
                    {
                        n8 += 1;
                    }

                    X8_8 = X8 - 2; Y8_8 = Y8 + 1;
                    if (bool_field[X8_8, Y8_8] == false)
                    {
                        n8 += 1;
                    }
                    //
                }
                /////////////////////////////////////////////////////////////////////////////////


                //метод из начала кода, который определяет наименьшее количество потенциальных ходов
                int N = MinN(n1, n2, n3, n4, n5, n6, n7, n8);

                //сравнение всех полученных количеств потенциальных ходов с наименьшим
                if (N == n1 && !(n1==0))
                {
                    //и если сравнение удачное, то все исходные данные заменяеются на данные этого хода
                    answer_field[X1, Y1] = i;
                    bool_field[X1, Y1] = true;
                    x = X1;
                    y = Y1;
                }
                else if (N == n2 && !(n2 == 0))
                {
                    answer_field[X2, Y2] = i;
                    bool_field[X2, Y2] = true;
                    x = X2;
                    y = Y2;
                }
                else if(N == n3 && !(n3 == 0))
                {
                    answer_field[X3, Y3] = i;
                    bool_field[X3, Y3] = true;
                    x = X3;
                    y = Y3;
                }
                else if (N == n4 && !(n4 == 0))
                {
                    answer_field[X4, Y4] = i;
                    bool_field[X4, Y4] = true;
                    x = X4;
                    y = Y4;
                }
                else if (N == n5 && !(n5 == 0))
                {
                    answer_field[X5, Y5] = i;
                    bool_field[X5, Y5] = true;
                    x = X5;
                    y = Y5;
                }
                else if (N == n6 && !(n6 == 0))
                {
                    answer_field[X6, Y6] = i;
                    bool_field[X6, Y6] = true;
                    x = X6;
                    y = Y6;
                }
                else if (N == n7 && !(n7 == 0))
                {
                    answer_field[X7, Y7] = i;
                    bool_field[X7, Y7] = true;
                    x = X7;
                    y = Y7;
                }
                else if (N == n8 && !(n8 == 0))
                {
                    answer_field[X8, Y8] = i;
                    bool_field[X8, Y8] = true;
                    x = X8;
                    y = Y8;
                }

                //Console.WriteLine($"Цикл №{i - 1} завершён");

            }
            while (i < 66 ); //цикл продолжается до тех пор, пока счётчик не станет равен 65

            //вывод
            Console.WriteLine("\n\n\n");
            for (int t = 53; t > 45; t--)
            {
                for (int z = 46; z < 54; z++)
                {
                    Console.Write(" {0,2} |", answer_field[z, t]);
                }
                Console.Write("\n\n");
            }
            Console.WriteLine("\n\n\n");

            Console.WriteLine("Успешно, нажмите любую кнопку, чтобы закрыть программу.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
