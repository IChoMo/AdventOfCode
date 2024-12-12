using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayFourPartTwo : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public char[] charactersLine1;
    public char[] charactersLine2;
    public char[] charactersLine3;

    public int totalCount = 0;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        //foreach line
        for (int i = 0; i < eachLine.Count; i++)
        {
            //if possible, find lines above and below
            if (i > 0) { charactersLine1 = eachLine[i - 1].ToCharArray(); }
            charactersLine2 = eachLine[i].ToCharArray();
            if (eachLine.Count - 1 > i) { charactersLine3 = eachLine[i + 1].ToCharArray(); }

            string aChar = "MAS";
            char[] myChars = aChar.ToCharArray();

            //foreach character
            for(int x = 0; x < charactersLine2.Length; x++)
            {
                //if this character is an A
                if (charactersLine2[x] == myChars[1])
                {
                    //check if theres room above and below
                    if (i > 0 && eachLine.Count - 1 > i)
                    {
                        //check if theres room infront and behind
                        if (charactersLine2.Length - 1 > x && x > 0)
                        {
                            Debug.Log("viable option and the length: " + charactersLine2.Length);

                            //check M's at front
                            if (charactersLine1[x - 1] == myChars[0] && charactersLine1[x + 1] == myChars[2] && charactersLine3[x - 1] == myChars[0] && charactersLine3[x + 1] == myChars[2])
                            {
                                totalCount++;
                            }

                            //check M's at back
                            if (charactersLine1[x - 1] == myChars[2] && charactersLine1[x + 1] == myChars[0] && charactersLine3[x - 1] == myChars[2] && charactersLine3[x + 1] == myChars[0])
                            {
                                totalCount++;
                            }

                            //check M's at bottom
                            if (charactersLine1[x - 1] == myChars[2] && charactersLine1[x + 1] == myChars[2] && charactersLine3[x - 1] == myChars[0] && charactersLine3[x + 1] == myChars[0])
                            {
                                totalCount++;
                            }

                            //check M's at top
                            if (charactersLine1[x - 1] == myChars[0] && charactersLine1[x + 1] == myChars[0] && charactersLine3[x - 1] == myChars[2] && charactersLine3[x + 1] == myChars[2])
                            {
                                totalCount++;
                            }
                        }

                    }
                }
            }
        }
    }
}

//862 is too low

//1886 is the answer