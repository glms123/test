using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BreakItemInfo {

    // 
    public int id;
    public string name;

    // 
    public int beHitNum;
	public List<int> dropPackageId;
    // public int dropPackageId1;
    // public int dropPackageId2;
    // public int dropPackageId3;
    // public int dropPackageId4;
    // public int dropPackageId5;
    
    public int GetDropPackageID(int _index) {
		return dropPackageId[_index];
        // if (_index == 0) return dropPackageId1;
        // if (_index == 1) return dropPackageId2;
        // if (_index == 2) return dropPackageId3;
        // if (_index == 2) return dropPackageId4;
        // if (_index == 2) return dropPackageId5;
        // return 0;
    }
}

public class BreakItemTable : DataCollection<int, BreakItemInfo>
{
}
