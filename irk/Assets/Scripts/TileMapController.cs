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
}
