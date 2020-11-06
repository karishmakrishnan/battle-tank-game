using UnityEngine;
using System.Collections;
public class EnemySpawnService : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnEnemy;
    [SerializeField]
    private float xPosition;
    [SerializeField]
    private float zPosition;
    private float spawnCount;
 
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        spawnCount=0;
        while (spawnCount<5)
        {
           xPosition=Random.Range(1,50);
           zPosition=Random.Range(1,31);
           Instantiate(spawnEnemy,new Vector3(xPosition,43,zPosition),Quaternion.identity);
           yield return new WaitForSeconds(0.1f);
           spawnCount++; 
        }
    }
}
