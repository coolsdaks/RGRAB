using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGRAB
{
    class DefaulterDetail
    {
        private string flatNo;
        private string name;
        private string amount;


        public DefaulterDetail()
        {

        }

        public DefaulterDetail(string flatNo, string name, string consumption)
        {
            this.flatNo = flatNo;
            this.Name = name;
            this.Amount = consumption;
 
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

        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        
    }
}
