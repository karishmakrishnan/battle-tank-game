using UnityEngine.UI;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    private float MaxHealth = 100f;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Image healthFillImage;
    [SerializeField]
    private Color fulllHealthColor = Color.green;
    [SerializeField]
    private Color lowHealthColor= Color.red;
    [SerializeField]
    private GameObject ExplosionPrefab;


    private AudioSource explosionAudio;
    private ParticleSystem explosionParticle;
    private float CurrentHealth;
    private bool IsDead;
    private void Awake()
    {
        explosionParticle=Instantiate(ExplosionPrefab).GetComponent<ParticleSystem>();
        //explosionAudio=explosionParticle.GetComponents<AudioSource>();
        explosionParticle.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CurrentHealth=MaxHealth;
        IsDead=false;
        SetHealthUI();
    }
    public void TakeDamage(float takeDamage)
    {
        CurrentHealth -=takeDamage;
        SetHealthUI();
        if(CurrentHealth<=0f && !IsDead)
        {
            PlayerDead();
        }
    }
    private void SetHealthUI()
    {
        healthSlider.value=CurrentHealth;
        healthFillImage.color=Color.Lerp(lowHealthColor,fulllHealthColor,CurrentHealth/MaxHealth);
    }
    private void PlayerDead()
    {
        IsDead = true;
        explosionParticle.transform.position=transform.position;
        explosionParticle.gameObject.SetActive(true);
        explosionParticle.Play();
        explosionAudio.Play();
        gameObject.SetActive(false);
    }
}
