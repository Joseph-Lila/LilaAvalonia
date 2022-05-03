namespace Lila.BLL.Services.Interfaces;

public interface ICrud<TEntity>
{
    public List<TEntity> GetAll();
    public TEntity GetById(int id);
    public int Create(TEntity item);
    public void Update(TEntity item);
    public void Delete(TEntity item);
}