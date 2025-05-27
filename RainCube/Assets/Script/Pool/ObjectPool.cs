using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> _storage;
    private T _tempT;

    public event Action ChangedInstanstiateCount;
    public event Action ChangeEnableCount;
    public event Action ActivedObjectPlus;
    public event Action ActivedObjectMinus;

    public void Initialization()
    {
        _storage = new Queue<T>();
    }

    public T GetItem(T cube, Transform conteiner)
    {
        ActivedObjectPlus?.Invoke();

        if (_storage.Count == 0)
        {
            _tempT = GameObject.Instantiate(cube, conteiner);
            ChangedInstanstiateCount?.Invoke();
            return _tempT; 
        }
        else
        {
            _tempT = _storage.Dequeue();
            ChangeEnableCount?.Invoke();
            _tempT.gameObject.SetActive(true);
            return _tempT;
        }
    }

    public void PutObject(T tempItem)
    {
        ActivedObjectMinus?.Invoke();
        tempItem.gameObject.SetActive(false);
        _storage.Enqueue(tempItem);
    }
}
