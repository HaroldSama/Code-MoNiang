using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        string filePath = Application.dataPath + "/Files/level" + GameManager.Instance.level + ".txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "XXXXXXXXXXXXXXXXXXXXXXXX\n" +
                                                 "X----------------------X\n" +
                                                 "X----------------------X\n" +
                                                 "X-----------G----------X\n" +
                                                 "X----------------------X\n" +
                                                 "X----------------------X\n" +
                                                 "X--P-------------------X\n" +
                                                 "X----------------------X\n" +
                                                 "X----------------------X\n" +
                                                 "XXXXXXXXXXXXXXXXXXXXXXXX\n");
        }

        string[] inputLines = File.ReadAllLines(filePath);

        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[inputLines.Length - 1 - y];

            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] != '-')
                {
                    GameObject tile = Instantiate(Resources.Load("Prefabs/" + line[x]), gameObject.transform) as GameObject;
                    tile.transform.position = new Vector2(x - 11.5f, y - 5);                
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
    
