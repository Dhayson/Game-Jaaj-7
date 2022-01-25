using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    [SerializeField] private float jumpMultiplier;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Stats>(out Stats stats))
        {
            stats.jumpFactor *= jumpMultiplier;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Stats>(out Stats stats))
        {
            stats.jumpFactor /= jumpMultiplier;
        }
    }
}
