using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool alive = true;

    // Start is called before the first frame update
    public float speed = 10;
    [SerializeField] Rigidbody rb;
    public float xRange = 4.5f;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 5;

    public float speedIncreasePerPoint = 0.1f;

    private void FixedUpdate()
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

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(transform.position.y < -5) 
        {
          Die();
        }
    }

    public void Die()
    {
      alive = false;
      Restart();
    }

    void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
