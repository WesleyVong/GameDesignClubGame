using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startingHealth;
    public float damage;
    private float health;
    public float speed;

    public Transform player;
    public Rigidbody2D rb;

    public event System.Action OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = startingHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * 5); // how much the enemy gets knocked back
        } 
        else if (collision.gameObject.tag == "projectile")
        {
            TakeDamage(1); // change damage of bullet
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        // we can add more death effects here
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //rb.MovePosition(transform.position + (player.position-transform.position).normalized * speed * Time.deltaTime);

    }
}
