using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    [SerializeField]
	private Transform playerPos;
    private Vector3 _pos = Vector3.zero;
	// Use this for initialization
    void Awake()
    {

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            _pos = Vector3.zero; //playerPos.position.Set(0f,0f,0f);
        }

        this.transform.position = _pos;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos)
            _pos = playerPos.position;

        _pos.y = 30;
        this.transform.position = _pos;
    }
}
