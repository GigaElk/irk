/*
Generates a level for the game based on a few options set in the editor.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LEVELTHEME
{
    FOREST
}

public class GenerateLevel : MonoBehaviour
{
    [Tooltip("The Level Number")]
    public int LevelNumber = 1;
    [Tooltip("The theme for this level")]
    public LEVELTHEME theme = LEVELTHEME.FOREST;
    [Tooltip("Higher value increases the chance of enemies")]
    public int Difficulty = 0;
    [Tooltip("Sets how many level peices to use in the level.")]
    public int LevelLength = 100;

    [Tooltip("There are no pickups yet...but when there are this should turn them off and on")]
    public bool IncludePickups = false;

    [Tooltip("An object that represents the goal for this level.")]
    public GameObject GoalObject;
    [Tooltip("Prefabs used for each part of the FOREST levels.")]
    public GameObject[] ForestSections;

    private int sectionWidth = 20; //Each section is 20 tiles wide.

    void Start()
    {
        GenerateTheLevelParts();
    }

    //Generates the level...
    private void GenerateTheLevelParts()
    {
        if(ForestSections.Length == 0) return;

        EDGEPOSITION previousTail = EDGEPOSITION.LOW;
        for(int partCounter = 0; partCounter < LevelLength; partCounter++)
        {
            Debug.Log("Processing part " + partCounter);
            Vector3 PartPos = new Vector3((sectionWidth * partCounter) - 10, -2.5f, 0);
            bool partIsGoal = false;
            bool validMatch = false;

            //Select a valid head section based on previous tail...
            GameObject chosenSection = ForestSections[Random.Range(0, ForestSections.Length)];

            do
            {
                if(partCounter == 0)
                {
                    validMatch = chosenSection.GetComponent<TileMapController>().canBeFirst;
                }
                else if(chosenSection.GetComponent<TileMapController>().headPosition == previousTail)
                {
                    //Keep checking until section is found with the same head as the previous tail
                    if(partCounter == LevelLength - 1 && chosenSection.GetComponent<TileMapController>().canBeFinal)
                    {
                        validMatch = true;
                        partIsGoal = true;
                    }
                    else
                        validMatch = true;
                }
                else
                    chosenSection = ForestSections[Random.Range(0, ForestSections.Length)];
            } while(!validMatch);
            
            previousTail = chosenSection.GetComponent<TileMapController>().tailPosition;
            GameObject newBit = Instantiate(chosenSection, PartPos, Quaternion.identity);
            //Set the object...
            //newBit.GetComponent<TileMapController>().isGoal = partIsGoal;
            newBit.GetComponent<TileMapController>().SetGoal(partIsGoal);
        }
        Debug.Log("DONE!");
    }
}
