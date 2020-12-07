using UnityEngine;

public class Tankcontrller : MonoSingleton<Tankcontrller>,TankInterface
 {	
	[SerializeField]
	private float MoveSpeed;
	private float vertical;
	private float horizontal;
	private Joystick joystick;
	private FixedJoyController joybutton;
	private Rigidbody rigidbody;
	[SerializeField]
	private  float rotateSpeed;
	[SerializeField]
	private AudioSource tankMovementAudio;
	[SerializeField]
	private AudioClip tankIdleAudio;
	[SerializeField]
	private AudioClip tankDrivingAudio;
	[SerializeField]
	private float audioPitchRange=0.2f;
	private float audioOriginalPitch;
	private void Awake()
	{
		joystick=FindObjectOfType<Joystick>();
		joybutton=FindObjectOfType<FixedJoyController>();
		rigidbody=GetComponent<Rigidbody>();
	}
	private void FixedUpdate()
	{
		JoyStickMove();
		TankMovement();
		TankRotate();
		TankDamge();
	}
	void Update ()
	{
		vertical=Input.GetAxis("VerticalUI");
		horizontal=Input.GetAxis("HorizontalUI");
		TankMovement();
		EngineAudio();
		
	}
	private void Start()
	{
		audioOriginalPitch=tankMovementAudio.pitch;
	}
	//collision detection of tank with other game object
	// {
	// 	Debug.Log("Collided with"+collision.gameObject.name);
	// }
	//Tank movement 
	private void TankMovement()
	{
		Vector3 moveTank=transform.forward*vertical*MoveSpeed*Time.deltaTime;
		rigidbody.MovePosition(rigidbody.position + moveTank);
	}
	private void TankRotate()
	{
		float rotate = horizontal*rotateSpeed*Time.deltaTime;
		Quaternion rotateTank=Quaternion.Euler(0f,rotate,0f);
		rigidbody.MoveRotation(rigidbody.rotation*rotateTank);
	}
	private void EngineAudio()
	{
		if(Mathf.Abs(vertical)<0.1f && Mathf.Abs(horizontal)<0.1f)
		{
			if(tankMovementAudio.clip == tankDrivingAudio)
			{
				tankMovementAudio.clip = tankIdleAudio;
				tankMovementAudio.pitch=Random.Range(audioOriginalPitch-audioPitchRange,audioOriginalPitch+audioPitchRange);
				tankMovementAudio.Play();
			}
		}
		else
		{
				if(tankMovementAudio.clip == tankIdleAudio)
			{
				tankMovementAudio.clip = tankDrivingAudio;
				tankMovementAudio.pitch=Random.Range(audioOriginalPitch-audioPitchRange,audioOriginalPitch+audioPitchRange);
				tankMovementAudio.Play();
			}
		}
	}
	//joystick 
	private void JoyStickMove()
	{
		rigidbody.velocity= new Vector3(joystick.Horizontal*5f,rigidbody.velocity.y,joystick.Vertical*5f);
	}

    public void TankDamge()
    {
        // Collision collision;
		// Debug.Log("Collided with"+ collision.gameObject.name);
		// Debug .Log("hello");
		Vector3 center=transform.position;
		float radius=0.2f;
		Collider[] hitColliders=Physics.OverlapSphere(center,radius);
		foreach(var hitCollider in hitColliders)
		{
			// hitCollider.SendMessage("Add damage");
			Debug.Log("Collide with "+hitCollider.gameObject.name);
		}
    }
}
