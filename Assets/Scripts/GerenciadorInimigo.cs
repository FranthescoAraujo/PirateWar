using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorInimigo : MonoBehaviour
{
    [SerializeField]
    private Vector3 posicaoDestino;
    public bool podeAtirar = true;
    public float tempoTiro = 0;
    public GameObject bala;
    private int pontos;
    public bool morreu = false;
    public bool stay = false;

    private void Start()
    {
        pontos = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>().RetornaPontos();
    }

    private void Update()
    {
        if (!stay)
        {
            Mover();
            Atirar();
            TempoTiro();
        }
    }

    void Mover()
    {
        transform.Translate(0.1f, 0, 0);
    }

    public void setPosicaoDestino(Vector3 posicaoDestino, bool isFlipx)
    {
        if (isFlipx) GetComponent<SpriteRenderer>().flipY = true;
        this.posicaoDestino = posicaoDestino;
        transform.right = posicaoDestino - transform.position;
    }

    private void Atirar()
    {
        if (podeAtirar && !morreu)
        {
            GameObject tiro = Instantiate(bala, transform.position, Quaternion.identity);
            Destroy(tiro, 10f);
            podeAtirar = false;
        }
    }

    private void TempoTiro()
    {
        tempoTiro += Time.deltaTime;
        if (tempoTiro >= (float)(2f+2f/(pontos+1)))
        {
            tempoTiro = 0;
            podeAtirar = true;
        }
    }

}
