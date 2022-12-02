using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildManager : MonoBehaviour
{
    GameObject followTarget;
    VehiclePart[,,] vehicleParts = new VehiclePart[10, 10, 10];
    Vector3 currentlyHoveredGridPosition;
    OutlineController outlineController;

    // Start is called before the first frame update
    void Start()
    {
        outlineController = OutlineController.Instance;
        currentlyHoveredGridPosition = new Vector3((int)vehicleParts.GetLength(0) / 2, (int)vehicleParts.GetLength(1) / 2, (int)vehicleParts.GetLength(2) / 2);
        followTarget = GameObject.FindGameObjectWithTag("FollowTarget");
        followTarget.transform.position = currentlyHoveredGridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (outlineController == null)
            outlineController = OutlineController.Instance;
        //ControllerCheck();
    }

    private void FixedUpdate()
    {
        
    }

    public void Move(InputAction.CallbackContext value)
    {

        switch (value.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                Vector2 _plannedDirection = value.ReadValue<Vector2>();
                
                currentlyHoveredGridPosition = new Vector3(Mathf.Clamp(currentlyHoveredGridPosition.x + _plannedDirection.x, 0, vehicleParts.GetLength(0)), currentlyHoveredGridPosition.y, Mathf.Clamp(currentlyHoveredGridPosition.z + _plannedDirection.y, 0, vehicleParts.GetLength(2)));
                followTarget.transform.position = (currentlyHoveredGridPosition);
                //outlineController.UpdateOutlineMoveToLocation(currentlyHoveredGridPosition);
                break;
            case InputActionPhase.Canceled:
                break;
            default:
                break;
        }

    }    
    public void VerticalMove(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            float _plannedDirection =value.ReadValue<float>();
            currentlyHoveredGridPosition.y = Mathf.Clamp(currentlyHoveredGridPosition.y + _plannedDirection, 0, vehicleParts.GetLength(1));
            followTarget.transform.position = (currentlyHoveredGridPosition);
            //outlineController.UpdateOutlineMoveToLocation(currentlyHoveredGridPosition);
        }

    }
}

public class gridTile
{
    public bool occupied;

}

public class VehiclePart
{
    
}
