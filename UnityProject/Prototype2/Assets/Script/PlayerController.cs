using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10f;
    public float xRange = 10f;
    public float zRangeTop = 14f;
    public float zRangeBottom = 0f;

    public Transform projectileSpawnPoint;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //keep the player in bounds
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z > zRangeTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeTop);
        }
        if (transform.position.z < zRangeBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeBottom);
        }

        //shoot banana
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //launch a projectile  from player
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }

        //movement player
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
    }
}
