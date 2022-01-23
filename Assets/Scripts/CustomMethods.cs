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
    public static Vector2 sizeMultiplier = new Vector2(1, 1);

    /// <summary>
    /// Return the Raycast of the current mouse position
    /// </summary>
    static public RaycastHit2D MouseClick(Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        return Physics2D.Raycast(ray.origin, ray.direction);
    }
}
