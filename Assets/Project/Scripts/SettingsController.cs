using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nexweron.Core.MSK;
using Nexweron.WebCamPlayer;
public class SettingsController : MonoBehaviour {

    [Header("Public Component")]
   
    public ChromaKey_Alpha_General mskAlphaGeneral;

    // Player prefs name
    string DChroma="DChroma";
    string R = "R";
    string G = "G";
    string B = "B";
    string Caption = "Caption";

    public static SettingsController instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey(DChroma))
        {
            PlayerPrefs.SetFloat(DChroma, mskAlphaGeneral.dChroma);
        }
        if (!PlayerPrefs.HasKey(R))
        {
            SetColor_Prefs(mskAlphaGeneral.keyColor);
        }
        if (!PlayerPrefs.HasKey(Caption))
        {
            SetCaption(UI_Controller.instance.GetCaptionState());
        }

        UI_Controller.instance.SetCaptionState(GetCaption());
        UI_Controller.instance.SetSliderValue(PlayerPrefs.GetFloat(DChroma));
        // UI
        UI_Controller.instance.SetPickedColor(GetColor_Prfs());
        // settings
        SettingsController.instance.SetKeyColor(GetColor_Prfs());
    }

    public void SetColor_Prefs(Color keycolor)
    {
        PlayerPrefs.SetFloat(R, mskAlphaGeneral.keyColor.r);
        PlayerPrefs.SetFloat(G, mskAlphaGeneral.keyColor.g);
        PlayerPrefs.SetFloat(B, mskAlphaGeneral.keyColor.b);
    }
    public Color GetColor_Prfs()
    {
        Color retColor = new Color(0, 0, 0, 1);
        retColor.r = PlayerPrefs.GetFloat(R);
        retColor.g = PlayerPrefs.GetFloat(G);
        retColor.b = PlayerPrefs.GetFloat(B);
        return retColor;

    }
    
    public void Set_DChromaValue(float value)
    {
        mskAlphaGeneral.dChroma = value;
        PlayerPrefs.SetFloat(DChroma, value);
    }

    public void SetKeyColor(Color color)// Called from Picked Controller
    {
        mskAlphaGeneral.keyColor = color;
        SetColor_Prefs(color);
    }


    public void Set_DChromaT_Slider(float value)
    {
        mskAlphaGeneral.dChroma = value;
    }
    public void Set_DLuma_Slider(float value)
    {
        mskAlphaGeneral.dLuma = value;
    }
    public void Set_DLumaT_Slider(float value)
    {
        mskAlphaGeneral.dLumaT = value;
    }

    public void SetCaption(bool state)
    {
        PlayerPrefs.SetInt(Caption, state ? 1: 0);
    }
    public bool GetCaption()
    {
        return PlayerPrefs.GetInt(Caption) == 1 ? true : false;
    }

}
