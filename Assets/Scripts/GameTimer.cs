using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public AudioClip clip;
	public float levelSeconds = 100;
	
	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;
	
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin (){
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create You Win object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if(slider.value >= 1f && !isEndOfLevel){
			isEndOfLevel = true;
			audioSource.Play ();
			winLabel.SetActive(true);
			Invoke("LoadNextLevel", audioSource.clip.length);
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
