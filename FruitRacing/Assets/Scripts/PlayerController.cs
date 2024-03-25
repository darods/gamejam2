using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 800;
    private GameObject focalPoint;
    private GameObject fruit;
    private Renderer render;
    private Color originalColor;

    public ParticleSystem dustCloud;
    public bool gotPowerUp;
    public GameObject onFire;

    public float playerDistance;
    public GameObject[] points;
    public PositionManager master;

    private const string NAME_SCENE_1 = "Level 1 Test";
    private const string NAME_SCENE_2 = "Level 2 Test";
    private const string NAME_SCENE_3 = "Level 3 Test";

    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        fruit = GameObject.Find("coco");
        render = fruit.GetComponent<Renderer>();
        onFire = GameObject.Find("onFire");
        onFire.gameObject.SetActive(false);

        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case NAME_SCENE_1:
                AudioManager.Instance.PlayMusic("Chunky_Monkey");
                break;
            case NAME_SCENE_2:
                AudioManager.Instance.PlayMusic("InfiniteDoors");
                break;
            case NAME_SCENE_3:
                AudioManager.Instance.PlayMusic("Tiny_Blocks");
                break;
            default:
                AudioManager.Instance.PlayMusic("Chunky_Monkey");
                break;
        }

    }
    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        onFire.transform.position = transform.position;
        dustCloud.transform.position = transform.position;
        FindDistance();
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("powerUp"))
        {
            gotPowerUp = true;
            onFire.gameObject.SetActive(true);
            dustCloud.Play();
            Destroy(other.gameObject);
            StartCoroutine(activatePowerUp());

        }
    }

    IEnumerator activatePowerUp()
    {
        originalColor = render.material.color;
        speed *= 2; // multiply by 3 the speed
        render.material.color = Color.blue;
        yield return new WaitForSeconds(3);
        speed /= 2; // set normal speed again
        render.material.color = originalColor;
        dustCloud.Stop();
        onFire.gameObject.SetActive(false);
    }

    public void FindDistance()
    {
        playerDistance = Vector3.Distance(points[master.currentPoint].transform.position, transform.position);
    }


}
