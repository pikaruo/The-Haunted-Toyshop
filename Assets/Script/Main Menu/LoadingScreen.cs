using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    float max_value = 100f;
    float current_value;

    public Slider slider;

    void Start()
    {
        current_value = 0f;
        slider.value=current_value;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(current_value > max_value){
            current_value = max_value;
            slider.value=current_value;
            Invoke("SwitchScene", 2);
        }else{
            current_value ++;
            slider.value=current_value;
        }
    }

    public void SwitchScene(){
        SceneManager.LoadScene("Gameplay");
    }
}
