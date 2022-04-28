using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSkin : MonoBehaviour
{
    public int skinValue = 0;

    public void setSkinValue()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorUI>().skinValue = skinValue;
    }
}
