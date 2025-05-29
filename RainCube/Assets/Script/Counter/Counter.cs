using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private DrawCounter _drawCounter;

    private int _countInstanstiate = 0;
    private int _countSpawn = 0;
    private int _countActive = 0;

    public void AddInstanstiate()
    {
        _countInstanstiate++;
        _drawCounter.DrawInstanstiate(_countInstanstiate);
    }

    public void AddEnable()
    {
        _countSpawn++;
        _drawCounter.DrawEnable(_countSpawn);
    }

    public void ActiveObjectePlus()
    {
        _countActive++;
        _drawCounter.DrawActive(_countActive);
    }

    public void ActiveObjecteMinus()
    {
        _countActive--;
        _drawCounter.DrawActive(_countActive);
    }
}
