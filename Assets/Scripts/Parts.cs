using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [SerializeField]
    private float forceMultiplier = 1.75f;

    [SerializeField]
    private float xDir = 0.0f;

    [SerializeField]
    private float yDir = 0.0f;

    [SerializeField]
    private float xRot = 0.0f;

    [SerializeField]
    private float yRot = 0.0f;

    private bool Bounce = false;
    private float xForce;
    private float yForce;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xForce = Random.Range(-50f, 50f);
        yForce = Random.Range(-50f, 50f);
        xDir = Random.Range(-.5f, .5f);
        yDir = Random.Range(-.5f, .5f);
        xRot = Random.Range(-.1f, 5f);
        yRot = Random.Range(-.1f, 5f);

        rb.AddForce(xForce, yForce, 0, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        //rb.AddForce(xForce, yForce, 0, ForceMode.Impulse);
    }

    void Update()
    {
        //GetComponent<Rigidbody>().transform.Translate(xDir, yDir, 0f);
        //GetComponent<Rigidbody>().transform.Rotate(xRot, 0, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!Bounce)
        {
            xDir -= xDir;
            yDir -= yDir;
            xForce -= xForce*forceMultiplier;
            yForce -= yForce*forceMultiplier;
            rb.AddForce(xForce, yForce, 0, ForceMode.Impulse);
            //Bounce = true;
        }
    }
}
