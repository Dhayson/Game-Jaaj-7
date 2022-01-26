using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObj : MonoBehaviour
{
    [SerializeField] private GameObject from;
    [SerializeField] private GameObject to;
    public void Switch()
    {
        from.SetActive(false);
        to.SetActive(true);
    }
}
