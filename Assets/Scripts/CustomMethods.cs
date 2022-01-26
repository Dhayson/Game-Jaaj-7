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
    /// <summary>
    /// Check if a Layer is contained in a LayerMask
    /// </summary>
    static public bool CompareLayer(int layer, LayerMask layermask)
    {
        //https://answers.unity.com/questions/50279/check-if-layer-is-in-layermask.html
        return layermask == (layermask | (1 << layer));
    }
    public static List<Coroutine> EvilRoutine = new();
}

public static class HabilitySet
{
    public static Hability Q;
    public static Hability W;
    public static Hability E;
    public static Hability R;
    public static Hability A;
    public static Hability S;
}

public enum Hability { vazio, gelo, raio, onda, espinho }
public enum Key { Q, W, E, R, A, S }

public static class UniqueNumber
{
    public static int Next()
    {
        int toReturn = list[index];
        index++;
        if (index == list.Length)
        {
            index = 0;
        }
        return toReturn;
    }

    static int index = 0;

    static int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
    11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23,
    24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36,
    37, 38, 39, 40, 41, 42, 420, 43, 44, 45, 46, 47, 48, 49, 50,
    51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63,
    64, 65, 66, 67, 68, 69 };
}
