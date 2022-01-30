using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkill4Script : MonoBehaviour
{
    private Image[] display;
    private ClickHability[] habilities;
    [SerializeField] private Sprite A;
    [SerializeField] private Sprite W;
    [SerializeField] private Sprite R;
    [SerializeField] private GameObject raio;
    [SerializeField] private GameObject onda;
    [SerializeField] private GameObject espinho;
    [SerializeField] private GameObject gravidade;
    [SerializeField] private GameObject lesma;
    [SerializeField] private GameObject fogo;
    // Start is called before the first frame update
    void Start()
    {
        display = GetComponentsInChildren<Image>();
        habilities = GetComponentsInChildren<ClickHability>();

        foreach (var skillSet in habilities)
        {
            if (HabilitySet.A == Hability.vazio)
            {
                skillSet.key = Key.A;
                for (int i = 1; i < display.Length; i += 2)
                {
                    display[i].sprite = A;
                }
            }
            else if (HabilitySet.W == Hability.vazio)
            {
                skillSet.key = Key.W;
                for (int i = 1; i < display.Length; i += 2)
                {
                    display[i].sprite = W;
                }
            }
            else if (HabilitySet.R == Hability.vazio)
            {
                skillSet.key = Key.R;
                for (int i = 1; i < display.Length; i += 2)
                {
                    display[i].sprite = R;
                }
            }
        }
        if (HabilitySet.A == Hability.raio) raio.SetActive(false);
        if (HabilitySet.W == Hability.onda) onda.SetActive(false);
        if (HabilitySet.R == Hability.espinho) espinho.SetActive(false);
        if (HabilitySet.A == Hability.gravidade) gravidade.SetActive(false);
        if (HabilitySet.W == Hability.fogo) fogo.SetActive(false);
        if (HabilitySet.R == Hability.lesma) lesma.SetActive(false);
    }

}
