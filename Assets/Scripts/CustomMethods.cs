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
public static class Global
{
    //global field to store the chosen image
    public static string nemesisImagePath;
    //global size scale
    public static float sizeMultiplier = 1f;
}
