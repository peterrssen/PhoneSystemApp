using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneSystemApp
{
    public class Call : VMBase
    {
        string description;
        PhoneSystem sourcePS;
        PhoneSystem destinationPS;

        public Call(PhoneSystem sourcePS, PhoneSystem destinationPS)
        {
            this.Description = sourcePS.Name + " ruft " + destinationPS.Name + " an";
            this.SourcePS = sourcePS;
            this.DestinationPS = destinationPS;
        }

        public void Start(int callDuration)
        {
            Thread callThread = new Thread(new ParameterizedThreadStart(MakeCall));
            callThread.Start(callDuration);
        }

        public void MakeCall(Object objDuration)
        {
            int callDuration = Convert.ToInt32(objDuration);

            SourcePS.GetConnection(this);
            DestinationPS.GetConnection(this);

            Thread.Sleep(callDuration);

            SourcePS.ReleaseConnection(this);
            DestinationPS.ReleaseConnection(this);
        }

        public void Wait(int callDuration)
        {
            Thread.Sleep(callDuration);
        }

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        public PhoneSystem SourcePS
        {
            get { return sourcePS; }
            set { sourcePS = value; OnPropertyChanged("SourcePS"); }
        }

        public PhoneSystem DestinationPS
        {
            get { return destinationPS; }
            set { destinationPS = value; OnPropertyChanged("DestinationPS"); }
        }
    }
}
