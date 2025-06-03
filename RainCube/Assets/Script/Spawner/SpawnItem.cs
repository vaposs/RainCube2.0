using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public abstract class SpawnItem: MonoBehaviour
{
    protected float MinTime = 2f;
    protected float MaxTime = 5f;
    protected MeshRenderer MeshRenderer;

    protected void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }
}
