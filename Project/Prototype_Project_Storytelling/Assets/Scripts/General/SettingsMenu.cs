using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour {

	//Main game AudioMixer
	public AudioMixer mainAudioMixer;

	//Resolution dropdown object
	public Dropdown resolutionDropdown;
	//quality dropdown object
	public Dropdown qualityDropdown;
	//Master volume slider object
	public Slider masterVolumeSlider;
	//Music volume slider object
	public Slider musicVolumeSlider;
	//SFX volume slider object
	public Slider sfxVolumeSlider;

	//resolutions array
	Resolution[] resolutions;

	// Use this for initialization
	void Start () {
		#region SetResolutionDropdown
		//gets all possible resolutions
		resolutions = Screen.resolutions;
		//clear the dropdown current options
		resolutionDropdown.ClearOptions();

		//creates a list of resolutions to convert the array to strings
		List<string> resolutionOptions = new List<string>();

		//current game resolution index
		int currentResolutionIndex = 0;

		//add each resolution to the string list
		for (int i=0; i <resolutions.Length; i ++){
			string resolutionOption = resolutions[i].width + " x " + resolutions[i].height;
			resolutionOptions.Add(resolutionOption);

			//checks the current resolution and gets its index
			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height){
				currentResolutionIndex = i;
			}
		}

		//adds the list of resolutions to the dropdown options
		resolutionDropdown.AddOptions(resolutionOptions);
		//sets the current selected option to the current resolution
		resolutionDropdown.value = currentResolutionIndex;
		//refreshes the dropdown to show the changes
		resolutionDropdown.RefreshShownValue();

		#endregion

		#region SetQualityDropdown

		//sets the current quality index to be the current quality level
		int currentQualityIndex = QualitySettings.GetQualityLevel();
		//sets de dropdown option to the current quality
		qualityDropdown.value = currentQualityIndex;
		//refreshes the dropdown to show the changes
		qualityDropdown.RefreshShownValue();

		#endregion

		#region SetVolumeSliders

		//current volume variable
		float currentMasterVolume = 0;
		//sets current volume value to the mixer value
		mainAudioMixer.GetFloat("masterVolume", out currentMasterVolume);
		//sets the slider to the current volume
		masterVolumeSlider.value = currentMasterVolume;

		//current volume variable
		float currentMusicVolume = 0;
		//sets current volume value to the mixer value
		mainAudioMixer.GetFloat("musicVolume", out currentMusicVolume);
		//sets the slider to the current volume
		musicVolumeSlider.value = currentMusicVolume;

		//current volume variable
		float currentSFXVolume = 0;
		//sets current volume value to the mixer value
		mainAudioMixer.GetFloat("sfxVolume", out currentSFXVolume);
		//sets the slider to the current volume
		sfxVolumeSlider.value = currentSFXVolume;

		#endregion
	}

	//Changes screen resolution
	public void SetResolution (int resolutionIndex){
		//gets resolution from array using index
		Resolution resolution = resolutions[resolutionIndex]; 
		//sets the resolution to the desirable amount
		Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
	}

	//changes the master volume
	public void SetMasterVolume (float volume){
		//set the mixer value to the desirable amount
		mainAudioMixer.SetFloat("masterVolume", volume);
	}

	//changes the music volume
	public void SetMusicVolume (float volume){
		//set the mixer value to the desirable amount
		mainAudioMixer.SetFloat("musicVolume", volume);
	}

	//changes the sfx volume
	public void SetSFXVolume (float volume){
		//set the mixer value to the desirable amount
		mainAudioMixer.SetFloat("sfxVolume", volume);
	}

	//changes quality settings
	public void SetQuality(int qualityIndex){
		//set the quality to the index selected
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	//toggle fullscreen
	public void SetFullScreen(bool isFullScreen){
		//sets fullscrren acording to the boolean received
		Screen.fullScreen = isFullScreen;
	}

}
