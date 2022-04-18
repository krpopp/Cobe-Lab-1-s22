using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public float sphereRadius = 3f;

    public float zOffset = 10f;

    GameObject heldObj;
    Vector3 objOriginalPos;

    public float rotationSpeed = 2f;

    public float mouseSensitivity = 0.5f;
    public float clampAngle = 80.0f;
    float rotationX;
    float rotationY;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 startRot = transform.localRotation.eulerAngles;
        rotationX = startRot.x;
        rotationY = startRot.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyePosition = transform.position;
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.nearClipPlane;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = mouseWorldPos - eyePosition;
        dir.Normalize();

        //Debug.Log(dir);

        RaycastHit hitter = new RaycastHit();

        Debug.DrawLine(eyePosition, dir * 1000f, Color.red);

        if (Physics.SphereCast(eyePosition, sphereRadius, dir, out hitter))
        {

            if(heldObj != null)
            {
                if(heldObj.name == hitter.collider.gameObject.name)
                {
                    // Debug.Log("cursor on held object");
                    float xRotate = Input.GetAxis("Mouse X") * rotationSpeed;
                    float yRotate = Input.GetAxis("Mouse Y") * rotationSpeed;

                    heldObj.transform.Rotate(Vector3.down, xRotate);
                    heldObj.transform.Rotate(Vector3.right, yRotate);
                }
            }

            if(Input.GetMouseButton(0) && hitter.collider.gameObject.tag == "pickable" && heldObj == null)
            {
                Debug.Log("can pickup");
                PickUpObject(hitter.collider.gameObject);
            }
        }

        if(Input.GetMouseButton(1) && heldObj != null)
        {
            DropObject();
        }
        MoveCamera();
        //Debug.Log(transform.rotation);
    }

    void PickUpObject(GameObject obj)
    {
        heldObj = obj;
        objOriginalPos = obj.transform.position;

        obj.transform.SetParent(gameObject.transform);

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);
        obj.transform.position = newPos;
    }

    void DropObject() {
        heldObj.transform.SetParent(null);
        heldObj.transform.position = objOriginalPos;

        objOriginalPos = Vector3.zero;
        heldObj = null;
    }

    void MoveCamera() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX += mouseY * mouseSensitivity * Time.deltaTime;
        rotationY += mouseX * mouseSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        Quaternion newRotation = Quaternion.Euler(-rotationX, rotationY, 0.0f);
        transform.rotation = newRotation;
    }
}
