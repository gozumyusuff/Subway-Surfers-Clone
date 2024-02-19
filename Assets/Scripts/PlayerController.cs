using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Karakterin ileri hareket hýzý
    public float laneDistance = 4; // Her bir þerit arasý mesafe

    private int desiredLane = 1; // Karakterin hedeflediði þerit
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bileþenini al
        rb.velocity = new Vector3(0, 0, speed); // Baþlangýç hýzýný ayarla
    }

    private void Update()
    {
        rb.velocity = new Vector3(0, 0, speed); // Baþlangýç hýzýný ayarla


        // Saða veya sola gitme
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        // Hedeflenen þerite doðru pozisyonu ayarlama
        Vector3 targetPosition = transform.position;
        targetPosition.z = desiredLane * laneDistance;

        // Karakteri hedef pozisyona doðru yumuþak bir þekilde hareket ettirme
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
    }
}
