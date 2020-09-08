using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject restartBtnObj;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private int count;
    private float timer;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 0;

        SetCountText();

        winTextObject.SetActive(false);
        restartBtnObj.SetActive(false);

        //Start the coroutine we define below named ExampleCoroutine.

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }

    private void Update()
    {
    }

    void SetCountText()
    {
        countText.text = "😎 Score: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            restartBtnObj.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count++;
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }


}
