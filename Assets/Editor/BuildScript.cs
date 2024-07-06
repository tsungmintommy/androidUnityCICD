
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

using System;
using System.Linq;
using System.IO;
using System.Collections;

using System.Collections.Generic;

public class BuildScript
{
    

    static string[] GetBuildScenes()
	{
		List<string> names = new List<string>();

		foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes) {
			if (e == null) {
				continue;
			}

			if (e.enabled) {
				names.Add(e.path);
			}
		}

		return names.ToArray();
	}

    public static void Build_Android()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = GetBuildScenes();
        buildPlayerOptions.locationPathName = "Build/Android/Unity-Android.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);


        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.outputPath);
        }
        else
        {
            Debug.LogError("Build failed");
        }
    }

}
