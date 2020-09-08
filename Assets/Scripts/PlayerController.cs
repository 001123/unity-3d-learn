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
    private float Timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
        restartBtnObj.SetActive(false);

        //Start the coroutine we define below named ExampleCoroutine.
        FindObjectOfType<SoundManager>().Play("wellcome");

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
        Timer += Time.deltaTime;
        if (count < 12)
        {
            countText.text = "😎 Score: " + count.ToString() + " - Time: " + Timer.ToString("0.00") + "s";
        }
    }

    void SetCountText()
    {
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            restartBtnObj.SetActive(true);
            FindObjectOfType<SoundManager>().Play("win");
            countText.text = "😎 Score: " + count.ToString() + " - Time: " + Timer.ToString("0.00") + "s";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count++;

            other.gameObject.SetActive(false);

            FindObjectOfType<SoundManager>().Play("kill" + count.ToString());

            SetCountText();
        }
    }


}
