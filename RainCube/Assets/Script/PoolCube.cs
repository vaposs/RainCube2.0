using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCube : ObjectPool<Cube>
{
    private void OnEnable()
    {
        Cube.ReturnPool += PutObject;
    }

    private void OnDisable()
    {
        Cube.ReturnPool -= PutObject;
    }
}
