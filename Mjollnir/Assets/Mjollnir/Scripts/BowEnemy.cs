using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowEnemy : EnemyBase
{

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 30)
        {
            rb.velocity += (player.transform.position - transform.position).normalized * speed * Time.fixedDeltaTime;
        } else if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            rb.velocity -= (player.transform.position - transform.position).normalized * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
