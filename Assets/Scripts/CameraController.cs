using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Hedefin mevcut pozisyonunu ve kamera aras�ndaki mesafeyi dikkate alarak yeni bir pozisyon hesaplay�n
        Vector3 desiredPosition = target.position + offset;

        // Yeni pozisyona do�ru yumu�ak ge�i� yaparak kameray� g�ncelleyin
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
    }
}
