using UnityEngine;

namespace Services
{
    public class LayerService
    {
        public bool CheckLayersEquality(LayerMask objectLayer, LayerMask requiredLayer) => ((1 << objectLayer) & requiredLayer) > 0;
    }
}