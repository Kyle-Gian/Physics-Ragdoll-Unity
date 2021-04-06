//Author Kyle Gian
//Date Created 28/3/2021
//Last Modified 2/4/2021

//Checks if the puzzle pattern matches the users inputs. If they match open the door and buttons become inactive
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PuzzleScript : MonoBehaviour
{
    [SerializeField] LayerMask m_buttonLayer;

    [SerializeField]
    List<Puzzle> m_puzzles = new List<Puzzle>();
    List<Color32> m_listOfColors = new List<Color32>();

    List<Vector3> m_startPos = new List<Vector3>();
    List<Vector3> m_endPos = new List<Vector3>();

    Color32 m_color;
    ColorBlock m_disabledButtonColor;

    float m_fraction = 0;
    float m_distance = 0.5f;
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
            m_puzzles[i].m_cube.GetComponent<Renderer>().material.color = m_color;
            m_puzzles[i].m_colorIndex = i;

            m_endPos.Add(new Vector3(m_puzzles[i].m_cube.transform.localPosition.x, m_puzzles[i].m_cube.transform.localPosition.y + m_distance, m_puzzles[i].m_cube.transform.localPosition.z));
            m_startPos.Add(m_puzzles[i].m_cube.transform.localPosition);

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            //Check if ray hits button
            if (Physics.Raycast(rayPos, Camera.main.transform.forward, out hitInfo, 30, m_buttonLayer))
            {
                hitInfo.transform.GetComponent<Button>().onClick.Invoke();

            }
        }
        if (CheckMatchingColors())
        {
            //Deactivate buttons and change color to grey
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
        // check the colors are in the correct position
        if (m_puzzles[0].m_cube.GetComponent<Renderer>().material.color == m_listOfColors[4] && m_puzzles[1].m_cube.GetComponent<Renderer>().material.color == m_listOfColors[2] && m_puzzles[2].m_cube.GetComponent<Renderer>().material.color == m_listOfColors[1] &&
            m_puzzles[3].m_cube.GetComponent<Renderer>().material.color == m_listOfColors[0] && m_puzzles[4].m_cube.GetComponent<Renderer>().material.color == m_listOfColors[3])
        {
            return true;
        }

        return false;
    }

    public void ButtonClicked(int buttonNumber)
    {
        //Get the button that has been pressed and change the color of the corresponding cube
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
            m_puzzles[buttonNumber].m_cube.GetComponent<Renderer>().material.color = m_listOfColors[m_puzzles[buttonNumber].m_colorIndex];
        }
    }
    IEnumerator LerpBetweenPoints(int cubeNumber)
    {

        if (m_fraction < m_distance)
        {
            m_fraction += Time.deltaTime * .05f;
            m_puzzles[cubeNumber].m_cube.transform.localPosition = Vector3.Lerp(m_startPos[cubeNumber], m_endPos[cubeNumber], m_fraction);
        }
        yield return null;
    }
}


