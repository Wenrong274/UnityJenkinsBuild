using System.IO;
using UnityEditor;
using UnityEngine;

namespace JenkinsBuild
{
    public class ToolBuild : MonoBehaviour
    {
        private static string SavePath
        {
            get { return Directory.GetParent(Application.dataPath).FullName.Replace('\\', '/') + "/Builds"; }
        }

        [MenuItem("Builds/Android")]
        public static void BuildAndroidTaiwan()
        {
            JenkinsBuild.BuildAndroid(SavePath);
        }

        [MenuItem("Builds/iOS")]
        public static void TestBuildiOS()
        {
            JenkinsBuild.BuildiOS(SavePath);
        }
    }
}