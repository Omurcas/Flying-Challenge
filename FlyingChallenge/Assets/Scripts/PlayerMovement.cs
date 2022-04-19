using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float verticalInput;
    [SerializeField] private FollowPlayer cameraT;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private bool isGameOver = false;
    private GameManager gm;
    void Start()
    {
        cameraT = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

       transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * verticalInput);

        if (isGameOver)
        {
            if (Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("Challenge 1");
                Time.timeScale = 1;
            }
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            GameOver();
            FinishScreen();

        }
    }

    void GameOver()
    {
        Time.timeScale=0;
        cameraT.offset = new Vector3(30, 9, -5);
        isGameOver = true;
        
    }

    void FinishScreen()
    {
        GameOverScreen.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finished"))
        {
            gm.FinishText();
            GameOver();
        }
    }
}
