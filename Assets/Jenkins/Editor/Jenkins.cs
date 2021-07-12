using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace hyhy.Jenkins
{
    public class Jenkins
    {
        private static readonly string GameName = PlayerSettings.productName;
        private static readonly string GameVersion = Application.version.Replace(".", "");
        private static string[] EnabledScenePaths => EditorBuildSettings.scenes
            .Where((scene) => scene.enabled == true)
            .Select((scene) => scene.path)
            .ToArray();

        public static void BuildPlatforms()
        {
            List<string> arguments = Environment.GetCommandLineArgs().ToList();

            string buildLocation = string.Empty;

            if (arguments.Contains("-buildPath"))
                buildLocation = arguments[arguments.IndexOf("-buildPath") + 1];
            else
                throw new ArgumentException("Project must be launched with a -buildPath argument! Where would we build the project too otherwise?");

            if (arguments.Contains("-windows32"))
                BuildWindows32(buildLocation);

            if (arguments.Contains("-windows64"))
                BuildWindows64(buildLocation);

            if (arguments.Contains("-linux64"))
                BuildLinux64(buildLocation);

            if (arguments.Contains("-macos"))
                BuildMacOS(buildLocation);

            if (arguments.Contains("-android"))
                BuildAndroid(buildLocation);

            if (arguments.Contains("-ios"))
                BuildiOS(buildLocation);

            if (arguments.Contains("-webgl"))
                BuildWebGL(buildLocation);
        }

        public static void BuildWindows32(string location)
        {
            string path = Path.Combine(location, "Windows32", $"{GameName}.exe");

            BuildPlayerOptions playerOptions = new BuildPlayerOptions()
            {
                scenes = EnabledScenePaths,
                locationPathName = Path.Combine(location, "Windows32", $"{GameName}.exe"),
                target = BuildTarget.StandaloneWindows
            };

            Build(path, playerOptions);
        }

        public static void BuildWindows64(string location)
        {
            string path = Path.Combine(location, "Windows64", $"{GameName}.exe");

            BuildPlayerOptions playerOptions = new BuildPlayerOptions()
            {
                scenes = EnabledScenePaths,
                locationPathName = Path.Combine(location, "Windows64", $"{GameName}.exe"),
                target = BuildTarget.StandaloneWindows64
            };

            Build(path, playerOptions);
        }

        public static void BuildLinux64(string location)
        {
            string path = Path.Combine(location, "Linux64", $"{GameName}.x86_64");

            BuildPlayerOptions playerOptions = new BuildPlayerOptions()
            {
                scenes = EnabledScenePaths,
                locationPathName = Path.Combine(location, "Linux64", $"{GameName}.x86_64"),
                target = BuildTarget.StandaloneLinux64
            };

            Build(path, playerOptions);
        }

        public static void BuildMacOS(string location)
        {
            string path = Path.Combine(location, "MacOS", $"{GameName}");

            BuildPlayerOptions playerOptions = new BuildPlayerOptions()
            {
                scenes = EnabledScenePaths,
                locationPathName = Path.Combine(location, "MacOS", $"{GameName}"),
                target = BuildTarget.StandaloneOSX
            };

            Build(path, playerOptions);
        }

        public static void BuildAndroid(string location)
        {
            string path = Path.Combine(location, "Android", $"{GameName}_Ver{GameVersion}.apk");

            BuildPlayerOptions playerOptions = new BuildPlayerOptions()
            {
                scenes = EnabledScenePaths,
                locationPathName = path,
                target = BuildTarget.Android
            };
            var keystore = Resources.Load<KeyStore>("AndroidKeyStore");
            if (keystore != null)
            {
                PlayerSettings.Android.keystoreName = keystore.KeystoreName;
                PlayerSettings.Android.keystorePass = keystore.KeystorePassword;
                PlayerSettings.Android.keyaliasName = keystore.AliasName;
                PlayerSettings.Android.keyaliasPass = keystore.AliasPassword;
            }

            Build(path, playerOptions);
        }

        public static void BuildiOS(string location)
        {
            string path = Path.Combine(location, "iOS", $"{GameName}_Ver{GameVersion}");

            BuildPlayerOptions playerOptions = new BuildPlayerOptions()
            {
                scenes = EnabledScenePaths,
                locationPathName = Path.Combine(location, "iOS", $"{GameName}_Ver{GameVersion}"),
                target = BuildTarget.iOS
            };

            Build(path, playerOptions);
        }

        public static void BuildWebGL(string location)
        {
            string path = Path.Combine(location, "WebGL", $"{GameName}");
            BuildPlayerOptions playerOptions = new BuildPlayerOptions()
            {
                scenes = EnabledScenePaths,
                locationPathName = path,
                target = BuildTarget.WebGL
            };

            Build(path, playerOptions);
        }

        private static void Build(string path, BuildPlayerOptions playerOptions)
        {
            UnityEditor.Build.Reporting.BuildReport Report = BuildPipeline.BuildPlayer(playerOptions);
            EditorUtility.RevealInFinder(path);
            Debug.Log(string.Format("{0} Build completed with a result of '{1}' ", Application.platform, Report.summary.result.ToString()));
        }
    }
}