using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsBoard;
    public GameObject AboutPanel;

    public void Start(){
        SettingsBoard.SetActive(false);
        AboutPanel.SetActive(false);
    }

    public void open_settings(){
        SettingsBoard.SetActive(true);
    }

    public void close_settings(){
        SettingsBoard.SetActive(false);
    }

    public void open_about(){
        AboutPanel.SetActive(true);
    }

    public void close_about(){
        AboutPanel.SetActive(false);
    }

    
}
