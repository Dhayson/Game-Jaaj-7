using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Villain : MonoBehaviour
{
    [SerializeField] private Vector2 mousePos;
    private VillainControl control;

    void Awake()
    {
        Type thisType = this.GetType();
        control = new();
        if (HabilitySet.E != Hability.vazio)
        {
            var method = thisType.GetMethod(HabilitySet.E.ToString());
            control.Skills.E.started += ctx => method.Invoke(this, null);
        }
        //syntax: control.Skills.Q.started += ctx => Method();
    }
    void Start()
    {
        control.Skills.Enable();
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void gelo()
    {
        Debug.Log("frio");
    }
}
