using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Puzzle
{
   public Image m_image;
   public int m_colorIndex;
   public Button m_button;
}

public class PuzzleScript : MonoBehaviour
{
    int m_colorIndex = 0;
    
    [SerializeField]
    List<Puzzle> m_puzzles = null;
    List<Color> m_listOfColors = null;
    // Start is called before the first frame update
    void Start()
    {
        m_listOfColors.Add(new Color(114, 0, 255));
        m_listOfColors.Add(new Color(255, 36, 0));
        m_listOfColors.Add(new Color(59, 250, 4));
        m_listOfColors.Add(new Color(0, 248, 255));
        m_listOfColors.Add(new Color(255, 246, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rayPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        //RaycastHit hitInfo;

        //if (Physics.Raycast(rayPos, Camera.main.transform.forward, out hitInfo, 30))
        //{
        //    for (int i = 0; i < m_images.Count; i++)
        //    {

        //        if (hitInfo.collider.gameObject == m_images[i].gameObject.GetComponent<Button>() && Input.GetMouseButtonDown(0))
        //        {
        //            m_images[i].color = m_listOfColors[m_colorIndex];
        //        }
        //    }
        //}

        for (int i = 0; i < m_puzzles.Count; i++)
        {
            m_puzzles[i].m_image.color = m_listOfColors[m_colorIndex];
        }

    }
    public void ChangeColor()
    {
        for (int i = 0; i < m_puzzles.Count; i++)
        {
            m_puzzles[1].m_button.onClick ;

        }
        if (m_colorIndex < m_listOfColors.Count)
        {
            m_colorIndex++;
        }
        else
        {
            m_colorIndex = 0;
        }
    }
}
