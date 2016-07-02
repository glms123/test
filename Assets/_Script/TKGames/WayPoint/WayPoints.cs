using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TKGames
{
	public class WayPoints : MonoBehaviour
	{
		[System.Serializable]
		public class WayPoint
		{
			public int id;
			public Vector2 point;
			public List<int> pre;
			public List<int> next;
		}

		public List<WayPoint> wps;
		public WayPoint GetById(int id)
		{
			if(wps == null)
				return null;

			for(int i = 0; i < wps.Count;i++)
			{
				if(wps[i].id == id)
					return wps[i];
			}
			return null;
		}

		public bool ContainsId(int id)
		{
			if(wps == null)
				return false;
			for(int i = 0; i < wps.Count;i++)
			{
				if(wps[i].id == id)
					return true;
			}
			return false;
		}

		public int GenerateID()
		{
			int maxID = 0;
			foreach(WayPoint wp in wps)
			{
				if(wp.id > maxID)
					maxID = wp.id;
			}
			return maxID + 1;
		}

		public void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			if(wps == null)
				return;
			foreach(WayPoint wp in wps)
			{
				Gizmos.DrawSphere(wp.point,0.1f);
				for(int i = 0; i < wp.next.Count;i++)
				{
					if(wp.next[i] == -1)
						continue;
					WayPoint nwp = GetById(wp.next[i]);
					Gizmos.DrawLine(wp.point,nwp.point);
				}
			}
		}
	}
}