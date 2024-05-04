using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public string KeyTag = "Key";

    private int clickCount = 0;

    public float maxDistance = 2f;

    public GameObject DoorObject; 

    private bool activeTimer = false;

    public float maxTime = 3f;
    public float currentTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                if(hit.collider.CompareTag(KeyTag) && Vector3.Distance(hit.collider.transform.position, hit.point) <= maxDistance){
                    if(Input.GetMouseButtonDown(0)){
                        activeTimer = true;
                        clickCount += 1;
                        Debug.Log(clickCount);
                    }
                }
            }

        if(activeTimer){
            currentTime += Time.deltaTime;
        }

        if(clickCount <=3 && currentTime >= maxTime){
            clickCount = 0;
            activeTimer = false;
            currentTime = 0f;
        }
        

        if(clickCount == 3){
            DoorObject.SetActive(false);
            Debug.Log("Pintu hilang");
        }
    }
}
