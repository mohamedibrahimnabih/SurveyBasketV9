using SurveyBasketV9.Api.Models;

namespace SurveyBasketV9.Api.Services.IServices
{
    public interface IPollService
    {
        IEnumerable<Poll> GetAll();
        Poll? GetById(int id);
        Poll Add(Poll poll);
        bool Edit(int id, Poll poll);
        bool Delete(int id);
    }
}
