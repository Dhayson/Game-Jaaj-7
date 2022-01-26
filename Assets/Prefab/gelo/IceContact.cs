using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceContact : MonoBehaviour
{
    [SerializeField] private float fallTime = 0;
    [SerializeField] private LayerMask Level;
    [SerializeField] private LayerMask Nemesis;
    private float Resist
    {
        get
        {
            return Resistance.ResistanceNow.gelo;
        }
    }

    void FixedUpdate()
    {
        fallTime += Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Level))
        {
            //try to detect nemesis near
            var contact = other.gameObject.GetComponent<Collider2D>().ClosestPoint(transform.position);
            Collider2D nemesisCol = Physics2D.OverlapCircle(contact, 2f, Nemesis);

            if (nemesisCol is not null)
            {
                GameObject nemesis = nemesisCol.gameObject;
                Stats stats = nemesis.GetComponent<Stats>();

                int damage = (int)(6 * (fallTime + 1) / Resist);
                stats.Damage(damage);
                CoroutineManager.Instance.StartCoroutine(slowTarget(stats, 1.5f));

                Debug.Log(Resist);
                Resistance.ResistanceStore.gelo += 0.1f;
            }
            else
            {
                Debug.Log("missed");
            }
            Destroy(gameObject);
        }
        else if (Global.CompareLayer(other.gameObject.layer, Nemesis))
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();

            int damage = (int)(10 * (fallTime + 1) / Resist);
            stats.Damage(damage);
            CoroutineManager.Instance.StartCoroutine(slowTarget(stats, 2));

            Debug.Log(Resist);
            Resistance.ResistanceStore.gelo += 0.08f;
            Destroy(gameObject);
        }
    }

    IEnumerator slowTarget(Stats stats, float intensity)
    {
        var intensity2 = intensity / Resist;

        float slow = 0.5f - 0.02f * intensity2;
        stats.speedMultiplier *= slow;
        int iden = UniqueNumber.Next();
        stats.colorFactor = (Color.blue, iden);

        yield return new WaitForSeconds(intensity2);

        stats.speedMultiplier /= slow;
        stats.RemoveColor(iden);
    }
}
