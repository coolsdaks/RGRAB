using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;

namespace RGRAB
{
    class Invoice_Retrieve
    {
        private string flatNo;
        private string name;
        private string subStatus;
        private string currentDate;
        private string currentUnit;
        private string lastDate;
        private string lastUnit;
        private string subsidyUnit;
        private string nonSubSidyUnit;
        private string span;
        private string unit;
        private string amount;

        public Invoice_Retrieve()
        {

        }

        public Invoice_Retrieve(string flatNo, string name, string subStatus, string currentDate, string currentUnit, string lastDate, string lastUnit, string subsidyUnit, string nonSubSidyUnit, string span, string unit, string amount)
        {
            this.flatNo = flatNo;
            this.Name = name;
            this.subStatus = subStatus;
            this.currentDate = currentDate;
            this.currentUnit = currentUnit;
            this.lastDate = lastDate;
            this.lastUnit = lastUnit;
            this.subsidyUnit = subsidyUnit;
            this.nonSubSidyUnit = nonSubSidyUnit;
            this.span = span;
            this.unit = unit;
            this.amount = amount;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FlatNo
        {
            get { return flatNo; }
            set { flatNo = value; }
        }

        public string SubStatus
        {
            get { return subStatus; }
            set { subStatus = value; }
        }

        public string CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }
        }

        public string CurrentUnit
        {
            get { return currentUnit; }
            set { currentUnit = value; }
        }

        public string LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }

        public string LastUnit
        {
            get { return lastUnit; }
            set { lastUnit = value; }
        }

        public string SubsidyUnit
        {
            get { return subsidyUnit; }
            set { subsidyUnit = value; }
        }

        public string NonSubsidyUnit
        {
            get { return nonSubSidyUnit; }
            set { nonSubSidyUnit = value; }
        }

        public string Span
        {
            get { return span; }
            set { span = value; }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
       
       

        
    }
    
}
