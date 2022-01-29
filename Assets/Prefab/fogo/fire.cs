using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField] private LayerMask Nemesis;
    private Rigidbody2D rig;
    [SerializeField] private float velocity;
    [SerializeField] private float time;
    private bool revert = false;
    private float Resist
    {
        get
        {
            return Resistance.ResistanceNow.fogo;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitTime());
        IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(time);
            revert = true;
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rig.angularVelocity = -360;
        if (!revert)
            rig.velocity = new Vector2(-velocity, 0);
        else
            rig.velocity = new Vector2(2 * velocity, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Nemesis))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();

            int damage;
            if (!revert)
            {
                damage = (int)(8 / Resist);
                Resistance.ResistanceStore.fogo += 0.05f;
            }
            else if (stats.wet)
            {
                damage = 0;
            }
            else
            {
                damage = (int)(18 / Resist);
                Resistance.ResistanceStore.fogo += 0.04f;
            }
            stats.Damage(damage);

        }
    }
}
