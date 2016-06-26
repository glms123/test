using UnityEngine;
using System.Collections;
using Valkyrie;

public class SplashScene : MonoBehaviour {

	// Use this for initialization
    GameObject logo1;
    GameObject logo2;
    GameObject logo3;
    public Camera mc;
    void Awake()
    {
        logo1 = gameObject.FindChild("Logo1");
        logo2 = gameObject.FindChild("Logo2");
        logo3 = gameObject.FindChild("Logo3");
    //    logo1.SetActive(false);
        //logo2.SetActive(false);
        //logo3.SetActive(false);
    }

	void Start () {

        StartCoroutine(SplashTimeHepler(2.5f));
        Debug.Log("!!!!!!!!!!!!!!!!!!");

    }
	
    IEnumerator SplashTimeHepler(float time)
    {
        //mc.backgroundColor = Color.white;
        //StartCoroutine(Test(time, logo2));
        yield return new WaitForSeconds(time);
        //mc.backgroundColor = Color.black;
       // StartCoroutine(Test(time, logo3));
       // yield return new WaitForSeconds(time);
        //mc.backgroundColor = Color.black;
        //StartCoroutine(Test(time, logo1));
        //yield return new WaitForSeconds(time);
        //Debug.Log("SplashTimeHepler end!!!!!!!!!!!!!!!!!!" + Time.time);
        if (SMSceneManager.Instance)
            SMSceneManager.Instance.LoadScreen(MapId.New);
    }

     IEnumerator Test(float time, GameObject logo)
    {
        logo.SetActive(true);
        TweenAlpha ta2 = logo.AddComponent<TweenAlpha>();
        ta2.duration = 0.5f;
        ta2.from = 0;
        ta2.to = 1;


        yield return new WaitForSeconds(time - 0.5f);
        ta2.PlayReverse();

      //  logo.SetActive(false);
    }
}
