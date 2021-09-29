using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : EnemyBase
{
    [SerializeField] MagicBoomerang hammer;
    
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 3)
        {
            rb.velocity += (player.transform.position - transform.position).normalized * speed * Time.fixedDeltaTime;
        } else
        {
            rb.velocity = Vector3.zero;
        }
        if (hammer.running)
        {
            //rb.velocity = transform.right * speed * Time.deltaTime;
            rb.velocity += Vector3.Cross(hammer.GetComponent<Rigidbody>().velocity, transform.up) * speed;
        }
    }
}
