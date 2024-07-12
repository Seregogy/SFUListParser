using SFUListParser.Model;
using Windows.UI.Xaml.Controls;

namespace SFUListParser.Components
{
    public sealed partial class CompetitionListDataComponent : UserControl
    {
        public CompetitionListData CompetitionListData;

        public CompetitionListDataComponent()
        {
            InitializeComponent();
        }

        public CompetitionListDataComponent(CompetitionListData competitionListData) : this()
        {
            CompetitionListData = competitionListData;
        }
    }
}
