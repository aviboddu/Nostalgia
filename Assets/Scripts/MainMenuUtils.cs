using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUtils : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Resolution;
    public GameObject DisplayMode;
    public GameObject Quality;
    public GameObject Volume;
    public GameObject Title;

    private TMP_Dropdown _resolution;
    private TMP_Dropdown _displayMode;
    private TMP_Dropdown _quality;
    private Slider _volume;
    
    private static readonly FullScreenMode[] DisplayModes =
        { FullScreenMode.ExclusiveFullScreen, FullScreenMode.Windowed, FullScreenMode.FullScreenWindow };

    private void Start()
    {
        _resolution = Resolution.GetComponent<TMP_Dropdown>();
        _displayMode = DisplayMode.GetComponent<TMP_Dropdown>();
        _quality = Quality.GetComponent<TMP_Dropdown>();
        _volume = Volume.GetComponent<Slider>();
        
        // Make the resolution list based on monitor compatible resolutions
        _resolution.ClearOptions();
        List<string> options = new List<string>();
        foreach (Resolution res in Screen.resolutions)
            options.Add(res.ToString());
        _resolution.AddOptions(options);

        loadSettings();
    }

    public void onLaunch()
    {
        SceneManager.LoadScene("Backstory", LoadSceneMode.Single);
    }

    public void onExit()
    {
    #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }

    public void onOpenSettings()
    {
        Settings.SetActive(true);
        Title.SetActive(false);
    }

    public void onCloseSettings()
    {
        Settings.SetActive(false);
        Title.SetActive(true);
    }

    public void setResolution(int index)
    {
        Screen.SetResolution(Screen.resolutions[index].width, Screen.resolutions[index].height, Screen.fullScreenMode);
        Application.targetFrameRate = Screen.resolutions[index].refreshRate;
    }

    public void setDisplay(int index)
    {
        Screen.fullScreenMode = DisplayModes[index];
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void setVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void saveSettings()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.currentResolution.Equals(Screen.resolutions[i]))
                PlayerPrefs.SetInt("Resolution", i);
        }
        
        for (int i = 0; i < DisplayModes.Length; i++)
        {
            if (Screen.fullScreenMode == DisplayModes[i])
                PlayerPrefs.SetInt("Display Mode", i);
        }
        
        PlayerPrefs.SetInt("Quality Level", QualitySettings.GetQualityLevel());
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        PlayerPrefs.Save();
    }

    public void loadSettings()
    {
        setResolution(PlayerPrefs.GetInt("Resolution"));
        _resolution.value = PlayerPrefs.GetInt("Resolution");
        
        setDisplay(PlayerPrefs.GetInt("Display Mode"));
        _displayMode.value = PlayerPrefs.GetInt("Display Mode");
        
        setQuality(PlayerPrefs.GetInt("Quality"));
        _quality.value = PlayerPrefs.GetInt("Quality");
        
        setVolume(PlayerPrefs.GetFloat("Volume"));
        _volume.value = PlayerPrefs.GetFloat("Volume");
    }
}
