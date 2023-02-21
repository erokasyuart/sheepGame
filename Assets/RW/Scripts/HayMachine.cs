using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateMovement(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //horizontal input is the left and right keys (input)
        if (horizontalInput < 0 )
        {
            transform.Translate(transform.right * - movementSpeed * Time.deltaTime); //transform.right 
        }
        else if (horizontalInput > 0)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }
}
