using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public enum AudioType
{   
    BGM = 1,
    SE,
    Voice,
    Material //≤ƒ÷ …˘“Ù
}

[System.Serializable]
public class AudioInfo {

    public int id;
    public AudioType audioType = AudioType.SE;
	public float playProb;
    public float minVolumeScale;
    public float maxVolumeScale;
    
	public List<string> clipPath;
	public string description;

    public AudioInfo()
    {

    }

    public string type
    {
        set
        {
            audioType = (AudioType)System.Enum.Parse(typeof(AudioType), value, true);
        }
    
    }

    public int GetMaterialSound(int idx)
    {
        if (audioType != AudioType.Material)
        {
            return 0;
        }

        if (idx < clipPath.Count)
        {
            return int.Parse(clipPath[idx]);
        }
        return 0;
    }
}

[System.Serializable]
public class AudioTable : DataCollection<int, AudioInfo>
{
}
