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
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.CompareTag("Enemy") && other.CompareTag("PlayerAttack"))
        {
            Attack attack = other.GetComponent<Attack>();
            Damage(attack.damage, attack.force);
        }
    }

    void Damage(float damageReceived, Vector2 forceReceived)
    {
        health -= damageReceived;
        rb.AddForce(forceReceived);
    }
}
