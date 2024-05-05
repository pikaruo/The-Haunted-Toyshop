using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public string KeyTag = "DoorToyshop";

    private int clickCount = 0;

    public float maxDistance = 2f;

    public ExitDoorAnimation ExitDoor; 

    private bool activeTimer = false;

    public float maxTime = 3f;
    public float currentTime = 0f;

    public bool isNotKeydoor = true;

    public GameObject tamat;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
                        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                if(hit.collider.CompareTag(KeyTag) && Vector3.Distance(hit.collider.transform.position, hit.point) <= maxDistance){
                    
                    if(isNotKeydoor == true){
                        activeTimer = true;
                        clickCount += 1;
                        Debug.Log(clickCount);
                        AudioManager.Instance.TestOne();
                    }
                    else{
                        tamat.SetActive(true);
                        Cursor.lockState = CursorLockMode.Confined;
                        Debug.Log("Player sedang membawa kunci");
                    }
                }
            }
        }

        if(activeTimer){
            currentTime += Time.deltaTime;
        }

        if(clickCount <= 3 && currentTime >= maxTime){
            clickCount = 0;
            activeTimer = false;
            currentTime = 0f;
        }
        

        if(clickCount == 3){
            ExitDoor.isOpen = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
