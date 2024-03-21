using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerSound : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 1000;
    private GameObject focalPoint;
    private Renderer render;
    private Color originalColor;
    private AudioSource audioSource;


    public bool gotPowerUp;
    void Start()
    {
        render = GetComponent<Renderer>();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerUp"))
        {
            gotPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(changeColor());
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if(playerRb.velocity.magnitude > 0.5)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();

        }
    }

    IEnumerator changeColor()
    {
        originalColor = render.material.color;
        render.material.color = Color.blue;
        yield return new WaitForSeconds(3);
        render.material.color = originalColor;
    }
}
