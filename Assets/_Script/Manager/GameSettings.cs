using System.Collections.Generic;
using UnityEngine;

    public enum Quality :int
    {
        None,
        Low,
        Mid,
        High
    }

    public enum Market
    {
        DevLocal,
        DevInternet,
        Teebik,
        Teebik2,
        Wan73,
		OMG,
        OMG_DEV
    }

    public class GameSettings : SingletonBehaviour<GameSettings>
    {
        public bool SkillBeginSFXflag = false;

        public bool showDebugArea = false;
		public bool editMode = false;
        public float specialTime = 1f;
        public float freezeTime = 0.1f;
        public float freezeSpeed = 0.01f;
        public bool targetPause = false;
        public float damping = 20f;
        public float gravity = 20.0f;
        public float floating = 10.0f;
        public float singleTapRunFix = 10.0f;
		[HideInInspector]
		public bool useNetwork = true;
        [HideInInspector]
		public bool guideing = false;
        public Quality quality = Quality.Low;
        public Market market = (Market)Market.DevLocal;

        public static bool useCharacterController = true;
        public static bool useFixedUpdate = true;
        public bool isSkillCheckMode = false;
		public bool remoteTable = false;
        [HideInInspector]
        public bool remote = true;
        public bool isShowDebugLog_ = true;
        public bool useTouchInput
        {
            get
            {
                return PlayerPrefs.GetInt("useTouchInput", 0) == 1;
            }

            set
            {
                if(value)
                    PlayerPrefs.SetInt("useTouchInput",1);
                else
                    PlayerPrefs.SetInt("useTouchInput", 0);
                PlayerPrefs.Save();
            }
        }

		public Vector3 joystickDir;

        [RangeAttribute(0.0f, 1.0f)]
        public static float defaultSceneVolume = 1.0f;
        [RangeAttribute(0.0f, 1.0f)]
        public static float defaultBGMVolume = 0.8f;

        public static System.Action<float> SEVolumeChanged;
        public static float SEVolume
        {
            get
            {
                return PlayerPrefs.GetFloat("SEVolume", defaultSceneVolume);
            }

            set
            {
                Debug.Log("PlayerPrefs SEVolume Set " + value);

                PlayerPrefs.SetFloat("SEVolume", value);
                PlayerPrefs.Save();
                if (SEVolumeChanged != null)
                {
                    SEVolumeChanged(value);
                }
            }
        }

        public static System.Action<float> BGMVolumeChanged;
        public static float BGMVolume
        {
            get
            {
                return PlayerPrefs.GetFloat("BGMVolume", defaultBGMVolume);
            }
            set
            {
                Debug.Log("PlayerPrefs BGMVolume Set " + value);

                PlayerPrefs.SetFloat("BGMVolume", value);
                PlayerPrefs.Save();
                if (BGMVolumeChanged != null)
                {
                    BGMVolumeChanged(value);
                }
            }
        }
    }

