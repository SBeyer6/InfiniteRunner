using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float jumpForce = 4f;

    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
        else if (collision.gameObject.tag == "Obstacle")
        {
            //Die!
            GameManager.Instance.GoToGameOverScreen(FindObjectOfType<ScoreManager>().Score);
        }
    }
        private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }
}
