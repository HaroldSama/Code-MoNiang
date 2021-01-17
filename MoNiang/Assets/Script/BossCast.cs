using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCast : MonoBehaviour
{
    public GameObject cast;
    public bool castReady;

    private int timer = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (castReady)
        {
            timer++;
    
            if (timer > 100)
            {
                timer = 0;
                Instantiate(cast, transform.position, Quaternion.identity);
            }        
        }
    }
}
