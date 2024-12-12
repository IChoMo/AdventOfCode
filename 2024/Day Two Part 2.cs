using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTwoPart2 : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public int TotalSafeLines = 0;

    private int LineCount = 0;

    //now add a tolerance of one failure

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        foreach (string line in eachLine)
        {
            if (LineTest(line))
            {
                TotalSafeLines++;
            }
            else
            {
                //if it fails

                string[] numbers = line.Split(' ');
                List<int> intNums = new();

                foreach (string num in numbers)
                {
                    if (int.TryParse(num, out int myValue)) { intNums.Add(myValue); }
                }

                for (int runcount = 0; runcount < intNums.Count; runcount++)
                {
                    //create a new string with all numers except the one that is on this run count
                    string newLine = "";

                    for (int i = 0; i < intNums.Count; i++)
                    {
                        //if its the same, skip it, and try the same test without it
                        if (i == runcount) { continue; }
                        newLine += " " + intNums[i];
                    }

                    if (LineTest(newLine))
                    {
                        //if the line works with the new change
                        TotalSafeLines++;
                        break;
                    }
                }
            }
        }
    }

    bool LineTest(string line)
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
            if (i < intNums.Count - 1)
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
            if (i < intNums.Count - 1)
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
                if (i < intNums.Count - 1)
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
                if (i < intNums.Count - 1)
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
            return true;
        }
        else
        {
            Debug.Log("Line " + LineCount + " is NOT safe");
            return false;
        }
    }
}

//Answer: 400