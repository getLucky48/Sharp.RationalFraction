using System;
using System.Collections.Generic;
using System.Text;

namespace Sharp.RationalFraction
{
    
    class RationalFraction
    {

        public RationalFraction(int numerator, int denominator)
        {

            this.wholePart = 0;
            this.numerator = numerator;
            this.denominator = denominator;

            if (this.denominator == 0)
                throw new Exception("Знаменатель не может быть равен нулю");

        }

        public RationalFraction(string value)
        {

            string[] values = value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (values.Length != 2)
                throw new Exception("Неверное число аргументов: " + values.Length);

            int num;
            int denom;

            if (!int.TryParse(values[0], out num))
                throw new Exception("Неверное значения числителя");
            if (!int.TryParse(values[1], out denom))
                throw new Exception("Неверное значение знаменателя");

            this.numerator = num;
            this.denominator = denom;

        }

        public void SetWholePart()
        {

            this.wholePart = this.numerator / this.denominator;
            this.numerator %= this.denominator;

        }

        public static RationalFraction operator +(RationalFraction arg1, RationalFraction arg2)
        {

            if(arg1.denominator == arg2.denominator)
                return new RationalFraction(arg1.numerator + arg2.numerator, arg1.denominator);

            int arg1Changed = arg1.numerator * arg2.denominator;
            int arg2Changed = arg2.numerator * arg1.denominator;

            return new RationalFraction(arg1Changed + arg2Changed, arg1.denominator * arg2.denominator);

        }

        public static RationalFraction operator -(RationalFraction arg1, RationalFraction arg2)
        {

            if (arg1.denominator == arg2.denominator)
                return new RationalFraction(arg1.numerator - arg2.numerator, arg1.denominator);

            int arg1Changed = arg1.numerator * arg2.denominator;
            int arg2Changed = arg2.numerator * arg1.denominator;

            return new RationalFraction(arg1Changed - arg2Changed, arg1.denominator * arg2.denominator);

        }

        public static RationalFraction operator *(RationalFraction arg1, RationalFraction arg2)
        {

            return new RationalFraction(arg1.numerator * arg2.numerator, arg1.denominator * arg2.denominator);

        }

        public static RationalFraction operator /(RationalFraction arg1, RationalFraction arg2)
        {

            return new RationalFraction(arg1.numerator * arg2.denominator, arg1.denominator * arg2.numerator);

        }

        public override string ToString()
        {

            string result = "";

            if (this.wholePart != 0)
                result += this.wholePart.ToString();

            result += $"({this.numerator}/{this.denominator})";

            return result;

        }

        private int wholePart { get; set; }
        private int denominator { get; set; }
        private int numerator { get; set; }

    }

}
