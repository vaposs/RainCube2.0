using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    private float _minTimeDelete = 2f;
    private float _maxTimeDelete = 5f;
    private WaitForSeconds _wait;
    private Coroutine _coroutine = null;
    private MeshRenderer _meshRenderer;
    private bool _isColorChanged = true;

    public event Action<Cube> ReturnedPool;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _meshRenderer.material.color = Color.white;
        _isColorChanged = true;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform returnPool))
        {
            if(_isColorChanged == true)
            {
                _isColorChanged = false;
                _wait = new WaitForSeconds(UnityEngine.Random.Range(_minTimeDelete, _maxTimeDelete));
                _meshRenderer.material.color = UnityEngine.Random.ColorHSV();

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
