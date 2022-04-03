using ABC.Facade;
using ABC.Facade.Party;
using Microsoft.AspNetCore.Http.Internal;

namespace ABC.Pages;

public interface IPageModel {
    public int PageIndex { get; }
    public string? CurrentFilter { get; }
    public string? CurrentOrder { get; }
    public string? SortOrder (string propertyName);
}

public interface IIndexModel<TView> where TView: UniqueView {
    public string[] IndexColumns{ get; }
    public IList<TView>? Items { get; }
    public object? GetValue(string name, TView v);

}