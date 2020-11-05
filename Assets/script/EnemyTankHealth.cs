using UnityEngine;
using UnityEngine.UI;
public class EnemyTankHealth : MonoBehaviour
{
    [SerializeField]
    private TankEnemyScriptableObject tankEnemyData;
    private float currentHealth;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Image healthFillImage;
    [SerializeField]
    private GameObject tankExplosion;
    private float MaxHealth;
    
    private Color highHealthColor=Color.green;
    private Color lowHealthColor=Color.red;
    private float enemyDamage;
    private AudioSource explosionAudio;
    private ParticleSystem explosionParticle;
    private bool IsDead;
    private void Awake()
    {
         explosionParticle=Instantiate(tankExplosion).GetComponent<ParticleSystem>();
         //explosionAudio=explosionParticle.GetComponents<AudioSource>();
         explosionParticle.gameObject.SetActive(false);
    }
    private void Start()
    {
        MaxHealth=tankEnemyData.EnemyMaxHealth;
        // lowHealthColor=tankEnemyData.LowHealthColor;
        // highHealthColor=tankEnemyData.HighHealthColor;
        enemyDamage=tankEnemyData.EnemyDamageTaken;
        Debug.Log("low health color"+MaxHealth);
    }
    private void OnEnable()
    {
        currentHealth=tankEnemyData.EnemyMaxHealth;
        IsDead=false;
        SetHealthUI();
        
    }
    public void TakeDamage(float enemyDamage)
    {
        currentHealth -=enemyDamage;
        SetHealthUI();
        if(currentHealth<=0f && !IsDead)
        {
            EnemyDead();
        }
    }
    private void SetHealthUI()
    {
        healthSlider.value=currentHealth;
        healthFillImage.color=Color.Lerp(lowHealthColor,highHealthColor,currentHealth/MaxHealth);
    }
    private void EnemyDead()
    {
        IsDead = true;
        explosionParticle.transform.position=transform.position;
        explosionParticle.gameObject.SetActive(true);
        explosionParticle.Play();
        explosionAudio.Play();
        gameObject.SetActive(false);
    }

}
