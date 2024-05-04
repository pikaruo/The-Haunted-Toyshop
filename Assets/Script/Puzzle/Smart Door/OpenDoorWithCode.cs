using UnityEngine;

public class OpenDoorWithCode : MonoBehaviour
{
    public bool isOpen = false; // Status awal pintu pintar tertutup
    
    public Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen == true){
            anim.SetTrigger("open");
        }
    }
}
