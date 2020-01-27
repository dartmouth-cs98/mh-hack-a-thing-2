using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody myRb;

    public Rigidbody cameraRb;
    public Camera myCamera;
    public float lerpSpeed;

    public float ballSpeed;
    public float cameraSpeed;
    public float ballForce;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            HorizontalMovement();
        }
    }

    private void FixedUpdate()
    {
        ForwardMovement();
        CameraMovement();
    }

    void HorizontalMovement()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), lerpSpeed * Time.deltaTime);

        }
    }


    void ForwardMovement()
    {
        myRb.velocity = Vector3.forward * ballSpeed;
    }

    void CameraMovement()
    {
        cameraRb.velocity = Vector3.forward * cameraSpeed;
    }
}
