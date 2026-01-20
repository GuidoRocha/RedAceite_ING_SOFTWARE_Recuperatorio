using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAceite_ING_SOFTWARE.Domain.Observer
{
    public interface IFormObserver
    {
        void Update(Form form);
    }
}
