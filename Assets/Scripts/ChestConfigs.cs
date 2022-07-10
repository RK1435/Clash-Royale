using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestConfigSO" , menuName = "ScriptableObjects/Chests/ChestConfiguration")]
public class ChestConfigs : ScriptableObject
{
    [Serializable]
    public class ChestConfigPair
    {
        public ChestType ChestType;
        public ChestScriptableObject ChestSO;
    }

    public ChestConfigPair[] ChestConfigurationMap;
}
