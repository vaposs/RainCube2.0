using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private SpawnerBomb _spawnerBomb;
    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _conteiner;

    private ObjectPool<Cube> _objectPoolCube;
    private Cube _tempCube;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _objectPoolCube = new ObjectPool<Cube>();
        _objectPoolCube.Initialization();
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            _tempCube = _objectPoolCube.GetItem(_cube, _conteiner);
            _tempCube.ReturnedPool += OnReturnedPool;
            _tempCube.transform.position = _spawnPosition.position;
            yield return _wait;
        }
    }

    private void CreateBomb(Vector3 vector3)
    {
        _spawnerBomb.SpawnBomb(vector3);
    }

    private void OnReturnedPool(Cube cube)
    {
        cube.ReturnedPool -= OnReturnedPool;
        CreateBomb(cube.transform.position);
        _objectPoolCube.PutObject(cube);
    }
}
