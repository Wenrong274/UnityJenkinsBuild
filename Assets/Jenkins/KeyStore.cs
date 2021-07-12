using UnityEngine;

namespace hyhy.Jenkins
{
    [CreateAssetMenu(fileName = "AndroidKeyStore", menuName = "JenkinsBuild/Creat AndroidKeyStore", order = 1)]
    public class KeyStore : ScriptableObject
    {
        public string KeystoreName;
        public string KeystorePassword;
        public string AliasName;
        public string AliasPassword;
    }
}