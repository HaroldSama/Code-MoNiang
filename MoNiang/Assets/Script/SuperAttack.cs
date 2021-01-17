using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttack : Attack
{
    // Start is called before the first frame update
    void Start()
    {
        force *= 10000;
        Invoke("Expire", effectTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Hit(other);
    }
}
