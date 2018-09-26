using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CargarInfoIDMB : MonoBehaviour {
    public GameObject gameCube;
    private float startTime;
    //public float moveSpeed = 10f;
    //public float turnSpeed = 50f;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
		StartCoroutine (GetColorInfo());
	}
	
	// Update is called once per frame
	void Update () {
       //transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
        if (Time.time - startTime >= 5)
        {
            // gameCube.gameObject.transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);

            StartCoroutine(GetColorInfo());
            startTime = Time.time;
        }
}

    //Método para consumir el servicio
	public IEnumerator GetColorInfo() {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/RestJsonCube-1.0-SNAPSHOT/rest/colorcube/list"))
        {

            yield return www.SendWebRequest();


            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                JsonData jData = JsonData.CreateFromJSON(www.downloadHandler.text);
                float r = coloNumberConversion(jData.red);
                float g = coloNumberConversion(jData.green);
                float b = coloNumberConversion(jData.blue);
                gameCube.GetComponent<Renderer>().material.color = new Color(r, g, b);
            }
        }
    }
    private float coloNumberConversion(float num)
    {
        return (num / 255.0f);
    }
}
