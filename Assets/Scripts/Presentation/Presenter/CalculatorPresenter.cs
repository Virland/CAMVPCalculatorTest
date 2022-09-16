using Domain.Entity;
using Domain.UseCase;
using View;
using Repository;

namespace Presenter
{
    public class CalculatorPresenter : ICalculatorPresenter, ICalculatorStateChangedHandler
    {
        private ICalculatorModel m_CalculatorModel;
        private ICalculatorView m_CalculatorView;

        public CalculatorPresenter(ICalculatorView view, ICalculatorModel model)
        {
            m_CalculatorView = view;
            m_CalculatorModel = model ?? new CalculatorModel(new PlayerPrefsRepository<CalculatorState>("CalculatorState"), this);
        }

        public void Haldle(CalculatorState result)
        {
            m_CalculatorView.Display(result.displayText);
        }

        public void OnStart()
        {
            m_CalculatorModel.Load();
        }

        public void OnQuit(string expression)
        {
            m_CalculatorModel.SetExpression(expression);
            m_CalculatorModel.Save();
        }

        public void OnResultRequested(string expression)
        {
            m_CalculatorModel.SetExpression(expression);
            m_CalculatorModel.Calculate();
        }
    }
}