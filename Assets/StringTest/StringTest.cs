using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class StringTest : MonoBehaviour
{
	void Start()
	{
		string s0 = "aabbccddeeff";
		string s1 = "aa,bb,ccddee";

		// 90byte
		Profiler.BeginSample("split 1");
		string[] array = s0.Split(',');
		Profiler.EndSample();

		// 48byte
		Profiler.BeginSample("no split");
		if (s0.IndexOf(',') >= 0)
		{
			
		}
		else
		{
			array = new string[] { s0 };
		}
		Profiler.EndSample();

		// 196byte
		Profiler.BeginSample("split 3");
		array = s1.Split(',');
		Profiler.EndSample();
	}
}
