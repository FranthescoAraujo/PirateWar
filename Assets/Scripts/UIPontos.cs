using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPontos : MonoBehaviour
{
    private Text texto;
    private GerenciadorJogo gerenciadorJogo;

    void Start()
    {
        texto = GetComponent<Text>();
        gerenciadorJogo = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }
    void Update()
    {
        texto.text = "Pontos: " + gerenciadorJogo.RetornaPontos().ToString();
    }
}
