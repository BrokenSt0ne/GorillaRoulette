using BepInEx;
using HoneyLib;
using Photon.Pun;
using System;
using UnityEngine;


namespace GorillaRoulette
{
    [BepInDependency("com.buzzbzzzbzzbzzzthe18th.gorillatag.HoneyLib", "1.0.9")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void OnEnable()
        {
            HoneyLib.Events.Events.InfectionTagEvent += InfectionTagEvent;
        }

        void InfectionTagEvent(object sender, HoneyLib.Events.InfectionTagEventArgs e)
        {
            if (e.taggedPlayer.IsLocal)
            {
                System.Random random = new System.Random();
                int randomNumber = random.Next(1, 7);
                if (randomNumber == 1)
                {
                    // Event that *should* happen with 1 in 6 chance
                    Application.Quit();
                }
            }
        }
    }
}
