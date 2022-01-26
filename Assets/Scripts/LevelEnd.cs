using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private LayerMask Nemesis;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Nemesis))
        {
            var neme = other.gameObject.GetComponent<NemesisSprite>();
            neme.NextScene();
        }
    }
}
