using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IDataCollection
{
    void Add(System.Object data);
    void Load(string txt);
    void OnLoaded();
    void Slim();
}
