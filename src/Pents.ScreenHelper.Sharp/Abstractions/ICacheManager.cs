using System.Diagnostics.CodeAnalysis;

namespace Pents.ScreenHelper.Sharp.Abstractions;

/// <summary>
/// Simple in-memory cache manager
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ICacheManager<T>
{
    T this[Guid id] { get; }
    
    Guid Add(T entity);
    bool AddIfNotExists(T entity, [NotNullWhen(true)]out Guid? id);

    bool TryGet(Guid id, [NotNullWhen(true)] out T? value);

    void Remove(Guid id);
    bool TryRemove(Guid id);
}