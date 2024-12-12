using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySix : MonoBehaviour
{
    public TextAsset dictionaryTextFile;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;
    private List<string> eachSlot;

    public int totalMoves = 0;

    private string currentDirection = "up";

    void Start()
    {
        theWholeFileAsOneLongString = dictionaryTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(theWholeFileAsOneLongString.Split("\n"[0]));

        //for each line
        for(int LineNumb = 0; LineNumb < eachLine.Count; LineNumb++)
        {
            //make an list of character
            eachSlot = new List<string>();

            //add all character into eachSlot list
            foreach(char myChar in eachLine[LineNumb].ToCharArray()) { eachSlot.Add("" + myChar); }

            //for each numberSlot in the line
            for (int numberSlot = 0; numberSlot < eachSlot.Count; numberSlot++)
            {
                //find the ^ starting position
                if (eachSlot[numberSlot] == "^")
                {
                    //Debug.Log("^ is located at line " + LineNumb + " slot " + numberSlot);
                    totalMoves = simulation(LineNumb, numberSlot, eachLine);
                    break;
                }
            }
        }
    }

    int simulation(int startingLine, int startingPos, List<string> lines)
    {
        int totalNumofSlots = 0;
        bool simulationTime = true;
        int currentVerticalPos = startingLine;
        int currentHorozontalPos = startingPos;
        //Debug.Log("START: Current Pos: " + currentVerticalPos + currentHorozontalPos);

        do
        {
            if (currentDirection == "up")
            {
                //if there is a line above this
                if (currentVerticalPos > 0)
                {
                    //if the slot above this is free
                    if (lines[currentVerticalPos - 1].ToCharArray()[currentHorozontalPos].ToString() != "#")
                    {
                        //creating a new line to replace the old one
                        string newLineWithX = "";
                        //for each character in the old line
                        for (int slot = 0; slot < lines[currentVerticalPos].Length; slot++)
                        {
                            //if its in the pos of the old one, change it to X
                            if (slot == currentHorozontalPos)
                            { newLineWithX += "X"; }
                            else // else keep it the same as previous character
                            { newLineWithX += lines[currentVerticalPos].ToCharArray()[slot]; }
                        }

                        //set the old line to the new line with the added X
                        lines[currentVerticalPos] = newLineWithX;
                        //set current pos to new slot
                        currentVerticalPos -= 1;

                        //Debug.Log("MOVED UP: Current Pos: " + currentVerticalPos + currentHorozontalPos);
                    }
                    else // if the slot == #
                    { currentDirection = "right"; }
                }
                else // if theres nothing above, we are exiting the simulation
                { simulationTime = false; }
            }
            else if (currentDirection == "right")
            {
                //if there is more chracters on this line (to the right)
                if (currentHorozontalPos < lines[currentVerticalPos].Length)
                {
                    //if the slot to the right is free
                    if (lines[currentVerticalPos].ToCharArray()[currentHorozontalPos + 1].ToString() != "#")
                    {
                        //creating a new line to replace the old one
                        string newLineWithX = "";
                        //for each character in the old line
                        for (int slot = 0; slot < lines[currentVerticalPos].Length; slot++)
                        {
                            //if its in the pos of the old one, change it to X
                            if (slot == currentHorozontalPos)
                            { newLineWithX += "X"; }
                            else // else keep it the same as previous character
                            { newLineWithX += lines[currentVerticalPos].ToCharArray()[slot]; }
                        }

                        //set the old line to the new line with the added X
                        lines[currentVerticalPos] = newLineWithX;
                        //set current pos to new slot
                        currentHorozontalPos += 1;

                        //Debug.Log("MOVED RIGHT: Current Pos: " + currentVerticalPos + currentHorozontalPos);
                    }
                    else // if the slot == #
                    { currentDirection = "down"; }
                }
                else // if this is the last character on this line // exit simulation
                { simulationTime = false; }
            }
            else if (currentDirection == "down")
            {
                //if there is a line above this
                if (currentVerticalPos < lines.Count-1)
                {
                    //if the slot below this is free
                    if (lines[currentVerticalPos + 1].ToCharArray()[currentHorozontalPos].ToString() != "#")
                    {
                        //creating a new line to replace the old one
                        string newLineWithX = "";
                        //for each character in the old line
                        for (int slot = 0; slot < lines[currentVerticalPos].Length; slot++)
                        {
                            //if its in the pos of the old one, change it to X
                            if (slot == currentHorozontalPos)
                            { newLineWithX += "X"; }
                            else // else keep it the same as previous character
                            { newLineWithX += lines[currentVerticalPos].ToCharArray()[slot]; }
                        }

                        //set the old line to the new line with the added X
                        lines[currentVerticalPos] = newLineWithX;
                        //set current pos to new slot
                        currentVerticalPos += 1;

                        //Debug.Log("MOVED DOWN: Current Pos: " + currentVerticalPos + currentHorozontalPos);
                    }
                    else // if the slot == #
                    { currentDirection = "left"; }
                }
                else // if theres nothing below, we are exiting the simulation
                { simulationTime = false; }
            }
            else if (currentDirection == "left")
            {
                //if there is more chracters on this line (to the right)
                if (currentHorozontalPos > 0)
                {
                    //if the slot to the left is free
                    if (lines[currentVerticalPos].ToCharArray()[currentHorozontalPos - 1].ToString() != "#")
                    {
                        //creating a new line to replace the old one
                        string newLineWithX = "";
                        //for each character in the old line
                        for (int slot = 0; slot < lines[currentVerticalPos].Length; slot++)
                        {
                            //if its in the pos of the old one, change it to X
                            if (slot == currentHorozontalPos)
                            { newLineWithX += "X"; }
                            else // else keep it the same as previous character
                            { newLineWithX += lines[currentVerticalPos].ToCharArray()[slot]; }
                        }

                        //set the old line to the new line with the added X
                        lines[currentVerticalPos] = newLineWithX;
                        //set current pos to new slot
                        currentHorozontalPos -= 1;

                        //Debug.Log("MOVED LEFT: Current Pos: " + currentVerticalPos + currentHorozontalPos);
                    }
                    else // if the slot == #
                    { currentDirection = "up"; }
                }
                else // if this is the first character on this line // exit simulation
                { simulationTime = false; }
            }
        } while (simulationTime);

        //Add up and count all X's
        foreach (string line in lines)
        {
            Debug.Log("Simulation has ended");

            foreach(char character in line.ToCharArray())
            {
                if(character.ToString() == "X")
                {
                    totalNumofSlots++;
                }
            }
        }

        //Add one for the last exit positon
        totalNumofSlots++;
        return totalNumofSlots;
    }
}