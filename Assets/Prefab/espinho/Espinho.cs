using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: fazer o script. O atual é uma cópia do gelo
//TODO: implementar resistência
public class Espinho : MonoBehaviour
{
    [SerializeField] private float fallTime = 0;
    [SerializeField] private LayerMask Nemesis;
    [SerializeField] private float force;
    private float Resist
    {
        get
        {
            return Resistance.ResistanceNow.espinho;
        }
    }

    void FixedUpdate()
    {
        fallTime += Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Nemesis))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();

            int damage = (int)(2 + (fallTime * 4) / Resist);
            stats.Damage(damage);

            Debug.Log(Resist);
            Resistance.ResistanceStore.espinho += 0.015f;

            CoroutineManager.Instance.StartCoroutine(Spike(nemesis, stats, 0.1f));
        }
    }

    IEnumerator Spike(GameObject nemesis, Stats stats, float time)
    {
        Rigidbody2D rig = nemesis.GetComponent<Rigidbody2D>();

        int iden = UniqueNumber.Next();
        stats.colorFactor = (Color.red, iden);


        if (fallTime >= 0.4f)
        {
            var resist2 = (Resist - 1) / 2 + 1;
            rig.AddForce(new Vector2(0, -force / resist2));
        }

        yield return new WaitForSeconds(time);

        stats.RemoveColor(iden);
    }
}
