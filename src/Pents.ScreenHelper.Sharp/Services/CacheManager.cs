using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Pents.ScreenHelper.Sharp.Abstractions;

namespace Pents.ScreenHelper.Sharp.Services;

public class CacheManager<T> : ICacheManager<T>
{
    private readonly ILogger? _logger;
    private readonly Dictionary<Guid, T> _innerMap;
    
    public CacheManager(ILogger<CacheManager<T>> logger) : this()
    {
        _logger = logger;
    }
    
    public CacheManager(ILogger logger) : this()
    {
        _logger = logger;
    }

    public CacheManager()
    {
        _innerMap = new Dictionary<Guid, T>();
    }

    public T this[Guid id] => _innerMap[id];

    public virtual Guid Add(T entity)
    {
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Calling {nameof(Add)} function");
        CheckEntityNotNull(entity);
        
        var id = Guid.NewGuid();
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Id for a new entity is '{id}'");
        _innerMap.Add(id, entity);
        return id;
    }

    public virtual bool AddIfNotExists(T entity, out Guid? id)
    {
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Calling {nameof(AddIfNotExists)} function");
        CheckEntityNotNull(entity);

        if (!_innerMap.ContainsValue(entity))
        {
            _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Collection does not contain value - proceeding");
            var newId = Guid.NewGuid();
            _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Id for a new entity is '{newId}'");
            _innerMap.Add(newId, entity);
            id = newId;
            return true;
        }
        
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Collection contains value - aborting");

        id = null;
        return false;
    }

    public virtual bool TryGet(Guid id, out T? value)
    {
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Calling {nameof(TryGet)} function");
        if (_innerMap.ContainsKey(id))
        {
            _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Key '{id}' is exists - proceeding");
            value = _innerMap[id];
            return true;
        }
        
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Key '{id}' is not exists - aborting");

        value = default;
        return false;
    }

    public virtual void Remove(Guid id)
    {
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Calling {nameof(Remove)} function");
        this.TryRemove(id);
    }

    public virtual bool TryRemove(Guid id)
    {
        _logger?.LogTrace($"[{nameof(CacheManager<T>)}] Calling {nameof(TryRemove)} function");
        return _innerMap.Remove(id);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void CheckEntityNotNull(T entity)
    {
        if (entity == null)
        {
            _logger?.LogError($"[{nameof(CacheManager<T>)}] Null is not a valid argument of '{nameof(entity)}' parameter");
            throw new ArgumentNullException(nameof(entity));
        }
    }
}