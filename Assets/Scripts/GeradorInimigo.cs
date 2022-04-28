using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigo : MonoBehaviour
{
    [Header("Posição X")]
    [SerializeField]
    private float POSITION_X_MIN = -15f;
    [SerializeField]
    private float POSITION_X_MAX = 15f;
    [SerializeField]
    private float[] posicaoX = new float[2];

    [Header("Posição Y")]
    [SerializeField]
    private float POSITION_Y_MIN = -5f;
    [SerializeField]
    private float POSITION_Y_MAX = 25f;
    [SerializeField]
    private float[] posicaoY = new float[2];

    private GerenciadorJogo gerenciadorJogo;
    public GameObject inimigo;
    public float tempoInimigo;
    public float tempoSpawn;

    private void Start()
    {
        gerenciadorJogo = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
        posicaoX[0] = POSITION_X_MIN;
        posicaoX[1] = POSITION_X_MAX;
    }

    void Update()
    {
        GerarInimigo();
    }

    private void GerarInimigo()
    {
        if (gerenciadorJogo.EstadoGame())
        {
            tempoInimigo += Time.deltaTime;
            tempoSpawn = (float)(5.0f / (1 + (0.01* gerenciadorJogo.RetornaPontos())));
            if (tempoInimigo > tempoSpawn)
            {
                posicaoY[0] = Random.Range(POSITION_Y_MIN, POSITION_Y_MAX);
                posicaoY[1] = Random.Range(POSITION_Y_MIN, POSITION_Y_MAX);
                int aux = Mathf.RoundToInt(Random.Range(0f, 1f));

                Vector3 posicao = new Vector3(posicaoX[aux], posicaoY[aux], 0);

                GameObject navio = Instantiate(inimigo, posicao, Quaternion.identity);
                navio.GetComponent<GerenciadorInimigo>().setPosicaoDestino(new Vector3(posicaoX[Mathf.Abs(aux - 1)], posicaoY[Mathf.Abs(aux - 1)], 0), (aux > 0.5));

                Destroy(navio, 5f);
                tempoInimigo = 0;
            }
        }
    }
}
