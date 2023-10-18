using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Profiling;
using UnityEngine;

public class MemoryProfiler : MonoBehaviour
{
    ProfilerRecorder TotalUsedMemoryRecorder;

    private string StatsText;
    void OnEnable()
    {
        TotalUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
        
    }
    void OnDisable()
    {
        TotalUsedMemoryRecorder.Dispose();
       // GCReservedMemoryRecorder.Dispose();
       // SystemUsedMemoryRecorder.Dispose();
    }
    void Update()
    {
        var sb = new StringBuilder(500);
        if (TotalUsedMemoryRecorder.Valid)
            sb.AppendLine($"Total Used Memory: {TotalUsedMemoryRecorder.CurrentValue}");
        StatsText = sb.ToString();
    }
    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 30, 250, 70), StatsText);
    }
}
