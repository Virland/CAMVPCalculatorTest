using Domain.Entity;
using Domain.UseCase;
using Presenter;
using View;
using Repository;
using UnityEngine;


public class CompositionRoot : MonoBehaviour
{
    [SerializeField]
    private CalculatorView _calculatorView;
    private ICalculatorModel _calculatorModel;
    private IRepository<CalculatorState> _stateRepository;
    private ICalculatorPresenter _calculatorPresenter;

    void Awake()
    {
        _calculatorModel = new CalculatorModel();
        _stateRepository = new CalculatorStateRepository();
        _calculatorPresenter = new CalculatorPresenter(_calculatorView, _calculatorModel, _stateRepository);
    }
}
