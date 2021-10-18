using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Per_Raq : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -265)
        {
            transform.position = new Vector3(-265, transform.position.y, transform.position.z);
        }
        if (transform.position.x > -256)
        {
            transform.position = new Vector3(-256, transform.position.y, transform.position.z);
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        //anim.SetFloat("VelX", x);
        //anim.SetFloat("VelY", y);


    }
}
