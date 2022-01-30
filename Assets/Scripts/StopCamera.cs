using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    [SerializeField] new private Camera camera;
    [SerializeField] private LayerMask Nemesis;
    private bool started = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Global.CompareLayer(other.gameObject.layer, Nemesis) && !started)
        {
            started = true;
            var script = camera.gameObject.GetComponent<CameraScript>();
            script.isFollowing = false;
        }
    }

    public void AutoReset()
    {
        started = false;
        Debug.Log($"restarted {gameObject}");
    }
}
