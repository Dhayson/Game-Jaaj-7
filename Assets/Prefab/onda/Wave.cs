using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField] private LayerMask Level;
    [SerializeField] private LayerMask Nemesis;
    [SerializeField] float velocity;
    [SerializeField] float acceleration;
    private bool isShrinking;
    private bool onNemesisContact;
    private float Resist
    {
        get
        {
            return Resistance.ResistanceNow.onda;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
        if (!onNemesisContact)
            rig.velocity += new Vector2(-acceleration * Time.fixedDeltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Nemesis))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();

            stats.speedBase += rig.velocity.x / (5 * Resist);

            stats.wet = true;
            if (stats.shock)
            {
                stats.superShock = true;
            }

            Debug.Log(Resist);
            Resistance.ResistanceStore.onda += 0.03f;

            onNemesisContact = true;
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

        if (Global.CompareLayer(other.gameObject.layer, Nemesis))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();
            stats.speedBase -= rig.velocity.x / (5 * Resist);

            stats.wet = false;
            stats.superShock = false;
            onNemesisContact = false;
        }
    }
}

