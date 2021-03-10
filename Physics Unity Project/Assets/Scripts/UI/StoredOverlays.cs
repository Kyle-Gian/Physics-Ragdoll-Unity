using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredOverlays : MonoBehaviour
{
    [SerializeField]
    bool autoAddCanvases = false;
    public List<Canvas> storeOverlays;

    Canvas[] getCanvases;

    // Start is called before the first frame update
    void Start()
    {

        getCanvases = GameObject.FindObjectsOfType<Canvas>();
        //if no canvases have been added to list then populate list with overlays
        if (storeOverlays == null && autoAddCanvases == true)
        {

            for (int i = 0; i < getCanvases.Length; i++)
            {
                storeOverlays.Add(getCanvases[i]);

            }
            storeOverlays.Sort();
        }

        //Let the user know there may be missing canvases
        if (storeOverlays.Count != getCanvases.Length)
        {
            Debug.Log("Some Canvases are missing. Potential for Canvases not working as intended.");
        }

        //If the list is empty notify user
        if (storeOverlays == null)
        {
            Debug.Log("No Canvases Added to Game Scene");
        }
    }
}
