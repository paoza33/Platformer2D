using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropDown;
    public Slider musicSlider;
    public Slider soundSlider;
    public void Start() {
        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray();

        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i=0; i< resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height){
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void setResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetMusicVolume( float volume){
        audioMixer.SetFloat("Music",volume);
    }

    public void SetSoundVolume( float volume){
        audioMixer.SetFloat("Sound",volume);
    }
    public void FullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    public void ResetData(){
        PlayerPrefs.DeleteAll();
    }
}
