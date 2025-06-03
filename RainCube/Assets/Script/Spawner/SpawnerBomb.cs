using UnityEngine;

public class SpawnerBomb : Spawner<Bomb>
{
    public override void SpawnBomb(Vector3 spawnPosition)
    {
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
        TempItem.transform.position = spawnPosition;
    }

    public override void OnReturnedPool(Bomb bomb)
    {
        bomb.ReturnedPool -= OnReturnedPool;
        ActivMinus();
        ObjectPool.PutObject(bomb);
    }
}