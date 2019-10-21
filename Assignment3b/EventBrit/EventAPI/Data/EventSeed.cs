using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            if(context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreConfiguredEventCategories());
                context.SaveChanges();

            }
            if (context.EventPrices.Any())
            {
                context.EventPrices.AddRange(GetPreConfiguredEventPrices());
                context.SaveChanges();

            }
            if (context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreConfiguredEventTypes());
                context.SaveChanges();

            }
            if (context.Events.Any())
            {
                context.Events.AddRange(GetPreConfiguredEvents());
                context.SaveChanges();

            }
        }

        private static IEnumerable<Event> GetPreConfiguredEvents()
        {
            return new List<Event>
            {
                new Event() {EventCategoryID=1, EventTypeID=1 , Name= "Northwest Yoga conference", Location="Kirkland", DateTime=12092019, Description="Come join us for a mindful session of yoga"},
                new Event() {EventCategoryID=1, EventTypeID=2 , Name= "Fall Food Festival", Location="Seattle", DateTime=12102019, Description="Enjoy some pumpkin spice and more!"},
                new Event() {EventCategoryID=1, EventTypeID=3 , Name= "Small business summit", Location="Redmond", DateTime=29092019, Description="Join us for a business summit with lots of networking opportunities"},
                new Event() {EventCategoryID=2, EventTypeID=1 , Name= "Wine walk", Location="Ballard", DateTime=29102019, Description="Taste varities of wine and take a stroll along the lake" },
                new Event() {EventCategoryID=3, EventTypeID=1 , Name= "TEDx conference", Location="Ballard", DateTime=29102019, Description="learn something new" }

            };
        }

        private static IEnumerable <EventType> GetPreConfiguredEventTypes()
        {
            return new List<EventType>
            {
                new EventType() { Typename="Class"},
                new EventType() { Typename="Festival"},
                new EventType() { Typename="Conference"},
                new EventType() { Typename="Expo"},

            };
        }

        private static IEnumerable<EventPrice> GetPreConfiguredEventPrices()
        {
            return new List<EventPrice>
            {
                new EventPrice(){Price= 100},
                new EventPrice(){Price= 110},
                new EventPrice(){Price= 50},
                new EventPrice(){Price= 70},
            };
            
        }

        private static IEnumerable<EventCategory> GetPreConfiguredEventCategories()
        {
            return new List<EventCategory>
            {
                new EventCategory() {CategoryName="Business"},
                new EventCategory() { CategoryName ="Health"},
                new EventCategory() { CategoryName ="Fashion"},
                new EventCategory() { CategoryName ="Food and Drink"}
            };
            
        }
    }
}
