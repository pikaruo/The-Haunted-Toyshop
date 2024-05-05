using UnityEngine;

public class BrankasSystem : MonoBehaviour
{
    public bool isOpen = false; // Mengatur kondisi awal brankas menjadi tertutup

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isOpen == true){
            anim.SetTrigger("open");
        }
    }


}
