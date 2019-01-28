using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class UnityAPITest : MonoBehaviour
{
    void Start()
    {
        // 46byte
        Profiler.BeginSample("Object.name");
        string s = gameObject.name;
        Profiler.EndSample();

        // 460byte
        Profiler.BeginSample("Object.name 10");
        for (int i = 0; i < 10; i++)
        {
            s = gameObject.name;
        }
        Profiler.EndSample();

		// 40byte
		Profiler.BeginSample("GameObject");
		var go = new GameObject();
		Profiler.EndSample();

		// 1.7KB
		Profiler.BeginSample("AddComponent");
		go.AddComponent<EmptyComponent>();
		Profiler.EndSample();
    }
}
