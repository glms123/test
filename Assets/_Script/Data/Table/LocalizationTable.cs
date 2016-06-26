using UnityEngine;
using System.Collections;

[System.Serializable]
public class LocalizationInfo {
    public int id;
    public string description;
    public string localizedText;
}

[System.Serializable]
public class LocalizationTable : DataCollection<int, LocalizationInfo> {

}
