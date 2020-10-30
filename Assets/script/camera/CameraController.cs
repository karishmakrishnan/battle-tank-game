using UnityEngine;

public class CameraController : MonoBehaviour
{
 [SerializeField]
 private float camMoveTime = 0.2f;
 [SerializeField]
 private float screenEdgeBuffer =4f;
 [SerializeField]
 private float minZoomSize = 6.5f;
 [SerializeField]
 private Transform[] camTarget;

 private Camera Mycamera;
 private float zoomSpeed;
 private Vector3 moveVelocity;
 private Vector3 camDesiredposition;


 private void Awake()
 {
     Mycamera=GetComponentInChildren<Camera>();
 }
 private void FixedUpdate()
 {
     Move();
     Zoom();
 }
 private void Move()
 {
     FindAveragePosition();
     transform.position =Vector3.SmoothDamp(transform.position,camDesiredposition,ref moveVelocity,camMoveTime);
 }
 private void FindAveragePosition()
 {
     Vector3 averagePosition= new Vector3();
     int numTarget=0;
     for(int i=0;i<camTarget.Length;i++)
     {
         if(!camTarget[i].gameObject.activeSelf)
            continue;
        averagePosition +=camTarget[i].position;
        numTarget++;
     }
     if(numTarget>0)
     {
         averagePosition /=numTarget;
         averagePosition.y =transform.position.y;
         camDesiredposition=averagePosition;
     }

 }
 private void Zoom()
 {
     float requredSize=FindRequiredPosition();
     Mycamera.orthographicSize = Mathf.SmoothDamp(Mycamera.orthographicSize,requredSize,ref zoomSpeed,camMoveTime);
 }
 private float FindRequiredPosition()
 {
     Vector3 desiredPosition=transform.InverseTransformPoint(camDesiredposition);
     float size=0;
     for(int i=0;i<camTarget.Length;i++)
     {
          if(!camTarget[i].gameObject.activeSelf)
            continue;
          Vector3 targetLocalPosition=transform.InverseTransformPoint(camTarget[i].position);
          Vector3 desiredPositionTotrget= targetLocalPosition-desiredPosition;
          size = Mathf.Max(size,Mathf.Abs(desiredPositionTotrget.y));
          size = Mathf.Max(size,Mathf.Abs(desiredPositionTotrget.x)/Mycamera.aspect);
     }
     size +=screenEdgeBuffer;
     size =Mathf.Max(size,minZoomSize);
     return size;
 }
 public void SetStartPositionAndSize()
 {
     FindAveragePosition();
     transform.position =camDesiredposition;
     Mycamera.orthographicSize =FindRequiredPosition();
 }
}
