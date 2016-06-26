
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class TableProcessInfo
{
	public string table_class_name;
	public string data_class_name;
    public int sheetIndex = 0;
//    public string sheet_name = "CharacterTable";
	public string ouput_asset_name;
    // excel
	public List<Object> input_excel;
}

public class TableProcessProfile : ScriptableObject {

	public List<TableProcessInfo> tableInfos;
}
