using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemesisMove : MonoBehaviour
{
    private Rigidbody2D rig;
    private Stats stats;
    public float vel;
    public float jumpForce;
    [SerializeField] LayerMask level;
    [SerializeField] Transform groundDetector;
    [SerializeField] private List<AttachedCoroutine<Collider2D>> jumpRoutines;
    private bool groundContact { get { return Physics2D.OverlapPoint(groundDetector.position, level); } }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        jumpRoutines = new();
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(vel * stats.speedFactor, rig.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "JumpPad")
        {
            //Start a Jump Coroutine attached to the respective Collider2D, and add to the list.
            var routine = new AttachedCoroutine<Collider2D>(StartCoroutine(Jump()), other);
            jumpRoutines.Add(routine);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "JumpPad")
        {
            //Stop and remove of the list all Coroutines with the respective Collider2D.
            foreach (var routine in jumpRoutines)
            {
                if (routine.origin == other)
                {
                    StopCoroutine(routine.routine);
                }
            }
            jumpRoutines.RemoveAll(routine => routine.origin == other);
        }
    }

    public IEnumerator Jump()
    {
        yield return new WaitUntil(() => groundContact);
        rig.velocity = new Vector2(rig.velocity.x, 0);
        rig.AddForce(new Vector2(0, jumpForce * stats.jumpFactor));
    }
}
