using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PuzzleScript : MonoBehaviour
{
    [SerializeField] LayerMask buttonLayer;

    [SerializeField]
    List<Puzzle> m_puzzles = new List<Puzzle>();
    List<Color32> m_listOfColors = new List<Color32>();

    Color m_color;
    ColorBlock m_disabledButtonColor;
    // Start is called before the first frame update
    void Start()
    {
        // Add colors that are on the images to list
        m_listOfColors.Add(new Color32(114, 0, 255, 255));
        m_listOfColors.Add(new Color32(59, 250, 4, 255));
        m_listOfColors.Add(new Color32(255, 36, 0, 255));
        m_listOfColors.Add(new Color32(0, 248, 255, 255));
        m_listOfColors.Add(new Color32(255, 246, 0, 255));

        //give default colors to the puzzle
        for (int i = 0; i < m_puzzles.Count; i++)
        {
            m_color = new Color32(m_listOfColors[i].r, m_listOfColors[i].g, m_listOfColors[i].b, m_listOfColors[i].a);

            m_puzzles[i].m_image.color = m_color;
            m_puzzles[i].m_colorIndex = i;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayPos, Camera.main.transform.forward, out hitInfo, 30, buttonLayer))
            {
                hitInfo.transform.GetComponent<Button>().onClick.Invoke();

            }
        }
        if (CheckMatchingColors())
        {
            for (int i = 0; i < m_puzzles.Count; i++)
            {
                m_puzzles[i].m_button.interactable = false;
                m_disabledButtonColor =  m_puzzles[i].m_button.colors;
                m_disabledButtonColor.normalColor = Color.grey;
                m_puzzles[i].m_button.colors = m_disabledButtonColor;
            }
            Debug.Log("Puzzle Completed");
        }
    }

    public bool CheckMatchingColors()
    {
        if (m_puzzles[0].m_image.color == m_listOfColors[4] && m_puzzles[1].m_image.color == m_listOfColors[2] && m_puzzles[2].m_image.color == m_listOfColors[1] &&
            m_puzzles[3].m_image.color == m_listOfColors[0] && m_puzzles[4].m_image.color == m_listOfColors[3])
        {
            return true;
        }

        return false;
    }

    public void ButtonClicked(int buttonNumber)
    {
        if (m_puzzles[buttonNumber].m_button.interactable)
        {
            if (m_puzzles[buttonNumber].m_colorIndex == m_listOfColors.Count - 1)
            {
                m_puzzles[buttonNumber].m_colorIndex = 0;
            }
            else
            {
                m_puzzles[buttonNumber].m_colorIndex++;
            }
            m_puzzles[buttonNumber].m_image.color = m_listOfColors[m_puzzles[buttonNumber].m_colorIndex];
        }
    }
}
