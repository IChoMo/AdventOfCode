using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTwo : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;

    public float TotalIDPoint;

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        foreach (string line in eachLine)
        {
            string[] pairs = line.Split(':');
            string[] GameIDs = pairs[0].Split(' ');
            float IDValue = float.Parse(GameIDs[1]);
            float redValue = 0;
            float greenValue = 0;
            float blueValue = 0;
            string[] colourValues = pairs[1].Split(';');

            foreach (string allListedColours in colourValues)
            {
                string[] listedColours = allListedColours.Split(',');

                foreach (string colour in listedColours)
                {
                    string[] thisColous = colour.Split(' ');
                    if (thisColous[2] == "blue") { blueValue = float.Parse(thisColous[1]); }
                    else if (thisColous[2] == "red") { redValue = float.Parse(thisColous[1]); }
                    else if (thisColous[2] == "green") { greenValue = float.Parse(thisColous[1]); }
                    if (blueValue > 14 || redValue > 12 || greenValue > 13) { break; }
                }
                if (blueValue > 14 || redValue > 12 || greenValue > 13) { break; }
            }
            if (redValue <= 12 && greenValue <= 13 && blueValue <= 14) { TotalIDPoint += IDValue; }
        }
    }
}
