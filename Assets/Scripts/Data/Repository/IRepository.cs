namespace Repository
{
    public interface IRepository<T>
    {
        T Read();
        void Write(T value);
    }
}
