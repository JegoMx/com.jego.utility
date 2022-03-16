using UnityEngine;

namespace Jego.Utility
{
    public static class LayerMaskUtility
    {
        /// <summary>
        /// Check whether a layermask contains a certain layer
        /// </summary>
        /// <param name="layer">The layer of which we want to know whether it's in the mask or not</param>
        /// <param name="layermask">The layermask we're checking against</param>
        /// <returns>True if the layer is in the layermask, false if not</returns>
        public static bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }
    }
}