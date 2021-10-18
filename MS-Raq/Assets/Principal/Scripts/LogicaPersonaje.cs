using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public CharacterController playerController;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 forwardMove = transform.TransformDirection(Vector3.forward);
        forwardMove.y = -9.8f;
        forwardMove.z *= y;
        playerController.SimpleMove(forwardMove);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        if (y != 0)
        {
            Vector3 forwardMove = transform.TransformDirection(Vector3.forward);
            forwardMove.y = -9.8f;
            forwardMove.z *= y;
            playerController.Move(forwardMove * Time.deltaTime * velocidadMovimiento);
        }
        //anim.SetFloat("VelX", x);
        //anim.SetFloat("VelY", y);


    }
}
