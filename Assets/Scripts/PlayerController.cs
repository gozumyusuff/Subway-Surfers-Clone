using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Karakterin ileri hareket h�z�
    public float laneDistance = 4; // Her bir �erit aras� mesafe

    private int desiredLane = 1; // Karakterin hedefledi�i �erit
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bile�enini al
        rb.velocity = new Vector3(0, 0, speed); // Ba�lang�� h�z�n� ayarla
    }

    private void Update()
    {
        rb.velocity = new Vector3(0, 0, speed); // Ba�lang�� h�z�n� ayarla


        // Sa�a veya sola gitme
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

        // Hedeflenen �erite do�ru pozisyonu ayarlama
        Vector3 targetPosition = transform.position;
        targetPosition.z = desiredLane * laneDistance;

        // Karakteri hedef pozisyona do�ru yumu�ak bir �ekilde hareket ettirme
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
    }
}
