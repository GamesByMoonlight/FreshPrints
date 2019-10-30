using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;	

public class SettingsUpdate : MonoBehaviour
{
	public Text GlobalVol;
	public Text MusicVol;
	public Text EffectVol;
	public Slider GlobalSlide;
	public Slider MusicSlide;
	public Slider EffectSlide;
	

    
    public void SliderUpdate()
    {
        GlobalVol.text = (GlobalSlide.value + "%");
		EffectVol.text = (EffectSlide.value + "%");
		MusicVol.text = (MusicSlide.value + "%");
    }
	
	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
