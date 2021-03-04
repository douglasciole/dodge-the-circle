using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public float music_volume, fx_volume;
    public bool vibr_state, camera_state;

    public Slider music_slider, fx_slider;
    public Toggle vibr_toggle, camera_toggle;

    private void Start()
    {
        music_volume = PlayerPrefs.GetFloat("Music_Volume", 1);
        fx_volume = PlayerPrefs.GetFloat("Fx_Volume", 1);
        vibr_state = (PlayerPrefs.GetInt("Vibr_State", 1) > .5) ? true : false;
        camera_state = (PlayerPrefs.GetInt("Camera_State", 1) > .5) ? true : false;
        UpdateUI();
    }

    private void FixedUpdate()
    {
        music_volume = music_slider.value;
        fx_volume = fx_slider.value;
        vibr_state = vibr_toggle.isOn;
        camera_state = camera_toggle.isOn;
        UpdatePrefs();
    }

    void UpdateUI()
    {
        music_slider.value = music_volume;
        fx_slider.value = fx_volume;
        vibr_toggle.isOn = vibr_state;
        camera_toggle.isOn = camera_state;
    }

    void UpdatePrefs()
    {
        PlayerPrefs.SetFloat("Music_Volume", music_volume);
        PlayerPrefs.SetFloat("Fx_Volume", fx_volume);
        PlayerPrefs.SetInt("Vibr_State", vibr_state ? 1 : 0);
        PlayerPrefs.SetInt("Camera_State", camera_state ? 1 : 0);
    }
}
