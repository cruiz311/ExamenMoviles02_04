using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject objeto;
    public LayerMask Pokebola;
    public bool isDragging;
    public float timer;

    private Vector3 touchStartPosition;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = touch.position;
            //touchPosition.z = Camera.main.nearClipPlane;

            // Convertir la posición del toque de la pantalla al mundo en un rayo
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);

            // Crear un raycast
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began && Physics.Raycast(ray, out hit, Mathf.Infinity, Pokebola))
            {
                touchStartPosition = touchPosition;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (isDragging)
                {
                    Vector3 direction = (touchPosition - touchStartPosition).normalized;
                    Rigidbody rb = objeto.GetComponent<Rigidbody>();
                    rb.velocity = direction * 2f; // Modifica el valor de la velocidad según lo necesites
                    isDragging = false;
                }
            }
        }
    }
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
