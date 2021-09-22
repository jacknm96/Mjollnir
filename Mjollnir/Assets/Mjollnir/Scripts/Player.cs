using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovementBase
{
    [SerializeField] float rotateSpeed;

    // Update is where we put our input
    void Update()
    {
        direction = Vector3.zero;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01)
        {
            direction += transform.forward * Input.GetAxis("Horizontal");
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.01)
        {
            direction += transform.right * Input.GetAxis("Vertical");
        }
        direction.Normalize();
        // transform.Rotate(transform.up, rotateSpeed * Input.GetAxis("Mouse X"));
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X") * rotateSpeed, transform.rotation.eulerAngles.z));
    }

    // where we do actual movement
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(direction.z, 0, direction.x) * speed * Time.deltaTime;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawSphere(transform.forward, .2f);
    }
}
