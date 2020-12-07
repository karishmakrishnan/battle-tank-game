using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    private float xPosition;
    [SerializeField]
    private float zPosition;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region SingleTon
    public static ObjectPooling Instance;
    private void Awake()
    {
        Instance=this;
    }
    #endregion
    public List<Pool>pools;
    void Start()
    {
        poolDictionary=new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool=new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                 xPosition=Random.Range(1,50);
                 zPosition=Random.Range(1,31);
                GameObject gameObject=Instantiate(pool.prefab,new Vector3(xPosition,43,zPosition),Quaternion.identity);
                gameObject.SetActive(false);
                objectPool.Enqueue(gameObject);
            }
            poolDictionary.Add(pool.tag,objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("pool with tag "+tag+" doesn't excist.");
            return null;
        }
        GameObject ObjectToSpawn = poolDictionary[tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position=position;
        ObjectToSpawn.transform.rotation=rotation;

        poolDictionary[tag].Enqueue(ObjectToSpawn);
        return ObjectToSpawn;
    }
}
