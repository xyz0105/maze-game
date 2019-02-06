using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Text winText;

    private Rigidbody rb;

    public LayerMask groundLayers;
    public float jumpForce = 2;
    public SphereCollider col;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.text = "";
        col = GetComponent<SphereCollider>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") *speed;
        float moveVertical = Input.GetAxis("Vertical")*speed;
        moveHorizontal *= Time.deltaTime;
        moveVertical *= Time.deltaTime;

        transform.Translate(moveHorizontal, 0 , moveVertical);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private bool IsGrounded()
    {
        if (transform.position.y >= 0.7f)
            return false;
        else
            return true;
    }
}