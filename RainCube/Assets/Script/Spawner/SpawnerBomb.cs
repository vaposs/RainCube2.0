using System;
using UnityEngine;

public class SpawnerBomb : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private Counter _counter;

    private ObjectPool<Bomb> _objectPoolBomb;
    private Bomb _tempBomb;

    private void Awake()
    {
        _objectPoolBomb = new ObjectPool<Bomb>();
        _objectPoolBomb.Initialization();
    }

    public void SpawnBomb(Vector3 spawnPosition)
    {
        if (_objectPoolBomb.TakeCountPool() == true)
        {
            _counter.AddInstanstiate();
        }
        else
        {
            _counter.AddEnable();
        }

        _counter.ActiveObjectePlus();


        _tempBomb = _objectPoolBomb.GetItem(_bomb, _conteiner);
        _tempBomb.ReturnedPool += OnReturnedPool;
        _tempBomb.transform.position = spawnPosition;
    }

    private void OnReturnedPool(Bomb bomb)
    {
        _counter.ActiveObjecteMinus();
        bomb.ReturnedPool -= OnReturnedPool;
        _objectPoolBomb.PutObject(bomb);
    }
}

