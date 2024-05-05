using UnityEngine;

public class ExitDoorAnimation : MonoBehaviour
{
   public bool isOpen = false;

   private Animator anim;

   private void Start(){
    anim = GetComponent<Animator>();
   }

   public void Update(){
    if(isOpen == true){
      anim.SetTrigger("open");
    }
   }
}
