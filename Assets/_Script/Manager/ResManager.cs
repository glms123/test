using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class WwwEntity
{
    public int requestCount;
    public int totalCount;
}

public class ResManager : SingletonBehaviour<ResManager>
{
	#region asset path
	// table asset bundle


    public static string CHARACTER_TABLE { get { return "TableAssets/Character"; } }
    public static string BREAKITEM_TABLE { get { return  "TableAssets/BreakItem";}}
    public static string DROPITEM_TABLE { get { return  "TableAssets/DropItem";}}
	public static string AUDIO_TABLE { get { return  "TableAssets/Audio";}}
	public static string LEVEL_TABLE { get { return  "TableAssets/LevelTable";}}
	public static string BATTLE_TABLE { get { return  "TableAssets/BattleTable";}}
           
	public static string COPY_TABLE { get { return  "TableAssets/Copy";}}
    public static string MISC_TABLE { get { return "TableAssets/MiscTable"; } }
    public static string SCENE_TABLE { get { return "TableAssets/SceneTable"; } }
    public static string LOCALIZATION_TABLE { get { return "TableAssets/Localization"; } }

    public static string DIALOGUE_TABLE { get { return "TableAssets/DialogueTable"; } }
    public static string CARD_TABLE { get { return "TableAssets/CardTable"; } }
    public static string UNIT_TABLE { get { return "TableAssets/UnitTable"; } }

    #endregion

    public CharacterTable characterTable;
	public BreakItemTable breakItemTable;
	public DropItemTable dropItemTable;
	public AudioTable audioTable;
	public LevelTable levelTable;
    public LocalizationTable localizationTable;
	public CopyTable copyTable;
    public MiscTable miscTable;
    public SceneTable sceneTable;
    public DialogueTable dialogueTable;
    public CardTable cardTable;
    public UnitTable unitTable;


    void Start()
    {
        LoadInitTable();
    }
	
	public void LoadObject<T>(string fileName, bool resourcesLoad, System.Action<T> finishLoad,bool instantiate = true) where T : UnityEngine.Object
	{
		ResManager.Instance.LoadAsync<T>(fileName, resourcesLoad, true, (obj) =>
		                                 {
			if (obj == null)
			{
				Debug.LogError("Load object failed : " + fileName);
				if (finishLoad != null)
				{
					finishLoad(null);
				}
				return;
			}
			T res;
			if(instantiate)
			{
				res = Instantiate(obj) as T;
			}
			else
			{
				res = obj as T;
			}
			if (finishLoad != null)
			{
				finishLoad(res);
			}
			
		});
	}

	public void LoadAsync<T>(string fileName, bool resourcesLoad , bool isUnload, System.Action<T> finishLoad) where T : UnityEngine.Object
	{
		if (resourcesLoad)
		{
			T obj = Resources.Load<T>(fileName);
			if (finishLoad != null)
			{
				finishLoad(obj as T);
			}
		}
		else
		{
             LoadResImmediately<T>(fileName,finishLoad);

            //string abPath = "ToBundle/" + fileName;
            //if (!ABMgr.Instance.abLookUp.ContainsKey(abPath))
            //{
            //    T obj = Resources.Load<T>(fileName);
            //    if (finishLoad != null)
            //    {
            //        finishLoad(obj as T);
            //    }
            //}
            //else
            //{
            //    ABMgr.Instance.LoadImmediately(abPath, finishLoad);
            //}
        }
	}



    #region table

    public Object GetObject(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return null;
        }
        Object res = Resources.Load(path);
        if (null != res)
        {
            return res;
        }
        return null;
    }

    public void LoadInitTable()
    {
        LoadTable<MiscTable>(ResManager.MISC_TABLE, (value) => {
            ResManager.Instance.miscTable = value;
            ResManager.Instance.miscTable.Init();
        });
        LoadTable<AudioTable>(ResManager.AUDIO_TABLE, (value) => {  ResManager.Instance.audioTable = value;  });
        LoadTable<LocalizationTable>(ResManager.LOCALIZATION_TABLE, (value) => { ResManager.Instance.localizationTable = value; });
        LoadTable<SceneTable>(ResManager.SCENE_TABLE, (value) => { ResManager.Instance.sceneTable = value; });
        LoadTable<LevelTable>(ResManager.LEVEL_TABLE, (value) => { ResManager.Instance.levelTable = value; });
        LoadTable<DialogueTable>(DIALOGUE_TABLE, (value) => { dialogueTable = value; });
        LoadTable<CardTable>(CARD_TABLE, (value) => { cardTable = value; });
        LoadTable<UnitTable>(UNIT_TABLE, (value) => { unitTable = value; });
    }
    /// <summary>
    /// 加载表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_path"></param>
    /// <param name="_end"></param>
    /// <returns></returns>
    protected bool LoadTable<T>(string _path, System.Action<T> _end = null) where T : class,new()
    {
        bool bIsLoad = true;

        LoadResImmediately<TextAsset>(_path, (textData) =>
        {
            if (textData != null)
            {
                ProcessData<T>(_path, textData, _end);
            }
            else
            {
                Debug.LogError("no table data! " + _path);
                bIsLoad = false;
            }
        });


        return bIsLoad;
    }

    private void ProcessData<T>(string _path, TextAsset loadData, System.Action<T> _end = null) where T : class,new()
    {
        IDataCollection data = new T() as IDataCollection;
        if (loadData == null)
        {
            int i = 1;
        }

        data.Load(loadData.text);
        data.Slim();
        if (_end != null)
        {
            _end((T)data);
        }
    }
    /// <summary>
    /// 从本地读取数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="onLoad"></param>
    public void LoadResImmediately<T>(string path, System.Action<T> onLoad) where T : UnityEngine.Object
    {
        StartCoroutine(LoadRes(path, onLoad));
    }

    private IEnumerator LoadRes<T>(string path, System.Action<T> onLoad) where T : UnityEngine.Object
    {
        ResourceRequest rr = Resources.LoadAsync(path);
        while (!rr.isDone)
        {
            yield return null;
        }

        if (onLoad != null)
        {
            onLoad(rr.asset as T);
        }
    }

    #endregion

    public void LoadSceneAsync<T>(string fileName, bool resourcesLoad, bool isUnload, System.Action<T> finishLoad) where T : UnityEngine.Object
    {
        StartCoroutine(LoadSceneRes<T>(fileName, resourcesLoad, isUnload, finishLoad));
    }
    IEnumerator LoadSceneRes<T>(string fileName, bool resourcesLoad, bool isUnload, System.Action<T> finishLoad) where T : UnityEngine.Object
    {
        while (!Caching.ready)
            yield return null;

        string path = "";

        path = "http://192.168.7.137/assetbundle" + fileName + ".unity3d";



        Debug.Log("LoadSceneRes path: " + path);
        WWW www = null;
        WwwEntity wwwEneity = null;
        AssetBundle bundle = null;
        //if (wwwCache.ContainsKey(path))
        //{
        //    Debug.Log(wwwCache + " exist !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!~~~~~~~~~~~~~~~~" + path + " add request " + wwwCache);
        //}
        //else
        //{
        //    wwwEneity = new WwwEntity();
        //    wwwCache.Add(path, wwwEneity);
        //    Debug.Log(wwwCache + "not exist !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!~~~~~~~~~~~~~~~~" + path + " add to " + wwwEneity);
        //}

        //wwwCache[path].requestCount += 1;
        //wwwCache[path].totalCount += 1;
        //if (assetBundles.ContainsKey(path))
        //    www = assetBundles[path];
        //else
        //{
        //    www = WWW.LoadFromCacheOrDownload(path, 1);
        //    //
        //    Debug.Log(path + " add to " + wwwCache);
        //    assetBundles.Add(path, www);

        //}
        yield return www;

        while (!www.isDone)
        {
            yield return null;
        }

        if (www.error != null)
        {
            Debug.LogError("cannot load res : " + path + "   error:" + www.error);
        }

        bundle = www.assetBundle;
        //wwwCache[path].requestCount -= 1;
        if (finishLoad != null)
        {
            if (bundle == null)
            {
                //Debug.LogError(wwwCache[path] + " bundle is null : " + path);
            }
            else
            {
                if (bundle.mainAsset == null)
                {
                    Debug.LogWarning("bundle.mainAsset is null : " + path);
                    finishLoad(null);
                }
                else
                {

                    finishLoad(bundle.mainAsset as T);
                }
            }
        }
        //if (wwwCache[path].requestCount <= 0)
        //{
        //    Debug.Log("to delete ~~~~~~~~~~~~~" + path + " remove " + wwwCache);
        //    assetBundles.Remove(path);
        //    if (isUnload)
        //    {
        //        bundle.Unload(false);
        //    }
        //}

    }
	public void OnDestory()
	{
		StopAllCoroutines();
	}
}