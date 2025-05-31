using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Explosion))]

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _timeChangeColor;
    [SerializeField] private float _timeDelete;

    private float _minTimeChangeColor = 2f;
    private float _maxTimeChangeColor = 5f;

    private Explosion _explosion;
    private MeshRenderer _meshRenderer;
    private Color _startColor;
    private Color _endColor;

    public event Action<Bomb> ReturnedPool;

    private void Awake()
    {
        _explosion = GetComponent<Explosion>();
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
        _explosion.Explosions();
        ReturnedPool?.Invoke(this);
    }
}
