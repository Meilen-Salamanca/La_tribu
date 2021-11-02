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
    public bool rotationMovement;
    public bool enableMovement;

    public SendToGoogle databaseManagement;

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
        if (enableMovement)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            if (rotationMovement)
            {
                transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
                if (y != 0)
                {
                    Vector3 forwardMove = transform.TransformDirection(Vector3.forward);
                    forwardMove.y = -9.8f;
                    forwardMove.z *= y;
                    playerController.Move(forwardMove * Time.deltaTime * velocidadMovimiento);
                }
                else
                {
                    Vector3 forwardMove = Vector3.zero;
                    forwardMove.y = -9.8f;
                    playerController.Move(forwardMove * Time.deltaTime * velocidadMovimiento);
                }
            }
            else
            {
                Vector3 forwardMove2 = Vector3.zero;
                forwardMove2.y = -9.8f;
                forwardMove2.z = y;
                forwardMove2.x = x * 0.5f;
                playerController.Move(forwardMove2 * Time.deltaTime * velocidadMovimiento);
            }
        }
    }
}
