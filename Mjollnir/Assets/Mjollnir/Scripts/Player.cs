using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovementBase
{
    [SerializeField] float rotateSpeed;
    float turnSmooth;
    float turnSpeed = 0.5f;
    Vector2 playerDirection;
    Vector2 playerFace;

    // Update is where we put our input
    void Update()
    {
        playerDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerFace = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        playerDirection.Normalize();
    }

    // where we do actual movement
    private void FixedUpdate()
    {
        OnMove();
    }

    protected override void OnMove()
    {
        if (playerFace != Vector2.zero)
        {
            //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmooth, turnSpeed);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y + playerFace.x, transform.eulerAngles.z);
        }
        rb.velocity = ((transform.forward * playerDirection.y) + (transform.right * playerDirection.x)) * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawSphere(transform.forward, .2f);
    }
}
