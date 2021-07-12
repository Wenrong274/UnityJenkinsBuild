using System.IO;
using UnityEditor;
using UnityEngine;

namespace hyhy.Jenkins
{
    public class BuildMenu : MonoBehaviour
    {
        private static string BuildFolder
        {
            get { return Directory.GetParent(Application.dataPath).FullName.Replace('\\', '/') + "/Builds"; }
        }

        [MenuItem("Builds/Android")]
        public static void BuildAndroid()
        {
            Jenkins.BuildAndroid(BuildFolder);
        }

        [MenuItem("Builds/iOS")]
        public static void BuildiOS()
        {
            Jenkins.BuildiOS(BuildFolder);
        }
    }
}