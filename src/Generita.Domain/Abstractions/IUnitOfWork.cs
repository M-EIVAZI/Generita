namespace Generita.Domain.Abstractions;

public interface IUnitOfWork
{
    public void SaveChangesAsync();
    public void Commit();
    public void Rollback();
}