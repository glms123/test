using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Mono.Xml;

[System.Serializable]
public class DataCollection<K, T> : IDataCollection where T : new()
{
    public List<T> elements = new List<T>();
    protected Dictionary<K, T> table = new Dictionary<K, T>();

    public void Add(System.Object data)
    {
        elements.Add((T)data);
    }

    public T this[int idx]
    {
        get { return elements[idx]; }
    }

    public System.Collections.IEnumerable GetEnumerator()
    {
        return elements;
    }

    public void Slim()
    {
        elements.TrimExcess();
    }

	private string text;

    public void Load(string txt)
    {
		TinyXmlReader reader = new TinyXmlReader(txt);
		while (reader.Read())
		{
			string objectName = typeof(T).Name;
            if (reader.tagName == objectName && reader.isOpeningTag)
			{
				T data = new T();
				while(reader.Read())
				{
                    if (reader.isOpeningTag && reader.tagName != objectName)
					{
                        string fieldName = reader.tagName;
                        System.Reflection.FieldInfo fieldInfo = typeof(T).GetField(fieldName);
						if (fieldInfo != null)
						{
							if (fieldInfo.FieldType == typeof(int))
							{
								fieldInfo.SetValue(data, int.Parse(reader.content));
							}
							else if (fieldInfo.FieldType == typeof(float))
							{
								fieldInfo.SetValue(data, float.Parse(reader.content));
							}
							else if (fieldInfo.FieldType == typeof(string))
							{
								fieldInfo.SetValue(data, reader.content);
							}
							else if (fieldInfo.FieldType == typeof(bool))
							{
								fieldInfo.SetValue(data, bool.Parse(reader.content));
							}
                            else if (fieldInfo.FieldType == typeof(int[]))
                            {
                                List<int> value = new List<int>();
                                while (reader.Read())
                                {
                                    if (reader.tagName == "int" && reader.isOpeningTag)
                                    {
                                        value.Add(int.Parse(reader.content));
                                    }
                                    else if (reader.tagName == fieldName && reader.isOpeningTag == false)
                                    {
                                        fieldInfo.SetValue(data, value.ToArray());
                                        goto ONEOBJ;
                                    }
                                }
                            }
                            else if (fieldInfo.FieldType == typeof(float[]))
                            {
                                List<float> value = new List<float>();
                                while (reader.Read())
                                {
                                    if (reader.tagName == "float" && reader.isOpeningTag)
                                    {
                                        value.Add(float.Parse(reader.content));
                                    }
                                    else if (reader.tagName == fieldName && reader.isOpeningTag == false)
                                    {
                                        fieldInfo.SetValue(data, value.ToArray());
                                        goto ONEOBJ;
                                    }
                                }
                            }
                            else if (fieldInfo.FieldType == typeof(string[]))
                            {
                                List<string> value = new List<string>();
                                while (reader.Read())
                                {
                                    if (reader.tagName == "string" && reader.isOpeningTag)
                                    {
                                        value.Add(reader.content);
                                    }
                                    else if (reader.tagName == fieldName && reader.isOpeningTag == false)
                                    {
                                        fieldInfo.SetValue(data, value.ToArray());
                                        goto ONEOBJ;
                                    }
                                }
                            }
                            else if (fieldInfo.FieldType == typeof(List<string>))
                            {
                                List<string> value = new List<string>();
                                while (reader.Read())
                                {
                                    if (reader.tagName == "string" && reader.isOpeningTag)
                                    {
                                        value.Add(reader.content);
                                    }
                                    else if (reader.tagName == fieldName && reader.isOpeningTag == false)
                                    {
                                        fieldInfo.SetValue(data, value);
                                        goto ONEOBJ;
                                    }
                                }
                            }
                            else if (fieldInfo.FieldType == typeof(List<int>))
                            {
                                List<int> value = new List<int>();
                                while (reader.Read())
                                {
                                    if (reader.tagName == "int" && reader.isOpeningTag)
                                    {
                                        value.Add(int.Parse(reader.content));
                                    }
                                    else if (reader.tagName == fieldName && reader.isOpeningTag == false)
                                    {
                                        fieldInfo.SetValue(data, value);
                                        goto ONEOBJ;
                                    }
                                }
                            }
                            else if (fieldInfo.FieldType == typeof(List<float>))
                            {
                                List<float> value = new List<float>();
                                while (reader.Read())
                                {
                                    if (reader.tagName == "float" && reader.isOpeningTag)
                                    {
                                        value.Add(float.Parse(reader.content));
                                    }
                                    else if (reader.tagName == fieldName && reader.isOpeningTag == false)
                                    {
                                        fieldInfo.SetValue(data, value);
                                        goto ONEOBJ;
                                    }
                                }
                            }
						}
					}

                ONEOBJ:
                    if (reader.tagName == objectName && reader.isOpeningTag == false)
					{
						break;
					}
				}
				Add(data);
			}
		}

		OnLoaded ();
	}
	
	public void OnLoaded()
	{
		try
		{
			System.Reflection.FieldInfo fieldInfo = typeof(T).GetField("id");
			if (fieldInfo != null)
			{
				foreach (T item in elements)
				{
					object fieldData = fieldInfo.GetValue(item);
					table.Add((K)fieldData, (T)item);
				}
			}
		}
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
		}
		
	}
	
	public T Get(K id)
	{
		T item;
		if (table.TryGetValue(id, out item))
		{
			return item;
		}
		else
		{
			return default(T);
		}
	}
	
	public T GetById(K id)
	{
		T item;
		if (table.TryGetValue(id, out item))
		{
			return item;
		}
		else
		{
			//            Debug.LogWarning(typeof(T).ToString() + " item not find, id:" + id);
			return default(T);
		}
	}
	
	public bool HasKey(K id)
	{
		if(id == null)
		{
			return false;
		}
		
		return table.ContainsKey(id);
	}
}