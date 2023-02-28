using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject haybale;
    public Transform haySpawn;
    public float shootInterval;
    private float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    private void UpdateMovement(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //horizontal input is the left and right keys (input)
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * - movementSpeed * Time.deltaTime); //transform.right 
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }

    private void ShootHay()
    {
        Instantiate(haybale, haySpawn.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }

    private void UpdateShooting(){
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)){
            shootTimer = shootInterval;
            ShootHay();
        }
    }
}
