using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
{
    public class Event
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int DateTime { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }


        public int EventCategoryID { get; set; }
        public virtual EventCategory EventCategory { get; set; }


        public int EventTypeID { get; set; }
        public virtual EventType EventType { get; set; }

    }
}
