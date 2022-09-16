using Domain.Entity;

namespace Domain.UseCase
{
    public interface ICalculatorStateChangedHandler
    {
        void Haldle(CalculatorState result);
    }
}