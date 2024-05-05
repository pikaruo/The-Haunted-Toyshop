using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneProperty : MonoBehaviour
{
   public void GameplayScene(){
    SceneManager.LoadScene("Loading");
   }

   public void MainmenuScene(){
    SceneManager.LoadScene("MainMenu");
   }



}
