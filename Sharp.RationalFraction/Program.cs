using System;

namespace Sharp.RationalFraction
{
    class Program
    {

        static void Main(string[] args)
        {

            RationalFraction rf = new RationalFraction(2, 5);
            RationalFraction rf1 = new RationalFraction("2/6");

            RationalFraction sum = rf + rf1;
            RationalFraction diff = rf - rf1;
            RationalFraction multi = rf * rf1;
            RationalFraction div = rf / rf1;

            div.SetWholePart();

            Console.WriteLine(sum.ToString());
            Console.WriteLine(diff.ToString());
            Console.WriteLine(multi.ToString());
            Console.WriteLine(div.ToString());

        }

    }
}
