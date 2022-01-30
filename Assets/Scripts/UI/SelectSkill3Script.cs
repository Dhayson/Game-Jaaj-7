using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkill3Script : MonoBehaviour
{
    private Image[] display;
    // Start is called before the first frame update
    void Start()
    {
        display = GetComponentsInChildren<Image>();

        if (HabilitySet.A != Hability.vazio)
        {
            display[0].gameObject.SetActive(false);
        }
        else if (HabilitySet.W != Hability.vazio)
        {
            display[4].gameObject.SetActive(false);
        }
        else if (HabilitySet.R != Hability.vazio)
        {
            display[2].gameObject.SetActive(false);
        }
    }

}
