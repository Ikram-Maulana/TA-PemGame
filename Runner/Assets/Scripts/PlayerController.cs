using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool alive = true;
    public float speed = 10;
    [SerializeField] Rigidbody rb;
    public float xRange = 4.5f;
    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 5;
    public float speedIncreasePerTime = 0.1f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] LayerMask groundMask;
    private Vector3 initialPosition;
    private Vector3 initialVelocity;
    private static PlayerController sharedInstance;

    private void Awake()
    {
      sharedInstance = this;
      initialPosition = transform.position;

      rb = GetComponent<Rigidbody>();
      initialVelocity = rb.velocity;
      alive = true;
    }

    public static PlayerController GetInstance()
    {
        return sharedInstance;
    }

    public void StartGame()
    {
      alive = true;
      transform.position = initialPosition;
      rb.velocity = initialVelocity;
    }

    private void FixedUpdate()
    {
        GameState currState = GameManager.GetInstance().currentGameState;
        if(currState == GameState.InGame)
        {
          if(!alive) return;

          Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
          Vector3 horizontalMove = transform.right * horizontalInput * Time.fixedDeltaTime * horizontalMultiplier;
          rb.MovePosition(rb.position + forwardMove + horizontalMove);
          if (transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
          }
          if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
          }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        bool inGameMode = GameManager.GetInstance().currentGameState == GameState.InGame;
        horizontalInput = Input.GetAxis("Horizontal");

        if(inGameMode && Input.GetKeyDown(KeyCode.Space)) {
          Jump();
        }

        if(inGameMode && transform.position.y < -5) 
        {
          Die();
        }
    }

    public void Die()
    {
      alive = false;
      Debug.Log("Fox has been eliminated");
      GameManager.GetInstance().GameOver();
    }

    void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump() 
    {
      if(IsOnTheGround() == true)
      {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      }
    }

    bool IsOnTheGround()
    {
      float height = GetComponent<Collider>().bounds.size.y;
      bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) * 0.1f, groundMask.value);
      return isGrounded;
    }
}
