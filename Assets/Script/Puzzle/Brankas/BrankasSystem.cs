using UnityEngine;

public class BrankasSystem : MonoBehaviour
{
    public bool isOpen = false; // Mengatur kondisi awal brankas menjadi tertutup

    public GameObject brankas_tertutup;
    public GameObject brankas_terbuka;

    public GameObject SpawnKey;

    void Start()
    {
        // SpawnKey.SetActive(false);
        brankas_terbuka.SetActive(false);
        brankas_tertutup.SetActive(true);
    }

    void Update()
    {
        if(isOpen == true){
            brankas_terbuka.SetActive(true);
            brankas_tertutup.SetActive(false);
            // SpawnKey.SetActive(true);
        }else{
            brankas_terbuka.SetActive(false);
            brankas_tertutup.SetActive(true);
        }
    }


}
