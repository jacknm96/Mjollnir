using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 50)]
    public float rotationSpeed;
    [SerializeField] Transform pivotPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pivotPoint.localRotation = Quaternion.Euler(pivotPoint.localRotation.eulerAngles.x - Input.GetAxis("Mouse Y"), 
            pivotPoint.localRotation.eulerAngles.y + Input.GetAxis("Mouse X"), pivotPoint.localRotation.eulerAngles.z);

    }
}
