﻿using System.Reflection;
using ABC.Aids;
using ABC.Data;
using ABC.Domain;

namespace ABC.Facade;

public abstract  class BaseViewFactory<TView, TEntity, TData>
    where TView: class, new()
    where TData: UniqueData, new()
    where TEntity: UniqueEntity<TData>
{
    protected abstract TEntity toEntity(TData d);

    protected virtual void copy(object? from, object? to) => Copy.Properties(from, to);
    public virtual TEntity Create(TView? v) {
        var d = new TData();
        copy(v, d);
        return toEntity(d);
    }

    public virtual TView Create(TEntity? e) {
        var d = e?.Data;
        var v = new TView();
        copy(d, v);
        return v;
    }
}