using System.Collections.Generic;

    [System.Serializable]
    public class SceneInfo
    {
        public int id;
        public string name;
        public int spawnPointNum;
        public List<string> spawnPoint;
        public int zoneNum;
        public string zonePoints;
        public string zoneSizes;
        public string zoneRotations;
        public string airIds;
        public string airPositions;
        public string airRotations;
        public string airScale;      //空气墙大小集合//
        public string airScaleIndex; //空气墙大小索引//
        public string mcSpawnRotation;
        public string mcSpawnPoints;
        public string position;
        public string signPositions;
        public string signDirRotations;
    }

    [System.Serializable]
    public class SceneTable : DataCollection<int, SceneInfo>
    {
    }

