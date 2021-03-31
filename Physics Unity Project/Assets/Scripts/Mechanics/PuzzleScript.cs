using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleScript : MonoBehaviour
{
    public GameObject m_puzzle = null;
    List<Image> m_images = null;
    List<Color> m_listOfColors = null;
    // Start is called before the first frame update
    void Start()
    {
        if (m_puzzle != null)
        {
            m_puzzle.transform.child
        }

        m_listOfColors.Add(new Color(114, 0, 255));
        m_listOfColors.Add(new Color(255, 36, 0));
        m_listOfColors.Add(new Color(59, 250, 4));
        m_listOfColors.Add(new Color(0, 248, 255));
        m_listOfColors.Add(new Color(255, 246, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
