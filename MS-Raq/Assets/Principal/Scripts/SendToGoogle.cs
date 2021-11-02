using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{

    public GameObject username;
    public GameObject frec;
    public GameObject tiempo;
    public GameObject doc;
    public GameObject niv;

    public Reloj tiempoReloj;
    public Text frecuenciaCardiaca;

    private string Name;
    private string Frec;
    private string Tiempo;
    private string Doc;
    private string Niv;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdz83egBqn5oC0a0rQQjeiWr-1R9zotyhNYGC4Bwsc2FlP8OA/formResponse";

    private IEnumerator Post(string name, string frec, string tiempo, string doc, string niv)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1788866389", name);
        form.AddField("entry.1906205503", frec);
        form.AddField("entry.2054568226", tiempo);
        form.AddField("entry.30141222", doc);
        form.AddField("entry.405680191", niv);


        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    public void Send()
    {
        Name = username.GetComponent<InputField>().text;
        Frec = frec.GetComponent<InputField>().text;
        Tiempo = tiempo.GetComponent<InputField>().text;
        Doc = doc.GetComponent<InputField>().text;
        Niv = niv.GetComponent<InputField>().text;
        StartCoroutine(Post(Name, Frec, Tiempo, Doc, Niv));
    }
    public void SendSecond()
    {
        Name = username.GetComponent<InputField>().text;
        Doc = doc.GetComponent<InputField>().text;
        Niv = niv.GetComponent<InputField>().text;
        StartCoroutine(Post(Name, frecuenciaCardiaca.text, tiempoReloj.GetFormatedTime(), Doc, Niv));
    }

    public void Send(string name, string frequency, string time, string specialist, string level)
    {
        StartCoroutine(Post(name, frequency, time, specialist, level));
    }

    public void Send(string frequency, string time)
    {
        Name = username.GetComponent<InputField>().text;
        Doc = doc.GetComponent<InputField>().text;
        Niv = niv.GetComponent<InputField>().text;
        StartCoroutine(Post(Name, frequency, time, Doc, Niv));
    }
}