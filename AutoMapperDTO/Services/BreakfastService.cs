using AutoMapperDTO.Models;

namespace AutoMapperDTO.Services
{
    public class BreakfastService : IBreakfastService
    {
        // storing it in memory (Dictionary) for now instead of database
        // Dictionary where we map and id to a breakfast
        private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

        public void CreateBreakfast(Breakfast breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);
        }

        public void DeleteBreakfast(Guid id)
        {
            _breakfasts.Remove(id);
        }

        public Breakfast GetBreakfast(Guid id)
        {
            return _breakfasts[id];
        }

        public void UpsertBreakfast(Breakfast breakfast)
        {
            _breakfasts[breakfast.Id] = breakfast;
        }
    }
}
