using UnityEngine;
using System.Collections.Generic;
public class EnemyObjectPolling : MonoBehaviour
{
   [SerializeField]
   private GameObject enemyPrefab;
   
   public Queue<GameObject> enemyPool = new Queue<GameObject>();
   private int poolStartSize=5;
   private float xPosition;
   private float zPosition;

   //Creating pool of enemy setting active
   private void Start()
   {
       for(int i=0; i<poolStartSize;i++)
       {
           xPosition=Random.Range(1,50);
           zPosition=Random.Range(1,31);
           GameObject enemy=Instantiate(enemyPrefab,new Vector3(xPosition,43,zPosition),Quaternion.identity);
           enemyPool.Enqueue(enemy);
           enemy.SetActive(false);
       }
   }

   //each enemy is taking out from queue and setting active
   public GameObject GetEnemy()
   {
     
       if(enemyPool.Count>0)
       {
           GameObject enemy=enemyPool.Dequeue();
           enemy.SetActive(true);
           return enemy;
       }
       else
       {
           GameObject enemy=Instantiate(enemyPrefab);
           return enemy;
       }
    //    return enemy;
   }

    //each enemy is returnig back to the pool and setting inactive 
   public void ReturnEnemyToPool(GameObject enemy)
   {
       enemyPool.Enqueue(enemy);
       enemy.SetActive(false);
   }
}
