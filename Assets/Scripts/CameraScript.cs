using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform follow;
    private Transform trans;
    private Vector3 relativePosition;

    void Start()
    {
        trans = GetComponent<Transform>();
        relativePosition = new Vector3(trans.position.x - follow.position.x, 0, 0);
    }

    void FixedUpdate()
    {
        //make the camera follow the transform x axis.
        trans.position = new Vector3(follow.position.x, trans.position.y, trans.position.z) + relativePosition;
    }
}
