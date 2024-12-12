using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTwo : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public int TotalSafeLines = 0;

    private int LineCount = 0;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        foreach (string line in eachLine)
        {
            LineCount++;

            string[] numbers = line.Split(' ');
            List<int> intNums = new();

            foreach (string num in numbers)
            {
                if (int.TryParse(num, out int myValue)) { intNums.Add(myValue); }
            }

            bool everyNumCountsUp = true;
            bool everyNumCountsdown = true;

            for (int i = 0; i < intNums.Count; i++)
            {
                if (i < intNums.Count-1)
                {
                    if (intNums[i] < intNums[i + 1])
                    {
                        //Debug.Log(intNums[i] + " is smaller then: " + intNums[i + 1]);
                        //if this number is smaller then the next one
                    }
                    else
                    {
                        everyNumCountsUp = false;
                        break;
                    }
                }
            }

            for (int i = 0; i < intNums.Count; i++)
            {
                if (i < intNums.Count-1)
                {
                    if (intNums[i] > intNums[i + 1])
                    {
                        //Debug.Log(intNums[i] + " is bigger then: " + intNums[i + 1]);
                        //if this number is greater then the next one
                    }
                    else
                    {
                        everyNumCountsdown = false;
                        break;
                    }
                }
            }

            if (everyNumCountsUp)
            {
                //Debug.Log("Line " + LineCount + " is counting up");

                for (int i = 0; i < intNums.Count; i++)
                {
                    if (i < intNums.Count-1)
                    {
                        if (intNums[i + 1] - intNums[i] > 3)
                        {
                            everyNumCountsUp = false;
                            break;
                        }
                    }
                }
            }
            else if (everyNumCountsdown)
            {
                //Debug.Log("Line " + LineCount + " is counting down");

                for (int i = 0; i < intNums.Count; i++)
                {
                    if (i < intNums.Count-1)
                    {
                        if (intNums[i] - intNums[i + 1] > 3)
                        {
                            everyNumCountsdown = false;
                            break;
                        }
                    }
                }
            }

            if (everyNumCountsUp || everyNumCountsdown)
            {
                Debug.Log("Line " + LineCount + " is safe");
                TotalSafeLines++;
            }
            else
            {
                Debug.Log("Line " + LineCount + " is NOT safe");
            }
        }
    }
}


//answer: 334