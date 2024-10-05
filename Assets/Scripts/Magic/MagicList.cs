using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    [CreateAssetMenu(fileName = "MagicList", menuName = "ScriptableObject/MagicList")]
    public class MagicList : ScriptableObject
    {
        public List<MagicData> magicList;
    }
}