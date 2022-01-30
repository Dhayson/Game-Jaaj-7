using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        while (true)
        {
            col.enabled = false;
            yield return new WaitForSeconds(2f);
            col.enabled = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
