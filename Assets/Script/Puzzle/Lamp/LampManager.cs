using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class LampManager : MonoBehaviour
{
    public List<string> listHintLampTurnOn = new List<string>();
    public List<string> listHintLampTurnOff = new List<string>();
    public List<TextMeshPro> listHintTxt = new List<TextMeshPro>();
    // public List<TextMeshProUGUI> listHintTxt = new List<TextMeshProUGUI>();

    public List<GameObject> listLamp = new List<GameObject>();
    public List<GameObject> listLight = new List<GameObject>();
    public List<GameObject> switchObjects = new List<GameObject>(); // GameObject sebagai saklar

    [SerializeField]
    private List<bool> lampStatus = new List<bool>(); // Status awal lampu

    private bool lampOn = false;

    public Transform playerTransform;
    public float maxDistance_To_ToggleLamp = 2f;

    private void Start()
    {
        // Memastikan jumlah lampu, saklar, dan teks sesuai
        if (listLamp.Count != switchObjects.Count || listLamp.Count != listHintTxt.Count)
        {
            Debug.LogError("Jumlah lampu, saklar, dan teks tidak sama!");
            return;
        }

        // Menginisialisasi status awal lampu
        for (int i = 0; i < listLamp.Count; i++)
        {
            listLight[i].SetActive(lampStatus[i]);
            listHintTxt[i].text = listHintLampTurnOff[i]; // Mengatur teks sesuai dengan status awal
        }
    }

    private void Update()
    {
        // Loop melalui setiap saklar
        for (int i = 0; i < switchObjects.Count; i++)
        {
            // Memeriksa apakah jarak antara pemain dan objek kunci kurang dari atau sama dengan maxDistance
            if (Vector3.Distance(playerTransform.transform.position, switchObjects[i].transform.position) <= maxDistance_To_ToggleLamp)
            {
                // Jika tombol keyboard untuk saklar ini ditekan
                if (Input.GetMouseButtonDown(0)) // Ubah menjadi tombol yang diinginkan
                {
                    // Menyalakan atau mematikan lampu terhubung
                    AudioManager.Instance.TestOne();
                    ToggleLamp(i);
                }
            }
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

        // Mengubah status lampu
        lampStatus[lampIndex] = !lampStatus[lampIndex];

        // Mengaktifkan atau menonaktifkan objek lampu terkait
        listLight[lampIndex].SetActive(lampStatus[lampIndex]);

        // Mengatur teks sesuai dengan status lampu
        listHintTxt[lampIndex].text = lampStatus[lampIndex] ? listHintLampTurnOn[lampIndex] : listHintLampTurnOff[lampIndex];
    }
}