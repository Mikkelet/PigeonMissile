using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class Missile : MonoBehaviour {

    private Rigidbody _rigidbody;

    // stuff for restarting scene
    private Vector3 _startPos;
    private Quaternion _startRot;

	// Use this for initialization
    private void Start () {
        _rigidbody = GetComponent<Rigidbody>();

        _startPos = transform.position;
        _startRot = Quaternion.identity;
	}
	
	// Update is called once per frame
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (_rigidbody.velocity.Equals(Vector3.zero))
                _rigidbody.AddRelativeForce(transform.up * 2000); //Fires up if standing still
            else
                _rigidbody.AddRelativeForce(transform.forward * 1000); // Fires forward if moving, ie in air
            print("explode!");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "terrain" && Grounded())
           RestartScene();

        print(Grounded());
    }

    private void OnCollisionExit(Collision collision)
    {

    }

    private void RestartScene()
    {
        transform.position = _startPos;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.rotation = _startRot;
        
        //isTouching = true;
    }

    private bool Grounded()
    {
        return _rigidbody.velocity.Equals(Vector3.zero);
    }
}   
