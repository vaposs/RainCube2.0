using System;
using System.Collections;
using UnityEngine;

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private SpawnerBomb _spawnerBomb;
    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private int _spawnPositionY = 10;
    [SerializeField] private int _minSpawnPosition = -5;
    [SerializeField] private int _maxSpawnPosition = 5;
    [SerializeField] private Counter _counter;

    private Vector3 _spawnPosition;
    private float _spawnPositionX;
    private float _spawnPositionZ;
    private ObjectPool<Cube> _objectPoolCube;
    private Cube _tempCube;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _objectPoolCube = new ObjectPool<Cube>();
        _objectPoolCube.Initialization();
        _wait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            _spawnPositionX = UnityEngine.Random.Range(_minSpawnPosition, _maxSpawnPosition);
            _spawnPositionZ = UnityEngine.Random.Range(_minSpawnPosition, _maxSpawnPosition);
            _spawnPosition = new Vector3(_spawnPositionX, _spawnPositionY, _spawnPositionZ);

            if(_objectPoolCube.TakeCountPool() == true)
            {
                _counter.AddInstanstiate();
            }
            else
            {
                _counter.AddEnable();
            }

            _counter.ActiveObjectePlus();

            _tempCube = _objectPoolCube.GetItem(_cube, _conteiner);
            _tempCube.ReturnedPool += OnReturnedPool;
            _tempCube.transform.position = _spawnPosition;
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
        _counter.ActiveObjecteMinus();
        CreateBomb(cube.transform.position);
        _objectPoolCube.PutObject(cube);
    }
}
