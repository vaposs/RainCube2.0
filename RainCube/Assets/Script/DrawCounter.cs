using UnityEngine;
using UnityEngine.UI;

public class DrawCounter: MonoBehaviour
{
    [SerializeField] private Text _spawnCountItem;
    [SerializeField] private Text _instantiateCountItem;
    [SerializeField] private Text _activeCountItem;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ChangedInstanstiateCount += DrawInstanstiate;
        _counter.ChangeEnableCount += DrawEnable;
        _counter.ActivedObject += DrawActive;
    }

    private void OnDisable()
    {
        _counter.ChangedInstanstiateCount -= DrawInstanstiate;
        _counter.ChangeEnableCount -= DrawEnable;
        _counter.ActivedObject -= DrawActive;
    }

    private void DrawInstanstiate(int count)
    {
        _instantiateCountItem.text = count.ToString();
    }

    private void DrawEnable(int count)
    {
        _spawnCountItem.text = count.ToString();
    }

    private void DrawActive(int count)
    {
        _activeCountItem.text = count.ToString();
    }
}
