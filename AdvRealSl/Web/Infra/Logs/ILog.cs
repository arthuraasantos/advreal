namespace Web.Infra.Logs
{
    public interface ILog<T, E>
        where T: class
        where E: class
    {
        void Register(T entity, E _event);
        void Create(T entity);
        void Modify(T oldEntity, T newEntity);
        void Delete(T entity);
        
    }
}
