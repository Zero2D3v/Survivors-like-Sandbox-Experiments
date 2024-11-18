using System.Collections.Generic;
using UnityEngine;



public class EnemyBase : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public float health;
    public float damage;

    private Transform player;
    private Transform target;
    private Vector2 direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(!target)
        {
            target = player;
        }
    }

    private Vector2 Direction()
    {
        //don't tforget to normalize!! --> otherwise enemy will slow down as gets closer.
        direction = (target.position - transform.position).normalized;
        return direction;
    }
    private void MoveTowardsPlayer(float moveSpeed)
    {
        if (!target) return;

        rb.linearVelocity = (direction * moveSpeed) * Time.deltaTime;
        //transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        Direction();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer(moveSpeed);
    }
}
