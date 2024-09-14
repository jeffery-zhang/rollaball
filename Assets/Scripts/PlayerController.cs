using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    #region private members
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count = 0;
    #endregion

    #region public members
    public int speed = 0;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    #endregion

    #region methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        WinTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    #endregion

    #region private methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = $"Count: {count}";
        if (count >= 12)
            WinTextObject.SetActive(true);
    }
    #endregion
}
