using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [SerializeField]
    public InstrumentsSO instrument;
    
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
    private AudioSource ss;

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

        ss = GetComponent<AudioSource>();
        ss.volume = instrument.CollisionVolume;
        ss.clip = instrument.Collision;
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
        // Play collision sound for this instrument
        PlayCollision();

        if (!Bounce)
        {
            xDir -= xDir;
            yDir -= yDir;
            xForce -= xForce * instrument.ForceMultiplier;
            yForce -= yForce * instrument.ForceMultiplier;
            rb.AddForce(xForce, yForce, 0, ForceMode.Impulse);
            //Bounce = true;
        }
    }

    public void PlayInstrument()
    {
        // Play musical sound for this instrument
        ss.volume = instrument.SoundVolume;
        ss.clip = instrument.Sound;
        ss.Play();

    }

    public void PlayCollision()
    {
        if (!ss.isPlaying)
        {
            ss.volume = instrument.CollisionVolume;
            ss.clip = instrument.Collision;
            var volume = instrument.CollisionVolume;
            Debug.Log("Collision clip: " + ss.clip.name);
            Debug.Log("Collision volume: " + volume);
            ss.Play();
        }
    }
}
