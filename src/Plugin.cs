using BepInEx;
using System.Security.Permissions;

#pragma warning disable CS0618 // Do not remove the following line.
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace ChieftainEternal;

[BepInPlugin("com.dual.chieftain-eternal", "Chieftain Eternal", "1.0.0")]
sealed class Plugin : BaseUnityPlugin
{
    public void OnEnable()
    {
        On.WinState.CycleCompleted += WinState_CycleCompleted;
    }

    private void WinState_CycleCompleted(On.WinState.orig_CycleCompleted orig, WinState self, RainWorldGame game)
    {
        if (self.GetTracker(WinState.EndgameID.Chieftain, addIfMissing: false) is WinState.FloatTracker chieftain && chieftain.progress >= chieftain.max) {
            orig(self, game);

            chieftain.progress = chieftain.max;
        }
        else {
            orig(self, game);
        }
    }
}
