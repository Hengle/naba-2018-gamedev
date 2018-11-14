using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShipWars/ShipData", fileName = "ShipData")]
public class ShipDataScriptableObject : ScriptableObject {

    public float speed = 0.5f;

    public float maxRoll = 45;

}
