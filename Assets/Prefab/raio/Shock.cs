using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : MonoBehaviour
{
    [SerializeField] private LayerMask Nemesis;
    [SerializeField] private Collider2D col;
    [SerializeField] private GameObject super;
    private List<(Stats, int)> allStats;
    private List<(Rigidbody2D, Vector2)> allRigs;
    private float Resist
    {
        get
        {
            return Resistance.ResistanceNow.raio;
        }
    }
    private float Corrected(float res, float max)
    {
        //A function that increases with more resistance, but the limit is the max value at infinity.
        return (-(max - 1) / res) + max;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Activate());
        allStats = new();
        allRigs = new();
    }

    private IEnumerator Activate()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1);

        transform.localScale *= 2;
        col.enabled = true;
        yield return new WaitForSeconds(1);

        foreach (var stats in allStats)
        {
            stats.Item1.shock = false;
            stats.Item1.RemoveColor(stats.Item2);
        }
        foreach ((Rigidbody2D, Vector2) rigVel in allRigs)
        {
            rigVel.Item1.velocity = rigVel.Item2;
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Nemesis))
        {
            Debug.Log("Shock");

            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();
            Rigidbody2D rig = nemesis.GetComponent<Rigidbody2D>();

            int damage = (int)(15 / Resist);
            stats.Damage(damage);

            int iden = UniqueNumber.Next();
            stats.colorFactor = (Color.yellow, iden);
            stats.shock = true;
            allStats.Add((stats, iden));

            StartCoroutine(NormalShock(rig, stats));

            Resistance.ResistanceStore.raio += 0.12f;
        }
    }

    IEnumerator NormalShock(Rigidbody2D rig, Stats stats)
    {
        Vector2 vel;
        Vector2 rigVel = rig.velocity;
        vel = rigVel * (0.5f * Corrected(Resist, 2));

        allRigs.Add((rig, vel));
        StartCoroutine(SuperShock(rig, stats, rigVel));

        while (true)
        {
            rig.velocity = new Vector2(0, 0);
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator SuperShock(Rigidbody2D rig, Stats stats, Vector2 rigVel)
    {
        yield return new WaitUntil(() => stats.superShock);

        super.SetActive(true);

        int damage = (int)(10 / (Resist * Resistance.ResistanceNow.onda));
        stats.Damage(damage);

        Vector2 vel = rigVel * (0.1f * Corrected(Resist * Resistance.ResistanceNow.onda, 10));
        for (int i = 0; i < allRigs.Count; i++)
        {
            if (ReferenceEquals(rig, allRigs[i].Item1))
            {
                allRigs[i] = (rig, vel);
            }
        }

    }
}
