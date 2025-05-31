using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _explosionRadiys = 30;
    private float _forse = 500f;

    public void Explosions()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadiys);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_forse, transform.position, _explosionRadiys);
            }
        }
    }
}
