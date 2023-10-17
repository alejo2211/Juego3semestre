using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntero : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;



        
        if (Physics.Raycast(ray, out hit, 100))
        {
                Debug.DrawLine(ray.origin, hit.point);

               
            if (hit.transform.CompareTag("ground"))
            {
                transform.LookAt(hit.point);

            }
        }
        
           
    }


}
