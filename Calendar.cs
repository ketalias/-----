using System;
using System.Collections.Generic;
namespace ШП_ЛБ1
{
	public class Calendar
	{
		public List<Events> EventsList { get; set; }

		public Calendar()
		{
			EventsList = new List<Events>();
		}

		public void AddEvent(Events newEvent)
		{
			EventsList.Add(newEvent);
		}

		public void CopyEvent(Events originalEvent, DateTime newDate)
		{
			Events clonedEvent = originalEvent.Clone(newDate);
			EventsList.Add(clonedEvent);
		}

		public void ShowAllEvents()
		{
			foreach (var ev in EventsList)
			{
				ev.ShowInfo();
			}
		}
		

	}
}

