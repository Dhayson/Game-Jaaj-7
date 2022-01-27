using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowLife : MonoBehaviour
{
    private Stats stats;
    private TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponentInParent<Stats>();
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = stats.Health.ToString();
    }
}
