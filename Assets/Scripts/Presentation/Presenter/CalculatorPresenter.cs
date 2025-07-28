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
            _calculatorView.Display(_calculatorState.DisplayText);
        }

        public void OnExpressionChanged(string expression)
        {
            _calculatorState.DisplayText = expression;
            SaveState();
        }

        public void OnResultRequested()
        {
            try
            {
                _calculatorState.DisplayText = _calculatorModel.Calculate(_calculatorState.DisplayText).ToString();
            }
            catch (Exception)
            {
                _calculatorState.DisplayText = "Error";
            }

            _calculatorView.Display(_calculatorState.DisplayText);

            SaveState();
        }

        private void SaveState()
        {
            _stateRepository.Write(_calculatorState);
        }
    }
}