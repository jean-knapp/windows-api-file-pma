using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMAFileAPI
{
    public class PMAObject : PMANode
    {
        public PMANode common = null;
        public PMANode specific = null;

        public void init()
        {
            common = getNodeByName("DadosComuns");
            specific = getNodeByName("DadosEspecificos");
        }

        public string getType() {
            return common.properties["Tipo"];
        }
    }
}
