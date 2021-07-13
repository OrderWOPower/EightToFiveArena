using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;

namespace EightToFiveArena
{
    public class EightToFiveArenaModel : DefaultSettlementAccessModel
    {
        public override bool CanMainHeroAccessLocation(Settlement settlement, string locationId, out bool disableOption, out TextObject disabledText)
        {
            disabledText = TextObject.Empty;
            disableOption = false;
            bool result = true;
            if (locationId == "arena")
            {
                result = CanMainHeroGoToArena(out disableOption, out disabledText);
            }
            return result;
        }
        // If the arena is closed, disable the option for entering the arena and replace the tooltip text.
        private bool CanMainHeroGoToArena(out bool disableOption, out TextObject disabledText)
        {
            if (IsArenaOpen)
            {
                disabledText = TextObject.Empty;
                disableOption = false;
                return true;
            }
            disabledText = new TextObject("Arena is closed before 0800 and after 1700.", null);
            disableOption = true;
            return false;
        }
        // Change the arena's opening hours.
        public bool IsArenaOpen
        {
            get
            {
                int num = CampaignTime.Now.GetHourOfDay;
                return num >= 8 && num < 17;
            }
        }
    }
}
