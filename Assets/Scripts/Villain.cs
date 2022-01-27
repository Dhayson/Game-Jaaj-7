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
    [SerializeField] private float geloCD;
    [SerializeField] private GameObject wave;
    [SerializeField] private float ondaCD;
    [SerializeField] private GameObject spike;
    [SerializeField] private float espinhoCD;
    [SerializeField] private GameObject shock;
    [SerializeField] private float raioCD;

    void Awake()
    {
        Type thisType = this.GetType();
        control = new();

        var method = thisType.GetMethod(HabilitySet.E.ToString());
        control.Skills.E.started += ctx => method.Invoke(this, null);

        var method2 = thisType.GetMethod(HabilitySet.W.ToString());
        control.Skills.W.started += ctx => method2.Invoke(this, null);

        var method3 = thisType.GetMethod(HabilitySet.R.ToString());
        control.Skills.R.started += ctx => method3.Invoke(this, null);

        var method4 = thisType.GetMethod(HabilitySet.A.ToString());
        control.Skills.A.started += ctx => method4.Invoke(this, null);
        //syntax: control.Skills.Q.started += ctx => Method();
    }
    void Start()
    {
        control.Skills.Enable();
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (E_CD > 0) E_CD -= Time.fixedDeltaTime;
        if (W_CD > 0) W_CD -= Time.fixedDeltaTime;
        if (R_CD > 0) R_CD -= Time.fixedDeltaTime;
        if (A_CD > 0) A_CD -= Time.fixedDeltaTime;
    }

    public void vazio() { }

    public float E_CD;
    private float E_CDog;
    public void gelo()
    {
        E_CDog = geloCD;
        if (E_CD <= 0)
        {
            Instantiate(ice, mousePos, ice.transform.rotation);
            E_CD = E_CDog;
        }
    }

    public float W_CD;
    private float W_CDog;
    public void onda()
    {
        W_CDog = ondaCD;
        if (W_CD <= 0)
        {
            Instantiate(wave, mousePos, wave.transform.rotation);
            W_CD = W_CDog;
        }
    }

    public float R_CD;
    private float R_CDog;
    public void espinho()
    {
        R_CDog = espinhoCD;
        if (R_CD <= 0)
        {
            Instantiate(spike, mousePos, spike.transform.rotation);
            R_CD = R_CDog;
        }
    }

    public float A_CD;
    private float A_CDog;
    public void raio()
    {
        A_CDog = raioCD;
        if (A_CD <= 0)
        {
            Instantiate(shock, mousePos, shock.transform.rotation);
            A_CD = A_CDog;
        }
    }
}
