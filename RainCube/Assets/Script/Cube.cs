using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private WaitForSeconds _wait;
    public static Action<Cube> ReturnPool;
    public static Action<Vector3> CreateBomb;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ReturnPool returnPool))
        {
            StartCoroutine(DeletionDelay());
        }
    }

    private IEnumerator DeletionDelay()
    {
        yield return _wait;
        CreateBomb?.Invoke(this.transform.position);
        ReturnPool?.Invoke(this);
    }
}
