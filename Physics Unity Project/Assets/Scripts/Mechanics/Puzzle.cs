using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Puzzle
{
    public Image m_image;
    public int m_colorIndex = 0;
    public Button m_button;

    public void SetcolorIndex(int a_colorIndex)
    {
        m_colorIndex = a_colorIndex;

    }
    public int GetcolorIndex()
    {
        return m_colorIndex;
    }
}
