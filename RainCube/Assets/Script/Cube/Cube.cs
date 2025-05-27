using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private float _timeDelete;
    private float _minTimeDelete = 2f;
    private float _maxTimeDelete = 5f;
    private WaitForSeconds _wait;


    public event Action<Cube> ReturnedPool;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform returnPool))
        {
            _wait = new WaitForSeconds(UnityEngine.Random.Range(_minTimeDelete, _maxTimeDelete));

            StartCoroutine(DeletionDelay());
        }
    }

    private IEnumerator DeletionDelay()
    {
        yield return _wait;
        ReturnedPool?.Invoke(this);
    }
}
