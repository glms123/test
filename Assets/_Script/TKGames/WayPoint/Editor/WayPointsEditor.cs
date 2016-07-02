using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
namespace TKGames
{
	[CustomEditor(typeof(WayPoints))]
	[ExecuteInEditMode]
	public class WayPointsEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			WayPoints wayPoints = (WayPoints) target;
			if(wayPoints.wps == null)
			{
				wayPoints.wps = new List<WayPoints.WayPoint>();
				EditorUtility.SetDirty(wayPoints);
			}

			EditorGUILayout.LabelField("size:" + wayPoints.wps.Count);
			EditorGUI.indentLevel += 1;
			for(int i = 0; i < wayPoints.wps.Count; i++)
			{
				WayPoints.WayPoint wp = wayPoints.wps[i];
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("id: " + wp.id);
				if(GUILayout.Button("-",GUILayout.Width(25)))
				{
					//EditorUtility.SetDirty(wayPoints);
				}
				EditorGUILayout.EndHorizontal();
				Vector2 newPoint = EditorGUILayout.Vector2Field("point: ",wp.point);
				if(!wp.point.Equals(newPoint))
				{
					wp.point = newPoint;
				}

				EditorGUILayout.LabelField("next: " + wp.next.Count);
				EditorGUI.indentLevel += 1;
				for(int j = 0; j < wp.next.Count; j++)
				{
					GUILayout.BeginHorizontal();
					int newId = EditorGUILayout.IntField(wp.next[j],GUILayout.Width(100));
					if(wp.next[j] != newId && wayPoints.ContainsId(newId) && newId != wp.id)
					{
						wp.next[j] = newId;
						WayPoints.WayPoint next = wayPoints.GetById(newId);
						if(!next.pre.Contains(wp.id))
						{
							next.pre.Add(wp.id);
						}
						EditorUtility.SetDirty(wayPoints);
					}
					if(GUILayout.Button("-",GUILayout.Width(25)))
					{
						if(wp.next[j] != -1)
						{
							WayPoints.WayPoint next = wayPoints.GetById(wp.next[j]);
							next.pre.Remove(wp.id);
						}

						wp.next.RemoveAt(j);
						GUILayout.EndHorizontal();
						EditorUtility.SetDirty(wayPoints);
						break;
					}
					GUILayout.EndHorizontal();
				}

				GUILayout.BeginHorizontal();
				GUILayout.Label("",GUILayout.Width(10));
				if(GUILayout.Button("+",GUILayout.Width(25)))
				{
					wp.next.Add(-1);
					EditorUtility.SetDirty(wayPoints);
				}
				GUILayout.EndHorizontal();
				EditorGUI.indentLevel -= 1;

				EditorGUILayout.LabelField("pre: " + wp.pre.Count);
				EditorGUI.indentLevel += 1;
				for(int j = 0; j < wp.pre.Count; j++)
				{
					EditorGUILayout.LabelField("" + wp.pre[j],GUILayout.Width(100));
				}
				EditorGUI.indentLevel -= 1;
			}
////			for(int i = 0; i < wayPoints.wayPointDic.Count; i++)
////			{
////				int id = i +1;
////				WayPoints.sWayPoint wp = wayPoints.wayPointDic[id];
////				EditorGUILayout.Vector2Field("point:",wp.point);
////			}

			GUILayout.BeginHorizontal();
			if(GUILayout.Button("+",GUILayout.Width(25)))
			{
				WayPoints.WayPoint wp = new WayPoints.WayPoint();
				wp.id = wayPoints.GenerateID();
				wp.point = Vector2.zero;
				wp.next = new List<int>();
				wp.pre = new List<int>();
				wayPoints.wps.Add(wp);
				EditorUtility.SetDirty(wayPoints);
			}

			GUILayout.EndHorizontal();

			EditorGUI.indentLevel -= 1;
		}
	}
}