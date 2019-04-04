using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QANode
{
    public int pageNumber;
    public string questionText;
    public string option1Text;
    public string option2Text;
    public string option3Text;
    public int[] optionPage;
    public bool option1Display;
    public bool option2Display;
    public bool option3Display;

    public QANode()
    {
        pageNumber = 0;
        questionText = "This is a default question text.";
        option1Text = "Yes";
        option2Text = "No";
        option3Text = "Not Sure";
        optionPage = new int[] {0, 0, 0};
        option1Display = true;
        option2Display = true;
        option3Display = true;
    }
}
