using UnityEngine;
using UnityEngine.UI;

public class DrawCounter: Counter
{
    [SerializeField] private Text _spawnCountItem;
    [SerializeField] private Text _instantiateCountItem;
    [SerializeField] private Text _activeCountItem;

    public override void DrawInstanstiate(int count)
    {
        _instantiateCountItem.text = count.ToString();
    }

    public override void DrawEnable(int count)
    {
        _spawnCountItem.text = count.ToString();
    }

    public override void DrawActive(int count)
    {
        _activeCountItem.text = count.ToString();
    }
}
