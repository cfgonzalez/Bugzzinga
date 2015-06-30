namespace Bugzzinga.Contexto.IoC
{
    public interface IFactory
    {
        T Create<T>();

        void Release(object value);
    }
}
