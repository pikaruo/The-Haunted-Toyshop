using UnityEngine;

public class ForwardViewObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mendapatkan arah pandangan kamera relatif terhadap objek
        Vector3 cameraDirection = Camera.main.transform.forward;

        // Membuat rotasi yang hanya mempengaruhi sumbu Y agar gambar selalu menghadap ke depan
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(cameraDirection.x, 0f, cameraDirection.z));

        // Menetapkan rotasi objek ke rotasi target
        transform.rotation = targetRotation;
    }
}
