using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public float sphereRadius = 3f;

    public float zOffset = 10f;

    GameObject heldObj;
    Vector3 objOriginalPos;

    // Start is called before the first frame update
    void Start()
    {
        
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

        RaycastHit hitter = new RaycastHit();

        Debug.DrawLine(eyePosition, dir * 1000f, Color.red);

        if (Physics.SphereCast(eyePosition, sphereRadius, dir, out hitter))
        {
            //Debug.Log("hit something!");
            //Debug.Log(hitter.collider.gameObject.name);
            Debug.Break();
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
}
