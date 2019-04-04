using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("PlayerAttack"))
        {
            Attack attack = other.gameObject.GetComponent<Attack>();
            Damage(attack.damage, attack.force, attack.direction);
        }
    }

    void Damage(float damageReceived, Vector2 forceReceived, Vector2 directionReceived)
    {
        health -= damageReceived;
        rb.AddForce(forceReceived * directionReceived.x);
    }
}
