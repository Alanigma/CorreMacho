using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Configuration : MonoBehaviour
{

    public Toggle m_MuteMusic, m_MuteSFX;

    public Slider m_MusicSlider, m_SFXSlider, m_Saturation;

    public AudioMixer m_AudioMixer;

    public Toggle m_HighContrast, m_LessMoviment, m_BigFont;

    public GameObject m_ConfigurationPanel;

    private const string m_MusicVolumeText = "MusicVolume", m_SFXVolumeText = "SfxVolume", m_BrightnessText = "Brightness", m_SaturationText = "Saturation", m_LessMovimentText = "LessMoviment", m_BigFontText = "BigFont";

    private Volume m_Volume;
    private ColorAdjustments m_ColorAdjust;
    public Material m_ColorBlindnessMat;
    public TMP_Dropdown colorBlindnessModeDropdown;

    private void Start()
    {

        m_Volume = GameObject.FindGameObjectWithTag("Volume").GetComponent<Volume>();

        MusicVolume(PlayerPrefs.GetFloat(m_MusicVolumeText, 0.5f));
        SFXVolume(PlayerPrefs.GetFloat(m_SFXVolumeText, 0.5f));
        Brightness(PlayerPrefs.GetFloat(m_BrightnessText, 0));
        Saturation(PlayerPrefs.GetFloat(m_SaturationText, 0));

        MusicMute(PlayerPrefs.GetInt("MuteMusic", 0) == 1);
        SFXMute(PlayerPrefs.GetInt("MuteSFX", 0) == 1);

        HighContrast(PlayerPrefs.GetInt("HighContrast", 0) == 1);
        LessMoviment(PlayerPrefs.GetInt(m_LessMovimentText, 0) == 1);
        BigFont(PlayerPrefs.GetInt(m_BigFontText, 0) == 1);

        ColorBlindness(PlayerPrefs.GetInt("ColorBlindness", 0));
        colorBlindnessModeDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("ColorBlindness", 0));

    }

    public void ColorBlindness(int _Value)
    {
        PlayerPrefs.SetInt("ColorBlindness", _Value);
        colorBlindnessModeDropdown.SetValueWithoutNotify(_Value);
        if (_Value == 0)
        {
            m_ColorBlindnessMat.DisableKeyword("_USE");
            m_ColorBlindnessMat.DisableKeyword("_MODE_PROTANOPIA");
            m_ColorBlindnessMat.DisableKeyword("_MODE_DEUTERANOPIA");
            m_ColorBlindnessMat.DisableKeyword("_MODE_TRITANOPIA");
        }
        else if (_Value == 1)
        {
            m_ColorBlindnessMat.EnableKeyword("_USE");
            m_ColorBlindnessMat.EnableKeyword("_MODE_PROTANOPIA");
            m_ColorBlindnessMat.DisableKeyword("_MODE_DEUTERANOPIA");
            m_ColorBlindnessMat.DisableKeyword("_MODE_TRITANOPIA");
        }
        else if (_Value == 2)
        {
            m_ColorBlindnessMat.EnableKeyword("_USE");
            m_ColorBlindnessMat.DisableKeyword("_MODE_PROTANOPIA");
            m_ColorBlindnessMat.EnableKeyword("_MODE_DEUTERANOPIA");
            m_ColorBlindnessMat.DisableKeyword("_MODE_TRITANOPIA");
        }
        else if (_Value == 3)
        {
            m_ColorBlindnessMat.EnableKeyword("_USE");
            m_ColorBlindnessMat.DisableKeyword("_MODE_PROTANOPIA");
            m_ColorBlindnessMat.DisableKeyword("_MODE_DEUTERANOPIA");
            m_ColorBlindnessMat.EnableKeyword("_MODE_TRITANOPIA");
        }
    }

    private float LinearToDecibel(float linearValue)
    {
        if (linearValue <= 0f) return -80f; // Minimum decibel value
        return 20f * Mathf.Log10(linearValue);
    }

    private float DecibelToLinear(float decibelValue)
    {
        return Mathf.Pow(10f, decibelValue / 20f);
    }

    public void MusicVolume(float _MusicVolume)
    {
        m_MusicSlider.SetValueWithoutNotify(_MusicVolume);
        m_AudioMixer.SetFloat(m_MusicVolumeText, LinearToDecibel(_MusicVolume));
        PlayerPrefs.SetFloat(m_MusicVolumeText, _MusicVolume);
    }

    public void MusicMute(bool _MusicMute)
    {
        m_MuteMusic.SetIsOnWithoutNotify(_MusicMute);
        m_AudioMixer.SetFloat(m_MusicVolumeText, LinearToDecibel(_MusicMute ? 0 : PlayerPrefs.GetFloat(m_MusicVolumeText)));
        PlayerPrefs.SetInt("MuteMusic", (_MusicMute) ? 1 : 0);
        m_MusicSlider.interactable = !m_MuteMusic.isOn;
    }

    public void SFXVolume(float _SFXVolume)
    {
        m_SFXSlider.SetValueWithoutNotify(_SFXVolume);
        m_AudioMixer.SetFloat(m_SFXVolumeText, LinearToDecibel(_SFXVolume));
        PlayerPrefs.SetFloat(m_SFXVolumeText, _SFXVolume);
    }

    public void SFXMute(bool _SFXMute)
    {
        m_MuteSFX.SetIsOnWithoutNotify(_SFXMute);
        m_AudioMixer.SetFloat(m_SFXVolumeText, LinearToDecibel(_SFXMute ? 0 : PlayerPrefs.GetFloat(m_SFXVolumeText)));
        PlayerPrefs.SetInt("MuteSFX", (_SFXMute) ? 1 : 0);
        m_SFXSlider.interactable = !m_MuteSFX.isOn;
    }

    public void Brightness(float _BrightValue) {

        if (m_Volume.profile.TryGet<ColorAdjustments>(out m_ColorAdjust))
            m_ColorAdjust.postExposure.value = _BrightValue;
        PlayerPrefs.SetFloat(m_BrightnessText, _BrightValue);
    }

    public void Saturation(float _BrightValue)
    {

        m_Saturation.SetValueWithoutNotify(_BrightValue);
        if (m_Volume.profile.TryGet<ColorAdjustments>(out m_ColorAdjust))
            m_ColorAdjust.saturation.value = _BrightValue;
        PlayerPrefs.SetFloat(m_SaturationText, _BrightValue);
    }

    public void HighContrast(bool _Value) {

        m_HighContrast.SetIsOnWithoutNotify(_Value);
        if (m_Volume.profile.TryGet<ColorAdjustments>(out m_ColorAdjust))
            m_ColorAdjust.contrast.value = _Value ? 20 : 0;
        PlayerPrefs.SetInt("HighContrast", (_Value) ? 1 : 0);
        ConfigValues.m_HighContrast = _Value;

    }

    public void LessMoviment(bool _Value)
    {

        m_LessMoviment.SetIsOnWithoutNotify(_Value);
        PlayerPrefs.SetInt(m_LessMovimentText, (_Value) ? 1 : 0);
        ConfigValues.m_LessMoviment = _Value;

    }

    public void BigFont(bool _Value)
    {

        m_BigFont.SetIsOnWithoutNotify(_Value);
        PlayerPrefs.SetInt(m_BigFontText, (_Value) ? 1 : 0);
        ConfigValues.m_BigFont = _Value;

    }

}

public static class ConfigValues
{

    public static bool m_AutoAim;
    public static bool m_AutoShoot;
    public static bool m_DamageText;
    public static bool m_HighContrast;
    public static bool m_Lifebar;
    public static bool m_LessMoviment;
    public static bool m_BigFont;

}