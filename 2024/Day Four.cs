using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayFour : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public char[] charactersLine1;
    public char[] charactersLine2;
    public char[] charactersLine3;
    public char[] charactersLine4;
    public char[] charactersLine5;
    public char[] charactersLine6;
    public char[] charactersLine7;

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
            if (i > 2) { charactersLine1 = eachLine[i - 3].ToCharArray(); }
            if (i > 1) { charactersLine2 = eachLine[i - 2].ToCharArray(); }
            if (i > 0) { charactersLine3 = eachLine[i - 1].ToCharArray(); }
            charactersLine4 = eachLine[i].ToCharArray();
            if (eachLine.Count - 1 > i) { charactersLine5 = eachLine[i + 1].ToCharArray(); }
            if (eachLine.Count - 1 > i + 1) { charactersLine6 = eachLine[i + 2].ToCharArray(); }
            if (eachLine.Count - 1 > i + 2) { charactersLine7 = eachLine[i + 3].ToCharArray(); }

            string aChar = "XMAS";
            char[] myChars = aChar.ToCharArray();

            //foreach character
            for(int x = 0; x < charactersLine4.Length; x++)
            {
                //if this character is an X
                if (charactersLine4[x] == myChars[0])
                {
                    //check all states:

                    //forward

                    //if there is room for "MAS" infront on this line
                    if (charactersLine4.Length > x + 3)
                    {
                        //if the next ones are M, A, S then add a point
                        if (charactersLine4[x+1] == myChars[1] && charactersLine4[x + 2] == myChars[2] && charactersLine4[x + 3] == myChars[3]) { totalCount++; }
                    }

                    //backward

                    //if there is room for "SAM" behind on this line
                    if (x > 2)
                    {
                        //if the previous ones are S, A, M then add a point
                        if (charactersLine4[x - 1] == myChars[1] && charactersLine4[x - 2] == myChars[2] && charactersLine4[x - 3] == myChars[3]) { totalCount++; }
                    }

                    //up

                    //if there is room above to fit M, A, S
                    if (i > 2)
                    {
                        if (charactersLine3[x] == myChars[1] && charactersLine2[x] == myChars[2] && charactersLine1[x] == myChars[3]) { totalCount++; }
                    }

                    //down

                    //if there is room below to fit M, A, S
                    if (eachLine.Count-1 > i + 2)
                    {
                        if (charactersLine5[x] == myChars[1] && charactersLine6[x] == myChars[2] && charactersLine7[x] == myChars[3]) { totalCount++; }
                    }

                    //diagnoal forward up

                    //if there is room in front and above for M, A, S
                    if (i > 2 && charactersLine4.Length > x + 3)
                    {
                        if (charactersLine3[x + 1] == myChars[1] && charactersLine2[x + 2] == myChars[2] && charactersLine1[x + 3] == myChars[3]) { totalCount++; }
                    }

                    //diadnoal forward down

                    //if there is room below and forward for M, A, S
                    if (eachLine.Count-1 > i + 2 && charactersLine4.Length > x + 3)
                    {
                        if (charactersLine5[x + 1] == myChars[1] && charactersLine6[x + 2] == myChars[2] && charactersLine7[x + 3] == myChars[3]) { totalCount++; }
                    }

                    //diagnoal backward down

                    //if there is room below and backward for M, A, S
                    if (eachLine.Count-1 > i + 2 && x > 2)
                    {
                        if (charactersLine5[x - 1] == myChars[1] && charactersLine6[x - 2] == myChars[2] && charactersLine7[x - 3] == myChars[3]) { totalCount++; }
                    }

                    //diagonal backward up

                    //if there is room behind and above for M, A, S
                    if (i > 2 && x > 2)
                    {
                        if (charactersLine3[x - 1] == myChars[1] && charactersLine2[x - 2] == myChars[2] && charactersLine1[x - 3] == myChars[3]) { totalCount++; }
                    }
                }
            }
        }
    }
}

//2531 is too low
//2533 is also too low
//2547 is too high!

//2545 is the answer!