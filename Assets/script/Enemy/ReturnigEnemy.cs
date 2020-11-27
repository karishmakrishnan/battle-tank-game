using UnityEngine;

public class ReturnigEnemy : MonoBehaviour
{
    
    private EnemyObjectPolling enemyObject;
    void Start()
    {
        enemyObject=FindObjectOfType<EnemyObjectPolling>();

    }

    private void OnDisable()
    {
        if(enemyObject!=null)
        {
            enemyObject.ReturnEnemyToPool(this.gameObject);
        }
    }
}
