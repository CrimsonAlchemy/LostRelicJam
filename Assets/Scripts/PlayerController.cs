using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private float speed;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        speed = 5f;

        // Instantiate(clone, new Vector3(3f, 3f, 0f), Quaternion.identity);
    }

    
    // Update is called once per frame
    void Update()
    {
        // Always have movement enabled for player, while script is enabled
        Movement();

    }


    // Dictate player movement
    void Movement()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        // if (move.x > 0)
        //     anim.SetBool("Right", true);
        // else if (move.x < 0)
        //     anim.SetBool("Right", false);

        rb.MovePosition(rb.position + movementVector.normalized * speed * Time.fixedDeltaTime);
    }


    // Checks for an object that is within the collider
    void OnTriggerEnter2D(Collider2D collider)
    {

    }
    

    // Checks for an object leaving the collider
    void OnTriggerExit2D(Collider2D collider)
    {

    }


    private IEnumerator Test()
    {
        yield return new WaitForSeconds(0.5f);
    }

}