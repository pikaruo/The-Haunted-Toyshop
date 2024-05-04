using UnityEngine;

public class Interactive : MonoBehaviour
{
    public GameObject keyPad;
    public FirstPersonController fpscontroll;

    private bool isInteractDevice = false;
    public float interactionDistance = 3f;

    private void Start()
    {
        keyPad.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, interactionDistance)) // Menambahkan parameter jarak
            {
                if (hit.collider.CompareTag("Computer"))
                {
                    // Toggle interaksi
                    isInteractDevice = !isInteractDevice;
                }
            }
        }

        if(isInteractDevice == true){
            keyPad.SetActive(true);
            fpscontroll.ActivityDevice = true;
        }else{
            keyPad.SetActive(false);
            fpscontroll.ActivityDevice = false;
        }
    }
}
