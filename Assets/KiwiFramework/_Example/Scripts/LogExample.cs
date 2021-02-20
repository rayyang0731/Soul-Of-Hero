using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using KiwiFramework.Core;
using UnityEngine;
using UnityEngine.Profiling;
using Debug = UnityEngine.Debug;

namespace KiwiFramework.Example
{
    public class LogExample : MonoBehaviour
    {
        #region Unity Methods

        IEnumerator Start()
        {
            yield return new WaitForSeconds(5);
            // KiwiLog.LogWriteEnabled = false;
            //
            // KiwiLog.Info("Sample Log");
            // KiwiLog.Info("Sample Log With Tracing Context", gameObject);
            //
            // KiwiLog.LogWriteEnabled = true;
            // KiwiLog.OutputStackTraceEnabled = true;
            // KiwiLog.Info("Concat ", "Log");
            // KiwiLog.Info(gameObject, "Concat ", "Log", "With", "Tracing Context");
            //
            // KiwiLog.InfoFormat("Log Format : {0}", "Kiwi");
            // KiwiLog.InfoFormat(gameObject, "Log Format : {0}", "With Tracing Context");
            //
            // "Log Extend".LogInfo();
            // "Log Extend with Tracing Context".LogInfo(gameObject);
            //
            // "Log Extend Format : {0}".LogInfoFormat("Kiwi");
            // "Log Extend Format : {0} with Tracing Context".LogInfoFormat(gameObject, "Kiwi");
            // //-------------------------------------------------------------------------------------------------------
            // KiwiLog.OutputStackTraceEnabled = false;
            //
            // KiwiLog.Warning("Warning Log");
            // KiwiLog.Warning("Warning Log With Tracing Context", gameObject);
            // KiwiLog.Warning("Concat ", "Warning Log");
            // KiwiLog.Warning(gameObject, "Concat ", "Warning Log", "With", "Tracing Context");
            //
            // KiwiLog.WarningFormat("Warning Log Format : {0}", "Kiwi");
            // KiwiLog.WarningFormat(gameObject, "Warning Log Format : {0}", "With Tracing Context");
            //
            // "LogWarning Extend".LogWarning();
            // "LogWarning Extend with Tracing Context".LogWarning(gameObject);
            //
            // "LogWarning Extend Format : {0}".LogWarningFormat("Kiwi");
            // "LogWarning Extend Format : {0} with Tracing Context".LogWarningFormat(gameObject, "Kiwi");
            // //-------------------------------------------------------------------------------------------------------
            // KiwiLog.Error("Error Log");
            // KiwiLog.Error("Error Log With Tracing Context", gameObject);
            // KiwiLog.Error("Concat ", "Error Log");
            // KiwiLog.Error(gameObject, "Concat ", "Error Log", "With", "Tracing Context");
            //
            // KiwiLog.ErrorFormat("Error Log Format : {0}", "Kiwi");
            // KiwiLog.ErrorFormat(gameObject, "Error Log Format : {0}", "With Tracing Context");
            //
            // "LogError Extend".LogError();
            // "LogError Extend with Tracing Context".LogError(gameObject);
            //
            // "LogError Extend Format : {0}".LogErrorFormat("Kiwi");
            // "LogError Extend Format : {0} with Tracing Context".LogErrorFormat(gameObject, "Kiwi");
            // //-------------------------------------------------------------------------------------------------------
            // KiwiLog.Exception(new Exception("This is Exception Log"));
            // KiwiLog.Exception(new Exception("This is Exception Log with Tracing Context"), gameObject);
            // KiwiLog.Exception("This is Exception Log by string");
            // KiwiLog.Exception("This is Exception Log by string with Tracing Context", gameObject);
            //
            // "LogException Extend".LogException();
            // "LogException Extend with Tracing Context".LogException(gameObject);
            // //-------------------------------------------------------------------------------------------------------
            // KiwiLog.LogEnabled = false;
            // KiwiLog.Info("You shouldn't see this message.");
            // //-------------------------------------------------------------------------------------------------------
            KiwiLog.LogEnabled = true;
            KiwiLog.LogWriteEnabled = false;
            KiwiLog.Info("Concat ", "Log");

            Profiler.BeginSample("KiwiLog");
            for (int i = 0; i < 100; i++)
            {
                KiwiLog.Info("Concat ", "Log", i.ToString());
            }

            Profiler.EndSample();

            Profiler.BeginSample("DebugLog");
            for (int i = 0; i < 100; i++)
            {
                Debug.Log("Concat " + "Log" + i.ToString());
            }

            Profiler.EndSample();
        }

        #endregion
    }
}