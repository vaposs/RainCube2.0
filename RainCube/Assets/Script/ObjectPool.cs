using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _cube;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private Counter _counter;

    private Queue<T> _storage;

    private void Awake()
    {
        _storage = new Queue<T>();
    }

    public T GetItem()
    {
        _counter.ActiveObjectePlus();

        if (_storage.Count == 0)
        {
            _counter.AddInstanstiate();
            return Instantiate(_cube, _conteiner);
        }
        else
        {
            T tempCube = _storage.Dequeue();
            tempCube.gameObject.SetActive(true);
            _counter.AddEnable();
            return tempCube;
        }
    }

    public void PutObject(T cube)
    {
        cube.gameObject.SetActive(false);
        _storage.Enqueue(cube);
        _counter.ActiveObjecteMinus();
    }
}
