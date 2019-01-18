using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class ArrayTest : MonoBehaviour
{
    void Start()
    {
        // 40 byte
        Profiler.BeginSample("test 2");
        int[] b = new int[0];
        Profiler.EndSample();

        // 44 byte
        Profiler.BeginSample("test");
        int[] a = new int[1];
        Profiler.EndSample();


        // 440 byte
        Profiler.BeginSample("int[]");
        int [] array = new int[10 * 10];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                array[i * 10 + j] = 0;
            }
        }
        Profiler.EndSample();


        // 488 byte
        Profiler.BeginSample("int[,]");
        int[,] array0 = new int[10, 10];

        for (int i = 0; i < array0.GetLength(0); i++)
        {
            for (int j = 0; j < array0.GetLength(1); j++)
            {
                array0[i, j] = 0;
            }
        }
        Profiler.EndSample();

        // 0.9 Kbyte
        Profiler.BeginSample("int[][]");
        int[][] array1 = new int[10][];

        for (int i = 0; i < array1.Length; i++)
        {
            array1[i] = new int[10];
            for (int j = 0; j < array1[i].Length; j++)
            {
                array1[i][j] = 0;
            }
        }
        Profiler.EndSample();

		// 32byte
		// int[] _items
		// int _size
		// int _version
		// (Object _syncRoot)
		Profiler.BeginSample("List<int>");
		List<int> list = new List<int>();
		Profiler.EndSample();

		// 76byte
		Profiler.BeginSample("List<int> 1");
		List<int> list1 = new List<int>(1);
		Profiler.EndSample();

		// 88byte
		// デフォルトのキャパシティが4なので4つまではメモリ確保されない
		Profiler.BeginSample("List<int> 2");
		List<int> list2 = new List<int>();
		list2.Add(1);
		list2.Add(2);
		list2.Add(3);
		list2.Add(4);
		Profiler.EndSample();

		// 88byte
		Profiler.BeginSample("List<int> 3");
		List<int> list3 = new List<int>(4);
		list3.Add(1);
		list3.Add(2);
		list3.Add(3);
		Profiler.EndSample();
    }

}
