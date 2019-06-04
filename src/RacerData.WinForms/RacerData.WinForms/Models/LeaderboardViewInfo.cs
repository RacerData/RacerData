namespace RacerData.WinForms.Models
{
    public class LeaderboardViewInfo : ViewInfo
    {
        #region fields
        #endregion

        #region properties

        public LeaderboardViewDefinition LeaderboardViewDefinition { get; set; }

        #endregion

        #region ctor

        public LeaderboardViewInfo()
            : base(ViewType.List)
        {
            LeaderboardViewDefinition = new LeaderboardViewDefinition();
        }

        #endregion

        #region public
        #endregion

        #region protected
        #endregion

        #region private
        #endregion
    }
}
