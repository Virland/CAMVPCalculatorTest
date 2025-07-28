using System;
using Domain.Entity;

namespace Domain.UseCase
{
    public class CalculatorModel : ICalculatorModel
    {
        private const char SIGN = '+';

        public decimal Calculate(string expression)
        {
            decimal result;

            if (expression.Contains("-")) throw new ArgumentException();
            var nums = expression.Split(SIGN);

            if (nums.Length == 2)
            {
                decimal n1 = decimal.Parse(nums[0]);
                decimal n2 = decimal.Parse(nums[1]);

                result = (n1 + n2);
            }
            else
            {
                throw new ArgumentException();
            }

            return result;
        }
    }
}