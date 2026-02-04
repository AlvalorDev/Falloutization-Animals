using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Falloutization.Animals
{
    public class GenStep_AlphaDeathclawSighting : GenStep
    {
        public override int SeedPart => 982347124;

        public override void Generate(Map map, GenStepParams parms)
        {
            var alphaDeathclawDef = DefDatabase<PawnKindDef>.GetNamedSilentFail("FCP_Animal_Alpha_Deathclaw");
            if (alphaDeathclawDef == null)
            {
                Log.Warning("[Falloutization: Animals] Could not find FCP_Animal_Alpha_Deathclaw pawn kind. Alpha Deathclaw will not spawn.");
                return;
            }

            // Spawn a single Alpha Deathclaw near the map center
            IntVec3 center = map.Center;
            if (CellFinder.TryFindRandomCellNear(center, map, 30, c => c.Standable(map) && !c.Fogged(map), out IntVec3 loc))
            {
                Pawn alphaDeathclaw = PawnGenerator.GeneratePawn(alphaDeathclawDef, null);
                GenSpawn.Spawn(alphaDeathclaw, loc, map);
            }
        }
    }
}
