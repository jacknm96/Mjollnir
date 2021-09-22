using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 50)]
    public float rotationSpeed;
    [SerializeField] Transform player;
    [SerializeField] float cameraOffset;
    Vector3 cameraClampX = new Vector2(-60, 60);
    Vector3 cameraClampY = new Vector2(-20, 40);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pitch = Input.GetAxis("Mouse Y");
        float yaw = Input.GetAxis("Mouse X");
        
        transform.eulerAngles = new Vector3(transform.localEulerAngles.x + pitch,
            transform.localEulerAngles.y + yaw, transform.localEulerAngles.z);
        transform.position = player.position - transform.forward * cameraOffset;
    }
}
