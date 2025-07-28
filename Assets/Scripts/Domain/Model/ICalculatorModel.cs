using Domain.Entity;
using System;

namespace Domain.UseCase
{
    public interface ICalculatorModel
    {
        decimal Calculate(string expression);
    }
}