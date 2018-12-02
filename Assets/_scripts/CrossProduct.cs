using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProduct : MonoBehaviour {

    [SerializeField]
    private Vector3 _cube1;
    [SerializeField]
    private Vector3 _cube2;

    private Vector3 _cross;
    private CrossProduct _c;
 
    private Ray _ray;
    private Vector3 _newAngle;
    private Rigidbody _rb;

    // Use this for initialization
    private void Start () {
        crossProduct();
        //transform.position = cube1;
    }
	
	// Update is called once per frame
    private void Update()
    {
        crossProduct();

        _ray = new Ray(transform.position, _cross);
        //Debug.DrawRay(r.origin, r.direction * 100,Color.white,100, true);
        //Debug.DrawRay(r.origin, Vector3.Angle(r.origin, cube2), Color.white, 100, true);
        _newAngle = _cube2 - transform.position;
        print(_newAngle);
        transform.rotation = Quaternion.LookRotation(_newAngle);

        Debug.DrawRay(_ray.origin, transform.up * 100);
        Debug.DrawRay(_ray.origin, transform.forward * -100, Color.red);
        Debug.DrawRay(_ray.origin, transform.right * 100, Color.yellow);

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    public void OnGui()
    {
    }

    private void crossProduct()
    {
        _cube1 = GameObject.Find("Cube1").transform.position;
        _cube2 = GameObject.Find("Cube2").transform.position;
        _cross = Vector3.Cross(_cube1, _cube2);

        Vector3 a = Vector3.Cross(_cube1, _cube2);
        var _quaternion = new Quaternion(a.x,
                           a.y,
                           a.z,
                           Mathf.Sqrt((Mathf.Pow(_cube1.magnitude, 2)) * (Mathf.Pow(_cube2.magnitude, 2))) + Vector3.Dot(_cube1, _cube2));

    }
}
