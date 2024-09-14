using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region private members
    private Vector3 offset;
    #endregion

    #region public members
    public GameObject Player;
    #endregion

    #region methods
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = offset + Player.transform.position;
    }
    #endregion
}
