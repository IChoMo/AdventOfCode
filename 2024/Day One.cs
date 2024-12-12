using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOne : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public float OurTotalPoint;

    public List<int> left = new();
    public List<int> right = new();

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        foreach (string line in eachLine)
        {
            string[] leftRight = line.Split(' ');

            left.Add(int.Parse(leftRight[0]));
            right.Add(int.Parse(leftRight[3]));
        }

        left.Sort();
        right.Sort();

        for (int i = 0; i < left.Count; i++)
        {
            if (left[i] > right[i])
            {
                OurTotalPoint += left[i] - right[i];
            }
            else
            {
                OurTotalPoint += right[i] - left[i];
            }
        }
    }
}
