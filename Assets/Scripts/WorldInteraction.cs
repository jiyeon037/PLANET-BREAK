using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour {
    Camera cam;
    Goal goal = new Goal();

    private void Start()
    {
        cam = Camera.main;

    }
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
            
       
	}

    void GetInteraction()
    {
        Vector2 wp = cam.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(wp, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
       
        if (hit.collider != null)
        {
            GameObject interactedObject = hit.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                Debug.Log("We hit" + hit.collider.name + " " + hit.point);
             
                interactedObject.GetComponent<Interact>().GetInteraction();
           
            }

        }
    }

    
}
