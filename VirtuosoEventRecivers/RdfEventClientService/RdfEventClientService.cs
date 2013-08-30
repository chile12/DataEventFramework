using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using RdfEventClientServiceLib;
using System.Threading;

namespace RdfEventClientService
{
    public partial class RdfEventClientService : ServiceBase
    {
        private Thread funcThread; 
        public RdfEventClientService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

    }
}
