using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMAFileAPI
{
    public class PMAObject : PMANode
    {
        private PMANode common = null;
        private PMANode specific = null;

        public string getType() {
            return getCommon().properties["Tipo"];
        }

        public PMANode getCommon()
        {
            if (common == null)
                common = getNodeByType("DadosComuns");

            if (common == null)
                throw new FormatException();
            return common;
        }

        public PMANode getSpecific()
        {
            if (specific == null)
                specific = getNodeByType("DadosEspecificos");

            if (specific == null)
                throw new FormatException();
            return specific;
        }

    }
}
