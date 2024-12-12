using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOne : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public float OurTotalPoint;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        foreach (string line in eachLine)
        {
            char[] characters = line.ToCharArray();
            string num1 = "";
            string num2 = "";

            foreach (char charry in characters)
            {
                string character = charry.ToString();
                if (character == "0" || character == "1" || character == "2" || character == "3" || character == "4" || character == "5" || character == "6" || character == "7" || character == "8" || character == "9")
                {
                    if (num1 == "") { num1 = character; }
                    else { num2 = character; }
                }
            }

            if (num2 == "") { num2 = num1; }
            string finalNum = "" + num1 + num2;
            float myValue = int.Parse(finalNum);
            OurTotalPoint += myValue;
        }
    }
}