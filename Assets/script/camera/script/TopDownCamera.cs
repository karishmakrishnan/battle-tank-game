using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target_transform;
    [SerializeField]
    private float camera_height=10f;
    [SerializeField]
    private float camera_distance=20f;
    [SerializeField]
    private float camera_angle=45f;
    private Vector3 refVelocity;
    [SerializeField]
    private float camera_moveSpeed=0.5f;
    void Start()
    {
        HandleCamera(); 
    }
    void Update()
    {
         HandleCamera(); 
      
    }
    private void HandleCamera()
    {
        if(!target_transform)
        {
            return;
        }
        //buil a worlposition vector
        Vector3 WorldPosition=(Vector3.forward *(-camera_distance))+(Vector3.up*camera_height);
        Debug.DrawLine(target_transform.position,WorldPosition,Color.red);

        //Buil a rotate vector
        Vector3 rotateVector=Quaternion.AngleAxis(camera_angle,Vector3.up)*WorldPosition;
        Debug.DrawLine(target_transform.position,rotateVector,Color.magenta);

        //move position
        Vector3 TargetPosition=target_transform.position;
        TargetPosition.y=0f;
        Vector3 FinalPosition=TargetPosition+rotateVector;
        Debug.DrawLine(target_transform.position,FinalPosition,Color.blue);
        transform.position=Vector3.SmoothDamp(transform.position,FinalPosition,ref refVelocity,camera_moveSpeed);
        transform.LookAt(TargetPosition);
}
}