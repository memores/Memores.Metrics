using System;
using System.Collections.Generic;
using System.Text;


namespace Memores.NetAPMAgent {
    /// <summary>
    /// Span contains information about a specific code path, executed as part of a transaction
    /// </summary>
    public abstract class Span : IDisposable {
        public string Name { get; set; }
        public string Type { get; set; }
       

        public Span(string name, string type) {
            Name = name;
            Type = type;
        }


        public abstract void End();


        #region IDisposable impl

        public void Dispose() {
            End();
        }

        #endregion
    }
}
