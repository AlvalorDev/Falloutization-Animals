using LudeonTK;
using RimWorld.Planet;
using Verse;

namespace Falloutization.Animals
{
    public static class DebugActions
    {
        [DebugAction("Falloutization: Animals", "Run Alpha Deathclaw GenStep", 
            actionType = DebugActionType.Action, 
            allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void RunAlphaDeathclawGenStep()
        {
            Map map = Find.CurrentMap;
            if (map == null)
            {
                Messages.Message("No current map available", MessageTypeDefOf.RejectInput);
                return;
            }

            var genStep = new GenStep_AlphaDeathclawSighting();
            var parms = new GenStepParams();
            
            genStep.Generate(map, parms);
            
            Messages.Message("Alpha Deathclaw GenStep executed!", MessageTypeDefOf.PositiveEvent);
        }
    }
}
