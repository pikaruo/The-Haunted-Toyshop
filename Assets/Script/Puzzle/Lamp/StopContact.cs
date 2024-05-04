using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class StopContact : MonoBehaviour
{
    public List<GameObject> lampSaklarTrue = new List<GameObject>(); // List lampu ketika status true
    public List<GameObject> lampSaklarFalse = new List<GameObject>(); // List lampu ketika status false
    public List<Button> stopContact = new List<Button>(); // Tombol stop contact
    public List<bool> lampSaklarStatus = new List<bool>(); // Status awal saklar lampu

    void Start()
    {
        UpdateLampSwitches();

        // Menambahkan fungsi StopContactButtonClicked ke setiap tombol stopContact
        for (int i = 0; i < stopContact.Count; i++)
        {
            int buttonIndex = i; // Simpan nilai i untuk digunakan dalam fungsi
            stopContact[i].onClick.AddListener(() => StopContactButtonClicked(buttonIndex));
        }
    }

    void UpdateLampSwitches()
    {
        for (int i = 0; i < lampSaklarTrue.Count; i++)
        {
            lampSaklarTrue[i].SetActive(lampSaklarStatus[i]);
        }
        for (int i = 0; i < lampSaklarFalse.Count; i++)
        {
            lampSaklarFalse[i].SetActive(!lampSaklarStatus[i]);
        }
    }

    public void StopContactButtonClicked(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < lampSaklarStatus.Count)
        {
            // Mengubah status saklar
            lampSaklarStatus[buttonIndex] = true;
            // Memperbarui tampilan saklar
            UpdateLampSwitches();
        }
        else
        {
            Debug.LogError("Invalid button index!");
        }
    }

}
