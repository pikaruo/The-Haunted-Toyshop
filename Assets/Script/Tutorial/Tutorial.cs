using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("open");
        Invoke("Close", 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close(){
        anim.SetTrigger("close");
    }
}
