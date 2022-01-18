using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private float spawnRangeY = 10;
    private float spawnRangeZ = 10;
    private float startDelay = 2;
    private float spawnInterval = 3f;
    private Rigidbody coinRb;
    public float jumpForce = 40;
    private int tipCount = 0;
    public bool isPlayerAlive = true;
    private PlayerController playerControlScript;
    private bool collidedWithBullet = false;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

        coinRb = GetComponent<Rigidbody>();
        InvokeRepeating("SpawnBigBall", startDelay, spawnInterval);
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, GameObject.FindWithTag("Player").transform.position, bulletPrefab.transform.rotation);
        }

    }

    void SpawnBigBall()
    {
        if (playerControlScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(10, Random.Range(10, 12), Random.Range(-10, 10));
            Instantiate(ballPrefabs[0], spawnPos, ballPrefabs[0].transform.rotation);
        }

        if (collidedWithBullet)
        {
            Destroy(gameObject);
            Vector3 spawnPosMedium = new Vector3(10, Random.Range(10, 12), Random.Range(-10, 10));
            Instantiate(ballPrefabs[1], transform.position, ballPrefabs[1].transform.rotation);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        tipCount++;

        if (collision.gameObject.CompareTag("Floor") && tipCount <= 2)
        {
            
            coinRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("collided");
        }

        else if (tipCount > 2)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            collidedWithBullet = true;
            Debug.Log("bulletcollision");

        }

    } 
} 
