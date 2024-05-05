using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    public GameObject Umum, Audio, Kontroller;
    public GameObject Setting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SetUmum(){
        Umum.SetActive(true);
        Audio.SetActive(false);
        Kontroller.SetActive(false);
    }

    public void SetAudio(){
        Umum.SetActive(false);
        Audio.SetActive(true);
        Kontroller.SetActive(false);
    }

    public void SetKontrol(){
        Umum.SetActive(false);
        Audio.SetActive(false);
        Kontroller.SetActive(true);
    }

    public void BukaPengaturan(){
        Setting.SetActive(true);
    }

    public void TutupPengaturan(){
        Setting.SetActive(false);
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
