using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour
{
    [SerializeField]
    Vector3 direction;

    [SerializeField]
    float speed = 4;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //make direction a unit vector
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
}
