using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemesisMove : MonoBehaviour
{
    private Rigidbody2D rig;
    public float vel;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(vel, rig.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "JumpPad")
        {
            Jump();
        }
    }

    public void Jump()
    {
        rig.AddForce(new Vector2(0, jumpForce));
    }
}
