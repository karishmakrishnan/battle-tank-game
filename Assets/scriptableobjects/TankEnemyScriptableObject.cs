using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="Enemy Data",menuName="Enemy Data")]
public class TankEnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    private float enemyMaxHealth;
    [SerializeField]
    private float enemyDamageTaken;
    [SerializeField]
    private float payRollSpeed;
    [SerializeField]
    private Color lowHealthColor=Color.red;
    [SerializeField]
    private Color highHealthColor=Color.green;
  
    public float EnemyMaxHealth{get{return enemyMaxHealth;}}
    public float EnemyDamageTaken{get{return enemyDamageTaken;}}
    public float PayRollSpeed{get{return payRollSpeed;}}
    public Color LowHealthColor{get{return lowHealthColor;}}
    public Color HighHealthColor{get{return highHealthColor;}}
 
}
