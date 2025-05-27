using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _timeChangeColor;
    [SerializeField] private float _timeDelete;

    private float _explosionRadiys = 30;
    private float _minTimeChangeColor = 2f;
    private float _maxTimeChangeColor = 5f;
    private float _forse = 500f;

    private MeshRenderer _meshRenderer;
    private Color _startColor;
    private Color _endColor;

    public event Action<Bomb> ReturnedPool;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _startColor = _meshRenderer.material.color;
        _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0);
    }

    private void OnEnable()
    {
        _meshRenderer.material.color = _startColor;
        _timeChangeColor = UnityEngine.Random.Range(_minTimeChangeColor, _maxTimeChangeColor);
        Changer();
    }

    private void Changer()
    {
        _meshRenderer.material.DOColor(_endColor, _timeChangeColor).OnComplete(OnFinish);
    }

    private void OnFinish()
    {
        Explosion();
        ReturnedPool?.Invoke(this);
    }

    private void Explosion()
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
