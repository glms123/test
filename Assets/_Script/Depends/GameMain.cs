//#define USE_SDK
//#define USE_SDK_OMG
//#define USE_SDK_TEEBIK
//#define USE_SDK_SQWAN
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

namespace Valkyrie
{

    public enum GameState: int
    {
        NULL = 0,
        LOGIN = 1,
        CONNECTING = 2,
        MAINCITY =3,
        CAMPAIGN = 4,
        JJC = 5,
        ACTIVITYCOPY = 6,

    }
    public class GameMain : Framework
    {
        public static GameState gState;
        public static bool enableOutlog;
        public static bool enableGuide = true;
        public static bool InitWorld = false;

        protected override void ConfigComponents()
        {
            base.ConfigComponents();
 #if UNITY_EDITOR
            enableOutlog = true;
#else
            enableOutlog = true;
#endif
            ComponentTools.AddComponent<AudioListener>(gameObject);

            if (Framework.Get<ResManager>() == null)
            {
                Framework.AddComponent<ResManager>();
            }
            if (Framework.Get<AudioManager>() == null)
            {
                Framework.AddComponent<AudioManager>();
            }

#if UNITY_EDITOR

#elif UNITY_IOS

#elif UNITY_ANDROID
         
#endif

            SMSceneManager sceneManager;
            sceneManager = AddComponent<SMSceneManager>();
            sceneManager.TransitionPrefab = "Prefabs/SMTransitions/SMFadeTransition";
       //     sceneManager.SceneLoaded += OnSceneLoaded;
        }

        IEnumerator SplashTimeHepler(float time)
        {
            yield return new WaitForSeconds(time);
            SMSceneManager.Instance.LoadScreen(MapId.MapSplash);
        }

        protected override void Start()
        {
			Debug.Log("GameMain Start!");
           
			SMSceneManager.Instance.LoadScreen(MapId.MapSplash);
            Application.runInBackground = true;
        }

        void OnApplicationPause(bool pauseStatus)
        {
            OnQuitOrPause();
        }

        void OnApplicationQuit()
        {
            OnQuitOrPause();
        }

        void OnQuitOrPause()
        {
            //if (UserModel.Instance.IsLogin)
            //{
            //    System.DateTime now = System.DateTime.Now.ToLocalTime();
            //    int nowTime = (int)((now - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local)).TotalMilliseconds / 1000);
            //    LocalNotificationManager.NotificationMessageAtSeconds(LanguageUtils.GetStaticString(StaticLangEnum.LOCAL_NOTIFY_APFULL_TITLE), LanguageUtils.GetStaticString(StaticLangEnum.LOCAL_NOTIFY_APFULL_DESC), nowTime + UserModel.Instance.GetNeedTimeMaxPower());                
            //}
        }

        float lastTimeEscape = 0;

        void Update()
        {
          
        }

        void OnGUI()
        {
#if UNITY_EDITOR

            Rect rect = new Rect(100, 200, 300, 300);
            GUILayout.BeginArea(rect);

            //if (GUILayout.Button("Test Android Back Button"))
            //{

            //    Framework.SendEvent(LocalChangeEvent.AndroidBackButton);

            //}

            GUILayout.EndArea();
            /*if (GUILayout.Button(" Speed up"))
            {
                Time.timeScale += 0.2f;
              
            }

            if (GUILayout.Button("  Speed down"))
            {
                Time.timeScale -= 0.2f;

            }
            GUILayout.Label("Time.timeScale = " + Time.timeScale);*/
//            if (GUILayout.Button("Test Something"))
//            {
//            //    Debug.Log(AltarModel.Instance.AltarBuild.nextTypeAltarBuild.unlockAltar);
//
//				//SMSceneManager.Instance.LoadScreen(MapId.MapLogin);
//				//AssetLoader.Instance.isBasicAssetsLoaded = false;
//            }

			//LocalNotificationManager.NotificationMessage("test","test notify",20);
#endif
        }
    }
}


