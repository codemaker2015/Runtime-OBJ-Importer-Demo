using Dummiesman;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ObjFromStream : MonoBehaviour {
	void Start () {

        StartCoroutine(GetModel("https://raw.githubusercontent.com/codemaker2015/3d-models/master/models/lamp.obj"));

        //make www
        // var www = new WWW("");
        // while (!www.isDone)
        //     System.Threading.Thread.Sleep(1);
        
        // //create stream and load
        // var textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.text));
        // var loadedObj = new OBJLoader().Load(textStream);
	}

    IEnumerator GetModel(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                //create stream and load
                var textStream = new MemoryStream(Encoding.UTF8.GetBytes(webRequest.downloadHandler.text));
                var loadedObj = new OBJLoader().Load(textStream);
            }
        }
    }
}
