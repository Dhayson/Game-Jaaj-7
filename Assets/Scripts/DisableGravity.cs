using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rig = GetComponent<Rigidbody2D>();
        rig.gravityScale = 0;
        rig.velocity = Vector2.zero;
    }
}
