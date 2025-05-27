using UnityEditor;
using UnityEngine;

public class SpawnerBomb : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;
    [SerializeField] private Transform _conteiner;

    private ObjectPool<Bomb> _objectPoolBomb;
    private Bomb _tempBomb;

    private void Awake()
    {
        _objectPoolBomb = new ObjectPool<Bomb>();
        _objectPoolBomb.Initialization();
    }

    public void SpawnBomb(Vector3 spawnPosition)
    {
        _tempBomb = _objectPoolBomb.GetItem(_bomb, _conteiner);
        _tempBomb.ReturnedPool += OnReturnedPool;
        _tempBomb.transform.position = spawnPosition;
    }

    private void OnReturnedPool(Bomb bomb)
    {
        bomb.ReturnedPool -= OnReturnedPool;
        _objectPoolBomb.PutObject(bomb);

    }
}

