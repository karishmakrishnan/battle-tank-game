using UnityEngine;

public class ShellScript : MonoBehaviour
{
 [SerializeField]
 private LayerMask TankLayer;
 [SerializeField]
 private ParticleSystem explosionParticle;
 [SerializeField]
 private AudioSource explosionAudio;
 [SerializeField]
 private float maxDamage;
 [SerializeField]
 private float explosionForce=1000f;
 [SerializeField]
 private float maxLifeTime=2f;
 [SerializeField]
 private float explosionRadious=5f;


private void Start()
{
    Destroy(gameObject,maxLifeTime);
}
private void OnTriggerEnter(Collider collider)
{
    Collider[] colliders=Physics.OverlapSphere(transform.position,explosionRadious,TankLayer);
    for(int i=0;i<colliders.Length;i++)
    {
        Rigidbody targetRigidbody=colliders[i].GetComponent<Rigidbody>();
        if(!targetRigidbody)
            continue;
        targetRigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadious);
        EnemyTankHealth targetHealth=targetRigidbody.GetComponent<EnemyTankHealth>();
        //float damage=TankDamage(targetRigidbody.position);
        float damage=10f;
        targetHealth.TakeDamage(damage);
    }
    explosionParticle.Play();
    explosionAudio.Play();
    Destroy(explosionParticle.gameObject,2f);
    Destroy(gameObject);
}
// private float TankDamage(Vector3 targetPosition)
// {
//     Vector3 explosionToTaget=targetPosition-transform.position;
//     float explosionDistance=explosionToTaget.magnitude;
//     float relativeDistance=(explosionRadious+explosionDistance)/explosionRadious;
//     float damage = relativeDistance*maxDamage;
//     if(damage<0)
//     {
//         damage=0;
//     }
//     return damage;
// }
}
