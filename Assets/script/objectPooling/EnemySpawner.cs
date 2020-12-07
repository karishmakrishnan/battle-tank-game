// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemySpawner : MonoBehaviour
// {
//     void FixedUpdate()
//     {
//         ObjectPooling.Instance.SpawnFromPool("Enemy",transform.position,Quaternion.identity);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField]
   private float TimeToSpawn=5f;
   private float timeSinceSpawn;
   private ObjectPooling objectPooling;
   public GameObject prefab;
   void Awake()
   {
      
   }
   void Start()
   {
        objectPooling=FindObjectOfType<ObjectPooling>();
       timeSinceSpawn +=Time.deltaTime;
       if(timeSinceSpawn>=TimeToSpawn)
       {
           GameObject newobj=ObjectPooling.Instance.SpawnFromPool("Enemy",transform.position,Quaternion.identity);
           newobj.transform.position=this.transform.position;
           timeSinceSpawn=0f;
       }
   }
}
