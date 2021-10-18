using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecogerItem : MonoBehaviour
{
    int cuenta;
    Rigidbody rb;
    public Text puntuacion;
    public float velocidad;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        cuenta = cuenta + 1;
        puntuacion.text = "Puntos:" + cuenta;

    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cuenta = 0;
        puntuacion.text = "Puntos:" + cuenta;

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        rb.AddForce(movimiento * velocidad);
    }
}

