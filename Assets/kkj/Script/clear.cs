using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class clear : MonoBehaviour
{
    public string sceneName = "";

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Vehicles"))
        {
            
            SceneManager.LoadScene(sceneName);
        }
    }
}
