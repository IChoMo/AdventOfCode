using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySeven : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    private List<int> BinaryArray = new();
    private long LongestLineLength = 10;

    public long SumTotal = 0;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        //build binary array
        for (long i = 0; i < LongestLineLength; i++)
        {
            if (i == 0) { BinaryArray.Add(1); }
            else { BinaryArray.Add(BinaryArray[(int)i-1] * 2); }
        }

        //foreach line
        foreach (string line in eachLine)
        {
            //before and after result numbs
            string[] beforeAndAfter = line.Split(':');
            long sum = long.Parse(beforeAndAfter[0]);

            //split this line up to numbers
            string[] holder = beforeAndAfter[1].Split(' ');
            //remove blanks from line
            List<string> numbs = new();
            foreach (string spacer in holder) { if (spacer != "") { numbs.Add(spacer); } }

            //make sure Binary Array is Big Enough
            if (BinaryArray.Count < numbs.Count) { BinaryArray.Add(BinaryArray[^1] * 2); }

            //caculate the binary max for this line
            long BinaryMax = 0;
            for (long i = 0; i < numbs.Count-1; i++)
            { BinaryMax += BinaryArray[(int)i]; }

            for (long i = 0; i <= BinaryMax; i++)
            {
                long mySum = long.Parse(numbs[0]);
                string binaryCode = BinaryConverter((int)i);

                //convert to char array
                char[] c = binaryCode.ToCharArray();

                for(int x = 0; x < numbs.Count - 1; x++)
                {
                    if (c[x].ToString() == "1") //plus
                    { mySum += long.Parse(numbs[x + 1]); }
                    else //multiply
                    { mySum *= long.Parse(numbs[x + 1]); }
                }

                if (sum == mySum)
                { SumTotal += sum; break; }
            }
        }
    }

    string BinaryConverter(int numberInput)
    {
        string output = "";
        string holder = "";

        for (int i = BinaryArray.Count-1; i > -1; i--)
        {
            if(numberInput >= BinaryArray[i])
            {
                //this is a 1
                numberInput -= BinaryArray[i];
                holder = 1 + output;
                output = holder;
            }
            else
            {
                holder = 0 + output;
                output = holder;
            }
        }

        return output;
    }
}

//13185538892 is too low
//8401132154762