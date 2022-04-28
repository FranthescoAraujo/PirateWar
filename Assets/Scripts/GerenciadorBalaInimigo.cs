using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorBalaInimigo : MonoBehaviour
{
    private GameObject player;
    private GerenciadorPersonagem gerenciador;
    private Vector3 posicaoXY;
    public bool stay = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gerenciador = player.GetComponent<GerenciadorPersonagem>();
        posicaoXY = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        transform.up = posicaoXY - transform.position;
    }
    void Update()
    {
        if (!stay)
        {
            Mover();
        }
    }

    private void Mover()
    {
        transform.Translate(0, 0.1f, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gerenciador.madeira[1] -= 5;
            gerenciador.aco[1] -= 5;
            GetComponent<Animator>().Play("Explosion");
            GetComponent<AudioSource>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            stay = true;
            Destroy(this.gameObject, 1.5f);
        }
    }
}
