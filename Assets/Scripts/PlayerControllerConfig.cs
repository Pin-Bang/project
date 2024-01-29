using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControllerConfig", menuName = "Create PlayerControllerConfig")]
public class PlayerControllerConfig : ScriptableObject
{
    public float defaultSpeed = 10f;
    public float defaultAngularSensitivity = 180f;
}
