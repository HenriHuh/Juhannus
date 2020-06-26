using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{

    public LayerMask hoverLayer, objLayer;

    GameObject hoveredObject;

    public ParticleSystem part;
    public Transform partStart, partTarget;

    void Start()
    {
        part.Stop();
    }

    void Update()
    {
        RaycastHit h;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out h, 100, hoverLayer))
        {
            partStart.transform.position = h.point;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, objLayer);
            if (hit.transform)
            {
                AudioManager.instance.Magic(true);
                part.Play();
                hoveredObject = hit.transform.gameObject;
                hoveredObject.GetComponent<Rigidbody>().drag = 4;
            }
        }

        if (hoveredObject != null)
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, hoverLayer);
            partTarget.position = hoveredObject.transform.position;
            Hover(hit.point + Vector3.up * 3f);

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                AudioManager.instance.Magic(false);
                part.Stop();
                hoveredObject.GetComponent<Rigidbody>().drag = 0;
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
