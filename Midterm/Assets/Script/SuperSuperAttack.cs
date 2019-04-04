using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSuperAttack : Attack
{
    // Start is called before the first frame update
    void Start()
    {
        effectTime = 5;
        velocity = Vector2.right;
        
        if (direction.x < 0)
        {
            Vector3 CharScale = transform.localScale;
            CharScale.x *= -1;
            transform.localScale = CharScale;
        }
        
        Invoke("Expire", effectTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 add = velocity * direction.x;
        transform.position += add / 15;
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Hit(other);
    }
}
