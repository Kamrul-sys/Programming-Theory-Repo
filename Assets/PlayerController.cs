using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject chick;
    public GameObject chicken;
    private float turnSpeed=45f;
    private float horizontalInput;
    private float forwardInput;
    public float moveSpeed;
    private Animal ani;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        chick.SetActive(true);
        chicken.SetActive(false);
        ani=chick.GetComponent<Animal>();
        moveSpeed=ani.MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            SwitchModel();
        }
        ani.Jump();
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed*horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed*forwardInput);
    }

    // ABSTRACTION
    public void SwitchModel(){
        if(chick.activeSelf){
            pos=chick.transform.position;
            chick.SetActive(false);
            chicken.SetActive(true);
            chicken.transform.position=pos;
            ani=chicken.GetComponent<Animal>();
        }else{
            pos=chicken.transform.position;
            chick.SetActive(true);
            chicken.SetActive(false);
            chick.transform.position=pos;
            ani=chick.GetComponent<Animal>();
        }
        moveSpeed=ani.MoveSpeed;
        ani.isGrounded=false;
    }
}
