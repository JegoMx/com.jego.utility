using UnityEngine;

namespace Jego.Utility
{
    /// <summary>
    /// Contains common operations
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary> Maps a number from range (a,b) to (c,d), clamping the result betwheen (c,d) </summary>
        /// <remarks><c>float a = 8; a.Map(0, 10, 0, 1000); // a = 800f</c>></c><c>return 100f.Map(0, 10, 0, 1); // Returns 1f </c></remarks>
        /// <returns> The mapped number </returns>
        /// <param name="fromSource">The lowest value of the orginal range (inclusive)</param>
        /// <param name="toSource">The highest value of the original range (inclusive)</param>
        /// <param name="fromTarget">The lowest value of the new range (inclusive)</param>
        /// <param name="toTarget">The highest value of the new range (inclusive)</param>
        public static float MapClamped(this float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            return Mathf.Clamp(((value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget), fromTarget, toTarget);
        }

        /// <summary> Maps a number from range (a,b) to (c,d), with the resulting number not being clamped to (c,d) </summary>
        /// <remarks><c> return 100f.Map(0, 10, 0, 1) // Returns 10f </c></remarks>
        /// <returns> The mapped number </returns>
        /// <param name="fromSource">The lowest value of the orginal range (inclusive)</param>
        /// <param name="toSource">The highest value of the original range (inclusive)</param>
        /// <param name="fromTarget">The lowest value of the new range (inclusive)</param>
        /// <param name="toTarget">The highest value of the new range (inclusive)</param>
        public static float MapUnclamped(this float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}