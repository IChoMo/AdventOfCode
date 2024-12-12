using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOnePartTwo : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public int OurTotalPoint;

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

        for (int i = 0; i < left.Count; i++)
        {
            int totalOccurances = 0;

            for (int x = 0; x < right.Count; x++)
            {
                if (left[i] == right[x])
                {
                    totalOccurances++;
                }
            }

            OurTotalPoint += left[i] * totalOccurances;
        }
    }
}
