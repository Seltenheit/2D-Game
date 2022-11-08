using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 7;
    float screenHalfWidthInWorldUnits;

    public event System.Action OnPlayerDeath;

    //float velocity;
    //int coinCounter;
    //Rigidbody rigidbody;
    //Vector2 velocity;
 
    void Start()
    {
       // rigidbody = GetComponent<Rigidbody>();
       screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        float halfPlayerWidth = transform.localScale.x / 2f;

    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Vector2 direction = input.normalized;
        //velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        //FindObjectOfType<GameOver>().OnGameOver();
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }    
            
    }
}
