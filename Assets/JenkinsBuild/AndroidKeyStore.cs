using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AndroidKeyStore", menuName = "JenkinsBuild/Creat AndroidKeyStore", order = 1)]
public class AndroidKeyStore : ScriptableObject
{
    public string KeystoreName;
    public string KeystorePassword;
    public string AliasName;
    public string AliasPassword;
    public string[] Levels;
}
