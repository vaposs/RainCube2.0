using UnityEngine.UI;
using UnityEngine;

public class DrawCounterAbstract<T> : MonoBehaviour where T : SpawnItem    
{
    [SerializeField] protected Text _spawnCountItem;
    [SerializeField] protected Text _instantiateCountItem;
    [SerializeField] protected Text _activeCountItem;
    [SerializeField] protected Spawner<T> Spawner;

    private void OnEnable()
    {
        Spawner.ChangedActiveCountMinus += DrawActive;
        Spawner.ChangedActiveCountPlus += DrawActive;
        Spawner.ChangedEnableCount += DrawEnable;
        Spawner.ChangedInstanstiateCount += DrawInstanstiate;
    }

    private void OnDisable()
    {
        Spawner.ChangedActiveCountMinus -= DrawActive;
        Spawner.ChangedActiveCountPlus -= DrawActive;
        Spawner.ChangedEnableCount -= DrawEnable;
        Spawner.ChangedInstanstiateCount -= DrawInstanstiate;
    }

    public virtual void DrawInstanstiate(int count)
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
