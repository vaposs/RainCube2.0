using UnityEngine;

public class SpawnerBomb : Spawner<Bomb>
{
    public override void SpawnItem(Vector3 spawnPosition)
    {
        Count();

        TempItem = ObjectPool.GetItem(PrefabItem, Conteiner);
        TempItem.ReturnedPool += OnReturnedPool;
        TempItem.transform.position = spawnPosition;
    }

    public override void OnReturnedPool(Bomb bomb)
    {
        bomb.ReturnedPool -= OnReturnedPool;
        ReduceCountActiveItem();
        ObjectPool.PutObject(bomb);
    }
}