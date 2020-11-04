using UnityEngine;

public class HealthUIDirection : MonoBehaviour
{
    [SerializeField]
    private bool IsRelativeRotation = true;
    private Quaternion relativeRotation;
    private void Start()
    {
        relativeRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRelativeRotation)
        {
            transform.rotation=relativeRotation;
        }
    }
}
