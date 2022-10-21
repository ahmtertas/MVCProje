using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByStatus();
        void HeadingAdd(Heading heading);
        void HeadingUpdate(Heading heading);
        void HeadingDelete(Heading heading);
        Heading GetById(int id);
    }
}
