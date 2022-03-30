using ABC.Domain;
using ABC.Facade;

namespace ABC.Pages;

public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : IBaseRepo<TEntity> {
    protected FilteredPage(TRepo r) : base(r) { }
}