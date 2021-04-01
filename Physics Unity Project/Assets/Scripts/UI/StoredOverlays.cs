using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Overlays
{
    [SerializeField]
    string id;
    [SerializeField]
    Canvas canvas;

    public Overlays(string a_id, Canvas a_canvas)
    {
        id = a_id;
        canvas = a_canvas;
    }
    public Overlays(Canvas a_canvas)
    {
        canvas = a_canvas;
        if (canvas.gameObject.tag != null)
        {
            id = canvas.gameObject.tag;
        }
        else
        {
            id = "null";
        }

    }

    string GetID()
    {
        return id;
    }
    public void SetID(string a_id)
    {
        id = a_id;

    }
    Canvas GetCanvas()
    {
        return canvas;
    }
    void SetCanvas(Canvas a_canvas)
    {
        canvas = a_canvas;
    }
}
public class StoredOverlays : MonoBehaviour
{
    [SerializeField]
    bool autoAddOverlays = false;

    public List<Overlays> storedOverlays;

    [SerializeField]
    Canvas playerOverlay = null;
    [SerializeField]
    Canvas pauseMenu;

    Canvas[] getCanvases;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu != null)
        {
            storedOverlays.Add(new Overlays(pauseMenu));
        }
        if (playerOverlay != null)
        {
            storedOverlays.Add(new Overlays(playerOverlay));
        }

        getCanvases = GameObject.FindObjectsOfType<Canvas>();

        //Let the user know there may be missing canvases
        if (storedOverlays.Count != getCanvases.Length)
        {
            Debug.Log("Some Canvases are missing. Potential for Canvases not working as intended.");
        }

        //If the list is empty notify user
        if (storedOverlays.Count == 0)
        {
            Debug.Log("No Canvases Added to Game Scene");
        }
    }
}
