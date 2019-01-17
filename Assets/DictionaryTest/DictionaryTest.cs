using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public enum EnumType
{
	A,
	B,
	C,
	D,
	E
}

public class EnumTypeComparer : IEqualityComparer<EnumType>
{
	public bool Equals( EnumType x, EnumType y )
	{
		return x == y;
	}

	public int GetHashCode( EnumType obj )
	{
		return ( int )obj;
	}
}

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

		// 0.6KB
		var comp = new EnumTypeComparer();
		Profiler.BeginSample("dictionary<EnumType, int>");
		Dictionary<EnumType, int> dic2 = new Dictionary<EnumType, int>(comp);
		Profiler.EndSample();

		// 488byte
		Profiler.BeginSample("dictionary<int, int>");
		Dictionary<int, int> dic1 = new Dictionary<int, int>();
		Profiler.EndSample();



	}
}
