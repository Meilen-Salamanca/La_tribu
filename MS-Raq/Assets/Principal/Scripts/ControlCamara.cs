using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 posicionRelativa;

    // Start is called before the first frame update
    void Start()
    {
        posicionRelativa = transform.position - jugador.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = jugador.transform.position + posicionRelativa;

    }
}
