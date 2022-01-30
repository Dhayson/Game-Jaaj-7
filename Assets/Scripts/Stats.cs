using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] bool isNemesis = false;
    [SerializeField] private GameObject[] reseters;
    public float Health;
    public float InvulnerableTime;
    [SerializeField] private float InvulnerableTimeCD;
    public float drag = 0;
    public float speedMultiplier = 1;
    public float jumpFactor = 1;
    public bool shock = false;
    public bool superShock { get { return shock && wet; } }
    public bool wet = false;
    private List<(Color, int)> colorQueue;
    private Vector3 startPos;
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
        colorQueue.Add((Color.white, 666));
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0.0f)
        {
            Kill();
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
        if (isNemesis)
        {
            Debug.Log($"kill {gameObject}");
            transform.position = startPos;
            Health = 100;
            foreach (var evil in Global.EvilRoutine)
            {
                StopCoroutine(evil);
            }
            var camera = Camera.main.GetComponent<CameraScript>();
            StartCoroutine(camera.Restart());
            foreach (var reset in reseters)
            {
                reset.BroadcastMessage("AutoReset");
            }
            Resistance.ResistanceNow = Resistance.ResistanceStore;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
