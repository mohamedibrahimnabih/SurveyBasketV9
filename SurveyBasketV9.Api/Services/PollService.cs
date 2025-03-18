using SurveyBasketV9.Api.Models;
using SurveyBasketV9.Api.Services.IServices;

namespace SurveyBasketV9.Api.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls = [
            new Poll
            {
                Id = 1,
                Title = "Poll 1",
                Notes = "My first poll"
            },
            new Poll
            {
                Id = 2,
                Title = "Poll 2",
                Notes = "My second poll"
            },
            new Poll
            {
                Id = 3,
                Title = "Poll 3",
                Notes = "My third poll"
            }
        ];

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1;
            _polls.Add(poll);

            return poll;
        }

        public bool Delete(int id)
        {
            var pollInDb = GetById(id);

            if (pollInDb == null)
                return false;

            _polls.Remove(pollInDb);
            return true;
        }

        public bool Edit(int id, Poll poll)
        {
            var pollInDb = GetById(id);

            if (pollInDb == null)
                return false;

            pollInDb.Title = poll.Title;
            pollInDb.Notes = poll.Notes;
            return true;
        }

        public IEnumerable<Poll> GetAll()
        {
            return _polls;
        }

        public Poll? GetById(int id)
        {
            return _polls.SingleOrDefault(e => e.Id == id);
        }
    }
}
