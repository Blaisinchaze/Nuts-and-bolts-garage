using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    public static OutlineController Instance;
    private Vector3Int moveToLocation;
    private float speed = 5;
    private bool move;
    GameObject followTarget;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        followTarget = GameObject.FindGameObjectWithTag("FollowTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(transform.position != followTarget.transform.position)
            transform.position = Vector3.MoveTowards(transform.position, followTarget.transform.position, speed * Time.deltaTime);
    }
}
