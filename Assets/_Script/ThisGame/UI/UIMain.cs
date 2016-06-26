using UnityEngine;
using System.Collections;

public class UIMain : MonoBehaviour
{
    void Awake()
    {
        Framework.RegisterEvent(ThisGameEvent.HideUI, EventHideUI);
    }
    void OnDestroy()
    {
        Framework.UnregisterEvent(ThisGameEvent.HideUI, EventHideUI);
    }
    // Use this for initialization
    void Start () {
        ComponentTools.SetUIEventListener(gameObject, "SoundBtn", OnSound);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnSound(GameObject btn)
    {
        SetAudio();
    }
    void EventHideUI(object obj)
    {
        gameObject.SetActive(false);
    }
   public  void SetAudio()
    {
        AudioManager.Instance.SetMusic();
        AudioManager.Instance.SetSound();
    }
   
}
