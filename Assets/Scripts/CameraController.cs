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

        // Hedefin mevcut pozisyonunu ve kamera arasýndaki mesafeyi dikkate alarak yeni bir pozisyon hesaplayýn
        Vector3 desiredPosition = target.position + offset;

        // Yeni pozisyona doðru yumuþak geçiþ yaparak kamerayý güncelleyin
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
    }
}
