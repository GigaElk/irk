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

        for(int partCounter = 0; partCounter < LevelLength; partCounter++)
        {
            Debug.Log("Processing part " + partCounter);
            Vector3 PartPos = new Vector3((sectionWidth * partCounter) - 10, -2.5f, 0);
            Instantiate(ForestSections[Random.Range(0, ForestSections.Length)], PartPos, Quaternion.identity);
        }
        Debug.Log("DONE!");
    }
}
