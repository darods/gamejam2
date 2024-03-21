using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;
    private Renderer render;
    private Color originalColor;

    public ParticleSystem dustCloud;
    public bool gotPowerUp;
    void Start()
    {
        render = GetComponent<Renderer>();
        playerRb = GetComponent<Rigidbody>();
        //focalPoint = GameObject.Find("Focal Point");

    }
    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(transform.forward * verticalInput * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("powerUp"))
        {
            gotPowerUp = true;
            dustCloud.Play();
            Destroy(other.gameObject);
            StartCoroutine(changeColor());

        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("powerUp") && gotPowerUp)
        {
            playerRb.AddForce(gotPowerUp* speed,force.Impulse)
        }
    }*/
    IEnumerator changeColor()
    {
        originalColor = render.material.color;
        render.material.color = Color.yellow;
        yield return new WaitForSeconds(3);
        render.material.color = originalColor;
        dustCloud.Stop();
    }
}
