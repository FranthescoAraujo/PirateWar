using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPersonagem : MonoBehaviour
{
    private float tempoPolvora = 3f;
    private float tempoMorrer = 0;
    private bool morreu = false;
    public GameObject canhao;

    public int[] polvora = new int[] { 100, 20 };
    public int[] madeira = new int[] { 100, 100 };
    public int[] aco = new int[] { 100, 100 };

    private void Update()
    {
        if (!morreu)
        {
            PerderPolvora();
        }
        Morrer();
    }

    public void ResetarAtributos()
    {
        polvora[1] = 20;
        madeira[1] = 100;
        aco[1] = 100;
        tempoMorrer = 0;
        morreu = false;
        GetComponent<Animator>().Play("Idle");
        GetComponent<BoxCollider2D>().enabled = true;
        canhao.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            madeira[1] -= 20;
            aco[1] -= 10;
            collision.gameObject.GetComponent<GerenciadorInimigo>().morreu = true;
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<GerenciadorInimigo>().stay = true;
            Destroy(collision.gameObject, 1.5f);
            return;
        }
        if (collision.gameObject.tag == "Barril")
        {
            madeira[1] -= 10;
            aco[1] -= 5;
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(collision.gameObject, 1.5f);
            return;
        }
        if (collision.gameObject.tag == "Madeira")
        {
            madeira[1] -= 5;
            aco[1] -= 5;
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(collision.gameObject, 1.5f);
            return;
        }
        if (collision.gameObject.tag == "Caixa")
        {
            madeira[1] -= 5;
            aco[1] -= 5;
            collision.gameObject.GetComponent<Animator>().Play("Explosion");
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(collision.gameObject, 1.5f);
            return;
        }
    }

    public void PerderPolvora()
    {
        tempoPolvora -= Time.deltaTime;
        if (tempoPolvora <= 0f)
        {
            polvora[1]--;
            tempoPolvora = 3f;
        }
    }

    public void Morrer()
    {
        if (madeira[1] <= 0 || aco[1] <= 0)
        {
            morreu = true;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorUI>().desabilitarSkin();
            TempoMorrer();
            GetComponent<Animator>().Play("Explosion");
            GetComponent<BoxCollider2D>().enabled = false;
            canhao.SetActive(false);
            GetComponent<AudioSource>().enabled = true;
            DestroyAllGameObjects(GameObject.FindGameObjectsWithTag("Inimigo"));
            DestroyAllGameObjects(GameObject.FindGameObjectsWithTag("Barril"));
            DestroyAllGameObjects(GameObject.FindGameObjectsWithTag("Caixa"));
            DestroyAllGameObjects(GameObject.FindGameObjectsWithTag("Madeira"));
            DestroyAllGameObjects(GameObject.FindGameObjectsWithTag("Bala"));
            DestroyAllGameObjects(GameObject.FindGameObjectsWithTag("BalaPersonagem"));
        }
    }

    public void TempoMorrer()
    {
        tempoMorrer += Time.deltaTime;
        if (tempoMorrer >= 2f)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>().GameOver();
        }
    }

    private void DestroyAllGameObjects(GameObject[] item)
    {
        if (item.Length > 0)
        {
            foreach (GameObject i in item)
            {
                Destroy(i);
            }
        }
    }
}
