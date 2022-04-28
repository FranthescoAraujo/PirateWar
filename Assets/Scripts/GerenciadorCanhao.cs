using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorCanhao : MonoBehaviour
{
    public Vector3 posicaoXY;
    public bool podeAtirar = true;
    public float tempoTiro = 0;
    public GameObject bala;
    private GerenciadorPersonagem player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GerenciadorPersonagem>();
    }

    void Update()
    {
        Rotacionar();
        TempoTiro();
        Atirar();
    }

    private void Rotacionar()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 posicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicaoXY = new Vector3(posicao.x, posicao.y, transform.position.z);
            transform.up = posicaoXY - transform.position;
        }
    }

    private void Atirar()
    { 
        if (podeAtirar)
        {
            GameObject tiro = Instantiate(bala, transform.position, Quaternion.identity);
            Destroy(tiro, 5f);
            podeAtirar = false;
        }
    }

    private void TempoTiro()
    {
        tempoTiro += Time.deltaTime;
        if (tempoTiro >= (float)(-0.008 * player.polvora[1] + 1f))
        {
            tempoTiro = 0;
            podeAtirar = true;
        }
    }
}
