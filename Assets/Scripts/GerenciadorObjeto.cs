using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorObjeto : MonoBehaviour
{
    private void Update()
    {
        Rotacionar();
    }

    void Rotacionar()
    {
        transform.rotation = Quaternion.AngleAxis(10, transform.forward);
    }
}
