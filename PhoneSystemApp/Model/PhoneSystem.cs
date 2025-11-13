using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PhoneSystemApp
{
    public class PhoneSystem : VMBase
    {
        private readonly object callsLock = new object();
        private readonly object phoneSystemLock = new object();
        ObservableCollection<Call> calls;
        string statusMessage;
        string name;

        public PhoneSystem(string name)
        {
            this.Calls = new ObservableCollection<Call>();
            this.Name = name;
        }

        public void MakeCall(PhoneSystem destinationPS)
        {
            if (this.Equals(destinationPS))
            {
                this.StatusMessage = "Ruf dich nicht selbst an!";
            }
            else
            {
                this.StatusMessage = "";
                Call call = new Call(this, destinationPS);
                call.Start(5000);
            }
            
        }

        public void GetConnection(Call call)
        {
            this.Calls.Add(call);
            Monitor.Enter(phoneSystemLock);
        }

        public void ReleaseConnection(Call call)
        {
            this.Calls.Remove(call);
            Monitor.Exit(phoneSystemLock);
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public string StatusMessage
        {
            get { return statusMessage; }
            set { statusMessage = value; OnPropertyChanged("StatusMessage"); }
        }


        public ObservableCollection<Call> Calls
        {
            get { return calls; }
            set {
                calls = value;
                BindingOperations.EnableCollectionSynchronization(calls, callsLock);
            }
        }

    }
}
