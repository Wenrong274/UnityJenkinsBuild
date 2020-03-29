using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AndroidKeyStore))]
public class AndroidKeyStoreEditor : Editor
{
    private float labelWidth = 125f;
    private AndroidKeyStore m_Target;

    private void OnEnable()
    {
        m_Target = (AndroidKeyStore)target;
    }

    public override void OnInspectorGUI()
    {
        SetKeyStorePath();
        SetKeyStorePassword();
        SetAliasName();
        SetAliasPassword();
        SaveAsset();
    }

    private void SaveAsset()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(m_Target);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        GUILayout.EndHorizontal();
    }

    private void SetAliasPassword()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Alias Password:", GUILayout.Width(labelWidth));
        m_Target.AliasPassword = GUILayout.TextField(m_Target.AliasPassword);
        GUILayout.EndHorizontal();
    }

    private void SetAliasName()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Alias Name:", GUILayout.Width(labelWidth));
        m_Target.AliasName = GUILayout.TextField(m_Target.AliasName);
        GUILayout.EndHorizontal();
    }

    private void SetKeyStorePassword()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Keystore Password:", GUILayout.Width(labelWidth));
        m_Target.KeystorePassword = GUILayout.TextField(m_Target.KeystorePassword);
        GUILayout.EndHorizontal();
    }

    private void SetKeyStorePath()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Select keystore", GUILayout.Width(labelWidth)))
            m_Target.KeystoreName = EditorUtility.OpenFilePanel("Select Keystore", Application.streamingAssetsPath, "keystore");

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Path:", GUILayout.Width(labelWidth));
        GUILayout.Label(m_Target.KeystoreName);
        GUILayout.EndHorizontal();
    }
}
