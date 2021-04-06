//Author Kyle Gian
//Date Created 2/4/2021
//Last Modified 6/4/2021

//Puzzle class used to take in information of an object, color and button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Puzzle
{
    public GameObject m_cube;

    [HideInInspector]
    public Color m_cubeColor;
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
