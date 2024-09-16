using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Chicken : Animal
{
    public float glideStrength = 2f;  
    private bool isGliding = false;

    // POLYMORPHISM
    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y < 0)
        {
            Glide(); 
        }
        
    }

    
    private void Glide()
    {
       
            
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Max(rb.velocity.y, -glideStrength), rb.velocity.z); 
        
    }
}

