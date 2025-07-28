using System;

namespace View
{
    public interface ICalculatorView
    {
        event Action<string> ExpressionChanged;
        event Action ResultRequested;
        void Display(string value);
    }
}
