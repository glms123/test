// Copyright (c) 2013 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Valkyrie;
/// <summary>
/// The base class for all level transitions.
/// </summary>
public abstract class SMTransition : MonoBehaviour {
	
	public static SMTransitionState state = SMTransitionState.None;
    public string[] loadingSceneArray = new string[] { "Map_Loading"};
	public bool loadAsync = false;
    public SceneAction SceneLoaded;
	/// <summary>
	/// The id of the screen that is being loaded.
	/// </summary>
	[HideInInspector]
	public string screenId;
	
	void Start() {
        if (state == SMTransitionState.None)
        {

            Debug.LogWarning("SMTransitionState " + state);
		    LoadSceneFile();
         }
        else
        {
            Destroy(gameObject);
        }
	}

	/// <summary>
	/// This method actually does the transition. It is run in a coroutine and therefore needs to do
	/// yield returns to play an animation or do another progress over time. When this method returns
	/// the transition is expected to be finished.
	/// </summary>
	/// <returns>
	/// A <see cref="IEnumerator"/> for showing the transition status. Use yield return statements to keep
	/// the transition running, otherwise simply end the method to stop the transition.
	/// </returns>
	protected virtual IEnumerator DoTransition() {
		state = SMTransitionState.Out;
		Prepare();
		float time = 0;

		while(Process(time)) {
			time += Time.deltaTime;
			// wait for the next frame
			yield return 0;
		}
		
		// wait another frame...
		yield return 0;
		
		state = SMTransitionState.Hold;
		DontDestroyOnLoad(gameObject);

		// wait another frame...
		yield return 0;
		
		IEnumerator loadLevel = DoLoadLevel();
		while (loadLevel.MoveNext()) {
			yield return loadLevel.Current;
		}
        System.GC.Collect(); 
        Resources.UnloadUnusedAssets();
        SceneLoaded(screenId);

		// wait another frame...
		yield return 0;

		state = SMTransitionState.In;
		Prepare();
		time = 0;

		while(Process(time)) {
			time += Time.deltaTime;
			// wait for the next frame
			yield return 0;
		}

		// wait another frame...
		yield return 0;
        state = SMTransitionState.None;
		Destroy(gameObject);
	}
	
	/// <summary>
	/// invoked during the <see cref="SMTransitionState.Hold"/> state to load the next scene. 
	/// Override this method to interrupt the transition before or after loading the scene. 
	/// Make sure to call <code>yield return base.LoadLevel()</code> in your implementation.
	/// </summary>
	/// <returns>
	/// A <see cref="IEnumerator"/> 
	/// </returns>
	protected virtual IEnumerator DoLoadLevel(string id_ = null) {
        if (id_ == null)
        {
            id_ = screenId;
        }
        yield return LoadLevel(id_);
	}


	void LoadSceneFile()
	{
        Resources.UnloadUnusedAssets();

        state = SMTransitionState.Prepare;
		string path = "Map/"+screenId;
        bool resourcesLoad = true;// screenId.Contains(MapId.MapLogin) ? true : false;
        //if (screenId.Contains(MapId.MapCity) ||
        //    screenId.Contains(MapId.MapSplash)    )
        //{
        //    resourcesLoad = true;
        //}

        // @TODO Î´À´ÒÆ³ý //
        if (screenId.Contains(MapId.Map_DargonTower))
        {
            path = "Content/Map/" + MapId.Map_DargonTower;
            //List<int> idHS = new List<int>() {9003, 6005, 4004, 5001, 5011, 5004, 11140001 };
            //for(int i = 0; i < idHS.Count - 1; i++)
            //{
            //    Debug.Log("Prepare unit for guider " + idHS[i]);
            //    LevelManager.Instance.PrepareUnit(idHS[i], null, null);
            //}
            //LevelManager.Instance.PrepareUnit(11140001, "Prefabs/Weapon/1400", null);                                                              
            //resourcesLoad = true;                               
        }

     
        if (resourcesLoad)
        {
            ResManager.Instance.LoadAsync<GameObject>(path, resourcesLoad, false, (res) =>
            {
                StartCoroutine(DoTransition());
            });
        }
        else
        {
            //TODO ///
          //  UDPServers.Instance.Exit();
           //ResManager.Instance.LoadAsync<GameObject>(path, resourcesLoad, false, (res) =>
            ResManager.Instance.LoadSceneAsync<GameObject>(path, resourcesLoad, false, (res) =>
            {
                StartCoroutine(DoTransition());
            });
        }
	}
	
	/// <summary>
	/// Starts the actual load operation
	/// </summary>
	/// <returns>
	/// The load operation or <code>null</code>
	/// </returns>
    protected virtual YieldInstruction LoadLevel(string screenId)
    {
		if (loadAsync) {
			return Application.LoadLevelAsync(screenId);
		} else {
			Application.LoadLevel(screenId);
			return null;
		}
	}
	
	/// <summary>
	/// invoked at the start of the <see cref="SMTransitionState.In"/> and <see cref="SMTransitionState.Out"/> state to 
	/// initialize the transition
	/// </summary>
	protected virtual void Prepare() {
	}
	
	/// <summary>
	/// Invoked once per frame while the transition is in state <see cref="SMTransitionState.In"/> or <see cref="SMTransitionState.Out"/> 
	/// to calculate the progress
	/// </summary>
	/// <param name='elapsedTime'>
	/// the time that has elapsed since the start of current transition state in seconds. 
	/// </param>
	/// <returns>
	/// false if no further calls are necessary for the current state, true otherwise
	/// </returns>
	protected abstract bool Process(float elapsedTime);
}
