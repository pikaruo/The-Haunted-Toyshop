using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusik : MonoBehaviour
{
    public int indexMusik;
    public static int playIndexMusik;

    private void Start()
    {

        playIndexMusik = indexMusik;

        if (GameObject.Find("Audio Manager") != null)
        {
            AudioManager.Instance.ChangeMusik(playIndexMusik);
        }
    }
}
