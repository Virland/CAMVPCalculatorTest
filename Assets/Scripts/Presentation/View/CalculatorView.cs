using Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private InputField m_ExpressionInput;
        [SerializeField] private Button m_CalculateButton;
        private ICalculatorPresenter m_Presenter;

        private void Construct(ICalculatorPresenter presenter)
        {
            m_Presenter = presenter;
        }

        private void Awake()
        {
            // inject
            Construct(new CalculatorPresenter(this, null));
        }

        private void Start()
        {
            m_CalculateButton.onClick.AddListener(ResultButtonClickHandler);
            m_Presenter.OnStart();
        }

        public void Display(string value)
        {
            m_ExpressionInput.SetTextWithoutNotify(value);
        }

        private void ResultButtonClickHandler()
        {
            m_Presenter.OnResultRequested(m_ExpressionInput.text);
        }

        private void OnApplicationQuit()
        {
            m_Presenter.OnQuit(m_ExpressionInput.text);
        }
    }
}