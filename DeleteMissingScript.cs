/*******************************************
*
*  DeleteNullScript
*
*  Created by Gavin on 2015/11/13 16:51:28.
*  
*******************************************/

using UnityEditor;
using UnityEngine;

public class DeleteMissingScript
{
    [MenuItem("Edit/DeleteMissingScripts &c")]
    public static void DeleteNull()
    {
        foreach (var gameObject in Selection.gameObjects)
        {
            var components = gameObject.GetComponents<Component>();
            var serializedObject = new SerializedObject(gameObject);
            var prop = serializedObject.FindProperty("m_Component");
            var r = 0;
            for (var j = 0; j < components.Length; j++)
            {
                if (components[j] != null) continue;
                prop.DeleteArrayElementAtIndex(j - r);
                r++;
            }
            serializedObject.ApplyModifiedProperties();
        }
        AssetDatabase.Refresh();
    }
}
