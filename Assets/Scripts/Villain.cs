using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Villain : MonoBehaviour
{
    [SerializeField] private Vector2 mousePos;
    private VillainControl control;

    void Awake()
    {
        control = new();
        //syntax: control.Skills.Q.started += ctx => Method();
    }
    void Start()
    {
        control.Skills.Enable();
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
