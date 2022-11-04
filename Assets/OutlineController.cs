using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    public static OutlineController Instance;
    private Vector3 moveToLocation;
    private float speed = 5;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!move) return;
        transform.position = Vector3.MoveTowards(transform.position, moveToLocation, speed * Time.deltaTime);
        if (transform.position == moveToLocation) move = false;
    }

    public void UpdateOutlineMoveToLocation(Vector3 _moveToVector)
    {
        moveToLocation = _moveToVector;
        move = true;
    }
}
