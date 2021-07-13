using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace EightToFiveArena
{
    // This mod changes the arena's opening hours to 8am - 5pm.
    public class EightToFiveArenaSubModule : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignStarter = (CampaignGameStarter)gameStarter;
                campaignStarter.AddModel(new EightToFiveArenaModel());
            }
        }
    }
}
