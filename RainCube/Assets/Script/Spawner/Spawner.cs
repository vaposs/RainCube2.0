using System;
using UnityEngine;

public abstract class Spawner<T>: MonoBehaviour where T : SpawnItem
{
    [SerializeField] protected T PrefabItem;
    [SerializeField] protected Transform Conteiner;

    protected int ActiveItem = 0;
    protected int InstantiateItem = 0;
    protected int EnableItem = 0;

    protected T TempItem;
    protected ObjectPool<T> ObjectPool = new ObjectPool<T>();

    public event Action<int> ChangedInstanstiateCount;
    public event Action<int> ChangedEnableCount;
    public event Action<int> ChangedActiveCountPlus;
    public event Action<int> ChangedActiveCountMinus;

    public abstract void SpawnBomb(Vector3 spawnPosition);

    public abstract void OnReturnedPool(T item);

    protected void ActivPlus()
    {
        ActiveItem++;
        ChangedActiveCountPlus?.Invoke(ActiveItem);
    }

    protected void ActivMinus()
    {
        ActiveItem--;
        ChangedActiveCountPlus?.Invoke(ActiveItem);
    }

    protected void EnablePlus()
    {
        EnableItem++;
        ChangedEnableCount?.Invoke(EnableItem);
    }

    protected void InstantiatePlus()
    {
        InstantiateItem++;
        ChangedInstanstiateCount?.Invoke(InstantiateItem);
    }
    
}
