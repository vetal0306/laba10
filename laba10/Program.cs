using System;

namespace laba10
{
    class Program
    {
        public static void ShowArray(int[] array) // функція виведення масиву на екран
        {
            Console.WriteLine("Ваш массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "   ");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            //вправа 1
            Console.WriteLine("Введiть числа: ");
            var parts = Console.ReadLine().Split(new[] { " ", ",", "; " }, StringSplitOptions.RemoveEmptyEntries);
            var array = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = Convert.ToInt32(parts[i]);
            }
            Pow(array);

            //Вправа 2
            Console.WriteLine("Введiть масив чисел: ");
            var parts1 = Console.ReadLine().Split(new[] { " ", ",", "; " }, StringSplitOptions.RemoveEmptyEntries);
            var array1 = new int[parts1.Length];

            for (int i = 0; i < parts1.Length; i++)
            {
                array1[i] = Convert.ToInt32(parts1[i]);
            }
            Console.WriteLine("На що домножити вiд'ємнi числа: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Peretvorennya(array1, n);

            //Вправа 3
            int[,] matrix = GenerateMatrix(5, -30, 30);
            Numeracja(matrix);


            //Вправа 1.2
            // Сигнатура коду:
            //Summa(int, [int = 0], [int = 0])
            int Summa(int a, int b = 0, int c = 0)
            {
                return a + b + c;
            }

            //Вправа 2.2
            Console.WriteLine("Введiть три числа типу double: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());
            double res = FindBiggerNumber(a, b, c);
            Console.WriteLine($"Найбiльше число: {res}");

            //Вправа 1.3
            Console.WriteLine("Введiть довжину ароифметичної прогресiї: ");
            var arifmetic = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < arifmetic; i++)
            {
                Console.Write("   " + Progression(i));
            }

            // Вправа 2.3
            Console.Write("Введiть бдовжину ароифметичної прогресiї:");
            var z = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kрок прогрессiї: ");
            var d = Convert.ToInt32(Console.ReadLine());

            var sum = 0;
            for (var i = 0; i < z; i++)
            {
                sum += ArifmeticProgression(i, d);
            }

            Console.WriteLine($"Сума {z} перших членiв прогресiї буде {sum}");




            //Вправа 3.3
            Console.Write("Введiть рядок: ");
            var inputText = Console.ReadLine();
            Console.WriteLine("Iнвертований рядок: " + Reverse(inputText));

            //Вправа 4.3
            Console.WriteLine("Введiть рядок: ");
            var p = Console.ReadLine().Split(new[] { " ", ",", "; " }, StringSplitOptions.RemoveEmptyEntries);
            var aa = new int[p.Length];

            for (int i = 0; i < p.Length; i++)
            {
                aa[i] = Convert.ToInt32(p[i]);
            }
            Console.WriteLine("Iндекс максимального елемента рядка: " + IndexOfMax(aa, aa.Length - 1));

            Console.ReadLine();

        }
        static void Pow(int[] array) //для вправи 1
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= array[i];
            }
            ShowArray(array);
        }

        // Функція генерації матриці
        private static int[,] GenerateMatrix(int n, int a, int b)
        {
            int[,] myArr = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    myArr[i, j] = rnd.Next(a, b);
                    Console.Write("{0,4}", myArr[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            return myArr;
        }       
        

        //для вправи 4.3
        static int IndexOfMax(int[] array, int len)
        {
            if (len == 0)
            {
                return len;
            }

            var i = IndexOfMax(array, len - 1);
            return array[len] > array[i] ? len : i;
        }


        //для вправи 3.3
        static string Reverse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            return Reverse(s.Substring(1)) + s[0].ToString();
        }



        //для вправи 2.3
        static int ArifmeticProgression(int n, int d)
        {
            if (n == 0)
            {
                return d;
            }

            return ArifmeticProgression(n - 1, d) + d;
        }


        //для вправи 1.3
        static int Progression(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return Progression(n - 1) + 1;

        }

        //для вправи 2.2
        static uint Mult(uint x, uint y) => x * y + 1;
        static int Mult(int x, int y) => x * y + 2;
        static long Mult(long x, long y) => x * y + 3;

        //для вправи 2.2
        static double FindBiggerNumber(double a, double b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        static double FindBiggerNumber(double a, double b, double c)
        {
            if (FindBiggerNumber(a, b) > c)
                return FindBiggerNumber(a, b);
            else
                return c;
        }


        //для вправи 3
        public static void Numeracja(int[,] matrix)
        {
            Console.WriteLine("З якого рядка нумерувати: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[,] array = new string[matrix.GetLength(0) + 1, matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[i + 1, j] = Convert.ToString(matrix[i, j]);
                }
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i < n)
                {
                    array[i, 0] = " ";
                }
                else
                {
                    array[i, 0] = Convert.ToString(i - n + 1);
                }
            }
            Console.WriteLine("Ваша пронумерована матриця: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "   ");
                }
                Console.Write("\n");
            }
        }


        //для вправи 2
        public static void Peretvorennya(int[] array, int n)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] *= n;
                }
            }
            ShowArray(array);
        }
        #region
        /*
        static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
        static void PrintHello(string name)
        {
            var text = "Hello" + name + " !";
            Console.WriteLine(text);
        }
        static int Cube(int x)
        {
            return x * x * x;
        }

        static void Main(string[] args)
        {
            PrintHelloWorld();
            PrintHello("Andrew");
            var b1 = Cube(2); //8
            var b2 = Cube(3); //27
            Console.ReadLine();

            var a = new int[10];
            var b = new int[7];
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"a[{ i}] = ");
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write($"b[{ i}] = ");
                b[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] t = GetArrayFromConsole("t", 5);
            var g = GetArrayFromConsole("g", 4);

            var num1 = 2;
            var num2 = 5;
            var sum = Add(num1, num2);
            Console.WriteLine($"{ num1} + { num2} = { sum}");
            Console.ReadLine();

            var n1 = 24;
            var n2 = 4;
            var mult = Mult(ref n1, n2);
            //змінна n1 містить нове значення

            Console.WriteLine($"{ n1}");
            Console.ReadLine();

            int r1;
            var err1 = Div(64, 8, out r1);
            PrintResult(err1, r1);

            //змінна r2 оголошується в списку аргументів
            var err2 = Div(34, 0, out int r2);
            PrintResult(err2, r2);
            Console.ReadLine();

            var s = GetPrettyName(lastName: "Jackson", firstName: "Anna");

            //депозит з ставкою та бонусом за замовчуванням
            var d1 = CalcDeposit(10000);
            //нараховано бонус 2.5% (передається як іменований аргумент), ставка за замовчуванням - 10 %
            var d2 = CalcDeposit(15000, bonus: 2.5m);
            //збільшено процентну ставку та бонус
            var d3 = CalcDeposit(20000, 15m, 3m);


        }

        static int[] GetArrayFromConsole(string arrayName, int elementCount)
        {
            var retVal = new int[elementCount];
            for (int i = 0; i < retVal.Length; i++)
            {
                Console.Write($"{arrayName}[{i}] = ");
                retVal[i] = Convert.ToInt32(Console.ReadLine());
            }
            return retVal;
        }


        static void Test(int i)
        {
            if (i <= 0 || i > 5)
            {
                return;
                Console.Write("123"); //цей рядок завжди ігнорується
            }
            Console.WriteLine(i);
        }
        static string ZeroCompare(double number)
        {
            if (number > 0)
            {
                return "Число менше нуля";
            }
            else if (number > 0)
            {
                return "Число більше нуля ";
            }
            return "Число рівне нулю";
        }
        static int Add(int x1, int x2)
        {
            x1 += x2; //зміна x1 не впливає на передану в якості аргументу змінну num1
            return x1;
        }


        static int Mult(ref int x1, int x2)
        {
            x1 *= x2; //зміна x1 впливає на змінну n1
            return x1;
        }


        static string Div(int a, int b, out int result)
        {
            if (b == 0)
            {
                result = int.MinValue;
                return "На нуль ділити не можна!";
            }
            else
            {
                result = a / b;
                return "";
            }                                 
        }

        static void PrintResult(string errorText, int res)
        {
            if (string.IsNullOrEmpty(errorText))
            {
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine(errorText);
            }
        }

        static string GetPrettyName(string firstName, string lastName)
        {
            return firstName + " " +lastName;
        }

        static decimal CalcDeposit(decimal sum, decimal percent = 10m, decimal bonus = 0m)
        {
            return sum + sum * ((percent + bonus) / 100m);
        }


        static void DisplayHello(string n)
        {
            Console.WriteLine("Привіт { 0}", n);
        }
        */
        #endregion
    }
}
