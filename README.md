# UnityJenkinsBuild

此為使用 Jenkins 輸出 Unity 專案注意事項。

## Setting

須注意 Unity 有無安裝輸出目標平台（Android、iOS、WebGL...）。

並且要設定 Jenkins 環境（AndroidSDK、JDK、Unity Editor）。

### Jenkins Android SDK

需要新增 Jenkins 環境變數（Environment variable），來設定 Android SDK 路徑。

Jenkins 頁面路徑為 `Manage Jenkins -> Configure System -> Global properties`。

設定如下圖：

![img_1]

`Name`：`ANDROID_HOME`

`Value`：AndroidSDK 路徑。

### Jenkins JDK

JDK 版本請選 `Java SE 8`，因為 Unity 只支援 Java SE 8。

Jenkins 頁面路徑為 `Manage Jenkins -> Global Tool Configuration -> JDK`。

![img_2]

### Jenkins Unity3d Plugin

需要至 Plugin Manager 安裝 Unity3d Plugin。

Jenkins 頁面路徑為 `Manage Jenkins -> Plugin Manager -> Available`

安裝完成後，需要設定 Unity Editor 路徑。

![img_3]

`Name`：unity version

`Installation directory`：unity installed path

### Jenkins item

基本設置可參考 [使用jenkins建置unity3d專案][ref_1] 介紹。

最主要是設定 `Editor command line arguments`。

頁面路徑：`Configure -> General -> Build`

點選 Add build step -> invoke Unity3d Editor，選擇對應的 Unity 編輯器版本。

在 Editor command line arguments 輸入

``` text
-projectPath "$WORKSPACE/" -executeMethod JenkinsBuild.BuildPlatforms -buildPath "$WORKSPACE\Builds" -android -batchmode -nographics -quit
```

`-buildPath "$WORKSPACE\Builds"` "$WORKSPACE\Builds 輸出放置資料夾路徑。

`-android` 為輸出平台，可改為 -windows32、-windows64、-linux64、-macos、-android、-ios、-webgl。

![img_4]

## [GitHub Repo][github]

## reference

[使用jenkins建置unity3d專案][ref_1] 

[Jenkins for Unity with DigitalOcean][ref_1]

________________________________________________________________________________

[img_1]:./doc/img/1.JPG
[img_2]:./doc/img/2.JPG
[img_3]:./doc/img/3.JPG
[img_4]:./doc/img/4.JPG
[github]:https://github.com/hybrid274/UnityJenkinsBuild
[ref_1]:http://hoseex.blogspot.com/2017/12/jenkinsunity3d.html
[ref_2]:https://github.com/CarlHalstead/Jenkins-for-Unity-with-DigitalOcean/
