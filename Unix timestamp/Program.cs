using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timestamp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("扣1进行时间转化为时间戳，扣2进行时间戳转化为时间");
            int a = int.Parse(Console.ReadLine());
            if (a == 1)
            {
                Console.WriteLine("按照年月日时分秒格式输入时间(格林尼治时间 UTC)");
                int Y = int.Parse(Console.ReadLine());
                int M = int.Parse(Console.ReadLine());
                int D = int.Parse(Console.ReadLine());
                int H = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                int s = int.Parse(Console.ReadLine());
                Console.WriteLine(DatetoTS.TS(Y, M, D, H, m, s));
                Console.ReadLine();
            }
            else if (a == 2)
            {
                Console.WriteLine("输入时间戳");
                int TS = int.Parse(Console.ReadLine());
                foreach (int number in TStoDate.TS(TS))
                    Console.WriteLine(number);
                Console.ReadLine();
            }
        }
    }

    class DatetoTS
    {
        public static long TS(int Y, int M, int D, int H, int m, int s)
        {
            int a, b, c, d, e, f;
            long Sum;
            {
                a = Y - 1972;
                if (a % 4 == 0)
                {
                    b = a * 31557600 + 2 * 31536000 + 86400;
                }
                else
                {
                    b = (a % 4) * 31536000 + (a - (a % 4)) * 31557600 + 2 * 31536000 + 86400;
                }
            }
            {
                c = 0;
                if (a % 4 == 0)
                {
                    switch (M)
                    {
                        case 1: c = 0; break;
                        case 2: c = 2678400; break;
                        case 3: c = 5184000; break;
                        case 4: c = 7862400; break;
                        case 5: c = 10454400; break;
                        case 6: c = 13132800; break;
                        case 7: c = 15724800; break;
                        case 8: c = 18403200; break;
                        case 9: c = 21081600; break;
                        case 10: c = 23673600; break;
                        case 11: c = 26352000; break;
                        case 12: c = 28944000; break;
                    }
                }
                else
                {
                    switch (M)
                    {
                        case 1: c = 0; break;
                        case 2: c = 2678400; break;
                        case 3: c = 5097600; break;
                        case 4: c = 7776000; break;
                        case 5: c = 10368000; break;
                        case 6: c = 13046400; break;
                        case 7: c = 15638400; break;
                        case 8: c = 18316800; break;
                        case 9: c = 20995200; break;
                        case 10: c = 23587200; break;
                        case 11: c = 26265600; break;
                        case 12: c = 28857600; break;
                    }

                }
            }
            {
                d = (D - 1) * 86400;
            }
            {
                e = H * 3600;
            }
            {
                f = m * 60;
            }
            Sum = b + c + d + e + f + s;
            return Sum;
        }
    }
    class TStoDate
    {
        public static int[] TS(int TS)
        {
            int a, b, c, d, e, f;
            int Y, M, D, H, m, s;
            d = M = 0;
            a = TS % 86400;
            b = (TS - a) / 86400;
            {
                c = a % 3600;
                H = (a - c) / 3600;
                s = c % 60;
                m = (c - s) / 60;
            }
            {
                e = b % 1461;
                f = (b - e) / 1461;
                if (e < 365)
                {
                    Y = 4 * f;
                }
                else if (e > 365 && e < 730)
                {
                    d = e - 365;
                    Y = 4 * f + 1;
                }
                else if (e > 730 && e < 1096)
                {
                    d = e - 731;
                    Y = 4 * f + 2;
                }
                else
                {
                    d = e - 1096;
                    Y = 4 * f + 3;
                }
                if (Y % 4 == 0)
                {
                    for (int i = 1; i < 13; i++)
                    {
                        if (i == 2)
                        {
                            if (d < 29)
                            {
                                M = M + 1;
                                break;
                            }
                            M = M + 1;
                            d = d - 29;
                        }
                        else if (i == 4 || i == 6 || i == 9 || i == 11)
                        {
                            if (d < 30)
                            {
                                M = M + 1;
                                break;
                            }
                            M = M + 1;
                            d = d - 30;
                        }
                        else
                        {
                            if (d < 31)
                            {
                                M = M + 1;
                                break;
                            }
                            else
                            {
                                M = M + 1;
                                d = d - 31;
                            }
                        }
                    }
                    D = e + 1;
                }
                else
                {
                    for (int i = 1; i < 13; i++)
                    {
                        if (i == 2)
                        {
                            if (d < 28)
                            {
                                M = M + 1;
                                break;
                            }
                            d = d - 28;
                            M = M + 1;
                        }
                        else if (i == 4 || i == 6 || i == 9 || i == 11)
                        {
                            if (d < 30)
                            {
                                M = M + 1;
                                break;
                            }
                            d = d - 30;
                            M = M + 1;
                        }
                        else
                        {
                            if (d < 31)
                            {
                                M = M + 1;
                                break;
                            }
                            d = d - 31;
                            M = M + 1;
                        }
                    }
                    D = e + 1;
                }
            }
            Y = Y + 1970;
            int[] arr = { Y, M, D, H, m, s };
            return arr;
        }
    }
}
