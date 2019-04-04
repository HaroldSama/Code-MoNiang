using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDisappear : MonoBehaviour
{
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Disappear", duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
