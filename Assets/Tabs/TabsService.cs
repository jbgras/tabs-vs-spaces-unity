/* 
 * Post Example
 * ------------------------------
 * An example of how to extend the SimpleWebService class and make 
 * a request to web API that returns JSON. This examples
 * uses https://jsonplaceholder.typicode.com/ and it's 
 * free User API to illustrate the round trip.
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class TabsService : SimpleWebService
{

    string baseURL = "http://localhost:5001/tabs";

    public void GetTabsScore(CallBack callback) 
    {
        base.Get(baseURL, callback);
    }


    public void AttemptAddTabScore(CallBack callback) 
    {
        string jsonPayload = "{}";
        base.Post(baseURL , jsonPayload, callback);
    }

}