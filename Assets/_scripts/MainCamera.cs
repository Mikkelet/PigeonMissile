using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private Collider col;
    private GameObject naziShip;
    private GameObject _parent;
    private Vector3 _posDiff;
    private Quaternion _qDiff;
    private bool _aiming = false;
    private readonly float speed = 200f;
    private Rigidbody _parentRb;
    private int _screenWidth;
    private int _screenHeight;
    private Vector2 _screenDim;
    private float _inverseAngle;


    // Use this for initialization
    private void Start () {
        _screenWidth = Camera.main.pixelWidth;
        _screenHeight = Camera.main.pixelHeight;

        col = GetComponent<Collider>();
        naziShip = GameObject.Find("Ship");
        _parent = transform.parent.gameObject;
        _parentRb = _parent.GetComponent<Rigidbody>();
        _screenDim = new Vector2(_screenWidth, _screenHeight);
    }
	
	// Update is called once per frame
    private void Update()
    {

#if UNITY_ANDROID || UNITY_IPHONE
     if(Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount > 0)
            Thrust(Input.GetTouch(0).position);
#endif
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        if (Input.GetMouseButton((0)))
            Thrust(Input.mousePosition);

#endif

    }


    /**
     * this method calculates the distance from the middle screen to the input.
     * the difference is then applied to a torque, so the object will move towards the click position.
     */
    private void Thrust(Vector3 input)
    {
        var xDiff = input.x - _screenDim.x;
        var yDiff = input.y - _screenDim.y;
        var oppX = (xDiff + _screenDim.x / 2) / _screenDim.x / 2;
        var oppY = (yDiff + _screenDim.y / 2) / _screenDim.y / 2;

        Vector3 torque = new Vector3(-oppY, oppX);

        //parentRB.rotation = transform.rotation;
        _parentRb.AddTorque(torque * Time.deltaTime * speed);
        _parentRb.AddRelativeForce(_parent.transform.forward * 200);

        Ray ray = Camera.main.ScreenPointToRay(input);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            if (hit.transform.gameObject == naziShip)
            {
                //posDiff = naziShip.transform.position - this.transform.position;
                _posDiff = naziShip.transform.position - this.transform.position;
                // finding the quaternion angle between missile and naziship
                Vector3 missile = _parent.transform.position;
            }
        }
    }
}

