using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorJogo : MonoBehaviour
{
    public bool estadoJogo = false;
    public int pontos;
    private GerenciadorPersonagem gerenciadorPersonagem;
    public GameObject UIGameOver;

    void Start()
    {
        estadoJogo = false;
        Time.timeScale = 0;
        ResetarAtributos();
        gerenciadorPersonagem = GameObject.FindGameObjectWithTag("Player").GetComponent<GerenciadorPersonagem>();
    }

    public void GameOver()
    {
        estadoJogo = false;
        Time.timeScale = 0;
        UIGameOver.SetActive(true);
        gerenciadorPersonagem.ResetarAtributos();
    }

    public bool EstadoGame()
    {
        return estadoJogo;
    }
    public void IniciarJogo()
    {
        estadoJogo = true;
        Time.timeScale = 1;
        ResetarAtributos();
    }

    public void FecharJogo()
    {
        Application.Quit();
    }


    public int RetornaPontos()
    {
        return pontos;
    }

    public void InserirPontos(int valor)
    {
        pontos += valor;
    }

    private void ResetarAtributos()
    {
        pontos = 0;

        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        GameObject[] barris = GameObject.FindGameObjectsWithTag("Barril");
        GameObject[] caixas = GameObject.FindGameObjectsWithTag("Caixa");
        GameObject[] madeiras = GameObject.FindGameObjectsWithTag("Madeira");

        DestroyAllGameObjects(inimigos);
        DestroyAllGameObjects(barris);
        DestroyAllGameObjects(caixas);
        DestroyAllGameObjects(madeiras);

        GameObject.FindGameObjectWithTag("Player").GetComponent<GerenciadorPersonagem>().ResetarAtributos();
    }

    private void DestroyAllGameObjects(GameObject[] item)
    {
        if(item.Length > 0)
        {
            foreach(GameObject i in item)
            {
                Destroy(i);
            }
        }
    }
}
