using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain;
using TestProject.Business.Services.Data;
using AutoMapper;

namespace TestProject.Business.Configurations.Impl
{
    public class DataConverter : IDataConverter
    {
        public T Convert<T>(object src)
        {
            return Mapper.Map<T>(src);
        }

        public TDest Convert<TSrc, TDest>(TSrc src)
        {
            return Mapper.Map<TSrc, TDest>(src);
        }
    }
}