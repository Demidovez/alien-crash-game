using UnityEngine;

namespace App.Scripts.Helpers
{
    public static class Helper
    {
        public static bool ContainsLayer(int layer, LayerMask layerMask)
        {
            return ((1 << layer) & layerMask) != 0;
        }
    }
}