using ABC.Domain;
using ABC.Facade;

namespace ABC.Pages;

public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : IBaseRepo<TEntity> {
    protected CrudPage(TRepo r) : base(r) {}
}