using UnityEngine;

namespace Jego.Utility
{
    public static class LayersUtility
    {
        public static bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }
    }
}