using UnityEngine;

public class Interactive : MonoBehaviour
{
    public OpenDoor opendoor;
    public GameObject KeyObject_IsRb;
    public GameObject KeyObject_NoRb;

    public GameObject keyPad_Panel;
    public Keypad KeyPad_Mechanism;
    public FirstPersonController fpscontroll;

    private bool isInteractDevice = false;
    public float interactionDistance = 3f;

    [HideInInspector] public bool BrankasTerbuka = false;
    [HideInInspector] public bool PintuTerbuka = false;

    private void Start()
    {
        keyPad_Panel.SetActive(false);
        KeyObject_NoRb.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, interactionDistance)) // Menambahkan parameter jarak
            {
                if (hit.collider.CompareTag("Computer") && PintuTerbuka == false)
                {
                    // Toggle interaksi
                    isInteractDevice = !isInteractDevice;

                    KeyPad_Mechanism.isSmartDoor = true;
                }else if(hit.collider.CompareTag("Brankas") && BrankasTerbuka == false){
                    isInteractDevice = true;

                    KeyPad_Mechanism.isSmartDoor = false;
                }else if(hit.collider.CompareTag("Key")){
                    GameObject[] keyObjects = GameObject.FindGameObjectsWithTag("Key");
                    foreach (GameObject keyObject in keyObjects)
                    {
                        Destroy(keyObject);
                        opendoor.isNotKeydoor = false;
                    }
                }
            }
        }else

        if(isInteractDevice == true){
            keyPad_Panel.SetActive(true);
            fpscontroll.ActivityDevice = true;
        }else{
            keyPad_Panel.SetActive(false);
            fpscontroll.ActivityDevice = false;
        }

        if(opendoor.isNotKeydoor == false && Input.GetKey(KeyCode.E)){
            DropKey();
        }
    }

    public void DropKey(){
        if(opendoor.isNotKeydoor == false){
            Instantiate(KeyObject_IsRb, transform.position, transform.rotation);
            KeyObject_NoRb.SetActive(false);
            opendoor.isNotKeydoor = true;
        }
    }

    public void OffBrankas(){
        keyPad_Panel.SetActive(false);
        isInteractDevice = false;
    }
}
