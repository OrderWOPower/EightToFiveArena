using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace EightToFiveArena
{
    public class EightToFiveArenaModel : SettlementAccessModel
    {
        private SettlementAccessModel _model;

        public EightToFiveArenaModel(SettlementAccessModel model) => _model = model;

        public bool IsArenaOpen
        {
            get
            {
                int num = CampaignTime.Now.GetHourOfDay;
                return num >= 8 && num < 17;
            }
        }

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

        public override bool CanMainHeroDoSettlementAction(Settlement settlement, SettlementAction settlementAction, out bool disableOption, out TextObject disabledText) => _model.CanMainHeroDoSettlementAction(settlement, settlementAction, out disableOption, out disabledText);

        public override void CanMainHeroEnterDungeon(Settlement settlement, out AccessDetails accessDetails) => _model.CanMainHeroEnterDungeon(settlement, out accessDetails);

        public override void CanMainHeroEnterLordsHall(Settlement settlement, out AccessDetails accessDetails) => _model.CanMainHeroEnterLordsHall(settlement, out accessDetails);

        public override void CanMainHeroEnterSettlement(Settlement settlement, out AccessDetails accessDetails) => _model.CanMainHeroEnterSettlement(settlement, out accessDetails);

        public override bool IsRequestMeetingOptionAvailable(Settlement settlement, out bool disableOption, out TextObject disabledText) => _model.IsRequestMeetingOptionAvailable(settlement, out disableOption, out disabledText);

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
    }
}
