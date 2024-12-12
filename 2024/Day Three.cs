using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayThree : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    //private List<string> eachLine;

    public List<string> Muls = new();

    public int total = 0;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        //eachLine = new List<string>();
        //eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        string[] muls = theWholeFileAsOneLongString.Split("mul");

        foreach (string line in muls)
        {
            //check format: (int,int)

            //if the first char is (
            if (line.Substring(0,1) == "(")
            {
                string[] numbs = line.Split(',');

                //if it has a ,
                if (numbs.Length > 1)
                {
                    if (int.TryParse(numbs[0].TrimStart('('), out int myValue))
                    {
                        if (myValue < 1000)
                        {
                            //first digit must be less then 3 chars

                            //then go on to check the second

                            string[] second = numbs[1].Split(')');

                            //second has a )
                            if (second.Length > 1)
                            {
                                if (int.TryParse(second[0], out int myValue2))
                                {
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

                //if the next char is a int


                //check if there is no second (will always be 1-3 num ints)

                //split at ) - everything after disragard

                //split at comma
            }
        }

        //each time "mul" comes up, check the nums after

        //split each character and check sequensially if it fits
    }
}


//Reminds for David:
//Sub string: - take a chunk of astring starting at a certian character point and counting a certian number of character up
//Trim: - cut a chunk off the end (or start?)
//Split: - split a string up into an array by any character(s)
//Character Array - split every character into a new line in an array
//Divide by lines - split every line into a new line in an array

//answer: 189600467