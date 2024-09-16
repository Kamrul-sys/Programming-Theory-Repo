using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    
    // ENCAPSULATION
    [SerializeField]
    private float _moveSpeed=20f;
    [SerializeField]
    protected float _jumpForce=100f;
    public bool isGrounded=false;
    protected Rigidbody rb;
    public float MoveSpeed { 
        get{
            return _moveSpeed;
        }
        set{
            _moveSpeed=value;
        }
    }
    void Start()
    {
        
        rb= gameObject.GetComponent<Rigidbody>();
    }

    public virtual void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded){
            rb.AddForce(Vector3.up * _jumpForce ,ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded=true;
        }
    }
    public void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded=false;
        }
    }
}
