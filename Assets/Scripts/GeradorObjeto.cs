using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorObjeto : MonoBehaviour
{
    private GerenciadorJogo gerenciadorJogo;
    public GameObject objeto;
    private float tempo;
    public float TEMPO_MIN = 2.0f;

    private void Start()
    {
        gerenciadorJogo = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    void Update()
    {
        if (gerenciadorJogo.EstadoGame())
        {
            tempo += Time.deltaTime;
            if (tempo > TEMPO_MIN)
            {
                float px = Random.Range(transform.position.x - 10, transform.position.x + 10);
                Vector3 posicao = new Vector3(px, transform.position.y, 0);
                GameObject Inimigo = Instantiate(objeto, posicao, Quaternion.identity);
                Destroy(Inimigo, 15f);
                tempo = 0;
            }
        }
    }
}
