using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject objeto;
    public LayerMask Pokebola;
    public bool isDragging;
    public float timer;
    public void Update()
    {
        Vector3 mouseStartPos = Input.mousePosition;
        mouseStartPos.z = Camera.main.nearClipPlane;

        // Convertir la posición del clic de la pantalla al mundo en un rayo
        Ray ray = Camera.main.ScreenPointToRay(mouseStartPos);

        // Crear un raycast
        RaycastHit hit;
        //estoy presionando click y chocando con la pokebola
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Pokebola))
            {
                timer = Time.deltaTime;
                isDragging = true;
                Debug.Log("presionando");
            }
            

        }else if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouseEndPos = Input.mousePosition;
            isDragging = false;
            
            Debug.Log(mouseEndPos);
        }



        //if (Input.GetMouseButton(0))
        //{
        //    isDragging = true;
        //    // Realizar el raycast y verificar si choca con el layer 'losa'
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, Pokebola))
        //    {
        //        Vector3 mouseEndPos = Input.mousePosition;
        //        Vector3 Direction = (mouseEndPos - mouseStartPos).normalized;
        //        float Speed = (mouseEndPos - mouseStartPos).magnitude;
        //        Rigidbody rb = objeto.GetComponent<Rigidbody>();
        //        rb.velocity = Direction * -Speed;
        //        Debug.Log(Direction);
        //        Debug.Log("speed:"  + Speed);
        //        objeto.transform.Rotate(0, 1, 0);
        //    }
        //    else
        //    {
        //        // El raycast no chocó con el layer 'losa'
        //        Debug.Log("No chocó con el layer 'losa'");
        //    }
        //    // Dibujar el rayo para visualizarlo en el momento del clic
        //    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);


        //    Debug.Log(mouseStartPos);

        //}

        //if (Input.GetMouseButton(0) && isDragging)
        //{
        //    isDragging = true;
        //    Vector3 mouseEndPos = Input.mousePosition;
        //}
    }

}
