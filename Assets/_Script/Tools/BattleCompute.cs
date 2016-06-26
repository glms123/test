using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


    /// <summary>
    /// 属性公式与战斗公式计算 //
    /// </summary>
    public static class BattleCompute
    {
        public enum SOType:int
        {
            Unit = 0,
            Monster = 1,
            Boss = 2,
            Player = 3
        }

        public static float DisOfTwoVec(Vector3 lhs, Vector3 rhs)
        {
            float ret = 0;
            Vector3 dis = lhs - rhs;
            dis.y = 0;
            ret = dis.magnitude;
            return ret;

        }

        public static List<int> GenRandomList(int count_ )
        {
            ;
            List<int> ret = new List<int>(count_);
            for (int i = 0; i < count_ ; i++)
            {
                ret.Add(i);
            }
            int tmp = 0;
            for(int i = 0; i < count_ - 1; i++)
            {
                int idx = UnityEngine.Random.Range(i + 1, count_ - 1);
                tmp = ret[idx];
                ret[idx] = ret[i];
                ret[i] = tmp;
            }
            return ret;
        }

        public static string ParsePath2Short(string inStr)
        {
            string ret = null;
            string[] vecO = inStr.Split(new char[] { '/' });
            ret = vecO[vecO.Length - 1];
            return ret;
        }

        public static List<string> ParseString2stringList(string str)
        {
            List<string> ret = new List<string>();
            if (string.IsNullOrEmpty(str) == false)
            {
                string[] vecO = str.Split(new char[] { ';' });
                for (int i = 0; i < vecO.Length; i++)
                {
                    ret.Add(vecO[i]);
                }
                return ret;
            }
            else
                return ret;
        }
        public static List<string> ParseString2stringListEnter(string str)
        {
            List<string> ret = new List<string>();
            if (string.IsNullOrEmpty(str) == false)
            {
                Regex re = new Regex(@"\r\n");
                string[] _value = re.Split(str);
                for (int i = 0; i < _value.Length; i++)
                {
                    ret.Add(_value[i]);
                }
                return ret;
            }
            else
                return ret;
        }
        public static Vector3 ParseString2Vec3(string str)
        {
            Vector3 pos = Vector3.zero;
            if (string.IsNullOrEmpty(str) == false)
            {
                string[] vec = str.Split(new char[] { ',' });
                if (vec.Length >= 3)
                {
                    Vector3 newPos = new Vector3(float.Parse(vec[0]), float.Parse(vec[1]), float.Parse(vec[2]));
                    return newPos;
                }
            }
            return pos;
        }

         public static List<int> ParseString2IntList(string str)
        {
            List<int> intList_ = new List<int>();
            if (string.IsNullOrEmpty(str) == false)
            {
                string[] vecO = str.Split(new char[] { ';' });
                for (int i = 0; i < vecO.Length; i++)
                {
                    int newPos = int.Parse(vecO[i]);
                    intList_.Add(newPos);
                }
            }
            return intList_;
        }

         public static List<float> ParseString2FloatList2(string str)
         {
             List<float> intList_ = new List<float>();
             if (string.IsNullOrEmpty(str) == false)
             {
                 string[] vecO = str.Split(new char[] { ',' });
                 for (int i = 0; i < vecO.Length; i++)
                 {
                     float newPos = float.Parse(vecO[i]);
                     intList_.Add(newPos);
                 }
             }
             return intList_;
         }
         public static List<int> ParseString2IntList2(string str)
         {
             List<int> intList_ = new List<int>();
             if (string.IsNullOrEmpty(str) == false)
             {
                 string[] vecO = str.Split(new char[] { ',' });
                 for (int i = 0; i < vecO.Length; i++)
                 {
                     int newPos = int.Parse(vecO[i]);
                     intList_.Add(newPos);
                 }
             }
             return intList_;
         }


         public static List<float> ParseString2FloatList(string str)
         {
             List<float> floatList_ = new List<float>();
             if (string.IsNullOrEmpty(str) == false)
             {
                string[] vecO = str.Split(new char[] { ';' });
                for (int i = 0; i < vecO.Length; i++)
                {
                    float newPos = float.Parse(vecO[i]);
                    floatList_.Add(newPos);
                }
             }
             return floatList_;
         }

        public static List<Vector3> ParseString2Vec3List(string str)
        {
            List<Vector3> posArray = new List<Vector3>(); 

            if (!string.IsNullOrEmpty(str))
            {
                string[] vecO = str.Split(new char[] { ';' });
                for (int i = 0; i < vecO.Length; i++)
                {
                    string[] vec = vecO[i].Split(new char[] { ',' });
                    if (vec.Length >= 3)
                    {
                        Vector3 newPos = new Vector3(float.Parse(vec[0]), float.Parse(vec[1]), float.Parse(vec[2]));
                        posArray.Add(newPos);
                    }
                }
            }
            return posArray;
        }
        public static int ConvertDamageInfo2AE(int oriId)
        {
            int ret = oriId;
            ret %= 100000;
            ret /= 10;
            return ret;
        }

        //合并字符串
        public static string ConvertNumber(string _num, string _prefix)
        {
            char[] numberChar = _num.ToCharArray();
            string str = "";
            for (int i = 0; i < numberChar.Length; i++)
            {
                str += _prefix;
                str += (numberChar[i]);
            }

            return str.ToString();
        }
       
        /// <summary>
        ///  //得到小数点后2位的百分比,自动 加上%号;
        /// </summary>
        /// <param name="molecule">分子</param>
        /// <param name="denominator">分母</param>
        /// <returns></returns>
        public static string ToPercentage(int molecule, int denominator)
        {
            double percent = System.Convert.ToDouble(molecule) / System.Convert.ToDouble(denominator);
            return percent.ToString("0%");
        }
       

        public static float FinalRandomDamageFix(float raw, float low = 0.9f, float high = 1.1f)
        {
            return raw * UnityEngine.Random.Range(low, high);
        }

        public static float DefRealDodge(float defDodge, float attHit)
        {
            return Mathf.Max(0, defDodge - attHit);
        }

        public static void ChangeShader(GameObject go, string name)
        {
            MeshRenderer[] renderers;
            //transparent effect//
            renderers = go.GetComponentsInChildren<MeshRenderer>();
            Shader shader_ = Shader.Find(name);
            SkinnedMeshRenderer[] skinRenders;
            skinRenders = go.GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < skinRenders.Length; i++)
            {
                skinRenders[i].material.shader = shader_;
				if(skinRenders[i].material.HasProperty("_EmissiveStrengh"))
				{
					skinRenders[i].material.SetFloat("_EmissiveStrengh",0);
				}
            }


            for (int i = 0; i < renderers.Length; i++)
            {
                //if (renderers[i].name != "Shadow")
                //    renderers[i].material.shader = shader_;
            }
        }

      
    }


