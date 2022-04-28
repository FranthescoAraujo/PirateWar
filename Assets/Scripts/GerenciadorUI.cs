using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorUI : MonoBehaviour
{
    private GerenciadorPersonagem atributosPersonagem;
    public GameObject polvora;
    public GameObject madeira;
    public GameObject aco;
    public GameObject[] skins;
    public int skinValue = 0;

    void Start()
    {
        atributosPersonagem = GameObject.FindGameObjectWithTag("Player").GetComponent<GerenciadorPersonagem>();
    }
    void Update()
    {
        modificaPolvora();
        modificaMadeira();
        modificaAco();
    }

    private void modificaPolvora()
    {
        int value = (int)(640 * atributosPersonagem.polvora[1] / atributosPersonagem.polvora[0]);
        polvora.GetComponent<RectTransform>().sizeDelta = new Vector2(value, 45);
    }

    private void modificaMadeira()
    {
        int value = (int)(640 * atributosPersonagem.madeira[1] / atributosPersonagem.madeira[0]);
        madeira.GetComponent<RectTransform>().sizeDelta = new Vector2(value, 45);
    }

    private void modificaAco()
    {
        int value = (int)(640 * atributosPersonagem.aco[1] / atributosPersonagem.aco[0]);
        aco.GetComponent<RectTransform>().sizeDelta = new Vector2(value, 45);
    }

    public void setSkin()
    {
        skins[skinValue].SetActive(true);
    }

    public void desabilitarSkin()
    {
        skins[skinValue].SetActive(false);
    }
}
