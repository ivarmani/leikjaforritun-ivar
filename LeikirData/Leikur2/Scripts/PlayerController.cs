using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {


    public Rigidbody rb;

    public TextMeshProUGUI CountText;
    public TextMeshProUGUI LevelText;
    public Transform SpawnPoint;
    private int count;
    private int level;

    public float jumpForce = 10f; // The force with which the player will jump
    private bool isGrounded; // Whether or not the player is on the ground
    public float forwardForce = 200f;
    public float sidewaysForce = 500f;

    void Start() 
    {
        count = 0;
        level = 1;
        SetCountText(); // setur skorið
        SetLevelText(); // setur hvaða level leikmaðurinn er á
    }


    void FixedUpdate() 
    {

        // allar hreyfingar leikmannsins

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("not grounded");
        }
    }


    // öll collision check
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) //checka hvort leimaðurinn er á ground
        {
            Debug.Log("Grounded");
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Coin")) // checka hvort leikmaðurinn er að snerta pening
        {
            Debug.Log("score");
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText(); //update-ar skorið
        }

        if (other.gameObject.CompareTag("Obstacle")) // checkar hvort leikmaður fer á obstacle sem tekur af þer stig og setur þig aftur a
        {
            Debug.Log("Hit Obstacle!");
            count = count - 1;
            transform.position = SpawnPoint.position;
            transform.rotation = SpawnPoint.rotation;

            SetCountText(); //update-ar skorið
        }

        if (other.gameObject.CompareTag("LevelTrigger")) //checka hvort leikmaður fer á leveltriggerinn
        {
            Debug.Log("next level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            level = level + 1;
            
            SetLevelText(); //update-ar level
        }
    }

    void SetCountText()
    {
        CountText.text = "Score: " + count.ToString();
    }

    void SetLevelText()
    {
        LevelText.text = "Level: " + level.ToString();
    }
}