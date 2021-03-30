using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public float music_volume, fx_volume, camera_move;
    public bool vibr_state;

    public Slider music_slider, fx_slider, camera_slider;
    public Toggle vibr_toggle;

    public AudioSource menuSounds;

    private void Start()
    {
        music_volume = PlayerPrefs.GetFloat("Music_Volume", 1);
        fx_volume = PlayerPrefs.GetFloat("Fx_Volume", 1);
        camera_move = PlayerPrefs.GetFloat("Camera_Move", .5f);
        vibr_state = (PlayerPrefs.GetInt("Vibr_State", 1) > .5) ? true : false;
        UpdateUI();
    }

    private void FixedUpdate()
    {
        if (menuSounds.isPlaying == false)
        {
            menuSounds.mute = false;
        }
        music_volume = music_slider.value;
        fx_volume = fx_slider.value;
        camera_move = camera_slider.value / 4;
        vibr_state = vibr_toggle.isOn;
        UpdatePrefs();
    }

    void UpdateUI()
    {
        music_slider.value = music_volume;
        fx_slider.value = fx_volume;
        camera_slider.value = camera_move * 4;
        vibr_toggle.isOn = vibr_state;
    }

    void UpdatePrefs()
    {
        PlayerPrefs.SetFloat("Music_Volume", music_volume);
        PlayerPrefs.SetFloat("Fx_Volume", fx_volume);
        PlayerPrefs.SetFloat("Camera_Move", camera_move);
        PlayerPrefs.SetInt("Vibr_State", vibr_state ? 1 : 0);
    }

    public void LoadMenu()
    {
        Vibration.QuickVibration();
        menuSounds.Play();
        SceneManager.LoadScene("1_MenuScene", LoadSceneMode.Single);
    }

    public void QuickVibration()
    {
        menuSounds.Play();
        Vibration.QuickVibration();
    }
    public void FxOnVolumeChange()
    {
        if (menuSounds.isPlaying == false)
        {
            menuSounds.Play();
        }
        Vibration.QuickVibration();
    }

    public void SoundlessVibration()
    {
        Vibration.QuickVibration();
    }

    public void OppositeVibration()
    {
        menuSounds.Play();
        Vibration.OppositeVibration();
    }


}
