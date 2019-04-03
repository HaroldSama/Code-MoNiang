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
        //gameObject.GetComponent<Rigidbody2D>().velocity = velocity * direction.x;
        Invoke("Expire", effectTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 add = velocity * direction.x;
        transform.position += add / 30;
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        /*if (!other.CompareTag("Player"))
        {*/
            print("Hit");
            Destroy(gameObject);
        //}
    }
}
