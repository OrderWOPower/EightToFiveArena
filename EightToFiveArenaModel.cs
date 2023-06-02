using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace EightToFiveArena
{
    public class EightToFiveArenaModel : SettlementAccessModel
    {
        private readonly SettlementAccessModel _model;

        public EightToFiveArenaModel(SettlementAccessModel model) => _model = model;

        public override bool CanMainHeroAccessLocation(Settlement settlement, string locationId, out bool disableOption, out TextObject disabledText)
        {
            if (locationId == "arena")
            {
                int num = MathF.Floor(CampaignTime.Now.CurrentHourInDay);

                if (num >= 8 && num < 17)
                {
                    disabledText = TextObject.Empty;
                    disableOption = false;

                    return true;
                }

                // Replace the tooltip text.
                disabledText = new TextObject("Arena is closed before 0800 and after 1700.", null);
                // Disable the option for entering the arena.
                disableOption = true;

                return false;
            }

            return _model.CanMainHeroAccessLocation(settlement, locationId, out disableOption, out disabledText);
        }

        public override bool CanMainHeroDoSettlementAction(Settlement settlement, SettlementAction settlementAction, out bool disableOption, out TextObject disabledText) => _model.CanMainHeroDoSettlementAction(settlement, settlementAction, out disableOption, out disabledText);

        public override void CanMainHeroEnterDungeon(Settlement settlement, out AccessDetails accessDetails) => _model.CanMainHeroEnterDungeon(settlement, out accessDetails);

        public override void CanMainHeroEnterLordsHall(Settlement settlement, out AccessDetails accessDetails) => _model.CanMainHeroEnterLordsHall(settlement, out accessDetails);

        public override void CanMainHeroEnterSettlement(Settlement settlement, out AccessDetails accessDetails) => _model.CanMainHeroEnterSettlement(settlement, out accessDetails);

        public override bool IsRequestMeetingOptionAvailable(Settlement settlement, out bool disableOption, out TextObject disabledText) => _model.IsRequestMeetingOptionAvailable(settlement, out disableOption, out disabledText);
    }
}
