using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct AttachedCoroutine<T>
{
    public AttachedCoroutine(Coroutine routine, T origin)
    {
        this.routine = routine;
        this.origin = origin;
    }
    public Coroutine routine;
    public T origin;
}
