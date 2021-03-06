﻿namespace E01_CSharp
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> holdByTitle = new MultiDictionary<string, Event>(true);

        private OrderedBag<Event> holdByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.holdByTitle.Add(title.ToLower(), newEvent);
            this.holdByDate.Add(newEvent);

            EventMessages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.holdByTitle[title])
            {
                removed++;
                this.holdByDate.Remove(eventToRemove);
            }

            this.holdByTitle.Remove(title);

            EventMessages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.holdByDate.RangeFrom(
                new Event(date, string.Empty, string.Empty), true);

            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                EventMessages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                EventMessages.NoEventsFound();
            }
        }
    }
}
