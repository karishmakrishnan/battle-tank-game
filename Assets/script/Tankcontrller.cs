using UnityEngine;

public class Tankcontrller : MonoSingleton<Tankcontrller> {	
	[SerializeField]
	private float MoveSpeed;
	private float vertical;
	private float horizontal;
	protected Joystick joystick;
	protected FixedJoyController joybutton;
	Rigidbody rigidbody;
	private void Awake(){
		joystick=FindObjectOfType<Joystick>();
		joybutton=FindObjectOfType<FixedJoyController>();
	}
	private void FixedUpdate()
	{
		//joystick 
		rigidbody=GetComponent<Rigidbody>();
		rigidbody.velocity= new Vector3(joystick.Horizontal*10f,rigidbody.velocity.y,joystick.Vertical*10f);
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
	transform.Translate(MoveSpeed*horizontal*Time.deltaTime,0f,MoveSpeed*vertical*Time.deltaTime);

	 }
	
}
