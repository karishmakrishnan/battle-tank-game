using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
   private float timeToSpawn=1f;
   private float timeSinceSpawn;
   private EnemyObjectPolling poolEnemy;


    void Start()
    {
        poolEnemy= FindObjectOfType<EnemyObjectPolling>();

    }

    
    void Update()
    {
        timeSinceSpawn+=Time.deltaTime;
        if(timeSinceSpawn>=timeToSpawn)
        {
            GameObject newEnemy=poolEnemy.GetEnemy();
            newEnemy.transform.position=this.transform.position;
            timeSinceSpawn=0f;
        }   
    }
}
