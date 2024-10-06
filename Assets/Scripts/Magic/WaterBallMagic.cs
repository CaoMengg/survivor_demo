using UnityEngine;

namespace Magic
{
    public class WaterBallMagic : Magic
    {
        protected override void OnStart()
        {
            transform.SetParent(Player.Instance.body);
            transform.position = (Vector2)Player.Instance.body.position + Random.insideUnitCircle.normalized * 3;
            transform.up = Vector2.zero;
        }
    }
}
