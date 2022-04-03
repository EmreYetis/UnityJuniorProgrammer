using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Özel Deðiþkenler
    [SerializeField] private float horsePower = 0;
    [SerializeField] float speed = 20.0f;
    [SerializeField] private float turnspeed = 50.0f;
    [SerializeField] float rpm;
    private float HorizontalInput;
    private float ForwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {   //Yatay Hareket   
        HorizontalInput = Input.GetAxis("Horizontal");
        //Dikey Hareket
        ForwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {     
        //Move the vehicle forward

        //transform.Translate(Vector3.forward * Time.deltaTime * speed * ForwardInput);
        //Translate-Rotate ve right-up sað,sol dönüþleri yumuþattý (- yerine anlamý taþýr) 
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * HorizontalInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * ForwardInput);

        speed =Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); //mil 2.237 km 3.6
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = (speed % 30)*40;
        rpmText.SetText("RPM: " + rpm);
        }


    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
