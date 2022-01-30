using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Villain : MonoBehaviour
{
    [SerializeField] private LayerMask Entity;
    [SerializeField] private LayerMask Nemesis;
    [SerializeField] private LayerMask Level;
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
    public float gravidadeCD;
    [SerializeField] private GameObject fire;
    public float fogoCD;
    [SerializeField] private GameObject slug;
    public float lesmaCD;

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

    public void gravidade(Float2 cd, Float2 cd_og)
    {
        if (cd.value <= 0)
        {
            var cols = Physics2D.OverlapCircleAll(mousePos, 1f);
            List<GameObject> games = new();
            foreach (var col in cols)
            {
                games.Add(col.gameObject);
            }
            games = games.Distinct().ToList();
            foreach (var game in games)
            {
                if (Global.CompareLayer(game.layer, Entity))
                {
                    StartCoroutine(Gravity(game));

                    IEnumerator Gravity(GameObject entity)
                    {
                        if (entity.TryGetComponent(out Rigidbody2D rig))
                        {
                            rig.gravityScale *= -1;
                            rig.rotation += 180;
                        }
                        if (Global.CompareLayer(entity.layer, Nemesis))
                        {
                            cd.value = cd_og.value;
                            Resistance.ResistanceStore.gravidade += 0.1f;
                            yield return new WaitForSeconds(0.7f / Resistance.ResistanceNow.gravidade);
                        }
                        else
                        {
                            yield return new WaitForSeconds(0.7f);
                        }
                        if (entity.TryGetComponent(out rig))
                        {
                            rig.gravityScale *= -1;
                            rig.rotation += 180;
                        }
                    }
                }
            }
        }
    }

    public void fogo(Float2 cd, Float2 cd_og)
    {
        if (cd.value <= 0)
        {
            Instantiate(fire, mousePos, shock.transform.rotation);
            cd.value = cd_og.value;
        }
    }

    public void lesma(Float2 cd, Float2 cd_og)
    {
        if (cd.value <= 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, new Vector2(0, -1), distance: 1000, layerMask: Level);
            if (hit.collider != null)
            {
                Instantiate(slug, hit.point, shock.transform.rotation);
                cd.value = cd_og.value;
            }

        }
    }
}
