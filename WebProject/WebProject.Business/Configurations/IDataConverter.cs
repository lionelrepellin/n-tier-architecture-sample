using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Business.Configurations
{
    public interface IDataConverter
    {
        T Convert<T>(object source);

        TDestination Convert<TSource, TDestination>(TSource source);
    }
}
