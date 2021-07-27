using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonCont : MonoBehaviour
{
    
    [SerializeField] private GameObject StartMenu = null;
    [SerializeField] private GameObject SettingMenu = null;
    [SerializeField] private GameObject _SettingMenu = null;
    [SerializeField] private Image light = null;
    [SerializeField] private Slider sliderLight;
    [SerializeField] private Slider sliderAudio;

    private float sliderValueAudio;
    private float sliderValueLight;

    private void OnEnable()
    {
        sliderValueAudio = PlayerPrefs.GetFloat("Audio");
        sliderAudio.value = sliderValueAudio;

        sliderValueLight = PlayerPrefs.GetFloat("Light");
        sliderLight.value = sliderValueLight;
        
        light.color = new Color(0, 0, 0, 1 - sliderValueLight);
        AudioListener.volume = sliderValueAudio;

    }


    public void LoadScene(int indexLevl)
    {
        SceneManager.LoadScene(indexLevl);
    }

    public void LoadStartMenu()
    {
        
        StartMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }
    public void LoadSettingMenu()
    {
        
        StartMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }
    public void Load_SettingMenu()
    {

        SettingMenu.SetActive(false);
        _SettingMenu.SetActive(true);
    }
    public void ReLoad_SettingMenu()
    {

        _SettingMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void AudioSetting()
    {
        if (sliderAudio != null)
        {
            AudioListener.volume = sliderAudio.value;
            PlayerPrefs.SetFloat("Audio", sliderAudio.value);
        }
    }

    public void LightSetting()
    {
        if (sliderLight != null)
        {
            light.color = new Color(0, 0, 0, 1 - sliderLight.value);
            PlayerPrefs.SetFloat("Light",  sliderLight.value);
        }

    }

    public void Scroll(Animator animator)
    {
        if (animator.GetBool("New Bool"))
        {
            animator.SetBool("New Bool", false);
        }
        else
        {
            animator.SetBool("New Bool", true);
        }
    }

    
}
