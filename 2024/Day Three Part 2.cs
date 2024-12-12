using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayThreePart2 : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;

    public List<string> Muls = new();
    public List<string> Dos = new();

    public int total = 0;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;

        string[] dos = theWholeFileAsOneLongString.Split("do()");

        foreach(string line in dos)
        {
            //check for don't
            string[] donts = line.Split("don't()");

            Dos.Add(donts[0]);

            CheckLine(donts[0]);
        }
    }

    void CheckLine(string myLine)
    {
        string[] muls = myLine.Split("mul");

        foreach (string line in muls)
        {
            //check format: (int,int)

            if(line == "") { continue; }

            //if the first char is (
            if (line.Substring(0, 1) == "(")
            {
                string[] numbs = line.Split(',');

                //if it has a ,
                if (numbs.Length > 1)
                {
                    if (int.TryParse(numbs[0].TrimStart('('), out int myValue))
                    {
                        //first digit must be less then 3 chars
                        if (myValue < 1000)
                        {
                            string[] second = numbs[1].Split(')');

                            //second has a )
                            if (second.Length > 1)
                            {
                                if (int.TryParse(second[0], out int myValue2))
                                {
                                    //second digit must be less then 3 chars
                                    if (myValue2 < 1000)
                                    {
                                        Debug.Log("first: " + myValue + " second: " + myValue2);

                                        Muls.Add(line);

                                        total += (myValue * myValue2);
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
    }
}

//6416483 is too low

//107069718 is the answer