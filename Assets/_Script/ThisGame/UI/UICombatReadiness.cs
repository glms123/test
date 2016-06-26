using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UICombatReadiness : BaseUI
{
   
    void Awake()
    {
        AudioManager.Instance.PlayBGM((int)BGMType.BGM02);
        ComponentTools.SetUIEventListener(gameObject, "fightBtn", OnBattle);
    }
    // Use this for initialization
    void Start ()
    {
      
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}



    void OnBattle(GameObject btn)
    {
        base.OnBack(btn);
        GameObject uibattle = null;
        WindowManager.ManageWinwodOpen(WindowAction.Open_UIBattle,null , uibattle);

        GameObject go = GameObject.Find("BattleManager");
        if (go == null)
        {
            go = new GameObject();
            go.name = "BattleManager";
        }
        BattleManager bm = ComponentTools.AddComponent<BattleManager>(go);
        
    }
    
}
