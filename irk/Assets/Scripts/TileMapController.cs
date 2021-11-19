using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDGEPOSITION
{
    LOW, MEDIUM, HIGH, DOUBLE
}

public class TileMapController : MonoBehaviour
{
    public EDGEPOSITION headPosition = EDGEPOSITION.LOW;
    public EDGEPOSITION tailPosition = EDGEPOSITION.LOW;
    public bool canBeFirst = true;
    public bool canBeFinal = true;
    public bool isGoal = false;
    public GameObject goalObject = null;

    void Start()
    {
        if(canBeFinal == false)
            isGoal = false;
        else if(goalObject != null)
        {
            if(isGoal)
                goalObject.SetActive(true);
            else
                goalObject.SetActive(false);
        }
    }

    public void SetGoal(bool goalToggle)
    {
        if(canBeFinal == false)
        {
            isGoal = false;
            return;
        }

        isGoal = goalToggle;
        if(isGoal)
            goalObject.SetActive(true);
        else
            goalObject.SetActive(false);
    }
}
