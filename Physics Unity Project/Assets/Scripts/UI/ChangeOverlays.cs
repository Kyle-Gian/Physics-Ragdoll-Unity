using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOverlays : MonoBehaviour
{
    StoredOverlays storedOverlays = null;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Game Manager") != null)
        {
            storedOverlays = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<StoredOverlays>();
        }

        StartCanvasesFalse();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCanvasToActive(storedOverlays.storeOverlays;
        }
        
    }

    void SetCanvasToInactive(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
    }
    void SetCanvasToActive(Canvas canvas)
    {
        canvas.gameObject.SetActive(true);
    }

    void StartCanvasesFalse()
    {
        //foreach (var overlay in StoredOverlays.storeOverlays)
        //{
        //    overlay.gameObject.SetActive(false);
        //}
    }
}
