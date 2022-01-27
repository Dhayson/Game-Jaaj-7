using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform follow;
    private Transform trans;
    private Vector3 relativePosition;
    public bool isFollowing = true;
    private Vector3 targetPosition;

    void Start()
    {
        trans = GetComponent<Transform>();
        relativePosition = new Vector3(trans.position.x - follow.position.x, 0, 0);
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        //make the camera follow the transform x axis.
        targetPosition = new Vector3(follow.position.x, trans.position.y, trans.position.z) + relativePosition;
        if (isFollowing)
        {
            trans.position = Vector3.MoveTowards(trans.position, targetPosition, 0.5f);
        }
    }

    private Vector3 startPos;
    private float duration = 0.5f;
    public IEnumerator Restart()
    {
        isFollowing = false;
        float time = 0;
        StartCoroutine(RestartY());
        //restartX
        while (time <= duration)
        {
            var delta = (targetPosition - trans.position) * (Time.fixedDeltaTime / duration);
            trans.position = Vector3.MoveTowards(trans.position, targetPosition, delta.magnitude);
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        isFollowing = true;
    }

    private IEnumerator RestartY()
    {
        float time = 0;
        Vector3 init = trans.position;
        while (time <= duration)
        {
            Vector3 startY = new(trans.position.x, startPos.y, trans.position.z);
            trans.position = Vector3.MoveTowards(trans.position, startY, (startPos.y - init.y) / 20);
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
