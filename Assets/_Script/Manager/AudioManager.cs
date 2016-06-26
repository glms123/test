using Valkyrie;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : SingletonBehaviour<AudioManager>
{
    /// <summary>
    /// 音乐开关
    /// </summary>
    public bool OnMusic { get; set; }
    /// <summary>
    /// 音效开关
    /// </summary>
    public bool OnSound { get; set; }
    Dictionary<int, GameObject> audioBGM = new Dictionary<int, GameObject>();
    List<GameObject> audioSE = new List<GameObject>();

    void Awake()
    {
        GameSettings.BGMVolumeChanged += BGMVolumeChanged;
        GameSettings.SEVolumeChanged += SEVolumeChanged;

        OnMusic = SaveDataUtils.GetBoolUserDefault(DataDefine.Music, true);
        OnSound = SaveDataUtils.GetBoolUserDefault(DataDefine.Sound, true);

        UpdateMusic();
        UpdateSound();
    }

    void OnLevelWasLoaded(int level)
    {
        audioBGM.Clear();
        audioSE.Clear();
    }

    public void BGMVolumeChanged(float val)
    {
        foreach (GameObject go in audioBGM.Values)
        {
            go.GetComponent<AudioSource>().volume = val;
        }
    }

    public void SEVolumeChanged(float val)
    {
        foreach (GameObject go in audioSE)
        {
            go.GetComponent<AudioSource>().volume = val;
        }
    }

    public GameObject CreateSoundObject(bool loop)
    {
        GameObject so = GameObject.Find("BGMplayer");
         if(so == null)
         { 
             so = new GameObject();
            so.name = "BGMplayer";
         }
        AudioSource audioSource = so.GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = so.AddComponent<AudioSource>();

        audioSource.volume = GameSettings.BGMVolume;
        audioSource.loop = loop;
        audioSource.maxDistance = 3600.0f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        return so;
    }

    public AudioSource CreateAudioSource(GameObject go)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = go.AddComponent<AudioSource>();

        

            audioSource.volume = GameSettings.SEVolume;
            audioSource.loop = false;
            audioSource.maxDistance = 60.0f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
        }

        if (!audioSE.Contains(go))
        {
            audioSE.Add(go);
        }

        return audioSource;
    }

    public void DestroyAudioSource(GameObject go)
    {
        audioSE.Remove(go);
    }

    public void PlayBGM(int key, bool loop = true)
    {
        if (!OnMusic) return;

        if (audioBGM.ContainsKey(key))
        {
           return;
        }

        AudioInfo au = ResManager.Instance.audioTable.GetById(key);
        if (null == au)
        {
            return;
        }

        string path = GetAudioClipPath(au);
        if (string.IsNullOrEmpty(path))
        {
            return;
        }
		AudioClip clip = null;
        ResManager.Instance.LoadAsync<AudioClip>(path,false, true,
		                                          (ob)=>{

			clip = ob as AudioClip;
			if (null != clip)
			{
                GameObject snd = CreateSoundObject(loop);
				audioBGM[key] = snd;
                snd.GetComponent<AudioSource>().clip = clip;
                snd.GetComponent<AudioSource>().Play();
				//snd.audio.PlayOneShot(clip);
				if (!loop)
				{
					StartCoroutine(DestroyAudioCoroutine(key, clip.length));
				}
			}
		});

    }

    public void StopBGM(int key)
    {
        GameObject soundObj;
        if (audioBGM.TryGetValue(key, out soundObj))
        {
            audioBGM.Remove(key);
            GameObject.Destroy(soundObj);
        }
    }

    public void StopBGM(int key, float time)
    {
        if (time <= 0)
        {
            StopBGM(key);
        }
        else
        {
            StartCoroutine(FadeAudioCoroutine(key, time));
        }
  
    }

    public void StopAllBGM()
    {
        foreach (GameObject go in audioBGM.Values)
        {
            GameObject.Destroy(go);
        }

        audioBGM.Clear();
    }

    IEnumerator FadeAudioCoroutine(int key, float time)
    {
        GameObject soundObj;
        if (!audioBGM.TryGetValue(key, out soundObj))
        {
            yield break;
        }

        float t = time;
        float v  = 0;
       if (soundObj)
        v = soundObj.GetComponent<AudioSource>().volume;

        while (t > 0.0f)
        {      
            t -= Time.deltaTime;
            if(t < 0.0f)
                t = 0.0f;
            if (soundObj)
                soundObj.GetComponent<AudioSource>().volume = t / time;
            yield return null;
        }

        StopBGM(key);
        yield return null;
    }

    IEnumerator DestroyAudioCoroutine(int key, float time)
    {
        yield return new WaitForSeconds(time);
        StopBGM(key);
    }

    public void PlayUISound(int key, float pitch = 1,bool loop=false)
    {
        if (!OnSound) return;

        AudioInfo au = ResManager.Instance.audioTable.GetById(key);
        if (null == au)
        {
            return;
        }

        string path = GetAudioClipPath(au);
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        AudioClip clip = null;
        ResManager.Instance.LoadAsync<AudioClip>(path, false, true,
        (ob) =>
        {

            clip = ob as AudioClip;
            if (null != clip)
            {
                float scale = UnityEngine.Random.Range(au.minVolumeScale, au.maxVolumeScale);
                NGUITools.PlaySound(clip, scale, pitch);
            }
        });
    }
    public void PlaySound(int key, AudioSource source)
    {
        if (!OnSound) return;

        AudioInfo au = ResManager.Instance.audioTable.GetById(key);
        if (null == au)
        {
            return;
        }
        /*
        if (AudioType.SE != au.audioType)
        {
            return;
        }*/

        // 播放概率
        if (0 == au.playProb || UnityEngine.Random.Range(0f, 1f) > au.playProb)
        {
            return;
        }

        string path = GetAudioClipPath(au);
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

		AudioClip clip = null;
        ResManager.Instance.LoadAsync<AudioClip>(path, false,true,
		                                          (ob)=>{
			
			clip = ob as AudioClip;
			if (null != clip)
			{
				
				float scale = UnityEngine.Random.Range(au.minVolumeScale, au.maxVolumeScale);
                if(source)
				    source.PlayOneShot(clip, scale);
			}
		});
    }

	public void PlaySound(string path, AudioSource source)
    {
        if (!OnSound) return;

		AudioClip clip = null;
        ResManager.Instance.LoadAsync<AudioClip>(path, false,true,
		                                          (ob)=>{
			clip = ob as AudioClip;
			if (null != clip)
			{
				source.PlayOneShot(clip);
			}
		});
    }
  
    /// <summary>
    /// 系统设置里设置音乐
    /// </summary>
    public void SetMusic()
    {
        OnMusic = !OnMusic;
        UpdateMusic();
        SaveDataUtils.SetBoolUserDefault(DataDefine.Music, OnMusic);
    }
    void UpdateMusic()
    {
        if (OnMusic)
        {
            BGMVolumeChanged(1);
        }
        else
        {
            BGMVolumeChanged(0);
        }
    }
    /// <summary>
    /// 系统设置里设置音效
    /// </summary>
    public void SetSound()
    {
        OnSound = !OnSound;
        UpdateSound();
        SaveDataUtils.SetBoolUserDefault(DataDefine.Sound, OnSound);
    }
    void UpdateSound()
    {
        if (OnSound)
        {
            SEVolumeChanged(1);
        }
        else
        {
            SEVolumeChanged(0);
        }
    }
    int GetAudioClipProbIndex(AudioInfo data)
    {
        if (null == data)
        {
            return -1;
        }

        int count = data.clipPath.Count;
        if (count <= 0)
        {
            return -1;
        }

        float aveProb = 1f / count;
        float prob = UnityEngine.Random.Range(0f, 1f);
        return Mathf.Min(Mathf.FloorToInt(prob / aveProb), count - 1);
    }

    string GetAudioClipPath(AudioInfo data)
    {
        if (null == data)
        {
            return "";
        }

        int _index = GetAudioClipProbIndex(data);
        if (_index >= 0 && _index < data.clipPath.Count)
        {
            return data.clipPath[_index];
        }

        return "";
    }
}

