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
    }

}
