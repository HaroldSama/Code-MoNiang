using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public int maxLevel;
    public static GameManager Instance;
    public KeyCode restart;
    
    private const string FILE_CURRENT_LEVEL = "/Files/CurrentLevel.txt";

    public int Level
    {
        get { return level;}
        set
        {
            level = value;
            File.WriteAllText(Application.dataPath + FILE_CURRENT_LEVEL, "CurrentLevel: " + level);
        }
    }

    private void Awake()
    {

        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        string fullSavingPath = Application.dataPath + FILE_CURRENT_LEVEL;

        if (!File.Exists(fullSavingPath))
        {
            File.WriteAllText(fullSavingPath, "CurrentLevel: " + level);
        }
        
        string currentLevelText = File.ReadAllText(fullSavingPath);

        string[] levelSplit = currentLevelText.Split(' ');
        
        level = Int32.Parse(levelSplit[1]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(restart))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerControl.freezed = false;
        }
    }
}
