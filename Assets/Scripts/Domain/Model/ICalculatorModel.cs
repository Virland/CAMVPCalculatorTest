namespace Domain.UseCase
{
    public interface ICalculatorModel
    {
        void SetExpression(string expression);
        void Calculate();
        void Load();
        void Save();
    }
}