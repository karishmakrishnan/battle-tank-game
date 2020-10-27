using UnityEngine;

public class Tankcontrller : MonoSingleton<Tankcontrller> {	
	[SerializeField]
	private float MoveSpeed;
	private float vertical;
	private float horizontal;
	private Joystick joystick;
	private FixedJoyController joybutton;
	Rigidbody rigidbody;
	[SerializeField]
	private  float rotateSpeed;

	private void Awake(){
		joystick=FindObjectOfType<Joystick>();
		joybutton=FindObjectOfType<FixedJoyController>();
	}
	private void FixedUpdate()
	{
		//joystick 
		rigidbody=GetComponent<Rigidbody>();
		rigidbody.velocity= new Vector3(joystick.Horizontal*5f,rigidbody.velocity.y,joystick.Vertical*5f);
	}
	void Update ()
	{
		TankMovement();
	}
	//collision detection of tank with other game object
	// void OnCollisionEnter(Collision collision)
	// {
	// 	Debug.Log("Collided with"+collision.gameObject.name);
	// }
	//Tank movement 
	private void TankMovement()
	{
		vertical=Input.GetAxis("VerticalUI");
		horizontal=Input.GetAxis("HorizontalUI");
		transform.Translate(0f,0f,MoveSpeed*vertical*Time.deltaTime);
		transform.Rotate(0,Input.GetAxis("HorizontalUI")*rotateSpeed*Time.deltaTime,0);

	 }
	
}
