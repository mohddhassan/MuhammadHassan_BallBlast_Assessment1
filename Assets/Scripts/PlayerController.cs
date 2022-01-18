//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}








using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float zRange = 10.0f;
    private int playerHealth = 100;
    public bool gameOver = false;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * horizontalInput * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BigBall"))
        {
            playerHealth -= 30;
            Destroy(GameObject.FindWithTag("BigBall"));
            Debug.Log(playerHealth);
        }

        if (playerHealth < 1)
        {
            Destroy(gameObject);
            gameOver = true;
            Debug.Log("Game Over");
        }


    }



}
