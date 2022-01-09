using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;


public enum httpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

public class RestClient
{
    public string url;
    public httpVerb methode;

    public RestClient(string url)
    {
        this.url = url;
        this.methode = httpVerb.GET;
    }

    public string makeRequest()
    {
        string strResponse = "";

        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

        request.Method = this.methode.ToString();

        // using: method that deletes data after being used
        using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
        {
            // for the case if request did not work
            if(response.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("error - not accessible");
            }
            // data stream that sends the data to unity
            using (Stream responseStream = response.GetResponseStream())
            {
                if(responseStream != null)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        strResponse = reader.ReadToEnd();
                    }
                }
            }
        }
        return strResponse;
    }
}
public class SwaggerTest1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Swagger Test Start Function");
        RestClient resti = new RestClient("https://api.coindesk.com/v1/bpi/currentprice.json");
        //ttps://digitaltwinservice.de/api/Database/GetAllDevices?user=admin
        Debug.Log(resti.makeRequest());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
