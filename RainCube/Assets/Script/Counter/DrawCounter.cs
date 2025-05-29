using UnityEngine;
using UnityEngine.UI;

public class DrawCounter : MonoBehaviour
{

    [SerializeField] private Text _spawnCountItem;
    [SerializeField] private Text _instantiateCountItem;
    [SerializeField] private Text _activeCountItem;

    public void DrawInstanstiate(int count)
    {
        _instantiateCountItem.text = count.ToString();
    }

    public void DrawEnable(int count)
    {
        _spawnCountItem.text = count.ToString();
    }

    public void DrawActive(int count)
    {
        _activeCountItem.text = count.ToString();
    }
}
