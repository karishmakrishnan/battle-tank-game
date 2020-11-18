using UnityEngine;
using UnityEngine.UI;

public class ShootingTanks : MonoBehaviour
{
    [SerializeField]
    private Rigidbody shell;
    [SerializeField]
    private Transform fireTransrorm;
    [SerializeField]
    private Slider aimSlider;
    [SerializeField]
    private AudioSource shootingAudio;
    [SerializeField]
    private AudioClip fireAudio;
    [SerializeField]
    private float launchForce = 50f;
    [SerializeField]
    private float maxChargeTime = 0.64f;

    private string fireButton;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool IsFired;
   
    void OnEnable()
    {
        currentLaunchForce = launchForce;
        aimSlider.value = launchForce;
    }
    private void Start()
    {
        fireButton = "Fire1";
        chargeSpeed=launchForce/maxChargeTime;
    }
    private void Update()
    {
        aimSlider.value=launchForce;
        currentLaunchForce=launchForce;
        if(!IsFired)
        {
            currentLaunchForce=launchForce;
            TankFire();
        }
        else if (Input.GetButtonDown(fireButton))
        {
            IsFired=false;
            currentLaunchForce=launchForce;
            shootingAudio.clip=fireAudio;
            shootingAudio.Play();
        }
        else if(Input.GetButton(fireButton))
        {
            currentLaunchForce=chargeSpeed*Time.deltaTime;
            aimSlider.value=currentLaunchForce;
        }
        else if(Input.GetButtonUp(fireButton))
        {
            TankFire();
        }
    }
    private void TankFire()
    {
        IsFired=true;
        Rigidbody shellInstance=Instantiate(shell,fireTransrorm.position,fireTransrorm.rotation) as Rigidbody;
        shellInstance.velocity=currentLaunchForce*fireTransrorm.forward;
        shootingAudio.clip=fireAudio;
        shootingAudio.Play();
        currentLaunchForce=launchForce;
    }
}