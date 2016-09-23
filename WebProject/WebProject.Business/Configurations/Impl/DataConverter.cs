using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain;
using WebProject.Business.Services.Data;
using AutoMapper;

namespace WebProject.Business.Configurations.Impl
{
    public class DataConverter : IDataConverter
    {
        public T Convert<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public TDestination Convert<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}