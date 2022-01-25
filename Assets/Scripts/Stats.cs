using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float Health;
    public float InvulnerableTime;
    [SerializeField] private float InvulnerableTimeCD;
    public float speedBase = 1;
    public float speedMultiplier = 1;
    public float speedFactor { get { return speedBase * speedMultiplier; } }
    public float jumpFactor = 1;
    private List<(Color, int)> colorQueue;
    public (Color, int) colorFactor
    {
        get
        {
            return colorQueue.Last();
        }
        set
        {
            colorQueue.Add(value);
        }
    }
    public void RemoveColor(int identifier)
    {
        colorQueue.RemoveAll(cor => cor.Item2 == identifier);
    }
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        InvulnerableTimeCD = InvulnerableTime;
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        colorQueue = new();
        colorQueue.Add((Color.white, UniqueNumber.Next()));
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0.0f)
        {
            Kill();
            Health = float.NaN;
        }

        if (float.IsNaN(speedMultiplier))
        {
            speedMultiplier = 1f;
        }
        if (float.IsNaN(jumpFactor))
        {
            jumpFactor = 1f;
        }
        spriteRender.color = colorQueue.Last().Item1;
    }

    public void FixedUpdate()
    {
        if (InvulnerableTimeCD > 0) InvulnerableTimeCD -= Time.fixedDeltaTime;
    }

    public void Damage(int damage)
    {
        if (InvulnerableTimeCD <= 0)
        {
            Health -= damage;
            InvulnerableTimeCD = InvulnerableTime;
        }
    }
    public void Kill()
    {
        Debug.Log($"kill {gameObject}");
        //uncomment to inactivate objects when they die.
        //gameObject.SetActive(false);
    }
}
