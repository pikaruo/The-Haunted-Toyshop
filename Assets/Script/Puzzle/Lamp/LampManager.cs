using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class LampManager : MonoBehaviour
{
    public List<string> listHintLampTurnOn = new List<string>();
    public List<string> listHintLampTurnOff = new List<string>();
    public List<TextMeshPro> listHintTxt = new List<TextMeshPro>();


    public List<GameObject> listLamp = new List<GameObject>();
    public Material materialOn; // Material saat lampu menyala
    public Material materialOff; // Material saat lampu mati
    public List<Button> buttons = new List<Button>();

    private bool lampOn = false; // Status lampu (menyala atau mati)

    [SerializeField]
    private List<bool> lampStatus = new List<bool>(); // Status awal lampu

    private void Start()
    {
        // Memastikan jumlah lampu, tombol, dan teks sesuai
        if (listLamp.Count != buttons.Count || listLamp.Count != listHintTxt.Count)
        {
            Debug.LogError("Jumlah lampu, tombol, dan teks tidak sama!");
            return;
        }

        // Menambahkan listener untuk setiap tombol
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => ToggleLamp(index));
        }

        // Mengatur status awal lampu dan teks sesuai dengan status
        for (int i = 0; i < listLamp.Count; i++)
        {
            Renderer lampRenderer = listLamp[i].GetComponent<Renderer>();
            if (lampRenderer != null)
            {
                lampRenderer.material = lampStatus[i] ? materialOn : materialOff;
            }

            listHintTxt[i].text = lampStatus[i] ? listHintLampTurnOn[i] : listHintLampTurnOff[i];
        }
    }

    // Mengaktifkan/menonaktifkan lampu
    public void ToggleLamp(int lampIndex)
    {
        // Memeriksa apakah indeks lampu valid
        if (lampIndex < 0 || lampIndex >= listLamp.Count)
        {
            Debug.LogError("Indeks lampu tidak valid!");
            return;
        }

        // Mendapatkan komponen Renderer dari lampu
        Renderer lampRenderer = listLamp[lampIndex].GetComponent<Renderer>();

        // Memeriksa apakah lampu memiliki komponen Renderer
        if (lampRenderer == null)
        {
            Debug.LogError("Lampu tidak memiliki komponen Renderer!");
            return;
        }

        // Mengubah status lampu dan materialnya
        lampStatus[lampIndex] = !lampStatus[lampIndex];
        lampRenderer.material = lampStatus[lampIndex] ? materialOn : materialOff;

        // Mengatur teks sesuai dengan status lampu
        listHintTxt[lampIndex].text = lampStatus[lampIndex] ? listHintLampTurnOn[lampIndex] : listHintLampTurnOff[lampIndex];
    }


}
