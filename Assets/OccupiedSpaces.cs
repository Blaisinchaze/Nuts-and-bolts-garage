using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedSpaces : MonoBehaviour
{    
    [SerializeField]
    public List<WholeTile> wholeTiles = new List<WholeTile>();


    //public Dictionary<Vector3, SpaceData> occupiedTiles = new Dictionary<Vector3, SpaceData>();

    private void OnDrawGizmosSelected()
    {
        foreach (var item in wholeTiles)
        {
            if (item.tileData.showTileLocation)
            {
                // Draw a semitransparent red cube at the transforms position
                Gizmos.color = new Color(1, 0, 0, 0.5f);
                Gizmos.DrawCube(transform.position + item.tileData.tileLocation, new Vector3(1, 1, 1));
            }
            foreach (var item2 in item.connectedTiles)
            {
                if (item2.showTileLocation)
                {
                    // Draw a semitransparent red cube at the transforms position
                    Gizmos.color = new Color(1, 0, 0, 0.5f);
                    Gizmos.DrawCube(transform.position + item2.tileLocation, new Vector3(1, 1, 1));
                }
            }
        }

    }
}

[System.Serializable]
public class WholeTile
{
    [SerializeField]
    public Tile tileData;
    [SerializeField]
    public Tile[] connectedTiles;

    public WholeTile()
    {
        tileData = new Tile();
        connectedTiles = new Tile[6];
        connectedTiles[0] = new Tile( Vector3Int.up);
        connectedTiles[1] = new Tile(Vector3Int.forward);
        connectedTiles[2]= new Tile(Vector3Int.right);
        connectedTiles[3]= new Tile(Vector3Int.back);
        connectedTiles[4]= new Tile(Vector3Int.left);
        connectedTiles[5] = new Tile(Vector3Int.down);
    }
}

public enum SpaceData { empty, centre, occupied, connectable};

[System.Serializable]
public class Tile
{
    public Vector3Int tileLocation;
    public SpaceData tileData;
    public bool showTileLocation;

    public Tile(Vector3Int? _tileLocation=null)
    {
        if (_tileLocation == null)
            tileLocation = Vector3Int.zero;
        else
        {
            tileLocation = _tileLocation.Value;
        }
    }
    //public Dictionary<Vector3, SpaceData> occupiedTiles;
    //public static int rows = 3;
    //public static int columns = 3;
    //public SpaceData[,] board = new SpaceData[columns, rows];
}



