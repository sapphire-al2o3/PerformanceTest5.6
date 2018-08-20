using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class DictionaryTest : MonoBehaviour
{
	void Start()
	{
		Dictionary<int, int> dic = new Dictionary<int, int>();

		for (int i = 0; i < 10000; i++)
		{
			dic.Add(i, i);
		}

		int sum = 0;

		// 88byte
		Profiler.BeginSample("values");
		foreach (var e in dic.Values)
		{
			sum += e;
		}
		Profiler.EndSample();

		// 88byte
		Profiler.BeginSample("keys");
		foreach (var k in dic.Keys)
		{
			sum += dic[k];
		}
		Profiler.EndSample();

		// 64byte
		Profiler.BeginSample("pair");
		foreach (var pair in dic)
		{
			sum += pair.Value;
		}
		Profiler.EndSample();
	}
}
