using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> _storage;
    private T _tempT;

    public void Initialization()
    {
        _storage = new Queue<T>();
    }

    public T GetItem(T cube, Transform conteiner)
    {
        if (_storage.Count == 0)
        {
            _tempT = GameObject.Instantiate(cube, conteiner);
            return _tempT; 
        }
        else
        {
            _tempT = _storage.Dequeue();
            _tempT.gameObject.SetActive(true);
            return _tempT;
        }
    }

    public void PutObject(T tempItem)
    {
        tempItem.gameObject.SetActive(false);
        _storage.Enqueue(tempItem);
    }

    public bool TakeCountPool()
    {
        if((_storage.Count == 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
