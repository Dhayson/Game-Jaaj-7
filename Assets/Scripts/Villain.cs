using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Villain : MonoBehaviour
{
    [SerializeField] private Vector2 mousePos;
    private VillainControl control;
    [SerializeField] private GameObject ice;
    [SerializeField] private GameObject wave;

    void Awake()
    {
        Type thisType = this.GetType();
        control = new();

        var method = thisType.GetMethod(HabilitySet.E.ToString());
        control.Skills.E.started += ctx => method.Invoke(this, null);

        var method2 = thisType.GetMethod(HabilitySet.W.ToString());
        control.Skills.W.started += ctx => method2.Invoke(this, null);
        //syntax: control.Skills.Q.started += ctx => Method();
    }
    void Start()
    {
        control.Skills.Enable();
        geloCDOG = geloCD;
        geloCD = 0;
        ondaCDOG = ondaCD;
        ondaCD = 0;
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (geloCD > 0) geloCD -= Time.fixedDeltaTime;
    }

    public void vazio() { }

    public float geloCD;
    private float geloCDOG;
    public void gelo()
    {
        if (geloCD <= 0)
        {
            Instantiate(ice, mousePos, ice.transform.rotation);
            geloCD = geloCDOG;
        }
    }
    public float ondaCD;
    private float ondaCDOG;
    public void onda()
    {
        if (ondaCD <= 0)
        {
            Instantiate(wave, mousePos, wave.transform.rotation);
            ondaCD = ondaCDOG;
        }
    }
}
