using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> ChangedInstanstiateCount;
    public event Action<int> ChangeEnableCount;
    public event Action<int> ActivedObject;

    private int _countInstanstiate;
    private int _countSpawn;
    private int _countActive;

    public void AddInstanstiate()
    {
        _countInstanstiate++;
        ChangedInstanstiateCount?.Invoke(_countInstanstiate);
    }

    public void AddEnable()
    {
        _countSpawn++;
        ChangeEnableCount?.Invoke(_countSpawn);
    }

    public void ActiveObjectePlus()
    {
        _countActive++;
        ActivedObject?.Invoke(_countActive);
    }

    public void ActiveObjecteMinus()
    {
        _countActive--;
        ActivedObject?.Invoke(_countActive);
    }
}
