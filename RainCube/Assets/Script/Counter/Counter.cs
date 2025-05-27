using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Counter : MonoBehaviour
{
    private int _countInstanstiate;
    private int _countSpawn;
    private int _countActive;

    public void AddInstanstiate()
    {
        _countInstanstiate++;
        DrawInstanstiate(_countInstanstiate);
    }

    public void AddEnable()
    {
        _countSpawn++;
        DrawEnable(_countSpawn);
    }

    public void ActiveObjectePlus()
    {
        _countActive++;
        DrawActive(_countActive);
    }

    public void ActiveObjecteMinus()
    {
        _countActive--;
        DrawActive(_countActive);
    }

    public abstract void DrawInstanstiate(int count);
    public abstract void DrawEnable(int count);
    public abstract void DrawActive(int count);
}
