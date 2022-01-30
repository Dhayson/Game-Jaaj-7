using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField] private LayerMask Level;
    [SerializeField] private LayerMask Entity;
    [SerializeField] private LayerMask Nemesis;
    [SerializeField] float velocity;
    [SerializeField] float acceleration;
    private bool isShrinking;
    private bool onEntityContact;
    private float Resist
    {
        get
        {
            return Resistance.ResistanceNow.onda;
        }
    }
    private List<Collider2D> triggerList;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        triggerList = new();
        rig.gravityScale = 0;
        rig.velocity = new Vector2(-velocity, 0);
    }

    void FixedUpdate()
    {
        if (transform.localScale.x <= 0.05f)
        {
            transform.position = new Vector2(69000, 69000);
            Destroy(gameObject, 1);
        }
        if (isShrinking)
        {
            transform.localScale *= 0.8f;
        }
        onEntityContact = triggerList.Count > 0;

        if (!onEntityContact)
            rig.velocity += new Vector2(-acceleration * Time.fixedDeltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Entity))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();
            if (Global.CompareLayer(other.gameObject.layer, Nemesis))
                stats.drag += rig.velocity.x / (Resist);
            else
                stats.drag += rig.velocity.x;

            stats.wet = true;

            Resistance.ResistanceStore.onda += 0.025f;
            triggerList.Add(other);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Level))
        {
            isShrinking = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Level))
        {
            isShrinking = false;
        }

        if (Global.CompareLayer(other.gameObject.layer, Entity))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();

            if (Global.CompareLayer(other.gameObject.layer, Nemesis))
                stats.drag -= rig.velocity.x / (Resist);
            else
                stats.drag -= rig.velocity.x;

            stats.wet = false;
            triggerList.Remove(other);
        }
    }
}

