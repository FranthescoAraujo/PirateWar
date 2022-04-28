using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorBala : MonoBehaviour
{
    private GameObject canhao;
    private GerenciadorPersonagem player;
    private GerenciadorJogo gerenciadorJogo;

    private void Start()
    {
        gerenciadorJogo = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GerenciadorPersonagem>();
        canhao = GameObject.FindGameObjectWithTag("Canhao");
        transform.up = canhao.GetComponent<GerenciadorCanhao>().posicaoXY - transform.position;
    }
    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        transform.Translate(0, 0.2f, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            gerenciadorJogo.InserirPontos(5);
            collision.gameObject.GetComponent<GerenciadorInimigo>().morreu = true;
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<GerenciadorInimigo>().stay = true;
            Destroy(collision.gameObject, 1.5f);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Barril")
        {
            gerenciadorJogo.InserirPontos(1);
            if (player.polvora[1] + 10 > player.polvora[0])
            {
                player.polvora[1] = player.polvora[0];
            }
            else
            {
                player.polvora[1] += 10;
            }
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(collision.gameObject, 1.5f);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Madeira")
        {
            gerenciadorJogo.InserirPontos(1);
            if (player.madeira[1] + 10 > player.madeira[0])
            {
                player.madeira[1] = player.madeira[0];
            }
            else
            {
                player.madeira[1] += 10;
            }
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(collision.gameObject, 1.5f);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Caixa")
        {
            gerenciadorJogo.InserirPontos(1);
            if (player.aco[1] + 10 > player.aco[0])
            {
                player.aco[1] = player.aco[0];
            }
            else
            {
                player.aco[1] += 10;
            }
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(collision.gameObject, 1.5f);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bala")
        {
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<GerenciadorBalaInimigo>().stay = true;
            Destroy(collision.gameObject, 1.5f);
            Destroy(this.gameObject);
        }
    }
}
