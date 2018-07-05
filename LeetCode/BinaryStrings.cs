using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BinaryStrings
    {
        public string AddBinary(string a, string b)
        {
            int length_a = a.Length;
            int length_b = b.Length;
            int length = length_a;

            if (length_a > length_b)
            {
                length = length_a;
                b = MakeSameLength(b, length);
            }
            else if (length_b > length_a)
            {
                length = length_b;
                a = MakeSameLength(a, length);
            }

            int a_bit = 0;
            int b_bit = 0;
            int carry_bit = 0;
            int sum_bit = 0;

            StringBuilder sb = new StringBuilder(length + 1);
            for (int i = length - 1; i >= 0; i--)
            {
                a_bit = (int)(a[i] - '0');
                b_bit = (int)(b[i] - '0');
                sum_bit = a_bit ^ b_bit ^ carry_bit;
                carry_bit = (a_bit & b_bit) | (b_bit & carry_bit) | (carry_bit & a_bit);
                sb.Insert(0, sum_bit);
            }

            if (carry_bit == 1)
            {
                sb.Insert(0, carry_bit);
            }

            return sb.ToString();
        }

        private string MakeSameLength(string num, int length)
        {
            return num.PadLeft(length, '0');
        }
    }
}
