using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    VehiclePart[,,] vehicleParts = new VehiclePart[10, 10, 10];
    Vector3 currentlyHoveredGridPosition;
    OutlineController outlineController;

    // Start is called before the first frame update
    void Start()
    {
        outlineController = OutlineController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        ControllerCheck();
    }

    private void FixedUpdate()
    {
        
    }

    void ControllerCheck()
    {
        Vector3 _plannedDirection = Vector3.zero;
        if(Input.GetKeyDown(KeyCode.W))
        {
            _plannedDirection.z++;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _plannedDirection.z--;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _plannedDirection.x--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _plannedDirection.x++;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _plannedDirection.y++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _plannedDirection.y--;
        }
        if (_plannedDirection == Vector3.zero) return;

        currentlyHoveredGridPosition = new Vector3(Mathf.Clamp(currentlyHoveredGridPosition.x + _plannedDirection.x, 0, vehicleParts.GetLength(0)), Mathf.Clamp(currentlyHoveredGridPosition.y + _plannedDirection.y, 0, vehicleParts.GetLength(1)), Mathf.Clamp(currentlyHoveredGridPosition.z + _plannedDirection.z, 0, vehicleParts.GetLength(2)));
        outlineController.UpdateOutlineMoveToLocation(currentlyHoveredGridPosition);
    }
}

public class gridTile
{
    public bool occupied;

}

public class VehiclePart
{
    
}
