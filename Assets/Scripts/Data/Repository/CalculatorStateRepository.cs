using Domain.Entity;

namespace Repository
{
    public class CalculatorStateRepository : PlayerPrefsRepository<CalculatorState>
    {
        private const string KEY = "CalculatorState";
        public CalculatorStateRepository() : base(KEY) {}
    }
}