using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGRAB
{
    class ConsumptionDetail
    {
        private string flatNo;
        private string name;
        private string consumption;


        public ConsumptionDetail()
        {

        }

        public ConsumptionDetail(string flatNo, string name, string consumption)
        {
            this.flatNo = flatNo;
            this.Name = name;
            this.Consumption = consumption;
 
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

        public string Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }
        
    }
}
