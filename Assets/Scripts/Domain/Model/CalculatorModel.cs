using Domain.Entity;
using System;

namespace Domain.UseCase
{
    public class CalculatorModel : ICalculatorModel
    {
        private const string ERROR_MESSAGE = "Error";
        private const char SIGN = '+';
        private IRepository<CalculatorState> m_StateRepository;
        private ICalculatorStateChangedHandler m_StateChangeHandler;
        private CalculatorState m_State;

        public CalculatorModel(IRepository<CalculatorState> stateRepository, ICalculatorStateChangedHandler stateHandler)
        {
            m_StateRepository = stateRepository;
            m_StateChangeHandler = stateHandler;
        }
        public void SetExpression(string expression)
        {
            m_State.displayText = expression;
        }
        public void Calculate()
        {
            var result = (string)null;
            try
            {
                if (m_State.displayText.Contains("-")) throw new ArgumentException();
                var nums = m_State.displayText.Split(SIGN);
                if (nums.Length == 2)
                {
                    int n1 = int.Parse(nums[0]);
                    int n2 = int.Parse(nums[1]);
                    result = (n1 + n2).ToString();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                result = ERROR_MESSAGE;
            }
            m_State.displayText = result;

            m_StateChangeHandler.Haldle(m_State);
        }

        public void Load()
        {
            m_State = m_StateRepository.Read();
            m_StateChangeHandler.Haldle(m_State);
        }

        public void Save()
        {
            m_StateRepository.Write(m_State);
        }
    }
}