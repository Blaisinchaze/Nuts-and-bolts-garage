using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedSpaces : MonoBehaviour
{
    public space TopLayer;
    public space MiddleLayer;
    public space BottomLayer;

}


public enum SpaceData { empty, centre, occupied, connectable};

[System.Serializable]
public class space
{
#if UNITY_EDITOR
    [HideInInspector] public bool showBoard;
#endif
    public static int rows = 3;
    public static int columns = 3;
    public SpaceData[,] board = new SpaceData[columns, rows];
}

