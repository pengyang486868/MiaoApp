using System.Collections.ObjectModel;
using EatWhat.Appears;
using MiaoCore;

namespace EatWhat.AppearModels
{
    public class MyMenuAppearModel : AppearModelBase
    {
        public MiaoCommand AddFoodCmd { get; set; }
        public MiaoCommand DeleteFoodCmd { get; set; }
        public MiaoCommand EscapeKeyCmd { get; set; }

        private ObservableCollection<string> _allRecords;

        public ObservableCollection<string> AllRecords
        {
            get { return _allRecords; }
            set { SetProp(ref _allRecords, value); }
        }

        private string _selectedRecord;

        public string SelectedRecord
        {
            get { return _selectedRecord; }
            set { SetProp(ref _selectedRecord, value); }
        }

        public MyMenuAppearModel()
        {
            AddFoodCmd = new MiaoCommand(OnAddFoodCmd);
            DeleteFoodCmd = new MiaoCommand(OnDeleteFoodCmd, () => SelectedRecord != null);

            EscapeKeyCmd = new MiaoCommand(OnEscapeKeyCmd);

            Environment.ReloadMenu();
            AllRecords = new ObservableCollection<string>(Environment.Menu);
        }

        private void OnAddFoodCmd()
        {
            var afam = new AddFoodAppearModel();
            var afa = new AddFoodAppear
            {
                Title = "添加吃的"
            };
            afa.InitAppear(afam);
            afa.ShowDialog();

            AllRecords.Add(afam.AddString);
            Environment.RefreshMenu(_allRecords);
        }

        private void OnDeleteFoodCmd()
        {
            AllRecords.Remove(SelectedRecord);
            Environment.RefreshMenu(_allRecords);
        }

        private void OnEscapeKeyCmd()
        {
            SelectedRecord = null;
        }
    }
}
