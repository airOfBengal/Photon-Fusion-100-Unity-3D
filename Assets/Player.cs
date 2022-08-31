using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private NetworkCharacterControllerPrototype characterControllerPrototype;

    private void Awake()
    {
        characterControllerPrototype = GetComponent<NetworkCharacterControllerPrototype>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            characterControllerPrototype.Move(5 * data.direction * Runner.DeltaTime);
        }
    }
}
