using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttack : Attack
{
    // Start is called before the first frame update
    void Start()
    {
        force *= 30;
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
}
