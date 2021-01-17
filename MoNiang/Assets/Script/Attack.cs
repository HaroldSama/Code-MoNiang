using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 5;
    public Vector2 velocity = Vector2.zero;
    public Vector2 force = new Vector2(100,0);
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

    void OnCollisionEnter2D(Collision2D other)
    {
        Hit(other);
    }

    void Expire()
    {
        Destroy(gameObject);
    }

    protected void Hit(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag("Player"))
        {
            print("Hit");
            Destroy(gameObject);
            Instantiate(Resources.Load("Prefabs/AttackEffect"), coll.contacts[Random.Range(0,coll.contacts.Length)].point, Quaternion.identity);
        }
    }
}
