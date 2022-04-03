using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float turnspeed;
    private float HorizontalInput;
    private float ForwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Yatay Hareket   
        HorizontalInput = Input.GetAxis("Horizontal");
        //Dikey Hareket
        ForwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward

        transform.Translate(Vector3.forward * Time.deltaTime * speed * ForwardInput);
        //Translate-Rotate ve right-up sað,sol dönüþleri yumuþattý (- yerine anlamý taþýr) 
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * HorizontalInput);
    }
}
