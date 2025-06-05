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
    public event Action<int> ChangedActiveCount;

    public abstract void SpawnItem(Vector3 spawnPosition);

    public abstract void OnReturnedPool(T item);

    protected void IncreaseCountActiveItem()
    {
        ActiveItem++;
        ChangedActiveCount?.Invoke(ActiveItem);
    }

    protected void ReduceCountActiveItem()
    {
        ActiveItem--;
        ChangedActiveCount?.Invoke(ActiveItem);
    }

    protected void IncreaseCountEnableItem()
    {
        EnableItem++;
        ChangedEnableCount?.Invoke(EnableItem);
    }

    protected void IncreaseCountInstanstiateItem()
    {
        InstantiateItem++;
        ChangedInstanstiateCount?.Invoke(InstantiateItem);
    }

    protected void Count()
    {
        if (ObjectPool.TakeCount() == true)
        {
            IncreaseCountInstanstiateItem();
        }
        else
        {
            IncreaseCountEnableItem();
        }

        IncreaseCountActiveItem();
    }
}
