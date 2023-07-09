using BepInEx;
using HoneyLib;
using Photon.Pun;
using System;
using UnityEngine;


namespace GorillaRoulette
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
            HoneyLib.Events.Events.InfectionTagEvent += InfectionTagEvent;
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
        }
        void InfectionTagEvent(object sender, HoneyLib.Events.InfectionTagEventArgs e)
        {
            if (e.taggedPlayer.IsLocal)
            {
                System.Random random = new System.Random();
                int randomNumber = random.Next(1, 11);
                if (randomNumber == 1)
                {
                    // Event that should happen with 1 in 10 chance
                    Application.Quit();
                }
                else
                {
                    // Event that should happen in the other 9 cases
                    Console.WriteLine("Survived.");
                }
            }
        }
    }
}
