using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Cube: SpawnItem
{
    private WaitForSeconds _wait;
    private Coroutine _coroutine = null;
    private bool _isCollided = true;

    public event Action<Cube> ReturnedPool;

    private void OnEnable()
    {
        MeshRenderer.material.color = Color.white;
        _isCollided = true;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isCollided == true)
        {
            if (collision.gameObject.TryGetComponent(out Platform returnPool))
            {
                _isCollided = false;
                _wait = new WaitForSeconds(UnityEngine.Random.Range(MinTime, MaxTime));
                MeshRenderer.material.color = UnityEngine.Random.ColorHSV();

                if (_coroutine == null)
                {
                    _coroutine = StartCoroutine(DeletionDelay());
                }
            }
        }
    }

    private IEnumerator DeletionDelay()
    {
        yield return _wait;
        ReturnedPool?.Invoke(this);
    }
}
