using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextControlDemo.Entities;

namespace TextControlDemo.Repositories
{
    public interface ITxDocumentRepository
    {
        bool Create(TXDocument document);
        bool Update(TXDocument document);
        TXDocument Get(int id);
    }
}
