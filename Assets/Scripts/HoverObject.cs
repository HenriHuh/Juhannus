using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{

    public LayerMask hoverLayer, objLayer;

    GameObject hoveredObject;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, objLayer);
            if (hit.transform)
            {
                hoveredObject = hit.transform.gameObject;
            }
        }

        if (hoveredObject != null)
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, hoverLayer);
            Hover(hit.point + Vector3.up * 3f);

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                hoveredObject = null;
            }
        }
    }

    void Hover(Vector3 trgt)
    {
        Vector3 hoverDirection = trgt - hoveredObject.transform.position;
        hoveredObject.GetComponent<Rigidbody>().AddTorque(hoverDirection * Time.deltaTime * 2.5f);

        hoveredObject.GetComponent<Rigidbody>().AddForce(hoverDirection * Time.deltaTime * 250);
    }
}
