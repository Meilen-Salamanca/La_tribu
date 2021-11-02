using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject EndScrn;
    public Reloj time;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<LogicaPersonaje>().enableMovement = false;
            EndScrn.gameObject.SetActive(true);
            time.stopTime = true;
            //other.GetComponent<LogicaPersonaje>().databaseManagement.Send();
        }
    }
}