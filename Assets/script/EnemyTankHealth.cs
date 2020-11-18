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
    
    private Color highHealthColor;
    private Color lowHealthColor;
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
        
    }
    private void OnEnable()
    {
        currentHealth=tankEnemyData.EnemyMaxHealth;
        IsDead=false;
        SetHealthUI();
        
    }
    public void TakeDamage(float enemyDamage)
    {
        enemyDamage=10f;
        currentHealth -=enemyDamage;
        Debug.Log("current health="+currentHealth);
        SetHealthUI();
        if(currentHealth<=0f && !IsDead)
        {
            EnemyDead();
        }
    }
    private void SetHealthUI()
    {
        lowHealthColor=tankEnemyData.LowHealthColor;
        highHealthColor=tankEnemyData.HighHealthColor;
        healthSlider.value=currentHealth;
        MaxHealth=tankEnemyData.EnemyMaxHealth;
        healthFillImage.color=Color.Lerp(lowHealthColor,highHealthColor,currentHealth/MaxHealth);
    }
    private void EnemyDead()
    {
        IsDead = true;
        explosionParticle.transform.position=transform.position;
        explosionParticle.gameObject.SetActive(true);
        explosionParticle.Play();
        //explosionAudio.Play();
        gameObject.SetActive(false);
    }

}
