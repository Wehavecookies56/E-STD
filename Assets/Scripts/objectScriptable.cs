using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {
    OPEN, PICKUP
}

[CreateAssetMenu(fileName = "Data", menuName = "CustomData/InteractiveObject", order = 1)]
public class objectScriptable : ScriptableObject {
    [SerializeField]
    private string objectName;
    [SerializeField]
    private Type type;

    public string ObjectName {
        get {
            return objectName;
        }
    }

    public Type OjbectType {
        get {
            return type;
        }
    }

}
