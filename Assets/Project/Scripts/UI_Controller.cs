using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Controller : MonoBehaviour {

    [Header("Settings panel")]
    public Animator SettingsPanelAnimator;
    public Animator CropControlPanelAnimator;
    public Image PickedColor;
    [Header("Settings Slider")]
    public Slider D_ChromaSlider;
    public Slider DChromaT_Slider;
    public Slider DLuma_Slider;
    public Slider DLumaT_Slider;

    public Toggle Caption_Toggle;
    public GameObject CaptionBG;

    

    public static UI_Controller instance;


    private void Awake()
    {
        instance = this;
    }
    
    public void SetSliderValue(float value)
    {
        D_ChromaSlider.value = value;
    }
    public void OnSliderValueChanged()
    {
        SettingsController.instance.Set_DChromaValue(D_ChromaSlider.value);
    }
    public void SetAppear_SettingsPanel(bool state)
    {
           SettingsPanelAnimator.SetBool("Appear", state);
    }

    public void SetAppear_CropControlPanel(bool state)
    {
        SetAppear_SettingsPanel(false);
        CropControlPanelAnimator.SetBool("Appear", state);

       
    }

    public void SetPickedColor(Color color)// Called from PickerCOntroler
    {
        PickedColor.color = color;
    }

    // Advanced Settings
    public void OnValueChanged_DChromaT_Slider()
    {
        SettingsController.instance.Set_DChromaT_Slider(DChromaT_Slider.value);
    }
    public void OnValueChanged_DLuma_Slider()
    {
        SettingsController.instance.Set_DLuma_Slider(DLuma_Slider.value);
    }
    public void OnValueChanged_DLumaT_Slider()
    {
        SettingsController.instance.Set_DLumaT_Slider(DLumaT_Slider.value);
    }

    // Caption
    public void SetCaptionState()  // called from UI Toggle on value changed
    {
        CaptionBG.SetActive(Caption_Toggle.isOn);
        SettingsController.instance.SetCaption(Caption_Toggle.isOn);
    }

    public void SetCaptionState(bool state)  // called from settings controller Start 
    {
        Caption_Toggle.isOn = state;
        CaptionBG.SetActive(state);
    }
    public bool GetCaptionState()// called from settings controller
    {
        return Caption_Toggle.isOn;
    }
}
