using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.level = (GameManager.Instance.level + 1) % GameManager.Instance.maxLevel;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
