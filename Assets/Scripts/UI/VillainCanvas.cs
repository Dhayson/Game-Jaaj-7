using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VillainCanvas : MonoBehaviour
{
    private Villain villain;
    [SerializeField] private GameObject E;
    private TextMeshProUGUI Ecd;
    [SerializeField] private GameObject W;
    private TextMeshProUGUI Wcd;
    [SerializeField] private GameObject R;
    private TextMeshProUGUI Rcd;
    // Start is called before the first frame update
    void Start()
    {
        villain = GetComponentInParent<Villain>();

        E.SetActive(HabilitySet.E != Hability.vazio);
        Ecd = E.GetComponentInChildren<TextMeshProUGUI>();

        W.SetActive(HabilitySet.W != Hability.vazio);
        Wcd = W.GetComponentInChildren<TextMeshProUGUI>();

        R.SetActive(HabilitySet.R != Hability.vazio);
        Rcd = R.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (E.activeSelf)
            Ecd.text = $"{Mathf.CeilToInt(villain.E_CD)}s";

        if (W.activeSelf)
            Wcd.text = $"{Mathf.CeilToInt(villain.W_CD)}s";

        if (R.activeSelf)
            Rcd.text = $"{Mathf.CeilToInt(villain.R_CD)}s";
    }
}