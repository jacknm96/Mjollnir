using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MovementBase
{
    protected GameObject player;
    [SerializeField] int hp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dam)
    {
        hp -= dam;
        if (hp < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    protected override void OnMove()
    {

    }
}
