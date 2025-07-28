using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField]
        private TMP_InputField _expressionInput;
        [SerializeField]
        private Button _calculateButton;

        public event Action<string> ExpressionChanged;
        public event Action ResultRequested;

        private void Awake()
        {
            _calculateButton.onClick.AddListener(OnResultButtonClicked);
            _expressionInput.onValueChanged.AddListener(OnExpressionChanged);
        }

        public void Display(string value)
        {
            _expressionInput.SetTextWithoutNotify(value);
        }

        private void OnResultButtonClicked()
        {
            ResultRequested?.Invoke();
        }

        private void OnExpressionChanged(string expression)
        {
            ExpressionChanged?.Invoke(expression);
        }
    }
}