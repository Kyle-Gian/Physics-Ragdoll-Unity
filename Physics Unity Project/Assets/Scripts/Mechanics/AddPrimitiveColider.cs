using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPrimitiveColider : MonoBehaviour
{
    MeshRenderer _obj = null;
    GameObject _gameObject = null;

    [SerializeField]
    int _createBoxColliders = 5;

    BoxCollider[] boxColliders;
    // Start is called before the first frame update
    void Start()
    {
        _gameObject = this.gameObject;
        _obj = GetComponent<MeshRenderer>();
        Debug.Log(_obj.bounds.ToString());
        Debug.Log(_obj.bounds.ToString());




        //Add the boxes to an array that stores required boxes
        for (int i = 0; i < _createBoxColliders; i++)
        {
            boxColliders[i] = new BoxCollider();
        }
    }

    void CreateCollider()
    {
        // Get center then Extents
       //add collider only on rendered positions
       // no greater than 0.2 outside extents
        foreach (var boxC in boxColliders)
        {
            if (_obj != null)
            {
                //_gameObject.AddComponent<>
            }
        }


    }

}
