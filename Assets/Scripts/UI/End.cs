using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] Text texto;
    // Start is called before the first frame update
    void Start()
    {
        if (Global.LifeCount == 20)
        {
            texto.text = "O herói fez sua jornada sem grandes problemas e derrotou o vilão";
        }
        else if (Global.LifeCount >= 0)
        {
            texto.text = "Apesar das tentativas do vilão, o herói criou resistência e o derrotou";
        }
        else
        {
            texto.text = "Seu maior inimigo foi derrotado. Parabéns";
        }
    }
}
