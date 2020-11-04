using UnityEngine;

[CreateAssetMenu(fileName="Enemy Data",menuName="Enemy Data")]
public class TankEnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    private float enemyMaxHealth;
    [SerializeField]
    private float enemyDamageTaken;
    [SerializeField]
    private float payRollSpeed;


    public float EnemyMaxHealth{get{return enemyMaxHealth;}}
    public float EnemyDamageTaken{get{return enemyDamageTaken;}}
    public float PayRollSpeed{get{return payRollSpeed;}}
}
