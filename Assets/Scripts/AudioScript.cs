using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var theCollisionSound = collision.gameObject.GetComponent<AudioSource>();
        Debug.Log("Collision sound: " + theCollisionSound);
        if(theCollisionSound != null)
        {
            theCollisionSound.Play();
            Debug.Log("Collision sound is playing: " + theCollisionSound);

        }

    }
}
