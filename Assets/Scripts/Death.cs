using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private LayerMask Entity;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Entity))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();
            stats.Kill();
        }
    }
}
