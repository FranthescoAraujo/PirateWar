using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public GameObject sound;

    public void onClick() {
        sound.SetActive(false);
    }
}
