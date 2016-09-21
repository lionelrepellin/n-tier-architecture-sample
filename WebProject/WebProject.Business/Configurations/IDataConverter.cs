using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Business.Configurations
{
    public interface IDataConverter
    {
        T Convert<T>(object src);

        Dest Convert<Src, Dest>(Src src);
    }

}
