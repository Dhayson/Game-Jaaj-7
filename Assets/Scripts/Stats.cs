using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float Health;
    public float InvulnerableTime;
    [SerializeField] private float InvulnerableTimeCD;
    public float speedFactor = 1;
    public float jumpFactor;
    public Color colorFactor = Color.white;
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        InvulnerableTimeCD = InvulnerableTime;
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0.0f)
        {
            Kill();
            Health = float.NaN;
        }

        if (float.IsNaN(speedFactor))
        {
            speedFactor = 1f;
        }
        if (float.IsNaN(jumpFactor))
        {
            jumpFactor = 1f;
        }
        spriteRender.color = colorFactor;
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
