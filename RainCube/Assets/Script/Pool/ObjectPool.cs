using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> _storage = new Queue<T>();

    public T GetItem(T cube, Transform conteiner)
    {
        T tempT;

        if (_storage.Count == 0)
        {
             tempT = GameObject.Instantiate(cube, conteiner);
            return tempT; 
        }
        else
        {
            tempT = _storage.Dequeue();
            tempT.gameObject.SetActive(true);
            return tempT;
        }
    }

    public void PutObject(T tempItem)
    {
        tempItem.gameObject.SetActive(false);
        _storage.Enqueue(tempItem);
    }

    public bool TakeCount()
    {
        return _storage.Count == 0 ? true: false;
    }
}
