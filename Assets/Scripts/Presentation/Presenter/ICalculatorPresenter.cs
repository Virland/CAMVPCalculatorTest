namespace Presenter
{
    public interface ICalculatorPresenter
    {
        void OnResultRequested(string expression);
        void OnStart();
        void OnQuit(string state);
    }
}