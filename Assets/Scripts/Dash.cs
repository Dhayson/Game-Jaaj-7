using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Stats>(out Stats stats))
        {
            stats.speedMultiplier *= speedMultiplier;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Stats>(out Stats stats))
        {
            stats.speedMultiplier /= speedMultiplier;
        }
    }
}
