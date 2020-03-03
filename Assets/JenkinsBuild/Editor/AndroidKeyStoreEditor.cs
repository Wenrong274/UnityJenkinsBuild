using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AndroidKeyStore))]
public class AndroidKeyStoreEditor : Editor
{
    float labelWidth = 125f;

    AndroidKeyStore m_Target;

    public override void OnInspectorGUI()
    {
        m_Target = (AndroidKeyStore)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Select keystore", GUILayout.Width(150f)))
        {
            string path = EditorUtility.OpenFilePanel("level", Application.streamingAssetsPath, "keystore");
            if (path.Length != 0)
                m_Target.KeystoreName = path;
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Path:", GUILayout.Width(labelWidth));
        GUILayout.Label(m_Target.KeystoreName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Keystore Password:", GUILayout.Width(labelWidth));
        m_Target.KeystorePassword = GUILayout.TextField(m_Target.KeystorePassword);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Alias Name:", GUILayout.Width(labelWidth));
        m_Target.AliasName = GUILayout.TextField(m_Target.AliasName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Alias Password:", GUILayout.Width(labelWidth));
        m_Target.AliasPassword = GUILayout.TextField(m_Target.AliasPassword);
        GUILayout.EndHorizontal();

    }
}
