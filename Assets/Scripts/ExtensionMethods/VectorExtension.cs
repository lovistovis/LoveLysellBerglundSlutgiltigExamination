using System;
using System.Collections;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

namespace ExtensionMethods
{
    public static class VectorExtension
    {
        /// <summary>
        /// Rotate a vector to face a forward and right direction.
        /// </summary>
        public static Vector3 FaceTowards(this Vector3 vector, Vector3 forward, Vector3 right)
        {
            float y = vector.y;
            vector = (forward * vector.x) + (right * vector.z);
            vector.y = y;
            return vector;
        }

        /// <summary>
        /// Lerp from current value to target in duration seconds.
        /// </summary>
        public static IEnumerator LerpOverTime(this Vector3 vector, Action<Vector3> setter, Vector3 target, float duration, bool ignoreTimeScale = false)
        {
            Vector3 startPosition = vector;
            float start = ignoreTimeScale ? Time.unscaledTime : Time.time;
            float elapsed = 0;
            float progress;
            while (elapsed <= duration)
            {
                yield return null;
                elapsed = (ignoreTimeScale ? Time.unscaledTime : Time.time) - start;
                progress = elapsed / duration;
                if (float.IsNaN(progress) || float.IsInfinity(progress)) { continue; }  // idk
                setter(Vector3.Lerp(startPosition, target, progress));
            }
            setter(target);
        }
    }
}