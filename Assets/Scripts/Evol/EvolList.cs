using System.Collections.Generic;
using UnityEngine;

namespace Evol
{
    [CreateAssetMenu(fileName = "EvolList", menuName = "ScriptableObject/EvolList")]
    public class EvolList : ScriptableObject
    {
        public List<EvolData> evolList;
    }
}