using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClickHability : ClickImage
{
    [SerializeField] private Hability skill;
    [SerializeField] private Key key;
    [SerializeField] private string nextScene;
    // Start is called before the first frame update
    new void Start()
    {
        parameters = new object[] { skill };
        base.Start();
    }

    public void Set(Hability skill)
    {
        if (key == Key.E)
        {
            HabilitySet.E = skill;
        }
        if (key == Key.W)
        {
            HabilitySet.W = skill;
        }
        if (key == Key.A)
        {
            HabilitySet.A = skill;
        }
        if (key == Key.R)
        {
            HabilitySet.R = skill;
        }
        Debug.Log($"skill {skill} is in {key}");
        SceneManager.LoadScene(nextScene);
    }
}
