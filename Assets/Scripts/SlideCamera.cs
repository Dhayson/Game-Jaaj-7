using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCamera : MonoBehaviour
{
    [SerializeField] new private Camera camera;
    [SerializeField] private LayerMask Nemesis;
    [SerializeField] private Vector2 cameraDelta;
    [SerializeField] private float duration;
    private bool started = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Nemesis) && !started)
        {
            started = true;
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        float time = 0;
        while (time <= duration)
        {
            time += Time.fixedDeltaTime;
            camera.transform.position += (Vector3)cameraDelta * (Time.fixedDeltaTime / duration);
            yield return new WaitForFixedUpdate();
        }
    }
}
