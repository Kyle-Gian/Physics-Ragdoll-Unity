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
    // Start is called before the first frame update
    void Start()
    {
        m_listOfColors.Add(new Color32(114, 0, 255,255));
        m_listOfColors.Add(new Color32(255, 36, 0,255));
        m_listOfColors.Add(new Color32(59, 250, 4,255));
        m_listOfColors.Add(new Color32(0, 248, 255,255));
        m_listOfColors.Add(new Color32(255, 246, 0,255));

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
                //hitInfo.transform.GetComponent<Button>().onClick.Invoke();

                for (int i = 0; i < m_puzzles.Count; i++)
                {
                    Debug.Log(hitInfo.collider);
                    if (hitInfo.collider == m_puzzles[i].m_button.GetComponent<BoxCollider>())
                    {
                        if (m_puzzles[i].m_colorIndex == m_listOfColors.Count - 1)
                        {
                            m_puzzles[i].m_colorIndex = 0;
                        }
                        else
                        {
                            m_puzzles[i].m_colorIndex++;
                        }
                        m_puzzles[i].m_image.color = m_listOfColors[m_puzzles[i].m_colorIndex];
                    }
                }
            }
        }

    }
}
