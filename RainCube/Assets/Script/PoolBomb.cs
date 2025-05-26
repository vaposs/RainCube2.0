using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBomb : ObjectPool<Bomb>
{
    private void OnEnable()
    {
        Bomb.ReturnPool += PutObject;
    }

    private void OnDisable()
    {
        Bomb.ReturnPool -= PutObject;
    }
}
