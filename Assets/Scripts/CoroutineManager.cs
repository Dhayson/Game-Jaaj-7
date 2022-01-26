using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//unityBerserker: https://answers.unity.com/questions/1664564/keep-doing-coroutine-even-when-destroy-game-object.html
//add to a fixed game object on the scene
public class CoroutineManager : MonoBehaviour
{
    static CoroutineManager instance;
    public static CoroutineManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}