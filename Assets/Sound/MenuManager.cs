using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [Header("System Musik")]
    public Slider volumeMusikSlider;

    [Header("System SFX")]
    public Slider volumeSFXSlider;

    private void Start()
    {

        // * musik
        if (AudioManager.Instance.audioSourceMusik.mute == true)
        {
        }
        else
        {
        }

        volumeMusikSlider.value = AudioManager.Instance.audioSourceMusik.volume;

        // * sfx
        if (AudioManager.Instance.audioSourceSFX.mute == true)
        {
        }
        else
        {
        }

        volumeSFXSlider.value = AudioManager.Instance.audioSourceSFX.volume;
    }

    #region musik

    public void VolumeMusik()
    {
        AudioManager.Instance.audioSourceMusik.volume = volumeMusikSlider.value;

        if (volumeMusikSlider.value <= volumeMusikSlider.minValue)
        {
            AudioManager.Instance.audioSourceMusik.mute = true;
        }
        else
        {
            AudioManager.Instance.audioSourceMusik.mute = false;
        }
    }

    public void MusikMute()
    {
        AudioManager.Instance.MusikMute();

        if (AudioManager.Instance.audioSourceMusik.mute == true)
        {
        }
        else
        {
        }
    }

    #endregion

    #region sfx

    public void VolumeSfx()
    {
        AudioManager.Instance.audioSourceSFX.volume = volumeSFXSlider.value;

        if (volumeSFXSlider.value <= volumeSFXSlider.minValue)
        {
            AudioManager.Instance.audioSourceSFX.mute = true;
        }
        else
        {
            AudioManager.Instance.audioSourceSFX.mute = false;
        }
    }

    public void SfxMute()
    {
        AudioManager.Instance.SfxMute();

        if (AudioManager.Instance.audioSourceSFX.mute == true)
        {
        }
        else
        {
        }
    }

    #endregion

}
