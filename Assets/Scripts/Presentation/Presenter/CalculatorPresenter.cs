using Domain.Entity;
using Domain.UseCase;
using Repository;
using System;
using View;

namespace Presenter
{
    public class CalculatorPresenter : ICalculatorPresenter
    {
        private readonly ICalculatorModel _calculatorModel;
        private readonly ICalculatorView _calculatorView;
        private readonly IRepository<CalculatorState> _stateRepository;
        private readonly CalculatorState _calculatorState;

        public CalculatorPresenter(ICalculatorView view, ICalculatorModel model, IRepository<CalculatorState> stateRepository)
        {
            _calculatorView = view;
            _calculatorModel = model;
            _stateRepository = stateRepository;

            _calculatorView.ExpressionChanged += OnExpressionChanged;
            _calculatorView.ResultRequested += OnResultRequested;

            _calculatorState = _stateRepository.Read();
            _calculatorView.Display(_calculatorState.displayText);
        }

        public void OnExpressionChanged(string expression)
        {
            _calculatorState.displayText = expression;
            SaveState();
        }

        public void OnResultRequested()
        {
            try
            {
                _calculatorState.displayText = _calculatorModel.Calculate(_calculatorState.displayText).ToString();
            }
            catch (Exception)
            {
                _calculatorState.displayText = "Error";
            }

            _calculatorView.Display(_calculatorState.displayText);

            SaveState();
        }

        private void SaveState()
        {
            _stateRepository.Write(_calculatorState);
        }
    }
}