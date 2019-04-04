using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialog;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;    
    public Text questionText;
    public Text option1Text;
    public Text option2Text;
    public Text option3Text;
    public int page;


    private QANode currentNode;
    private string fileLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        fileLocation = Application.dataPath + "/Files/QAPage" + page + ".json";
        
        if (!File.Exists(fileLocation)) WriteNewJson(fileLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WriteNewJson(string fileLocation)
    {
        currentNode = new QANode();

        string jsonStr = JsonUtility.ToJson(currentNode, true);
        print(jsonStr);
        File.WriteAllText(fileLocation, jsonStr);
    }
    
    void ReadFromJson(string fileLocation)
    {
        string input = File.ReadAllText(fileLocation);

        currentNode = JsonUtility.FromJson<QANode>(input);
    }
    
    void UpdateUI(QANode node)
    {
        if (currentNode.pageNumber == 20)
        {
            PlayerControl.freezed = false;
            transform.parent.transform.Find("CastPoint").GetComponent<BossCast>().castReady = true;
            print("Fight!");
            Destroy(gameObject);
        }
        
        questionText.text = node.questionText;
        option1Text.text = node.option1Text;
        option2Text.text = node.option2Text;
        option3Text.text = node.option3Text;
        option1.SetActive(currentNode.option1Display);
        option2.SetActive(currentNode.option2Display);
        option3.SetActive(currentNode.option3Display);        
    }

    public void ChooseOption(int optionNum)
    {
        fileLocation = Application.dataPath + "/Files/QAPage" + currentNode.optionPage[optionNum - 1] + ".json";
        ReadFromJson(fileLocation);
        UpdateUI(currentNode);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ReadFromJson(fileLocation);            
            PlayerControl.freezed = true;
            dialog.SetActive(true);
            UpdateUI(currentNode);
        }
    }
}
