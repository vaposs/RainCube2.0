using System.Collections;
using UnityEngine;

public class SpawnerCube : Spawner<Cube>
{
    [SerializeField] private float _delay;
    [SerializeField] private int _spawnPositionY = 10;
    [SerializeField] private int _minSpawnPosition = -5;
    [SerializeField] private int _maxSpawnPosition = 5;
    [SerializeField] private SpawnerBomb _spawnerBomb;

    private Vector3 _spawnPosition;
    private float _spawnPositionX;
    private float _spawnPositionZ;

    private WaitForSeconds _wait;

    private void OnEnable()
    {
        _wait = new WaitForSeconds(_delay);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            _spawnPositionX = Random.Range(_minSpawnPosition, _maxSpawnPosition);
            _spawnPositionZ = Random.Range(_minSpawnPosition, _maxSpawnPosition);
            _spawnPosition = new Vector3(_spawnPositionX, _spawnPositionY, _spawnPositionZ);

            if (ObjectPool.TakeCountPool() == true)
            {
                InstantiatePlus();
            }
            else
            {
                EnablePlus();
            }

            ActivPlus();
            TempItem = ObjectPool.GetItem(PrefabItem, Conteiner);
            TempItem.ReturnedPool += OnReturnedPool;
            TempItem.transform.position = _spawnPosition;
            yield return _wait;
        }
    }

    public override void SpawnBomb(Vector3 vector3)
    {
        _spawnerBomb.SpawnBomb(vector3);
    }

    public override void OnReturnedPool(Cube cube)
    {
        cube.ReturnedPool -= OnReturnedPool;
        SpawnBomb(cube.transform.position);
        ActivMinus();
        ObjectPool.PutObject(cube);
    }
}