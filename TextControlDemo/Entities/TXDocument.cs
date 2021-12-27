using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextControlDemo.Entities
{
    public class TXDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UniqueId { get; set; }
    }
}
