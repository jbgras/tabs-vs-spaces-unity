using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class SpacesService : SimpleWebService
{
    string baseURL = GameConfig.apiBaseUrl + "/spaces";

    public void GetSpacesScore(CallBack callback) 
    {
        base.Get(baseURL, callback);
    }

    public void AttemptAddSpaceScore(CallBack callback) 
    {
        string jsonPayload = "{}";
        base.Post(baseURL , jsonPayload, callback);
    }
}