using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public static class MyExtensions
    {
        public static GameObject GetParent(this GameObject go)
        {
            return go.transform.parent ? go.transform.parent.gameObject : null;
        }

        public static void AddChild(this GameObject go, GameObject child)
        {
            child.transform.parent = go.transform;
            child.transform.localPosition = Vector3.zero;
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = Vector3.one;
        }

        public static void RemoveChild(this GameObject go, GameObject child)
        {
            if (child.GetParent() == go)
            {
                child.transform.parent = null;
            }
        }
 
        public static GameObject FindChild(this GameObject go, string name)
        {
            Transform t = GetChild(go, name);
            return t == null ? null : t.gameObject;
        }

        public static Transform GetChild(this GameObject go, string name)
        {
            Transform child = go.transform.FindChild(name);
            if (child != null)
            {
                return child;
            }

            return GetChildRecurse(go.transform, name);
        }

        public static Transform GetParaChild(GameObject go, string name)
        {
            Transform child = go.transform.FindChild(name);
            if (child != null)
            {
                return child;
            }

            return GetChildRecurse(go.transform, name);
        }
        /*
        public static Transform GetChild(this Transform transform, string name)
        {
            Transform child = transform.FindChild(name);
            if (child != null)
            {
                return child;
            }

            return GetChildRecurse(transform, name);
        }*/

        public static Transform GetChild(this Component comp, string name)
        {
            Transform child = comp.transform.FindChild(name);
            if (child != null)
            {
                return child;
            }

            return GetChildRecurse(comp.transform, name);
        }
        /*
        public static Transform GetChild(this Character comp, string name)
        {
            Transform child = comp.transform.FindChild(name);
            if (child != null)
            {
                return child;
            }
            return GetChildRecurse(comp.transform, name);
        }
        */
        public static Transform GetChildRecurse(Transform trans, string name)
        {
            if (trans.name == name)
            {
                return trans;
            }

            foreach (Transform child in trans.transform)
            {
                Transform t = GetChildRecurse(child, name);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
        }

        public class UserDataComponent : MonoBehaviour
        {
            public object data;
        }

        public static object GetUserData(this GameObject go)
        {
            UserDataComponent c = go.GetComponent<UserDataComponent>();
            if (c != null)
            {
                return c.data;
            }
            return null;
        }

        public static object GetUserData(this Component c)
        {
            return c.gameObject.GetUserData();
        }

        public static void SetUserData(this GameObject go, object data)
        {
            UserDataComponent c = go.GetComponent<UserDataComponent>();
            if (c == null)
            {
                c = go.AddComponent<UserDataComponent>();
            }

            c.data = data;
        }

        public static void SetUserData(this Component c, object data)
        {
            c.gameObject.SetUserData(data);
        }
    }
