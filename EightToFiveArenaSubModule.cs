using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace EightToFiveArena
{
    // This mod changes the arena's opening hours to 8am - 5pm.
    public class EightToFiveArenaSubModule : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarterObject;

                campaignGameStarter.AddModel(new EightToFiveArenaModel((SettlementAccessModel)campaignGameStarter.Models.Last(model => model is SettlementAccessModel)));
            }
        }
    }
}
