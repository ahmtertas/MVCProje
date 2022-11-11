using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByContent(string content);
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingId(int id);
        void ContentAdd(Content content);
        void ContentUpdate(Content content);
        void ContentDelete(Content content);
        Content GetById(int id);
    }
}
