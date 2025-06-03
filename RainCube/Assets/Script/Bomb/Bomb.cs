using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Exploder))]

public class Bomb : SpawnItem
{
    [SerializeField] private float _timeChangeColor;

    private Exploder _exploder;
    private Color _startColor;
    private Color _endColor;

    public event Action<Bomb> ReturnedPool;

    private void Awake()
    {
        base.Awake();

        _exploder = GetComponent<Exploder>();
        _startColor = MeshRenderer.material.color;
        _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0);
    }

    private void OnEnable()
    {
        MeshRenderer.material.color = _startColor;
        _timeChangeColor = UnityEngine.Random.Range(MinTime, MaxTime);
        Changer();
    }

    private void Changer()
    {
        MeshRenderer.material.DOColor(_endColor, _timeChangeColor).OnComplete(OnFinish);
    }

    private void OnFinish()
    {
        _exploder.Explode();
        ReturnedPool?.Invoke(this);
    }
}
