using UnityEngine;
using System.Collections;

public class TouchButton : MonoBehaviour
{
    public Color defaultColor;
    public Color selectedColor;
    private Material mat;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    void OnTouchDown()
    {
        mat.color = selectedColor;
        gameObject.AddComponent<SendWWWMessage>();
    }
    void OnTouchUp()
    {
        mat.color = defaultColor;
    }
    void OnTouchStay()
    {
        mat.color = selectedColor;
    }
    void OnTouchExit()
    {
        mat.color = defaultColor;
    }
}

public class SendWWWMessage : MonoBehaviour
{
    public void Start() 
    {
        string url = "http://10.0.69.111:1881/test/";
        byte[] postBytes = System.Text.Encoding.ASCII.GetBytes("on");
        WWW www = new WWW(url, postBytes);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        if (www.error == null)
            Debug.Log("WWW Success: " + www.text + " - " + www.url);
        else
            Debug.Log("WWW Error: " + www.error + " - " + www.url);
    }
}
