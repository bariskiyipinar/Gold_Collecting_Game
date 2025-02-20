using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character : MonoBehaviour
{
    public float speed = 5f;
    public TextMeshProUGUI text;
    private int goldtext=0;
    public GameObject ball;

    private Rigidbody rb;
    public float jumpforce = 5f;
    public bool isgrounded = true;



    public CameraController cameraController;

    private void Start()
    {
        text.text = goldtext + " ";
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        float yatayhareket = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float dikeykontrol=Input.GetAxis("Vertical")*Time.deltaTime * speed;

        Vector3 go = new Vector3(yatayhareket, 0f, dikeykontrol);
        
        transform.Translate(go);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y < 0.1f) // Yere yakýnsa zýpla
            {
                isgrounded = false;
                rb.AddForce(jumpforce * Vector3.up, ForceMode.Impulse); // Zýplama kuvveti uygula
            }
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GOLD"))
        {
            Destroy(other.gameObject);
            goldtext++;
            text.text= goldtext + " ";
        }
        if (other.gameObject.name=="Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(ball))
        {
            Time.timeScale = 0;
            cameraController.enabled = false;
               
        }
        if (collision.gameObject.CompareTag("ENEMY"))
        {
            Time.timeScale = 0;
            cameraController.enabled = false;
        }

        if ((collision.gameObject.CompareTag("GROUND")))
        {
            isgrounded=true;
        }
    }
}
