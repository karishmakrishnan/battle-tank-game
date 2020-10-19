using UnityEngine;

public class Tankcontrller : MonoSingleton<Tankcontrller> {	
	[SerializeField]
	private float MoveSpeed;
	private float vertical;
	private float horizontal;
	void Update () {
	vertical=Input.GetAxis("VerticalUI");
	horizontal=Input.GetAxis("HorizontalUI");
	transform.Translate(MoveSpeed*horizontal*Time.deltaTime,0f,MoveSpeed*vertical*Time.deltaTime);
	}
}
