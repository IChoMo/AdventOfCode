using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayFive : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> data1;
    private List<string> data2;

    public int total = 0;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        data1 = new List<string>();
        data2 = new List<string>();
        data1.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));
        data2.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));
        List<string> dataPlaceHolder = new();
        int intPlaceHolder = 0;

        //fill data place holder with all lines up to the break
        foreach (string line in data1)
        {
            if (line == "") { break; }
            dataPlaceHolder.Add(line);
        }

        //update data1 to the new found data
        data1 = dataPlaceHolder;
        dataPlaceHolder = new List<string>();

        //find line location of the split
        for (int i = 0; i < data2.Count; i++)
        {
            if (data2[i] != "") { continue; }
            intPlaceHolder = i;
            break;
        }

        //fill data place holder with text after the split
        for (int i = 0; i < data2.Count; i++)
        {
            if (i <= intPlaceHolder) { continue; }
            dataPlaceHolder.Add(data2[i]);
        }

        //update data 2 to just text after the split
        data2 = dataPlaceHolder;

        //make a new array for good data
        List<string> goodData = new();

        foreach (string line in data2)
        {
            //split up the line into an array of number
            dataPlaceHolder = new List<string>();
            dataPlaceHolder.AddRange(line.Split(","[0]));
            goodData.Add(line);

            //for each number in the array
            for (int i = 0; i < dataPlaceHolder.Count; i++)
            {
                bool lineCanbeskipped = false;
                //add all faliures to an array
                //all the others are good

                //for every number between the current number and the top of the array
                for (int x = i+1; x < dataPlaceHolder.Count; x++)
                {
                    if (lineCanbeskipped) { lineCanbeskipped = false; break; } //TODO remove the line from the good data

                    //check each line in data 1
                    foreach(string lineNum in data1)
                    {
                        //if x is on a line where i also appears
                        if (lineNum.Contains(dataPlaceHolder[x]) && lineNum.Contains(dataPlaceHolder[i]))
                        {
                            //break line into parts
                            string[] numbs = lineNum.Split('|');

                            //check to see that x comes after i
                            if (numbs[0] == dataPlaceHolder[i])
                            {
                                //PASSED
                                //Debug.Log("PASSED rule: " + lineNum + "on number: " + (i+1) + "one line: " + line);
                                continue;
                            }
                            else
                            {
                                //DID NOT PASS
                                lineCanbeskipped = true;
                                //Debug.Log("LINE FAILED: " + line);
                                goodData.Remove(line);
                                break;
                            }
                        }
                    }
                }
            }
        }

        foreach (string line in goodData)
        {
            //Debug.Log("This is a good line: " + line);

            //find line center and add tot total
            string[] numbs = line.Split(',');

            //Debug.Log("center number is: " + numbs[numbs.Length/2]);
            total += int.Parse(numbs[numbs.Length / 2]);
        }
    }
}

//answer: 5991