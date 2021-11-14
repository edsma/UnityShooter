using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    [SerializeField]
    private  int enemies;

    public UnityEvent onEnemyChange;

    public int Enemies
    {
        get => enemies;
        set
        {
            enemies = value;
            if (enemies <= 0)
            {
                enemies = 0;
            }
        }

    }

    public void RemoveEnemy()
    {
        Enemies--;
        onEnemyChange.Invoke();
        
    }

    public void AddEnmy(int enemy)
    {
        Enemies++;
    }

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;   
        }
        else
        {
            Destroy(this);
        }
    }
}
