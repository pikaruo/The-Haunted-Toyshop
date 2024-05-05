using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // * melakukan inisiate script musik control
    public static AudioManager Instance { get; set; }

    [Header("System Musik")]
    public AudioSource audioSourceMusik;
    public AudioClip[] clipMusik;

    [Header("System Sfx")]
    public AudioSource audioSourceSFX;
    public AudioClip testSfxOne;
    public AudioClip testSfxTwo;
    public AudioClip testSfxThree;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // * mengganti musik berdasarkan scene
    public void ChangeMusik(int indexMusik)
    {
        if (audioSourceMusik.clip != clipMusik[indexMusik])
        {
            // * mematikan musik
            audioSourceMusik.Stop();
            // * mengganti musik berdasarkan index musik
            audioSourceMusik.clip = clipMusik[indexMusik];
            // * memutar musik
            audioSourceMusik.Play();
        }
    }

    #region musik
    public void MusikMute()
    {
        if (audioSourceMusik.mute == false)
        {
            audioSourceMusik.mute = true;
        }
        else
        {
            audioSourceMusik.mute = false;
        }
    }

    #endregion

    #region  sfx

    public void SfxMute()
    {
        if (audioSourceSFX.mute == false)
        {
            audioSourceSFX.mute = true;
        }
        else
        {
            audioSourceSFX.mute = false;
        }
    }

    public void TestOne()
    {
        audioSourceSFX.PlayOneShot(testSfxOne);
    }

    public void TestTwo()
    {
        audioSourceSFX.PlayOneShot(testSfxTwo);
    }

    public void TestThree()
    {
        audioSourceSFX.PlayOneShot(testSfxThree);
    }

    #endregion
}
