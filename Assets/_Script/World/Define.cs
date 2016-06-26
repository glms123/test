
using System.Collections.Generic;
using UnityEngine;

    public enum BGMType : int
    {
        MainCity = 2000001,
        Battle = 20,
        Victory = 1007,
        Defeat = 1008,
    JJC = 19,
        SwipeHint = 2400010,
        SE01 = 2000002, //普通按钮音效//
        SE04 = 2000003, //1按钮轻点击取消//
        SE03 = 2000004, //1按钮轻点击确定//
        SE06 = 2000005, //1感叹号提示//
        SE07 = 2000006, //进军副本音效//
        SE18 = 2000007, //战役木门//
        SE19 = 2000008, //1购买物品成功//
        SE20 = 2000009, //1获得任务奖励//
        SE21 = 2000010, //1卖出物品//
        SE14 = 2000011, //1下一步//
        SE17 = 2000012, //1点击背包物品栏物品//
        SE16 = 2000013, //1扫荡成功//
        SE02 = 2000014, //1返回键//
        SE22 = 2000015, //Boss警告音效//
		SESSK = 2000017,//超必杀//
		SESK = 2000018, //技能可释放//
        SE05 = 2000019, //1贫血时心脏跳动//
        SE08 = 2000020, //1召唤抽奖//
        SE09 = 2000021, //附魔音效//
        SE10 = 2000022, //英雄穿戴装备的音效//
        SE11 = 2000023, //英雄使用经验药水的音效//
        SE12 = 2000024, //英雄技能升级音效//
        SE13 = 2000025, //英雄升星音效//
        SE15 = 2000026, //英雄升阶音效//
        SE26 = 2000027, //抽奖英雄获得音效//
        SE27 = 2000028, //战队等级提升音效//
        SE34 = 2000035, //登陆界面//
        SE23 = 2000016, //星星音效//
		SE35 = 2000038, //神器升级//
		SE37 = 2000040, //祭坛经验//
		SE36 = 2000039,//升级界面框//
		SE37get = 2000040, //接受任务//
		SE38 = 2000041,//完成任务//
		SE39 = 2000042,//获得奖励音效//
		DIRTY = 2300219,
		CRUEL = 2300220,
		WONDERFUL = 2300221,
		ANARCHIC = 2300222,
		SADISTIC = 2300223,
		SENSATIONAL = 2300224,
		UNBELIEVABLE = 2300225,
        SQAUDIO_LONG=2000048,//神器技能龙 声音
        SQAUDIO_HUOYAN = 2000049,//神器技能火焰 声音
        SQAUDIO_BING=2000050,//神器技能冰 声音
        SQAUDIO_ZHIYU=2000051,//神器技能治愈 声音


    BGM01 = 1010,
    BGM02 = 1011,
    BGM03 = 1012,

}
    /// <summary>
    /// 非UI界面的Prefabs路径
    /// </summary>
    public class PrefabsPath
    {
        public const string UIroot = "Prefabs/UI/UIRoot";
        public const string UIAutoPF = "Prefabs/UI/UIAutoPF";
        public const string UIMask = "Prefabs/UI/UIMask";
        public const string QuestTip = "Prefabs/UI/UIActivity/QuestTip";            //每日活动的面板//
        public const string ActivityInfo = "Prefabs/UI/UIActivity/UIActivityInfo";            //每日活动的面板//
        public const string DisplayItem = "Prefabs/UI/DisplayItem";            //道具//
        public const string MultiMopupDetail = "Prefabs/UI/UIMultiMopupDetail";            //扫荡面板//
        public const string MopupDetail = "Prefabs/UI/UIMopupDetail";            //扫荡完成面板//
        public const string Skill = "Prefabs/UI/UIHero/HeroUISkill";            //技能//
        public const string Birth = "Prefabs/UI/UIHero/Birth";            //出处//
        public const string SMpt = "Prefabs/SMTransitions/SMProgressTransition";
        public const string HeadIcon = "Prefabs/UI/UIHero/HeadIcon";            //头像图标//
        public const string UIMainMenu = "Prefabs/Scene/MainCity/UIMainMenu";            //主菜单//
        public const string HeroHpBar = "Prefabs/UI/UIHero/HeroHpBar";            //英雄血条和能量//
        public const string ShopCommodity = "Prefabs/UI/UiShop/ShopCommodity";            //商店商品信息//
        public const string SMProgressTransition = "Prefabs/SMTransitions/SMProgressTransition";
        public const string CommonDesc = "Prefabs/UI/CommonUI/UICommonDesc";            //npc信息//
        public const string TroopInfo = "Prefabs/UI/CommonPrefabs/TroopInfo";            //天梯队伍预制件//
        public const string ArenaHead = "Prefabs/UI/CommonPrefabs/ArenaHead";            //竞技场头像//
        public const string SelectHeroBox = "Prefabs/UI/CommonPrefabs/SelectHeroBox";           //阵形用的选择英雄框//
        public const string SelectHeroBoxZhandou = "Prefabs/UI/CommonPrefabs/SelectHeroBoxZhandou";           //阵形用的选择英雄框//
        public const string EquipObject = "Prefabs/UI/CommonPrefabs/EquipObject";           //装备预制件//
        public const string BorderSAnimation = "Prefabs/UI/UIEffect/BorderSAnimation";            //品质边框特效//
        public const string AcceptAnimation = "Prefabs/UI/UIActivity/UIQuestAccept";              //接受任务
        public const string FinishTaskAnimation = "Prefabs/UI/UIActivity/UIQuestComplete";            //完成任务
        public const string BattleMap = "Prefabs/UI/CopaMap/BattleMap";            //战役地图
        public const string Map = "Prefabs/UI/CopaMap/Map/{0}";            //地图文件夹

        //UI特效
        public const string UIEffect06 = "Prefabs/UI/UIFX/UIEffect06";            //装备特效//
        public const string UIEffect07 = "Prefabs/UI/UIFX/UIEffect07";         ////  
        public const string UIEffect08 = "Prefabs/UI/UIFX/UIEffect08";//升级特效//
        public const string GuideFX = "Prefabs/UI/UIFX/GuideFx02";            //光圈//
        public const string UIEffect09 = "Prefabs/UI/UIFX/UIEffect09";//副本地图当前进度特效//
        public const string UIJingBi = "Prefabs/FX/Character/Tongyong/TY_Jinbi";//金币特效
        public const string UIBaofuEffect = "Prefabs/FX/Character/Tongyong/TY_Baofu";//包裹特效
        public const string UIXiangziEffect = "Prefabs/FX/Character/Tongyong/TY_Xiangzi";//箱子特效
        public const string UIGuangQuanB = "Prefabs/FX/Character/Tongyong/Guangquan_B";//光柱特效B
        public const string UIGuangQuanG = "Prefabs/FX/Character/Tongyong/Guangquan_G";//光柱特效G
        public const string UIGuangQuanR = "Prefabs/FX/Character/Tongyong/Guangquan_R";//光柱特效R
        public const string UIJjinbiEffect = "Prefabs/Misc/Parkour/Drop_parkour";//移动到人物身上的特效
        //伤害数字动画特效
        public const string HUDNormal = "Prefabs/UI/HUDText/HUDNormal";
        public const string HUDNormal01 = "Prefabs/UI/HUDText/HUDNormal01";
        public const string HUDNormal02 = "Prefabs/UI/HUDText/HUDNormal03";
        //排行榜前几名
        public const string RankNpcList = "Prefabs/UI/3DMainCityPos/RankNpcList";
        /// <summary>
        /// 世界boss专用战斗UI部分
        /// </summary>
        public const string WorldScript = "Prefabs/UI/UIWorldBoss/WorldScript";
        //超杀相机
        public const string GameBeginCamera = "Prefabs/Depends/GameBeginCamera";
        //超杀相机UI展示
        public const string heroskillUICamera = "Prefabs/Depends/HeroSkillUICamera";
        //BOSS出场相机
        public const string SplineForShowCamera = "Prefabs/Depends/BossBeginShowCamera";//BossShow
        //Boss出场UI显示
        public const string BossShowUICamera = "Prefabs/Depends/BossShowUICamera";
        public const string UIKarmaShowLevel = "Prefabs/UI/UIHero/UIKarmaShowLevel";

    }
    /// <summary>
    /// UI界面的Prefabs路径
    /// </summary>
    public class UIName
    {
        public readonly static string UIPVP = "Prefabs/UI/UIPVP/UIPVP";         //竞技场UI界面
        public readonly static string UIAltarJTStart = "Prefabs/UI/UIArtifact/UIAltarJTStart";//祭坛;
        public readonly static string UIAltarSQSkillSelect = "Prefabs/UI/UIArtifact/UIAltarSQSkillSelect";//神器技能选择;
        public readonly static string UIAltarSQSkill = "Prefabs/UI/UIArtifact/UIAltarSQSkill";//神器技能;
        public readonly static string UIAltarST = "Prefabs/UI/UIArtifact/UIAltarST";//神坛界面;
        public readonly static string UIArtifact = "Prefabs/UI/UIArtifact/UIArtifact";//神器界面;
        public readonly static string UIRuneBuyPanel = "Prefabs/UI/UIArtifact/UIRuneBuyPanel";

        public readonly static string UIBattleEnd = "Prefabs/UI/UIBattleEnd";
        public readonly static string UIBattleEndFaild = "Prefabs/UI/UIBattleEndFaild";
        public readonly static string UINULL = "";
        public readonly static string UICompound = "Prefabs/UI/UICompound";
        public readonly static string UIHeroList = "Prefabs/UI/UIHeroList";                  //英雄列表界面//
        public readonly static string UIHeroList2 = "Prefabs/UI/UIHeroList2";                  //英雄列表界面//
        public readonly static string UIHero = "Prefabs/UI/UIHero/UIHero";                          //单个英雄信息界面//
        public readonly static string UIAdvanceResources = "Prefabs/UI/UIHero/UIAdvanceResources";                               //进阶消耗资源面板
        public readonly static string UIHeroExp = "Prefabs/UI/UIHero/UIHeroExp";            //英雄吃经验界面//
        public readonly static string UIEvolveSucceed = "Prefabs/UI/UIHero/UIEvolveSucceed";            //进化成功界面//
        public readonly static string UIAdvanceSucceed = "Prefabs/UI/UIHero/UIAdvanceSucceed";            //进阶成功界面//
        public readonly static string UIsellwindow = "Prefabs/UI/UIsellwindow";
        public readonly static string UISellInfo = "Prefabs/UI/UISellInfo";

        public readonly static string UIMap = "Prefabs/UI/UIMap";
        public readonly static string UIUnOpened = "Prefabs/UI/UIUnOpened";
//        public readonly static string UIEmbattle = "Prefabs/UI/UIEmbattle";
		public readonly static string UIEmbattle = "Prefabs/UI/UICommonEmbattle";
//        public readonly static string UIPvpEmbattle = "Prefabs/UI/UIPvpEmbattle";
		public readonly static string UIPvpEmbattle = "Prefabs/UI/UICommonEmbattle";
        public readonly static string UIShop = "Prefabs/UI/UIShop";                              //商店界面//
        public readonly static string UIShopSell = "Prefabs/UI/UiShop/UIShopSell";                              //商店出售界面//
        public readonly static string UIBuy = "Prefabs/UI/UIBuy";
        public readonly static string UIOrdeal = "Prefabs/UI/UIOrdeal";                          //英雄试练//
        public readonly static string UICaveOfTime = "Prefabs/UI/UICaveOfTime";                  //时光之穴//
        public readonly static string UIDifficulty = "Prefabs/UI/UIDifficulty";                  //时光之穴英雄试练选择难度//
        public readonly static string UIArenaSelect = "Prefabs/UI/UIArena/UIArenaSelect";                  //竞技场选择界面//
        public readonly static string UIArena = "Prefabs/UI/UIArena/UIArena";                            //竞技场//
        public readonly static string UIArenaRule = "Prefabs/UI/UIArena/UIArenaRule";                            //竞技场规则说明界面//
        public readonly static string UIArenaBattleRecord = "Prefabs/UI/UIArena/UIArenaBattleRecord";                            //竞技场对战记录界面//
		public readonly static string UIArenaResult = "Prefabs/UI/UIArena/UIArenaResult";

        public readonly static string UICall = "Prefabs/UI/UICall/UICall";                              //召唤//
        public readonly static string UICallResult = "Prefabs/UI/UICall/UICallResult";
        public readonly static string UICallPreview = "Prefabs/UI/UICall/UICallPreview";
        public readonly static string UICallKBox = "Prefabs/UI/UICall/UICallKBox";
        public readonly static string UIRedEnvelope = "Prefabs/UI/UICall/UIRedEnvelope";
        public readonly static string UIRedEnvelopeDetail = "Prefabs/UI/UICall/UIRedEnvelopeDetail";
        public readonly static string UIGetHero = "Prefabs/UI/UIGetHero";
        public readonly static string UIClip = "Prefabs/UI/UIClip";
        public readonly static string UIItem = "Prefabs/UI/UIItem";
		public readonly static string UIItemEx = "Prefabs/UI/UIItemEx";
        public readonly static string UIItemDetail = "Prefabs/UI/UIItemDetail";                  //道具详情//
        public readonly static string UITask = "Prefabs/UI/UITask";
        public readonly static string UIActivity = "Prefabs/UI/UIActivity/UIActivity";                       //每日活动//
        public readonly static string UIActivityAward = "Prefabs/UI/UIActivity/UIActivityAward";            //获得奖励确认界面//

        public readonly static string UIRecharge = "Prefabs/UI/UIRecharge";                  //充值界面//     

        public readonly static string UICrusade = "Prefabs/UI/UICrusade/UICrusade";                 //远征界面
        public readonly static string UICrusadeRule = "Prefabs/UI/UICrusade/UICrusadeRule";         //远征规则
        public readonly static string UICrusadeShop = "Prefabs/UI/UICrusade/UICrusadeShop";        //远征商店
        public readonly static string UICrusadeSelect = "Prefabs/UI/UICrusade/UICrusadeSelect";    //远征选关
        public readonly static string CrusadeIcon = "Prefabs/UI/UICrusade/CrusadeIcon";            //远征关卡图标和宝箱预制件//
        public readonly static string UICrusadeBoxAward = "Prefabs/UI/UICrusade/UICrusadeBoxAward";        //宝箱未解锁点击宝箱显示的界面//
        public readonly static string UICrusadeReward = "Prefabs/UI/UICrusade/UICrusadeReward";        //宝箱解锁点击宝箱显示的界面//
//        public readonly static string UICrusadeEmbattle = "Prefabs/UI/UICrusade/UICrusadeEmbattle";        //远征站前准备界面//
		public readonly static string UICrusadeEmbattle = "Prefabs/UI/UICommonEmbattle";        //远征站前准备界面//
        public readonly static string UIChat = "Prefabs/UI/UIChat/UIChat";                          //聊天界面//
        public readonly static string UIChatPanel = "Prefabs/UI/UIChat/UIChatPanel";
        public readonly static string UIChatPlayerInfo = "Prefabs/UI/UIChat/UIChatPlayerInfo";          //聊天界面玩家信息//
        public readonly static string UIBlockList = "Prefabs/UI/UIChat/UIBlockList";          //黑名单界面//
        public readonly static string UILevelButton = "Prefabs/UI/CopaMap/UILevelButton";
        public readonly static string UILevelSelect = "Prefabs/UI/UILevelSelect";
        public readonly static string UISmallLevelButton = "Prefabs/UI/UISmallLevelButton";
        public readonly static string UICopyMap = "Prefabs/UI/CopaMap/UICopyMapTwo";                   //战役界面

        public readonly static string UIMopup = "Prefabs/UI/UIMopup";
        public readonly static string UIMultiPopup = "Prefabs/UI/UIMultiMopup";
        public readonly static string UIMail = "Prefabs/UI/UIMail";
        public readonly static string UIGoldenHand = "Prefabs/UI/UIGoldenHand";
        public readonly static string UIGoldenHand_BP = "Prefabs/UI/UIGoldenHand_BP";

        public static string UIConfirm { get { return "Prefabs/UI/UIConfirm"; } }
        public readonly static string UISignIn = "Prefabs/UI/UISignIn/UISignIn";                          //签到界面//
        public readonly static string UISignInDetail = "Prefabs/UI/UISignIn/UISignInDetail";               //签到奖励详情界面//
        public readonly static string UISignInConfirm = "Prefabs/UI/UISignIn/UISignInConfirm";               //签到奖励确认界面//
        public readonly static string UIMessage = "Prefabs/UI/UIMessage";

        public readonly static string UIIcon = "Prefabs/UI/UIIcon";
        public readonly static string UICombat = "Prefabs/UI/UICombat";
        public readonly static string COMBATCOUNT = "Prefabs/UI/CombatCount";
        public readonly static string UIJJCCombat = "Prefabs/UI/UIJJCCombat";

        public readonly static string UIShowCoordinate = "Prefabs/UI/UIShowCoordinate";
        public readonly static string UIResource = "Prefabs/UI/UIResource";
        public readonly static string UISelectIcon = "Prefabs/UI/UISelectIcon";
        public readonly static string UISelectIcon_Peak = "Prefabs/UI/UISelectIcon_Peak";

        public readonly static string UIWeapon = "Prefabs/UI/UIWeapon/UIWeapon";
        public readonly static string UIGetSoulStone = "Prefabs/UI/UIGetSoulStone";             //获取灵魂石路径界面//
        public readonly static string UISkillDesc = "Prefabs/UI/UISkillDesc";             //技能描述//
        public readonly static string UIOperation = "Prefabs/UI/Operation/UIOperation";             //人物信息界面//
        public readonly static string UIOpera = "Prefabs/UI/Operation/UIOpera";                     //更换头像
        public readonly static string UIAlterPlayerName = "Prefabs/UI/UIAlterPlayerName";   //更改昵称
        public readonly static string UISystemSetting = "Prefabs/UI/UISystemSetting";             //系统设置界面//
        public readonly static string UIItemMix = "Prefabs/UI/UIItemMix";             //装备合成界面//

        public readonly static string UISettings2 = "Prefabs/UI/UISettings2";
        public readonly static string UIMailDetail = "Prefabs/UI/UIMailDetail";

        public readonly static string UIThumpBar = "Prefabs/UI/ThumpBar";
        public readonly static string UINameBoard = "Prefabs/UI/HUDText/NameBoard";
        public readonly static string UIPvpGradeBoard = "Prefabs/UI/HUDText/PvpGradeBoard";

        public readonly static string UIBloodBar = "Prefabs/UI/UIBloodBar/BloodBar";
        public readonly static string UIGreenBloodBar = "Prefabs/UI/UIBloodBar/UIGreenBloodBar";
        public readonly static string UIBlueBloodBar = "Prefabs/UI/UIBloodBar/UIBlueBloodBar";
        public readonly static string UIBossBloodBar = "Prefabs/UI/UIBloodBar/BossBloodBar";
        public readonly static string UIDialogBox = "Prefabs/UI/UIDialogBox";
        public readonly static string UISkillDialogBox = "Prefabs/UI/UISkillDialogBox";    //释放技能出现对话//
        public readonly static string UISplitCamera = "Prefabs/UI/UISplitScreen";
        public readonly static string UISimpePopup = "Prefabs/UI/UISimpePopup";             //右侧菜单栏//

        public readonly static string UIHint = "Prefabs/UI/CommonUI/UIHint";             //无按钮的提示界面//
        public readonly static string UISpeakAside = "Prefabs/UI/CommonUI/UISpeakAside";         //关卡内旁白，不暂停游戏//
        public readonly static string UIHintLeft = "Prefabs/UI/CommonUI/UIHintLeft";             //左对齐无按钮的提示界面//
        public readonly static string UIHintLeft2 = "Prefabs/UI/CommonUI/UIHintLeft2";             //左对齐无按钮的提示界面//
        public readonly static string UIStageTopHint = "Prefabs/UI/CommonUI/UIStageTopHint";
        public readonly static string UIStageHint = "Prefabs/UI/CommonUI/UIStageHint";
        public readonly static string UIFlotage = "Prefabs/UI/CommonUI/UIFlotage";             //漂浮文字界面//
        public readonly static string UIFlotageLeft = "Prefabs/UI/CommonUI/UIFlotageLeft";             //左对齐漂浮文字界面//
        public readonly static string UIFlotageLeft2 = "Prefabs/UI/CommonUI/UIFlotageLeft2";             //左对齐漂浮文字界面//
        public readonly static string UIFlotageRight = "Prefabs/UI/CommonUI/UIFlotageRight";             //右对齐漂浮文字界面//
        public readonly static string UIFlotageRight2 = "Prefabs/UI/CommonUI/UIFlotageRight2";             //右对齐漂浮文字界面//
        public readonly static string UIFlotageMine = "Prefabs/UI/CommonUI/UIFlotageMine";             //矿洞飘字//
        public readonly static string UIFlotageFight = "Prefabs/UI/CommonUI/UIFlotageFight";             // //
        public readonly static string UIConnecting = "Prefabs/UI/CommonUI/UIConnecting";             //连接中//
        public readonly static string UICommonAward = "Prefabs/UI/CommonUI/UICommonAward";             //通用奖励界面//

        public readonly static string UIFingerGuideStep = "Prefabs/UI/UIFingerGuide";
        public readonly static string UIWeakFingerGuideStep = "Prefabs/UI/WeakFingerGuideStep";
        public readonly static string UIFingerWeakGuideStep = "Prefabs/UI/UIWeakFingerGuide";
        public readonly static string UIFingerRayGuideStep = "Prefabs/UI/UIFingerRayGuide";
        public readonly static string UIUnion = "Prefabs/UI/UIUnion/UIUnion";             //公会界面//
        public readonly static string UIUnionBoss = "Prefabs/UI/UIUnion/UIUnionBoss";
		public readonly static string UIUnionCrap = "Prefabs/UI/UIUnion/UIUnionCrap";
        public readonly static string UIUnionManage = "Prefabs/UI/UIUnion/UIUnionManage";             //公会管理界面//
        public readonly static string UIUnionMember = "Prefabs/UI/UIUnion/UIUnionMember";             //成员管理
        public readonly static string UIUnionAmend = "Prefabs/UI/UIUnion/UIUnionAmend";               //修改公告
        public readonly static string UIUnionTeam = "Prefabs/UI/UIUnion/UIUnionTeam";             //公会团队副本界面//
        public readonly static string UIUnionTeamRule = "Prefabs/UI/UIUnion/UIUnionTeamRule";             //公会团队副本规则说明界面//
        //public readonly static string UIUnionWorshipGod = "Prefabs/UI/UIUnion/UIUnionWorshipGod";             //公会膜拜大神界面//
        public readonly static string UIUnionWorship = "Prefabs/UI/UIUnion/UIUnionWorship";             //公会玩家膜拜别人界面//
        public readonly static string UIUnionShop = "Prefabs/UI/UIUnion/UIUnionShop";             //公会商店界面//
        public readonly static string UICreatUnion = "Prefabs/UI/UIUnion/UICreatUnion";             //创建公会界面//
        public readonly static string UIUnionLog = "Prefabs/UI/UIUnion/UIUnionLog";                 //公会日志
        public readonly static string UIUnionTimeGo = "Prefabs/UI/UIUnion/UIUnionTimeGo";             //前往副本
        public readonly static string UIUnionJoin = "Prefabs/UI/UIUnion/UIUnionJoin";
		public readonly static string UIUnionMemberMessage = "Prefabs/UI/UIUnion/UIUnionMemberMessage";	
		public readonly static string UIUnionMemberManage = "Prefabs/UI/UIUnion/UIUnionMemberManage";
		public readonly static string UIUnionSet = "Prefabs/UI/UIUnion/UIUnionSet";						//公会设置界面//
        public readonly static string UIUnionIcon = "Prefabs/UI/UIUnion/UIUnionicon";                   //公会图标设置界面//


        public readonly static string UIMercenary = "Prefabs/UI/Mercenarycamp/UIMercenary";            //佣兵
        public readonly static string UIMercenaryCommission = "Prefabs/UI/Mercenarycamp/UIMercenaryCommission";            //佣兵收入

        public readonly static string UIAnimationGuideStep = "Prefabs/UI/UIAnimationGuideStep";
        public readonly static string UIDialogGuideStep = "Prefabs/UI/UIDialogGuide";
        public readonly static string UITouchArrow = "Prefabs/UI/TouchArrow";
        public static string UIRankingList { get { return "Prefabs/UI/RankingList/UIRankingList"; } }           //排行榜界面//
        public static string UIRankingListTwo { get { return "Prefabs/UI/RankingList/UIRankingListTwo"; } }            //排行榜界面//
        public readonly static string UIRankPlayerInfo = "Prefabs/UI/RankingList/UIRankPlayerInfo";             //排行榜玩家信息界面//

        public readonly static string UIExcavateMain = "Prefabs/UI/UIExcavate/UIExcavateMain";             //神秘地穴界面//
        public readonly static string UIExcavateRule = "Prefabs/UI/UIExcavate/UIExcavateRule";             //神秘地穴界面//
        public readonly static string UIExcavateNote = "Prefabs/UI/UIExcavate/UIExcavateNote";             //防守记录界面
        public readonly static string UIExcavateSelect = "Prefabs/UI/UIExcavate/UIExcavateSelect";                   //藏宝地穴选择界面
        public readonly static string UIExcavateBonus = "Prefabs/UI/UIExcavate/UIExcavateBonus";                   //藏宝地穴面包奖励界面

        public readonly static string UIEnchanting = "Prefabs/UI/UIEnchanting/UIEnchanting";             //附魔界面//
        public readonly static string UIEnchantingSelectHeor = "Prefabs/UI/UIEnchanting/UIEnchantingSelectHeor";             //附魔选择英雄界面//

        //public readonly static string UIWorldBoss { get { return "Prefabs/UI/UIWorldBoss/UIWorldBoss"; } }         //世界BOSS
        public static string WorldBoss { get { return "Prefabs/UI/UIWorldBoss/WorldBoss"; } }          //世界BOSS
        public static string UIWorldBossKilled { get { return "Prefabs/UI/UIWorldBoss/UIWorldBossKilled"; } }         //BOSS已被击杀界面

        public readonly static string UITeamUpgrade = "Prefabs/UI/CommonUI/UITeamUpgrade";             //战队升级界面//
        public readonly static string UICommonRule = "Prefabs/UI/CommonUI/UICommonRule";            //通用规则说明界面
        public readonly static string UICommonShop = "Prefabs/UI/CommonUI/UICommonShop";            //通用商店界面
        public readonly static string UICommonOpenTime = "Prefabs/UI/CommonUI/UICommonOpenTime";            //通用时间提醒界面 时光,试练用
        public readonly static string UICommonEmbattle = "Prefabs/UI/CommonUI/UICommonEmbattle";            //通用备战界面
        public readonly static string UICommonSelectHeor = "Prefabs/UI/CommonUI/UICommonSelectHeor";            //通用选英雄界面
        public readonly static string UIHireAffirm = "Prefabs/UI/CommonUI/UIHireAffirm";            //确认雇佣界面
        public readonly static string UICommonHarmRanking = "Prefabs/UI/CommonUI/UICommonHarmRanking";            //通用伤害排名界面
        public readonly static string UIBtnUnlockFX = "Prefabs/UI/CommonUI/UIBtnUnlockFX";            //按钮解锁播放特效界面
        public readonly static string UIWellDoen = "Prefabs/UI/CommonUI/UIWellDoen";            //干得漂亮界面


        public readonly static string UIHighlightStep = "Prefabs/UI/UIHighlightGuide";
        public readonly static string UIOperateSelect = "Prefabs/UI/UIOperateSelect";
        public readonly static string UIImageGuideStep = "Prefabs/UI/UIImageGuideStep";
        public readonly static string UIPositionCheckStep = "Prefabs/UI/UIPositionCheckStep";
        public readonly static string UISkillCheckStep = "Prefabs/UI/UISkillCheckStep";
        public readonly static string UIJoystick = "Prefabs/UI/UIJoystick";

        public readonly static string UITower = "Prefabs/UI/UITower/UITower";                          //无限塔
        public readonly static string UITowerOpenBox = "Prefabs/UI/UITower/UITowerOpenBox";
        public readonly static string UITowerKeyBuyPanel = "Prefabs/UI/UITower/UITowerKeyBuyPanel";    //购买钥匙选择界面//
        public readonly static string UITowerChallengePanel = "Prefabs/UI/UITower/UITowerChallengePanel"; //无限城显示关卡信息界面//
        public readonly static string UITowerSweepComplete = "Prefabs/UI/UITower/UITowerSweepComplete";
        
        public readonly static string UICreatPlayerName = "Prefabs/UI/UICreatPlayerName/UICreatPlayerName";

		public readonly static string UIRTArenaIntegral = "Prefabs/UI/UIRTArena/UIRTArenaIntegral";
		public readonly static string UIRTArenaMacthing = "Prefabs/UI/UIRTArena/UIRTArenaMacthing";
        public readonly static string UIRTArenaAchieve = "Prefabs/UI/UIRTArena/UIRTArenaAchievement";
        public readonly static string UIRTArenaRule = "Prefabs/UI/UIRTArena/UIRTArenaRule";

        public readonly static string UIArenaLadder = "Prefabs/UI/UIArenaLadder/UIArenaLadder";         //排位赛界面
        public readonly static string UIPDArena = "Prefabs/UI/UIPDArena/UIPDArena";         //巅峰竞技场界面
        public readonly static string UIArenaLadderChallenge = "Prefabs/UI/UIArenaLadder/UIArenaLadderChallenge";         //巅峰竞技场界面
        public readonly static string UIPDArenaAdjust = "Prefabs/UI/UIPDArena/UIPDArenaAdjust";         //巅峰竞技场选人界面
        public readonly static string UIPDArenaAdjustWeapon = "Prefabs/UI/UIPDArena/UIPDArenaAdjustWeapon";         //巅峰竞技场选人武器头像界面
        public readonly static string UIPDArenaAdjustHero = "Prefabs/UI/UIPDArena/UIPDArenaAdjustHero";         //巅峰竞技场选人英雄头像界面
        public readonly static string UIPDArenaPVP = "Prefabs/UI/UIPDArena/UIPDArenaPVP";         //巅峰竞技场UI界面
        public readonly static string UIPDArenarival = "Prefabs/UI/UIPDArena/UIPDArenarival"; //队友信息界面
        public readonly static string UIPDArenaSearch = "Prefabs/UI/UIPDArena/UIPDArenaSearch";//巅峰竞技场对手选择界面
        public readonly static string UITeamMapTrophy = "Prefabs/UI/UIUnion/UITeamMapTrophy";//战利品申请界面
        public readonly static string UITeamMapQueue = "Prefabs/UI/UIUnion/UITeamMapQueue"; //战利品申请详情界面
        public readonly static string UIUnionDoubluOk = "Prefabs/UI/UIUnion/UIUnionDoubluOk";//战利品申请二次确认界面
        public readonly static string UIunionDestrotion = "Prefabs/UI/UIUnion/UInionDistribution";//分配记录界面
        public readonly static string UIUnionDrop = "Prefabs/UI/UIUnion/UIUnionDrop";//掉落显示页面

        public readonly static string UIPeakArena = "Prefabs/UI/UIPeakArena/UIPeakArena";
        public readonly static string UIPeakArenaDefend = "Prefabs/UI/UIPeakArena/UIPeakArenaDefend";
        public readonly static string UIPeakArenaOpponent = "Prefabs/UI/UIPeakArena/UIPeakArenaOpponent";
        public readonly static string UIPeakArenaOppDetail = "Prefabs/UI/UIPeakArena/UIPeakArenaOppDetail";
        public readonly static string UIPeakArenaEmbattle = "Prefabs/UI/UIPeakArena/UIPeakArenaEmbattle";
        public readonly static string UIPeakArenaCombat = "Prefabs/UI/UICombat_Peak";
        

        public readonly static string UIFirst = "Prefabs/UI/UIFirst";                           //充值反馈界面
        public readonly static string UIFirstPanel = "Prefabs/UI/UIFirstPanel";                           //首充界面
        public readonly static string UIActivityb = "Prefabs/UI/UIActivityb";                   //精彩活动界面
        public readonly static string UIEightDayActive = "Prefabs/UI/EightDayActive/UIEightDayActive";    //开服八天活动
        public readonly static string UICarnivalActive = "Prefabs/UI/EightDayActive/UICarnivalActive";    //开服嘉年华
        public readonly static string UICarnivalAlltarget = "Prefabs/UI/EightDayActive/UICarnivalAlltarget";  //嘉年华全目标奖励

        public readonly static string UIRTArenaSelectTitle = "Prefabs/UI/UIRTArena/UIRTArenaSelectTitle"; //查看称号界面
        public readonly static string UITrumpet = "Prefabs/UI/UIChat/UITrumpt";         //弹出喇叭消息框

        public readonly static string UIAnnouncement = "Prefabs/UI/UIAnnouncement";     //登陆时的公告
        public readonly static string UIOpenFunction = "Prefabs/UI/CommonPrefabs/UIOpenFunction";            //新功能开启界面//

        public readonly static string UIWellDone = "Prefabs/UI/CommonUI/UIWellDoen";             //左对齐无按钮的提示界面//
        public readonly static string UIHeroSkill = "Prefabs/UI/UIHeroSkill";
		public readonly static string UIHeroSkillEx = "Prefabs/UI/UIHeroSkillEx";
		public readonly static string UIHeroSkillBall = "Prefabs/FX/Character/UI/UI_Tuowei";


        public readonly static string UIHeroPvpBackup = "Prefabs/UI/UIHeroPvpBackup";
        public readonly static string UIHeroPvpBackupEx = "Prefabs/UI/UIHeroPvpBackupEx";

        public readonly static string UIQuestAccept = "Prefabs/UI/UIActivity/UIQuestAccept";  //接收任务界面
        public readonly static string UIQuestComplete = "Prefabs/UI/UIActivity/UIQuestComplete";  //完成任务界面
        public readonly static string UIHeroAttribute = "Prefabs/UI/UIHero/UIHeroAttribute";  //英雄类型描述界面
        public readonly static string UIRedeemCode = "Prefabs/UI/SystemSetting/UIRedeemCode";  //兑换码界面
        public readonly static string UIGuideSystem = "Prefabs/UI/UIGuideSystem/UIGuideSystem";  //引导系统
        public readonly static string UISingleAddHeroExp = "Prefabs/UI/UIHero/UISingleAddHeroExp"; //
        public readonly static string UIServerList = "Prefabs/UI/UIServerList/UIServerList2";  //服务器列表
        public readonly static string UIMission = "Prefabs/UI/UIActivity/UIMission";  //任务界面
        public readonly static string UIHeroMenu = "Prefabs/UI/UIHeroMenu";//英雄录

        public readonly static string UITeamProperty = "Prefabs/UI/UITeamProperty/UITeamProperty";

        //星图
        public readonly static string UIConstellationSelect = "Prefabs/UI/UIConstellation/UIConstellationSelect";
        public readonly static string UIConstellation = "Prefabs/UI/UIConstellation/UIConstellation";
        public readonly static string UIConstellationMap = "Prefabs/UI/UIConstellation/UIConstellationMap";
        public readonly static string UIConstellationSpeedUp = "Prefabs/UI/UIConstellation/UIConstellationSpeedUp";
        public readonly static string UIConstellationGetGem = "Prefabs/UI/UIConstellation/UIConstellationGetGem";

        
    };

    public class MapId
    {
        public readonly static string MapLogin = "denglu";
        public readonly static string MapCity = "Map_City2";//fucheng_new fucheng_night////fucheng_new01
        public readonly static string MapBigMap = "mainCity";
        public readonly static string MapFunction = "";

        public const string Map_DargonTower = "Map_DargonTower";
        public readonly static string MapSplash = "Splash";
        public readonly static string Launcher = "Launcher2";
        public readonly static string JJC = "jjc1001";
        public readonly static string FirstSceneForGuide = "julang_xg";
        public readonly static string Renmodazhan_dh = "renmodazhan_dh";

        public static string New { get { return "new"; } }
}

    public enum PopType : int
    {
        NULL =0, 
        RED =1,
        WHITE =2,
        GREEN =3,
        BLUE =4,
        GRAY =5,
        YELLOW =6,
        BUFF =7,
        DEBUFF =8,
        StateEffect=9,
        IMMUE =10,
        CRITIAL = 101,
        BLOCK = 102,
        DODGE = 103,
        IMMUNITY = 104,
//        PHYIMMUNITY = 105,
//        SPEIMMUNITY = 106,
        PHYIMMUNITY = 51,
        SPEIMMUNITY = 52,
        //....
    }

    public enum TagType : int
    {
        NONE_TAG = 0,
        FIRE_TAG = 1,
        ICE_TAG = 2,
        POSITION_TAG = 3,
        LIGHT_TAG = 4,
    }

    public enum ItemType : int
    {
        None = 0,           //没有 //
        Equip = 1,          //装备 //
        Scroll = 2,         //卷轴 //
        SoulStone = 3,      //灵魂石 //
        Consumables = 4,    //消耗品 //
        EquipClip = 5,      //装备碎片//
        ScrollClip = 6,     //卷轴碎片//
		Resoures = 9,		//货币类//
        SpeedUp = 10,       //加速道具
    }

    public enum ItemObejctType : int
    {
        None = 0,           //没有 //
        Equip = 1,			//装备 //
        Scroll = 2,         //卷轴 //
        SoulStone = 3,      //灵魂石 //
        Consumables = 4,	//消耗品 //
        EquipClip = 5,      //装备碎片
        ScrollClip = 6,     //卷轴碎片
		Resoures = 9,		//货币类//
        Hero = 101,			//英雄//
		Coin = 102,			//金币//
        Cash = 103,     	//钻石//
		Exp = 104,			//团队经验//
		AP = 105,			//体力//
		Weapon = 106,		//武器//
        BP = 107		//圣魂//
    }

    public enum ProcessType : int
    {
        Assembly = 0, //0-整件装备/卷轴；
        Compound = 1, //1-合成装备/卷轴
        Power = 2, //2-消耗品体力药
        Experience = 3, //3-消耗品经验药；
        Enchanting = 4, //4-消耗品附魔宝物
        Gold = 5, //5-消耗品金币道具
        Swept = 6, //6-扫荡券
        Chip = 7, //7-碎片
        Key = 8, //8-钥匙
        Diamond = 9, //9 钻石消耗
        BP = 10, //10 圣魂消耗
        GiftBag = 11, //礼包
    }
    public enum ResourceType : int
    {
        Gold = 0, //金币
        Diamond = 1, //钻石
        PVPCoin = 2, //PvP硬币
        AP = 3, //体力
        BP = 4, //圣魂
        TeamExp = 20, //团队经验
    }
    public enum ItemQuality : int
    {
       White = 1, //白
       Green = 2, //绿
       Blue = 3, //蓝
       Purple = 4,//紫
       Yellow = 5, //黄
    }
    //英雄阶
    public enum HeroRank : int
    {
        White = 1, //白
        Green = 2, //绿
        GreenOne = 3, //绿1
        Blue = 4, //蓝
        BlueOne = 5, //蓝1
        BlueTwo = 6, //蓝1
        Purple = 7,//紫
        PurpleOne = 8,//紫1
        PurpleTwo = 9,//紫2
        PurpleThree = 10,//紫3
        PurpleFour = 11,//紫4
        Yellow = 12, //黄
        YellowOne = 13, //黄1
    }

    public class ModelChangeEvent
    {

        public static string FightingPower_Changed = "FightingPower_Changed"; //战力改变
        public static string Update_SQ_Skill = "Update_SQ_Skill"; //更新神器技能//
        public static string Update_SQ_RedPoint = "Update_SQ_RedPoint"; //刷新神器
        public static string UserModel_Inited = "UserModel_Inited";
        public static string UserModel_Changed = "UserModel_Changed";
        public static string Money_Changed = "Money_Changed"; //钱改变
        public static string Diamond_Changed = "Diamond_Changed"; //钻石改变
        public static string Power_Changed = "Power_Changed"; //体力改变
        public static string BP_Changed = "BP_Changed"; //圣魂改变
        public static string TowerClip_Changed = "TowerClip_Changed"; //开宝箱碎片改变
        public static string TeamLevel_Changed = "TeamLevel_Changed";
        public static string HeroMenuAward = "HeroMenuAward";
        public static string ItemList_Changed = "ItemList_Changed";
        public static string Item_Add = "Item_Add";
        public static string Mu_Item_Add = "Mu_Item_Add";
        public static string Item_Removed = "Item_Removed";
        public static string Item_Costed = "Item_Costed";
        public static string ClipList_Changed = "ClipList_Changed";
        public static string Clip_Add = "Clip_Add";
        public static string Clip_Removed = "Clip_Removed";
        public static string Clip_Costed = "Clip_Costed";
        public static string HeroList_Changed = "HeroList_Changed";
        public static string Weapons_Changed = "Weapons_Changed";
        public static string Knights_Changed = "Knights_Changed";
        public static string Skills_Changed = "Skills_Changed";
        public static string VipLevel_Changed = "VipLevel_Changed";
        public static string GoldenHandData_Changed = "GoldenHandData_Changed";
        public static string Guid_Step_Changed = "Guid_Step_Changed";
        public static string Skill_Point_Chanaged = "Skill_Point_Chanaged";
        public static string Macro_Changed = "Macro_Changed";
        public static string Name_Changed = "Name_Changed";
        public static string AvatarID_Changed = "AvatarID_Changed";
        public static string BuyNum_Chanaged = "BuyNum_Chanaged";

        public static string CallModel_Inited = "CallModel_Inited";
        public static string CallModel_Changed = "CallModel_Changed";

        public static string ShopModel_Inited = "ShopModel_Inited";

        public static string TaskModel_Inited = "TaskModel_Inited";
        public static string TaskModel_Changed = "TaskModel_Changed";

        public static string DailyActivity_Inited = "DailyActivity_Inited";
        public static string DailyActivity_Changed = "DailyActivity_Changed";

        public static string RTArenaAchieve_Inited = "RTArenaAchieve_Inited";
        public static string RTArenaAchieve_Changed = "RTArenaAchieve_Changed";

        public static string SignModel_Inited = "SignMoel_Inited";
        public static string SignModel_Changed = "SignModel_Changed";

        public static string Mail_List_Changed = "Mail_List_Changed";
        public static string Mail_Deleted = "Mail_Deleted";

        public static string ArenaEnemyList_Changed = "ArenaEnemyList_Changed";
        public static string ArenaPeakEnemyList_Changed = "ArenaPeakEnemyList_Changed";
        public static string ArenaRecordList_Changed = "ArenaRecordList_Changed";
        public static string ArenaModel_Changed = "ArenaModel_Changed";
        public static string ArenaModel_Title_Changed = "ArenaModel_Title_Changed";
        public static string ArenaModel_Random_Changed = "ArenaModel_Random_Changed";
        public static string ArenaModel_V27_Changed = "ArenaModel_V27_Changed";
        public static string ArenaV27EnemyList_Changed = "ArenaV27EnemyList_Changed";

        public static string CrusadeTargetList_Changed = "CrusadeModel_Changed";
        public static string CrusadeModel_Changed = "CrusadeModel_Changed";

        public static string BattleModel_Inited = "BattleModel_Inited";
        public static string BattleModel_Changed = "BattleModel_Changed";
        public static string HireInfo_Inited = "HireInfo_Inited";

        public static string Main_Hero_Changed = "Main_Hero_Changed";
        public static string Call_Buy_More = "Call_Buy_More"; //召唤继续购买
        public static string Update_Hero_Equip = "Update_Hero_Equip"; //更新英雄装备//
        public static string Update_Hero_Equip_Plus = "Update_Hero_Equip_Plus"; //更新英雄装备//
        public static string Hero_Rank_Changed = "Hero_Rank_Changed";
        public static string Hero_Star_Changed = "Hero_Star_Changed";
        public static string Hero_Exp_Changed = "Hero_Exp_Changed";

        public static string Update_SQ_Equip = "Update_SQ_Equip"; //更新神器符文//

        public static string PVP_Ranking_Changed = "PVP_Ranking_Changed";

        public static string Chat_All = "Chat_All";
        public static string Chat_New = "Chat_New";
        public static string Guild_Chat_New = "Guild_Chat_New";
        public static string PM_Chat_New = "PM_Chat_New";

        public static string XX_New = "XX_New";
        public static string XX_Over = "XX_Over";

        public static string WorldChatList_Changed = "WorldChatList_Changed";
        public static string GuildChatList_Changed = "GuildChatList_Changed";
        public static string CityChatList_Changed = "CityChatList_Changed";
        public static string PrivateChatList_Changed = "PrivateChatList_Changed";
        public static string BlockList_Changed = "BlockList_Changed";
        public static string Trumpet_Changed = "Trumpet_Changed";
        public static string CityChat_Add = "CityChat_Add";

        public static string LevelNum_Changed = "LevelNum_Changed";
        public static string LevelStar_Changed = "LevelStar_Changed";
        public static string Guild_LevelNum_Changed = "Guild_LevelNum_Changed";
        public static string Guild_Maps_Changed = "Guild_Maps_Changed";
        public static string Guild_Hires_Changed = "Guild_Hires_Changed";
        public static string Guild_Map_Changed = "Guild_Map_Changed";
        public static string Guild_Setting_Changed = "Guild_Setting_Changed";
        public static string Guild_JoinList_Changed = "Guild_JoinList_Changed";
        public static string Guild_ItemList_Changed = "Guild_ItemList_Changed";
        public static string Guild_ItemAppleList_Changed = "Guild_ItemAppleList_Changed";
        public static string Guild_ItemApplyLog_Changed = "Guild_ItemApplyLog_Changed";
        public static string Guild_MapTop_Changed = "Guild_MapTop_Changed";
        public static string Guild_Icon_Changed = "Guild_Icon_Changed";

        public static string DungeonModel_Changed = "DungeonModel_Changed";

        public static string CityPlayers_List_Changed = "CityPlayers_List_Changed";
        public static string Add_CityPlayer = "Add_CityPlayer";
        public static string Remove_CityPlayer = "Remove_CityPlayer";
        public static string CityPlayer_Changed = "CityPlayer_Changed";
        public static string CityPlayer_Moved = "CityPlayer_Moved";
        public static string CityPlayer_Change_Avatar = "CityPlayer_Change_Avatar";
        public static string CityPlayer_Chat = "CityPlayer_Chat";

        public static string UDP_MESSAGE = "UDP_MESSAGE";

        public static string GuildModel_Changed = "GuildModel_Changed";
        public static string Guild_Member_Changed = "Guild_Member_Changed";

        public static string WorldBoss_Changed = "WorldBoss_Changed";
        public static string WorldBoss_HP_Changed = "World_HP_Changed";
        public static string WorldBoss_Lv_Changed = "WorldBoss_Lv_Changed";
        public static string WorldBoss_DamageNum_Changed = "WorldBoss_DamageNum_Changed";
        public static string WorldBoss_GuildDamageNum_Changed = "WorldBoss_GuildDamageNum_Changed";
        public static string WorldBoss_Top_Changed = "WorldBoss_Top_Changed";
        public static string WorldBoss_LastTop_Changed = "WorldBoss_LastTop_Changed";
        public static string WorldBoss_BossLog_Changed = "WorldBoss_BossLog_Changed";

        public static string Mine_Heros_Changed = "Mine_Heros_Changed";
        public static string Mine_Changed = "Mine_Changed";
        public static string Mine_Log_Changed = "Mine_Log_Changed";
        public static string VipShop_Changed = "VipShop_Changed";

        public static string Notice_Changed = "Notice_Changed";

        public static string AltarBuild_Changed = "AltarBuild_Changed";

        public static string ActivityDataModel_Changed = "ActivityDataModel_Changed";
        public static string Online_Changed = "Online_Changed"; //在线奖励数据改变
        public static string Day8_Changed = "Day8_Changed"; //数据改变
        public static string DestoryOtherPlayer = "DestoryOtherPlayer";
        public static string CarnivalChanged = "CarnivalChanged"; //嘉年华领取奖励
        public static string Consume_State = "Consume_State"; //实时更新运营活动index数据

        public static string Money_Full = "Money_Full"; //充值充满
        public static string Ranking_Type = "Ranking_Type"; //排行榜类型id
        //
        public static string Title_SmallBtnClick = "Title_SmallBtnClick"; //title类型id

        public static string TowerModel_Changed = "CallModel_Changed";

        public static string Wing_Change = "Wing_Change"; //翅膀改变
    }

    public class LocalChangeEvent
    {
		public static string Popup_Close = "Popup_Close";       //弹出框对于的窗口被关闭//
        public static string Change_Popup_Hero = "Change_Popup_Hero";       //改变弹出款按钮 英雄 背包 碎片//
        public static string Change_Popup_Pack = "Change_Popup_Pack";       //改变弹出款按钮 英雄 背包 碎片//
        public static string Change_Popup_Clip = "Change_Popup_Clip";       //改变弹出款按钮 英雄 背包 碎片//
        public static string Change_Popup_Task = "Change_Popup_Task";       //改变弹出款按钮 英雄 背包 碎片//
        public static string Change_Popup_Activity = "Change_Popup_Activity";       //改变弹出款按钮 英雄 背包 碎片//

        public static string Close_SellWindow = "Close_SellWindow";       //关闭出售界面//

        public static string Rank_Button = "Rank_Button";       //打开排行榜后的按钮处理//
        public static string SignIn_Update = "SignIn_Update";       //刷新签到界面//
        public static string Enchanting_Hero = "Enchanting_Hero";       //向附魔界面传递英雄信息//
        public static string DailyActivity_Delete = "DailyActivity_Delete";       //每日活动删除单个//
        public static string Task_Delete = "Task_Delete";       //任务删除单个//

        public static string CopyMap_Camera = "CopyMap_Camera";       //战役地图摄像机//
        public static string UIRoot_Camera = "UIRoot_Camera";       //UIroot摄像机//
        public static string MainCity_Camera = "MainCity_Camera";       //主城摄像机//

        public static string MainCity_OtherButtonClick = "MainCity_OtherButtonClick";       //主城非2级菜单按钮点击//
        public static string MainCity_AthleticsClick = "MainCity_AthleticsClick";       //主城2级菜单竞技点击//
        public static string MainCity_OrdealClick = "MainCity_OrdealClick";       //主城非2级菜单试练点击//
        public static string MainCity_SettingClick = "MainCity_SettingClick";       //主城非2级菜单设置点击//
        public static string MainCity_MainClick = "MainCity_MainClick";       //主城非2级菜单主菜单点击//

        public static string Enchanting_CostClick = "Enchanting_CostClick";       //附魔材料点击//
        public static string Enchanting_Full = "Enchanting_Full";       //附魔装备是否已达到最大值//

		public static string Somethindg_Buy = "Somethindg_Buy";	//uibuy界面确认出售后通知事件//
        public static string Buy_Error16 = "Buy_Error16";	//购买报16号错误//

        public static string Hero_UseExpItem = "Hero_UseExpItem";	//英雄使用经验道具 需要通知道具剩余值//
        public static string Crusade_UnLockBox = "Crusade_UnLockBox";	//解锁宝箱//
        public static string Crusade_UnLockLevel = "Crusade_UnLockLevel";	//解锁关卡//

        public static string SEND_SELECT_INFO = "send_select_info";         //更改称号名称
        public static string CANCEL_NAME_INFO = "cancel_name_info";         //取消更改称号名称
       

		public static string Guild_Create = "Guild_Create";
		public static string Guild_Join = "Guild_Join";

		public static string New_Day = "New_Day";
		public static string New_Day2 = "New_Day2";
		public static string New_Day3 = "New_Day3";

        public static string Hero_Equip_Flotage = "Hero_Equip_Flotage";         //英雄穿装备飘字

        public static string Mercenary_SelectHero = "Mercenary_SelectHero";         //佣兵选英雄

        public static string Enter_Fighting = "Enter_Fighting";                 //进入战斗界面

        public static string Call_Palying = "Call_Palying";                 //继续召唤
        public static string Call_Show = "Call_Show";                 //显示或隐藏召唤
        public static string Call_SetPanel = "Call_SetPanel";    
        public static string WorldBoss_Bonus = "WorldBoss_Bonus";             //世界boss发放奖励
        public static string Call_Point = "Call_Point";    //积分排名更新


        public static string Mine_ALREADY = "MINE_ALREADY";                 //守矿成功
        public static string Mine_Collect = "MINE_Collect";                 //采集成功
        public static string Mine_Search = "Mine_Search";            //调用矿洞查找目标方法
        public static string Mine_StateChange = "Mine_StateChange";        //矿洞状态改变
        public static string Mine_TargetNull = "Mine_TargetNull";           //掠夺胜利//
        public static string Mine_Collected = "Mine_Collected";             //完成采集
        public static string CLICK_NPC = "click_npc";                       //NPC;
        public static string ENTER_BATTLE = "enter_battle";                 //进入战斗

        public static string Guile_IconChange = "Guile_IconChange";

        public static string Toll_Gate_Show = "Toll_Gate_Show";             //是否显示下一个关卡（主要针对剧情任务）

        public static string Stage_Task = "Stage_Task";                         //剧情阶段任务（是否接任务）

        public static string PrivateChat_Button = "PrivateChat_Button";//点击头像,发送私聊消息;

        public static string PrivateChat_Item = "PrivateChat_Item";// 点击玩家Item 显示玩家名称在上面;

        public static string Change_Guide_Icon = "Change_Guide_Icon";//更改右上角引导图标

        public static string Change_Guide_Battle = "Change_Guide_Battle";//更改右上角引导图标为双刀Icon
        
        public static string PrivateChatGuild_Button = "PrivateChatGuild_Button";//公会点击玩家发送私聊消息;

        public static string EnterPrivateChatPage = "EnterPrivateChatPage";//进入私聊界面;
        public static string EquipEffect = "EquipEffect";//装备特效;

        public static string OpenWindow = "OpenWindow";//有界面打开;
        public static string CloseWindow = "CloseWindow";//有界面关闭;

        public static string IsEnterNextStep = "IsEnterNextStep";//是否进入下个阶段的引导

        public static string CloseUILevelTarget = "CloseUILevelTarget";//关卡目标关闭

        public static string NoticeShow = "ShowNotice";//显示公告
        public static string NoticeHide = "HideNotice";//隐藏公告

        public static string ClickOpenFirstItem = "ClickOpenFirstItem";//点击第一个道具

        public static string OpenEmbattle = "OpenEmbattle";//布阵界面打开
        public static string CloseEmbattle = "CloseEmbattle";//布阵界面关闭

        public static string QuestIdChange = "QuestIdChange";//任务id改变
        public static string QuestIdChangeRed = "QuestIdChangeRed";//任务红点

        public static string HeroSkillChanged = "Hero_Skill_Changed"; //英雄技能升级改变

        public static string RemoveHero = "RemoveHero"; //移除新手引导英雄

        public static string SAIClick = "SAIClick"; //精彩活动 右边按钮点击
        public static string SAIClickRed = "SAIClickRed";//活动红点
        public static string RedEnvelopeRed = "RedEnvelopeRed";//红包红点


        public static string ResourceOnExit = "ResourceOnExit"; //界面退出但是不通过左上角按钮退出

        public static string BuyChestKeySuccess = "BuyChestKeySuccess"; //购买宝箱钥匙成功
        public static string TowerSweepEnd = "TowerSweepEnd";//无尽塔扫荡完成
        public static string AdvanceSuccess = "AdvanceSuccess";            //进阶成功  今： 1. 整理理新手引导 2.英雄进阶UI接数据  明：新手引导新机制

        public static string WindowManagerOpen = "WindowManagerOpen";//窗口管理打开某个界面;
        public static string WindowManagerClose = "WindowManagerClose";//窗口管理关闭某个界面;

        public static string SelectServer = "SelectServer";//换区;
        public static string CarnivalAlltargetClose = "CarnivalAlltargetClose";  //嘉年华全目标奖励关闭
        public static string CarnivalGetAward = "CarnivalGetAward";              //嘉年华领完奖励刷新事件
        public static string CarnivalDataUpdate = "CarnivalDataUpdate";          //嘉年华数据更新
        public readonly static string commonAwardQuit = "commonAwardQuit";         //通用奖励界面关闭
        public readonly static string UITeamUpgrade = "UITeamUpgrade";         //团队升级界面关闭

		public readonly static string FirstRechargeSucceed="FirstRechargeSucceed";       //首充成功
        public readonly static string PoppingFirstCharge = "PoppingFirstCharge";         //弹出首充界面
        public readonly static string JudgeGuideStep = "JudgeGuideStep";                 //判断引导是否结束
        public readonly static string MinusLevle = "MinusLevle";                         //Vip等级递减
        public readonly static string AddLevel = "AddLevel";                             //Vip等级递加
        public readonly static string HurtStatus = "HurtStatus";                         //显示受伤状态
        public readonly static string Skillliansuo = "Skillliansuo";                     //技能连锁
        public readonly static string HeroKarmaClose = "HeroKarmaClose";                 //关闭英雄情缘事件

        public readonly static string AndroidBackButton = "AndroidBackButton";
        public readonly static string UpgradeWing = "UpgradeWing";
        public static string RefreshUI { get { return "RefreshUI"; } }     //刷新UI 收到这个事件 刷新一下界面
    }

    public class ShopType
    {
        /// <summary>
        ///普通商店.
        /// </summary>
        public const int NORMAL = 500001;

        /// <summary>
        ///竞技商店.
        /// </summary>
        public const int PVP = 500002;

        /// <summary>
        ///远征商店.幻境商店
        /// </summary>
        public const int CRUSADE = 500003;

        /// <summary>
        ///公会商店.
        /// </summary>
        public const int GUILD = 500004;

        /// <summary>
        ///巅峰商店.
        /// </summary>
        public const int PD_PVP = 500005;

        /// <summary>
        /// 世界boss商店
        /// </summary>
        public const int WorldBoss = 500006;

        /// <summary>
        /// 奸商.游商
        /// </summary>
        public const int Profiteer = 510001;

        /// <summary>
        /// 黑店.黑商
        /// </summary>
        public const int Unscrupulous = 510002;

        /// <summary>
        /// 开宝箱碎片积分商店
        /// </summary>
        public const int Towerchip = 500007;
    }

    public class PrefabPathName
    {
        public static string CityTouch = "Prefabs/Depends/CityTouch";
        public static string SplitCamera = "Prefabs/Depends/SplitCamera";
        public static string mUICommonJumpNumberprefabPth = "Prefabs/UI/CommonUI/UICommonJumpNumber";
        public static string mUILabelJumpNumberprefabPth = "Prefabs/UI/CommonUI/UILabelJumpNumber";
        public static string UINoticepath = "Prefabs/UI/UINotice/UINotice";
    }


    //其他类中常用数字定义
    public class CommonDefine
    {
        /// <summary>
        /// 扫荡卷ID
        /// </summary>
        public const int TICKET_ID = 446300;
		/// <summary>
		/// 經驗藥水
		/// </summary>
		public const int SMALL_EXP_ID = 443200;
		/// <summary>
		/// 經驗藥膏
		/// </summary>
		public const int BIG_EXP_ID = 443300;
        /// <summary>
        /// 普通难度最大扫荡数量
        /// </summary>
		public const int NORMAL_SO_MAX_NUMBER = 10;
		/// <summary>
		/// 体力上限偏移.
		/// </summary>
		public const int OffsetPower = 60;
		/// <summary>
		/// 每次购买的技能点点数
		/// </summary>
		public const int BUY_SKILLPOINT = 10;
        /// <summary>
        /// 钻石买的体力数量
        /// </summary>
        public const int BuyPowerNumber = 120;
        /// <summary>
        /// 最大道具数量
        /// </summary>
        public const int MaxItemNumber = 999;
        /// <summary>
        /// 普通副本服务端初始Id
        /// </summary>
        public const int GeneralServerId = 10000;
        /// <summary>
        /// 精英副本服务端初始Id
        /// </summary>
        public const int EliteServerId = 20000;
        /// <summary>
        /// 团队副本服务端初始Id
        /// </summary>
        public const int TeamServerId = 3070000;
        /// <summary>
        /// 精英副本开放需要的客户端副本id
        /// </summary>
        public const int EliteOpenClientCopyId = 801000;
		/// <summary>
		/// 试炼塔最大层数
		/// </summary>
		public const int MaxTower = 100;

        ///新手引导使用到的几个特殊数据
        public const int GuideID= 4021001;//用于索取到Guide表
        public const int ClientID = 801803;//关卡客户端ID
        public const int EliteIndexID = 20000; //精英地图初ID

		/// <summary>
		///领取体力的3个时间段.
		/// </summary>
		public const int Noon = 599001;
		public const int Noon_Start = 12;
		public const int Noon_end = 18;
		public const int Nightfall = 599002;
		public const int Nightfall_Start = 18;
		public const int Nightfall_end = 21;
		public const int Midnight = 599003;
		public const int Midnight_Start = 21;
		public const int Midnight_end = 24;
        //每日活动Id
        public const int MonthCard = 599004;
        public const int UnionMonthCard = 599005;
        public const int Ticket = 599006;
        public const int CopyKiller = 599007;
        public const int EliteCopyKiller = 599008;
        public const int SkillUpgrade = 599009;
        public const int Call = 599010;
        public const int GoldHand = 599011;
        public const int Arena = 599012;
        public const int CaverOfTime = 599013;
        public const int Enchanting = 599014;
        public const int Ordeal = 599015;
        public const int TBC = 599016;
        public const int Mercenary = 599017;
        public const int Team = 599018;
        public const int Huntsman = 599019;
        public const int HotWell = 599020;
        public const int AltarBuild = 599021;
        public const int TreasureBox = 599022;
        public const int HeroLevelUp = 599023;
        public const int UnionDonate = 599027;//公会捐献

        //开放等级限制
        public const int LimitArena = 10;//竞技场
        public const int LimitCavernsofTime = 14;  //时光
        public const int LimitShop = 8;      //商店
        public const int LimitEnchanting = 20;        //附魔
        public const int LimitOrdea = 25;        //试练
        public const int LimitTBC = 30;       //远征
        public const int LimitUnion = 32;        //公会
        public const int LimitMines = 42;       //矿洞
        public const int Limitxianzhi = 55;           //温泉
        public const int LimitTower = 28;           //无限塔
        public const int LimitGoldHand = 12;             //点金手
        public const int LimitQualifying = 18;  //排位赛
        public const int LimitWorldBoss = 26;             //世界boss
        

		public const string NoImage = "what the fxxk";


//499001	499001	竞技币
//499002	499002	远征币
//499003	499003	公会币
//499004	499004	巅峰币
//499005	499005	诸神币
//499901	499901	钻石
//499902	499902	金币
//499903	499903	行动力
//499904	499904	圣魂
//499905	499905	战队经验

		public const int Pvp_Resources_Id = 499001;
        public const int Crusade_Resources_Id = 499002;
		public const int Guild_Resources_Id = 499003;
		public const int PDPVP_Resources_Id = 499004;
        public const int WorldBoss_Resources_Id = 499005;
        public const int TowerClip_Resources_Id = 499006;

        public const int BP_Id = 499904;

        //附魔道具Id
        public const int MagicItemOne = 444400;
        public const int MagicItemTwo = 444300;
        public const int MagicItemThree = 444200;
        //附魔道具消耗
        public const int MagicItemOneCost = 200;
        public const int MagicItemTwoCost = 60;
        public const int MagicItemThreeCost = 10;
        //随机昵称
        public const int AdjectivenNameStart = 1;
        public const int AdjectiveNameLength = 343;
        public const  int nameStart = 1;
        public const  int nameLength = 965;
        public const  int characterLimitMin = 4;
        public const  int characterLimitMax = 21;

        //远征最大关卡数量
        public const int CrusadeMaxNumber = 15;

		public const int Create_Guild_Price = 500;
        public const int Guild_Max_Slave_Num = 5;
		public const int Guild_Max_Member_Num = 50;
        //规则说明
        public const int TbcRuleTitle = 20004;     //时空幻境
        public const int TbcRule = 20005;
        public const int RTArenaRuleTitle = 20006; //实时竞技场
        public const int RTArenaRule = 20007;
        public const int HLArenaRuleTitle = 20008;   //天梯竞技
        public const int HLArenaRule = 20009;
        public const int TbcMulRuleTitle = 20010;    //时空幻境(多人)
        public const int TbcMulRule = 20011;
        public const int InfiniteRuleTitle = 20012;         //无限挑战
        public const int InfiniteRule = 20013;
        public const int NightmareArenaRuleTitle = 20014;   //噩梦竞技
        public const int NightmareArenaRule = 20015;
        public const int ArenaRuleTitle = 20016;         //竞技场
        public const int ArenaRule = 20017;
//         public const int ArenaPeakednessRuleTitle = 20018;         //巅峰时的竞技场
//         public const int ArenaPeakednessRule = 20019;
        public const int ArenaPeakednessRuleTitle = 20020;         //巅峰竞技场
        public const int ArenaPeakednessRule = 20021;
        public const int BossRuleTitle = 20022;         //世界boss
        public const int BossRule = 20023;
        public const int TeamRuleTitle = 20024;         //团队副本
        public const int TeamRule = 20025;
        public const int ExcavateRuleTitle = 20026;         //神秘地穴
        public const int ExcavateRule = 20027;
        public const int SigninRuleTitle = 20028;         //签到奖励说明
        public const int SigninRule = 20029;
        public const int MercenaryRuleTitle = 20039;         //佣兵规则标题
        public const int MercenaryRule = 20040;             //佣兵规则
        public const int MercenaryDesc = 20041;             //佣兵描述

        public const int ArtifactRuleTitle = 20042;         //神器
        public const int ArtifactRule = 20043;

        public const int OpenBoxRuleTitle = 20044;         //开宝箱
        public const int OpenBoxRule = 20045;

        public const int ConstellationRuleTitle = 20046;         //星图
        public const int ConstellationRule = 20047;

        /// <summary>
        /// 阵形最大英雄数量
        /// </summary>
        public const int MacroMaxHero = 5;

        /// <summary>
        /// 时光,试练大关卡id
        /// </summary>
        public const int RUNE_EXPID = 880100;  //符文秘境--经验//
        public const int RUNE_COINID = 880200; //符文秘境--金币//
        public const int ORDEAL_1ID = 880300;    //英雄秘境--巨神之锤//
        public const int ORDEAL_2ID = 880400;    //英雄秘境--巨神之剑//
        public const int ORDEAL_3ID = 880500;    //英雄秘境--巨神之仗//
        public const int RUNE_JINBI = 880201;//20151021添加符文秘境--金币第一关
        public const int RUNE_JINBIMax = 880206;//金币最大关卡ID
        public const int RUNE_EXP = 880101;//符文秘境-经验第一关ID
        public const int RUNE_EXPMax = 880106;//符文秘境-经验最大关卡ID
        public const int ORDEALID1 = 880301;//英雄试炼-狂战之墓第一关
        public const int ORDEALID1Max = 880306;//英雄试炼-狂战之墓最大关卡ID
        public const int ORDEALID2 = 880401;//英雄试炼-元素禁区第一关
        public const int ORDEALID2Max = 880406;//元素禁区最大关卡id
        public const int ORDEALID3 = 880501;////英雄试炼-女神圣殿第一关
        public const int ORDEALID3Max = 880506;//女神圣殿最大关卡id
        public const int SHIKONGHUANJING = 889813;//时空幻境ID
        /// <summary>
        /// 无限塔宝箱钥匙id
        /// </summary>
        public const int KeyId_Copper = 448300;    //铜钥匙id//
        public const int KeyId_Silver = 448400;    //银钥匙id//
        public const int KeyId_Gold = 448500;    //金钥匙id//
        /// <summary>
        /// 团队副本最大挑战次数
        /// </summary>
        public const int TeamCopyMaxNum = 2;
        /// <summary>
        /// 雇佣兵最低守营时间
        /// </summary>
        public const int MercenaryTime = 30;
        /// <summary>
        /// 远征雇佣英雄指定id 这里不能用英雄的id
        /// </summary>
        public const int TBCHireHeroId = 999999;

		public const int JoinGuildTime = 24 * 60 * 60;

        //世界boss
        public const int WorldBossGoldCost = 2000;// 金币鼓舞消耗
        public const int WorldBossGoldCD = 30;       //金币鼓舞冷却时间
        public const int WorldBossDiamondCost = 5;  //钻石鼓舞消耗
        public const int WorldBossDamageUp = 5;  //伤害提升比例
        public const int WorldBossResurgenceTime = 60;  //复活时间 秒
        public const int WorldBossResurgenceCost = 10;  //复活消耗
        public const int WorldBossVIPResurgenceCost = 100;  //VIP复活消耗

        public const int ClearCDNeedDiamond = 50;       //重置CD消耗钻石数
        //
        public const int LevelMaxStarNum = 3;       //最大星星数
        /// <summary>
        /// 最大等级上限
        /// </summary>
        public static int MaxLevelLimit 
        {
            get
            {
                return ResManager.Instance.miscTable.GetPropInt("PLAYER_TOP_LEVEL");
            }
          
        }
        //购买数量标签
        public const string BuyNum_Vip = "vip";
		public const string BuyNum_Coin = "coin";
		public const string BuyNum_Ap = "ap";
		public const string BuyNum_SkillPoint = "skillPoint";
		public const string BuyNum_Expedition = "expedition";
		public const string BuyNum_Random = "random";
		public const string BuyNum_Pvp = "pvp";
        public const string BuyNum_PvpPeak = "pvpPeak";
		public const string BuyNum_V27 = "v27";
		public const string GuildAp_Coin = "guildApCoin";
		public const string GuildAp_Cash = "guildApCash";
		public const string GuildAp_All = "guildApAll";
        public const string BuyNum_GoldChestKey = "chestKeyG";   //金宝箱钥匙
        public const string BuyNum_SliverChsetKey = "chestKeyS"; //银宝箱钥匙
        public const string BuyNum_copperChestKey = "chestKeyW"; //同宝箱钥匙
        public const string BuyNum_Bp = "bp";
        /// <summary>
        /// 矿洞等级限制
        /// </summary>
        //public const int MineLevelLimit = 35;
        public const int MineItemId = 443200; //道具id

        /// <summary>
        /// 主城按钮移动速度
        /// </summary>
        public const float OpenWinowAniSpeed = 0.3f;
        public const float CloseWinowAniSpeed = 0.2f; 
        /// <summary>
        /// 最大资源显示数
        /// </summary>
        public const int MaxDisplayNumber = 99999999;

        /// <summary>
        /// 资源的道具id,用于道具图标显示用
        /// </summary>
        public const int Item_DiamondId = 499901;
        public const int Item_GoldId = 499902;
        public const int Item_APId = 499903;
        public const int Item_BPId = 499904;
        public const int Item_ExpId = 499905;
        /// <summary>
        /// 最大星星数
        /// </summary>
        public const int MaxStarNum = 5;
        /// <summary>
        /// 英雄最大阶数
        /// </summary>
        //public const int MaxHeroRankNum = 12;
        /// <summary>
        /// 英雄派系偏移值
        /// </summary>
        public const int HeroFactionOffset = 200;
        /// <summary>
        /// 可以加入公会的最小战队等级
        /// </summary>
        public const int GuildMinNeelLv = 16;
        /// <summary>
        /// 可以加入公会的最大战队等级
        /// </summary>
        public static int GuildMaxNeelLv
        {
            get
            {
                return MaxLevelLimit;
            }
        } 
	}


    /// <summary>
    /// 阵形定义
    /// </summary>
    public class MacroDefine
    {
		public const int NOAMAL = 1;			//战役副本//
		public const int RUNE_EXP = 2;			//符文秘境--经验//
		public const int RUNE_COIN = 3;			//符文秘境--金币//
		public const int HERO_1 = 4;			//英雄秘境--巨神之锤//
		public const int HERO_2 = 5;			//英雄秘境--巨神之剑//
		public const int HERO_3 = 6;			//英雄秘境--巨神之仗//
		public const int PVP_DEFEND = 7;		//竞技场--防守//
		public const int PVP_ATTACK = 8;		//竞技场--进攻//
		public const int TOWER = 9;				//试炼塔//
		public const int PDPVP_TROOPS_1 = 10;	//巅峰竞技场队伍1//
		public const int PDPVP_TROOPS_2 = 11;	//巅峰竞技场队伍2//
		public const int PDPVP_TROOPS_3 = 12;	//巅峰竞技场队伍3//
        public const int WORLDBOSS = 13;	//世界boss//
		public const int SQ_SKILL = 14;
        public const int UNIONBOSS = 15;   //工会boss
		public const int NEW_PLAER0 = 99;
		public const int NEW_PLAER = 100;
		public const int CRUSADE = 101;     	//远征阵形//
		public const int LIVE_PVP = 102;		//实时PVP//
		public const int HDPVP_TROOPS = 103;	//天梯竞技场队伍//
        public const int TEAM_TROOPS = 104;		//团队副本队伍//
        public const int MINE = 105;		//矿洞//
    }

	public class ActivityLevelDefine
	{
		public const int RUNE_1 = 1;		//符文秘境--经验//
		public const int RUNE_2 = 2;		//符文秘境--金币//
		public const int HERO_1 = 3;		//英雄秘境--巨神之锤//
		public const int HERO_2 = 4;		//英雄秘境--巨神之剑//
		public const int HERO_3 = 5;		//英雄秘境--巨神之仗//
	}

    public class PropertDefine
    {
       public const int Strength = 1; //力量
       public const int Intellect = 2; //智力
       public const int Agility = 3;  //敏捷
       public const int MaxHP = 4;   //最大生命值
        //物理攻击力
        // 魔法强度
        // 物理护甲
        // 魔法抗性
        // 物理暴击
        // 魔法暴击
        // 生命回复
        // 能量回复
        // 命中
        // 闪避
        // 穿透物理护甲
        // 忽视魔法抗性
        // 吸血等级
        // 能量消耗降低
        // 治疗效果提升
        // 技能等级增加
        // 几率抵抗沉默
        // 格挡
        // 初始能量
        // 力量成长
        // 智力成长
        // 敏捷成长

    }

    public class MaxCaps
    {
        // 最大等待次数 //
        public const int maxWaitTime = 30;
    }



    public class Property
    {
        /// <summary>
        /// //力
        /// </summary>
        public const int Strength = 1;          
        /// <summary>
        ///  //智
        /// </summary>
        public const int Intellect = 2;     
        /// <summary>
        /// //敏
        /// </summary>
        public const int Agility = 3;           
    };
    /// <summary>
    /// 图集路径
    /// </summary>
    public class AtlasPath
    {
        public const string AtlasPVEUI= "Atlas/PVEUI";            //公用图集//
        public const string AtlasCommon = "Atlas/Common";            //公用图集//
        public const string AtlasQuestRes = "Atlas/QuestRes";            //任务图集//
        public const string hitNumName = "Atlas/HitNum";
        public const string combo = "Atlas/ComboRes/ComboRes";
        public const string AtlasCombat = "Atlas/Combat";            //公用图集//
        public const string AtlasBorder = "Atlas/Border";            //公用图集//
        public const string AtlasCopyMap = "Atlas/CopyMap/CopyMapTwo";            //公用图集//
        public const string AtlasSelectTitle = "AtlasExtra/SelectTitle";            //排位赛图标//
    }
    /// <summary>
    /// 贴图路径
    /// </summary>
    public class TexturePath
    {
        public const string HalfPhoto = "HalfPhoto/";            //半身像路径//
    }

