//Author Kyle Gian
//Date Created 3/4/2021
//Last Modified 6/4/2021

//Rotates the cubes used in the puzzle 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_objectsToRotate = new List<GameObject>();

    [SerializeField]
    float m_rotationSpeed = 30;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_objectsToRotate.Count; i++)
        {
            RotateFloatingCubes(i);
        }

    }

    void RotateFloatingCubes(int cubeNumber)
    {
        m_objectsToRotate[cubeNumber].transform.Rotate(Vector3.down, m_rotationSpeed * Time.deltaTime);

    }
}
