using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] private ObjectPool<Cube> _objectPoolCube;
    [SerializeField] private ObjectPool< Bomb> _objectPoolBomb;
    [SerializeField] private Transform _spawnPosition;

    private Cube _cube;
    private Bomb _bomb;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(Spawn());
    }

    private void OnEnable()
    {
        Cube.CreateBomb += SpawnBomb;
    }

    private void OnDisable()
    {
        Cube.CreateBomb -= SpawnBomb;
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            _cube = _objectPoolCube.GetItem();
            _cube.transform.position = _spawnPosition.position;
            yield return _wait;
        }
    }

    private void SpawnBomb(Vector3 _spawnPosition)
    {
        _bomb = _objectPoolBomb.GetItem();
        _bomb.transform.position = _spawnPosition;
    }
}
