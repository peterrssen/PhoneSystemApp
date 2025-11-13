using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhoneSystemApp
{
    public class MainWindowVM : VMBase
    {
        
        private ObservableCollection<PhoneSystem> phoneSystemsList;

       
        private PhoneSystem phoneA;
        private PhoneSystem phoneB;
        private PhoneSystem phoneC;
        private PhoneSystem phoneD;
        private PhoneSystem phoneE;

        private ObservableCollection<String> captions;

        public ICommand PSAStartCallClickCommand { get; set; }
        public ICommand PSBStartCallClickCommand { get; set; }
        public ICommand PSCStartCallClickCommand { get; set; }
        public ICommand PSDStartCallClickCommand { get; set; }
        public ICommand PSEStartCallClickCommand { get; set; }

        public MainWindowVM()
        {

            // Phones
            this.phoneA = new PhoneSystem("A");
            this.phoneB = new PhoneSystem("B");
            this.phoneC = new PhoneSystem("C");
            this.phoneD = new PhoneSystem("D");
            this.phoneE = new PhoneSystem("E");

            //
            this.phoneSystemsList = new ObservableCollection<PhoneSystem> { phoneA, phoneB, phoneC, phoneD, phoneE };

            //Captions
            this.Captions = new ObservableCollection<string> { "Akt. Anruf:", "Warteliste:", "Anrufen:", "Status-Message:" };

            // Phone-Call commands
            PSAStartCallClickCommand = new PhoneCallCommand(PhoneA.MakeCall);
            PSBStartCallClickCommand = new PhoneCallCommand(PhoneB.MakeCall);
            PSCStartCallClickCommand = new PhoneCallCommand(PhoneC.MakeCall);
            PSDStartCallClickCommand = new PhoneCallCommand(PhoneD.MakeCall);
            PSEStartCallClickCommand = new PhoneCallCommand(PhoneE.MakeCall);

        }



        #region Properties

        public ObservableCollection<PhoneSystem>PhoneSystemsList
        {
            get { return phoneSystemsList; }
            set { phoneSystemsList = value; OnPropertyChanged("PhoneSystemsList"); }
        }

        public ObservableCollection<String> Captions
        {
            get { return captions; }
            set { captions = value; OnPropertyChanged("Captions"); }
        }

        public PhoneSystem PhoneA
        {
            get { return phoneA; }
            set { phoneA = value; OnPropertyChanged("PhoneA"); }
        }

        public PhoneSystem PhoneB
        {
            get { return phoneB; }
            set { phoneB = value; OnPropertyChanged("PhoneB"); }
        }

        public PhoneSystem PhoneC
        {
            get { return phoneC; }
            set { phoneC = value; OnPropertyChanged("PhoneC"); }
        }

        public PhoneSystem PhoneD
        {
            get { return phoneD; }
            set { phoneD = value; OnPropertyChanged("PhoneD"); }
        }

        public PhoneSystem PhoneE
        {
            get { return phoneE; }
            set { phoneE = value; OnPropertyChanged("PhoneE"); }
        }
        #endregion
    }
}
