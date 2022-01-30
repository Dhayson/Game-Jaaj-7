using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesma : MonoBehaviour
{
    private GameObject Nemesis;
    private Rigidbody2D rig;
    private Stats stats;
    [SerializeField] private float vel;
    [SerializeField] Collider2D colNormal;
    [SerializeField] Collider2D colBottom;
    [SerializeField] LayerMask level;
    [SerializeField] private Transform insideDetector;

    private float Resist
    {
        get
        {
            return Resistance.ResistanceNow.lesma;
        }
    }
    void Start()
    {
        Nemesis = GameObject.FindGameObjectsWithTag("Nemesis")[0];
        rig = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
    }

    void FixedUpdate()
    {
        float s = Mathf.Sign(Nemesis.transform.position.x - transform.position.x);
        rig.velocity = new Vector2(vel * s + stats.drag, rig.velocity.y);
        transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x) * -s,
            transform.localScale.y,
            transform.localScale.z);
    }

    //TODO: implement multiple colliders (e.g. slug is above the enemy)
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Nemesis)
        {
            GameObject nemesis = other.gameObject;
            Stats stats = nemesis.GetComponent<Stats>();
            Rigidbody2D rigNeme = nemesis.GetComponent<Rigidbody2D>();

            if (other.otherCollider == colNormal)
            {
                int damage = (int)(7 / Resist);
                stats.Damage(damage);
                CoroutineManager.Instance.StartCoroutine(Nojo(6f));
            }
            else if (other.otherCollider == colBottom)
            {
                int damage = (int)(7 / Resist);
                stats.Damage(damage);
                CoroutineManager.Instance.StartCoroutine(Nojo(9f));
            }
            IEnumerator Nojo(float dps)
            {
                float slow = 0.9f - 0.2f / Resist;
                stats.speedMultiplier *= (slow * slow * slow);
                int iden = UniqueNumber.Next();
                stats.colorFactor = (Color.green, iden);

                for (int i = 0; i < 3; i++)
                {
                    rigNeme.velocity *= 0.9f;
                    int damage = (int)(dps / Resist);
                    stats.Damage(damage);
                    stats.speedMultiplier /= slow;
                    yield return new WaitForSeconds(0.8f);
                }

                stats.RemoveColor(iden);
            }

            Resistance.ResistanceStore.lesma += 0.08f;
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (Global.CompareLayer(other.collider.gameObject.layer, level)
            && Physics2D.OverlapPoint(insideDetector.position, level))
        {
            transform.position -= new Vector3(0, -0.5f, 0);
        }
    }
}
