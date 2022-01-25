using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceContact : MonoBehaviour
{
    [SerializeField] private float fallTime = 0;
    [SerializeField] private LayerMask Level;

    [SerializeField] private LayerMask Nemesis;

    void FixedUpdate()
    {
        fallTime += Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Level))
        {
            var contact = other.gameObject.GetComponent<Collider2D>().ClosestPoint(transform.position);
            Collider2D nemesisCol = Physics2D.OverlapCircle(contact, 2f, Nemesis);
            if (nemesisCol is not null)
            {
                GameObject nemesis = nemesisCol.gameObject;
                Debug.Log($"explosion {nemesis}");
                Stats stats = nemesis.GetComponent<Stats>();
                stats.Damage(7 + (int)(fallTime * 7));
                CoroutineManager.Instance.StartCoroutine(slowTarget(stats, 1.5f));
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
            Debug.Log($"hit {nemesis}");
            Stats stats = nemesis.GetComponent<Stats>();
            stats.Damage(10 + (int)(fallTime * 10));
            CoroutineManager.Instance.StartCoroutine(slowTarget(stats, 2));
            Destroy(gameObject);
        }
    }

    IEnumerator slowTarget(Stats stats, float intensity)
    {
        float slow = 0.5f - 0.02f * intensity;
        stats.speedFactor *= slow;
        stats.colorFactor = Color.blue;
        yield return new WaitForSeconds(intensity);
        stats.speedFactor /= slow;
        stats.colorFactor = Color.white;
    }
}
