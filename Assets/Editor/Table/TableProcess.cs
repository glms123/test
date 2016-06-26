using System;
using System.Collections.Generic;
using System.Reflection;
using Aspose.Cells;
using UnityEditor;
using UnityEngine;
using System.CodeDom.Compiler;
#if UNITY_EDITOR
using System.Xml;
#endif
using System.IO;


public class SortTestObj2Camparer : IComparer<TableProcessInfo>
{
    #region 类字段定义

    #endregion
    #region 构造器

    #endregion
    #region IComparer接口比较方法的实现
    public int Compare(TableProcessInfo obj1, TableProcessInfo obj2)
    {
        int res = 0;
        if ((obj1 == null) && (obj2 == null))
        {
            return 0;
        }
        else if ((obj1 != null) && (obj2 == null))
        {
            return 1;
        }
        else if ((obj1 == null) && (obj2 != null))
        {
            return -1;
        }


        res = string.CompareOrdinal(obj1.table_class_name, obj2.table_class_name);
        if (res > 0)
            res = 1;
        if (res < 0)
            res = -1;
        return res;
    }
    #endregion
}

public class TableProcess : EditorWindow {

    // create asset
    static string assetName = "TableProcess.asset";
    static string assetOutputPath = @"Assets\Resources\TableAssets";
	
    [MenuItem("Helper/Table Process")]
    public static TableProcess NewWindow() {
        TableProcess newWindow = EditorWindow.GetWindow<TableProcess>();		
        return newWindow;
    }

    [MenuItem("Assets/Create/Custom Assets/Table Process")]
    static void CreateAnimationTableAsset() {
        EditorHelper.CreateNewEditorProfile<TableProcessProfile>(assetName);
    }

    
    // 
    TableProcessProfile asset;		
    List<SerializedProperty> tables;
    SerializedObject serialized;
    Assembly asm;

    void OnEnable() {
        name = "Table Process";
        autoRepaintOnSceneChange = false;

        asset = AssetDatabase.LoadAssetAtPath(EditorHelper.profileFolder + "/" + assetName,
                                              typeof(TableProcessProfile)) as TableProcessProfile;
        if (asset == null) {
            Debug.LogError(EditorHelper.profileFolder + "/" + assetName + " no found, please create it first!" );
        }

        tables = new List<SerializedProperty>();
        serialized = new SerializedObject(asset);
        SerializedProperty tableInfos = serialized.FindProperty("tableInfos");
        for (int i = 0; i < tableInfos.arraySize; i++) {
            SerializedProperty obj = tableInfos.GetArrayElementAtIndex(i);
            if (obj != null) {
                tables.Add(obj);
            }
        }
        SortTestObj2Camparer st = new SortTestObj2Camparer();

        asset.tableInfos.Sort(st);
        if (asm == null) {
            asm = Assembly.Load("Assembly-CSharp");
        }


    }


    int currentIndex = -1;
    Vector2 scrololPos = Vector2.zero;
    void OnGUI()
    {
        GUIStyle style = null;

        // if we don't have a profile
        if (asset == null)
        {
            GUILayout.Space(10);

            style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.red;
            GUILayout.Label("Please create a Table Asset!", style);
            return;
        }

        GUILayout.Space(30);

        // ======================================================== 
        // excel table 
        // ========================================================      
        style = new GUIStyle();
        style.fontStyle = FontStyle.Bold;

        if (GUILayout.Button("Exec All", GUILayout.Width(150)) )
        {
         //   tables.Sort();
            /*
            AudioTable test = new AudioTable();
            AudioInfo info = new AudioInfo();
            info.clipPath = new List<string>();
            info.clipPath.Add("test1");
            info.clipPath.Add("test2");
            info.clipPath.Add("test3");
            info.clipPath.Add("test4");
            test.Add(info);
            test.Add(info);
            test.Add(info);
            Utils.Save<AudioTable>(Application.dataPath + "/test.xml", test);
      		*/
            for (int i = 0; i < tables.Count; i++)
            {
                if (asset.tableInfos[i].input_excel != null)
                {
                    ExportTable(asset.tableInfos[i]);
                }          
            }
        }

       // GUILayout.Space(10);
        scrololPos = GUILayout.BeginScrollView(scrololPos);

        for (int i = 0; i < tables.Count; i++)
        {
            style.normal.textColor = (i == currentIndex) ? Color.green : EditorStyles.label.normal.textColor;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(asset.tableInfos[i].table_class_name, style, GUILayout.Width(200));
            EditorGUILayout.LabelField(asset.tableInfos[i].ouput_asset_name, style, GUILayout.Width(200));

            if (GUILayout.Button("Exec", GUILayout.Width(50)) && asset.tableInfos[i].input_excel != null)
            {
                currentIndex = i;
                ExportTable(asset.tableInfos[i]);
            }

            EditorGUILayout.EndHorizontal();

            //	EditorGUILayout.PropertyField(tables[i].FindPropertyRelative("input_excel"));
           
        }

        GUILayout.EndScrollView();
        serialized.ApplyModifiedProperties();
    }


    const int characterTableTitleRow = 1;
    const int characterTableValueTypeRow = 2;
    string[] header = null;
    string[] type = null;
    Dictionary<string, Dictionary<string, string>> excelData;

    void ExportTable(TableProcessInfo _tableInfo)
    {
        excelData = new Dictionary<string, Dictionary<string, string>>();
        header = null;
        type = null;

        foreach (UnityEngine.Object excel in _tableInfo.input_excel)
        {
            string excelName = AssetDatabase.GetAssetPath(excel);
            Worksheet sheet = EditorHelper.LoadExcelSheet(excelName, _tableInfo.sheetIndex);

            int maxColumns = sheet.Cells.MaxDataColumn + 1;
            bool initHead = false;
            if (header == null)
            {  
                Debug.Log("excel name : " + excelName + ", sheet index : " + _tableInfo.sheetIndex);
                Debug.Log("sheet Cells Columns Count : " + maxColumns);
                // parse title 
                header = new string[maxColumns];
                type = new string[maxColumns];
                initHead = true;
            }
            else
            {
                if (header.Length != maxColumns)
                {
                    Debug.LogWarning("diferent column count, excel name : " + excelName + ", sheet index : " + _tableInfo.sheetIndex);
                    Debug.LogWarning("sheet Cells Columns Count : " + maxColumns);
                }

                if (maxColumns < header.Length)
                {
                    maxColumns = Math.Max(maxColumns, header.Length);
                    header = new string[maxColumns];
                    type = new string[maxColumns];
                    initHead = true;
                }

            }

            if (initHead)
            {
                for (int i = 0; i < maxColumns; ++i)
                {
                    header[i] = sheet.Cells.Rows[characterTableTitleRow].GetCellOrNull(i)
                                != null ? sheet.Cells.Rows[1].GetCellOrNull(i).StringValue : null;
                    if (header[i] != null)
                    {
                        header[i].Trim();
                    }

                    if (string.IsNullOrEmpty(header[i]))
                    {
                        Debug.LogError("null column name :" + i);
                    }

                    type[i] = sheet.Cells.Rows[characterTableValueTypeRow].GetCellOrNull(i)
                                != null ? sheet.Cells.Rows[2].GetCellOrNull(i).StringValue : null;
                    if (type[i] != null)
                    {
                        type[i].Trim();
                    }
                    if (string.IsNullOrEmpty(type[i]))
                    {
                        Debug.LogError("null column type :" + i);
                    }
                    if (type[i] == "varchar")
                    {
                        type[i] = "string";
                    }

                    if (type[i] == "bit")
                    {
                        type[i] = "bool";
                    }

                    if (type[i] == "char")
                    {
                        type[i] = "byte";
                    }

                    Debug.Log("column : " + header[i] + ", type : " + type[i]);
                }
            }
            

            // parse table content
            foreach (Row row in sheet.Cells.Rows)
            {
                if (row.Index <= characterTableValueTypeRow)
                    continue;

                string key = row.GetCellOrNull(0) != null ? row.GetCellOrNull(0).StringValue : null;
                if (string.IsNullOrEmpty(key) == false)
                {
                    if (excelData.ContainsKey(key) == false)
                    {
                        excelData.Add(key, new Dictionary<string, string>());
                    }

                    for (int i = 0; i < maxColumns; ++i)
                    {
                        string value = row.GetCellOrNull(i) != null ? row.GetCellOrNull(i).StringValue : null;
                        if (key == "21")
                        {
                            Debug.Log(value);
                        }

                        if (string.IsNullOrEmpty(value) == false)
                        {
                            if (excelData[key].ContainsKey(header[i]))
                            {
                                Debug.LogError("Try to add duplicate key " + header[i] + " for animation " + key);
                                continue;
                            }
                            excelData[key].Add(header[i], value);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(header[i]) == false)
                            {
                                excelData[key].Add(header[i], "");
                            }
                        }
                    }
                }
            }


        }
        /*
        foreach (string s in excelData.Keys)
        {
            if (s != "21")
            {
                continue;
            }

            string str = "";
            Dictionary<string, string> dict = excelData[s];
            foreach (string k in dict.Keys)
            {
                str += ((dict[k]) + " ");
            }

            Debug.Log(str);
        }*/

        // parse excelData
        if (_tableInfo.ouput_asset_name.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
        {
            WriteXML(_tableInfo);
        }
        else if (_tableInfo.ouput_asset_name.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            WriteCSV(_tableInfo);
        }
        else if (_tableInfo.ouput_asset_name.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            WriteJSON(_tableInfo);
        }
        else
        {
            TableParseMethod(_tableInfo);
        }
    }


    void WriteXML(TableProcessInfo _tableInfo)
    {
        XmlDocument doc = new XmlDocument();
        XmlElement root = doc.CreateElement(_tableInfo.table_class_name);
        doc.AppendChild(root);
        XmlElement elements = doc.CreateElement("elements");
        root.AppendChild(elements);

        Dictionary<string, XmlElement> listCol = new Dictionary<string, XmlElement>();

        foreach (Dictionary<string, string> row in excelData.Values)
        {
            int index = 0;
            XmlElement e = doc.CreateElement(_tableInfo.data_class_name);
            elements.AppendChild(e);
            listCol.Clear();
            foreach (string title in row.Keys)
            {
                if (string.IsNullOrEmpty(row[title]))
                {
                    index++;
                    continue;
                }

                int len = title.Length - 1;
                while (title[len] >= '0' && title[len] <= '9')
                    --len;
                string name = title.Substring(0, len + 1);
                string val = row[title];

                if (string.Compare(type[index], "bool", true) == 0)
                {
                    val = val.ToLower();
                }

                if (len == title.Length - 1)
                {
                    XmlElement field = doc.CreateElement(header[index]);
                    XmlText value = doc.CreateTextNode(val);
                    e.AppendChild(field);
                    field.AppendChild(value);
                }
                else
                {
                    XmlElement field;
                    if (!listCol.TryGetValue(name, out field))
                    {
                        field = doc.CreateElement(name);
                        e.AppendChild(field);
                        listCol[name] = field;
                    }

                    XmlElement item = doc.CreateElement(type[index]);
                    XmlText value = doc.CreateTextNode(val);
                    item.AppendChild(value);
                    field.AppendChild(item);
                }

                index++;
            }

        }

        string path = Path.Combine(assetOutputPath, _tableInfo.ouput_asset_name);

        doc.Save(path);
    }

    void WriteCSV(TableProcessInfo _tableInfo)
    {
        string path = Path.Combine(assetOutputPath, _tableInfo.ouput_asset_name);
        using (StreamWriter file = File.CreateText(path))
        {
            foreach (string s in header)
            {
                file.Write(s);
                file.Write(",");
            }
            file.WriteLine();
            foreach (string s in type)
            {
                file.Write(s);
                file.Write(",");
            }
            file.WriteLine();
            foreach (Dictionary<string, string> row in excelData.Values)
            {
                for (int i = 0; i < header.Length; i++)
                {
                    file.Write(row[header[i]]);
                    if (i != header.Length - 1)
                    {   
                        file.Write(",");
                    }
                 
                }
                file.WriteLine();
            }

            file.Flush();
        }

    }

    void WriteJSON(TableProcessInfo _tableInfo)
    {

    }

	void TableParseMethod(TableProcessInfo _tableInfo)
	{
        ScriptableObject table
            = EditorHelper.CreateNewEditorProfile<ScriptableObject>(_tableInfo.ouput_asset_name,
                                                                    assetOutputPath,
                                                                    _tableInfo.table_class_name);
        if (table == null) {
            Debug.LogError("create table " + _tableInfo.table_class_name + " failed! output path : " + assetOutputPath + ", table class name : " + _tableInfo.table_class_name);
            return;
        }

        foreach (Dictionary<string, string> row in excelData.Values) {
            int index = 0;
        
            Type t = asm.GetType(_tableInfo.data_class_name);
            System.Object c = Activator.CreateInstance(t);
            foreach (string title in row.Keys) {

                int len = title.Length - 1;
                while (title[len] >= '0' && title[len] <= '9')
                    --len;
                string name = title.Substring(0, len + 1);

                FieldInfo mInfo = t.GetField(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (mInfo != null)
                {
                    object param = EditorHelper.GetTableValue(type[index], row[title]);
                    if (param != null)
                    {
                        if (name.Length == title.Length)
                        {
                            t.InvokeMember(mInfo.Name, BindingFlags.SetField | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, c, new object[] { param });
                        }
                        else
                        {
                            SetValue(type[index], mInfo, c, param);
                        }
                    }
                }
                else
                {
                    PropertyInfo pInfo = t.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (pInfo != null)
                    {
                        object param = EditorHelper.GetTableValue(type[index], row[title]);
                        if (param != null)
                        {
                            t.InvokeMember(pInfo.Name, BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public, null, c, new object[] { param });
                        }
                    }
                    else
                    {
                        Debug.LogError("cannot find field " + header[index]);
                    }
                }
         
                index++;   
             
            }

            IDataCollection lst = table as IDataCollection;
            if (lst != null) {
                lst.Add(c);
            }
            else {
                Debug.LogError(table.GetType() + " " + "isn't implemente IDataList interface!");
            }
        }     	           
        EditorUtility.SetDirty(table);
        AssetDatabase.SaveAssets();
	}


    static public void SetValue(string _valueType, FieldInfo mInfo, object c, object param)
    {
        if (string.Compare(TableValueType.INT.ToString(), _valueType, true) == 0)
        {
            List<int> temp = mInfo.GetValue(c) as List<int>;
            if (temp == null)
                temp = new List<int>();
            if (param != null)
                temp.Add((int)param);
            mInfo.SetValue(c, temp);
        }
        else if (string.Compare(TableValueType.LONG.ToString(), _valueType, true) == 0)
        {
            List<long> temp = mInfo.GetValue(c) as List<long>;
            if (temp == null)
                temp = new List<long>();
            if (param != null)
                temp.Add((long)param);
            mInfo.SetValue(c, temp);
        }
        else if (string.Compare(TableValueType.FLOAT.ToString(), _valueType, true) == 0)
        {
            List<float> temp = mInfo.GetValue(c) as List<float>;
            if (temp == null)
                temp = new List<float>();
            if (param != null)
                temp.Add((float)param);
            mInfo.SetValue(c, temp);
        }
        else if (string.Compare(TableValueType.BOOL.ToString(), _valueType, true) == 0)
        {
            List<bool> temp = mInfo.GetValue(c) as List<bool>;
            if (temp == null)
                temp = new List<bool>();
            if (param != null)
                temp.Add((bool)param);
            mInfo.SetValue(c, temp);
        }
        else if (string.Compare(TableValueType.STRING.ToString(), _valueType, true) == 0)
        {
            List<string> temp = mInfo.GetValue(c) as List<string>;
            if (temp == null)
                temp = new List<string>();
            if (param != null && !string.IsNullOrEmpty((string)param))
                temp.Add((string)param);
            mInfo.SetValue(c, temp);
        }
        else if (string.Compare(TableValueType.CUSTOM.ToString(), _valueType, true) == 0)
        {
        }
    }
}
