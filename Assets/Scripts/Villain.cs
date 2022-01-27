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
    public float geloCD;
    [SerializeField] private GameObject wave;
    public float ondaCD;
    [SerializeField] private GameObject spike;
    public float espinhoCD;
    [SerializeField] private GameObject shock;
    public float raioCD;

    public Float2 E_CD; private Float2 E_CDog;
    public Float2 W_CD; private Float2 W_CDog;
    public Float2 R_CD; private Float2 R_CDog;
    public Float2 A_CD; private Float2 A_CDog;

    void Awake()
    {
        E_CD = new(); E_CDog = new();
        W_CD = new(); W_CDog = new();
        R_CD = new(); R_CDog = new();
        A_CD = new(); A_CDog = new();

        Type thisType = this.GetType();
        control = new();

        var method = thisType.GetMethod(HabilitySet.E.ToString());
        control.Skills.E.started += ctx => method.Invoke(this, new object[] { E_CD, E_CDog });
        E_CDog.value = (float)thisType.GetField($"{HabilitySet.E.ToString()}CD").GetValue(this);

        var method2 = thisType.GetMethod(HabilitySet.W.ToString());
        control.Skills.W.started += ctx => method2.Invoke(this, new object[] { W_CD, W_CDog });
        W_CDog.value = (float)thisType.GetField($"{HabilitySet.W.ToString()}CD").GetValue(this);

        var method3 = thisType.GetMethod(HabilitySet.R.ToString());
        control.Skills.R.started += ctx => method3.Invoke(this, new object[] { R_CD, R_CDog });
        R_CDog.value = (float)thisType.GetField($"{HabilitySet.R.ToString()}CD").GetValue(this);

        var method4 = thisType.GetMethod(HabilitySet.A.ToString());
        control.Skills.A.started += ctx => method4.Invoke(this, new object[] { A_CD, A_CDog });
        A_CDog.value = (float)thisType.GetField($"{HabilitySet.A.ToString()}CD").GetValue(this);
        //syntax: control.Skills.Q.started += ctx => Method();
    }
    void Start()
    {
        control.Skills.Enable();
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (E_CD.value > 0) E_CD.value -= Time.fixedDeltaTime;
        if (W_CD.value > 0) W_CD.value -= Time.fixedDeltaTime;
        if (R_CD.value > 0) R_CD.value -= Time.fixedDeltaTime;
        if (A_CD.value > 0) A_CD.value -= Time.fixedDeltaTime;
    }

    [NonSerialized] public float vazioCD;
    public void vazio(Float2 cd, Float2 cd_og) { }

    public void gelo(Float2 cd, Float2 cd_og)
    {
        if (cd.value <= 0f)
        {
            Instantiate(ice, mousePos, ice.transform.rotation);
            cd.value = cd_og.value;
        }
    }

    public void onda(Float2 cd, Float2 cd_og)
    {
        if (cd.value <= 0)
        {
            Instantiate(wave, mousePos, wave.transform.rotation);
            cd.value = cd_og.value;
        }
    }

    public void espinho(Float2 cd, Float2 cd_og)
    {
        if (cd.value <= 0f)
        {
            Instantiate(spike, mousePos, spike.transform.rotation);
            cd.value = cd_og.value;
        }
    }

    public void raio(Float2 cd, Float2 cd_og)
    {
        if (cd.value <= 0)
        {
            Instantiate(shock, mousePos, shock.transform.rotation);
            cd.value = cd_og.value;
        }
    }
}
