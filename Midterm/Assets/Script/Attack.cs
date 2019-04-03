using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 5;
    public Vector2 velocity = Vector2.zero;
    public Vector2 force = Vector2.right;
    public float effectTime = 0.2f;
    
    public Vector2 direction = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Expire", effectTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Expire()
    {
        Destroy(gameObject);
    }

    void Hit()
    {
        
    }
}
