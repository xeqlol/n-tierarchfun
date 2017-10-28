using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using System.Collections.Generic;
using System.Linq;

namespace Store.Service
{
    // probably, it would be better to make some kind of IService interface 
    //and than inherit from him all these services (I from SOLID huh)
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Gadget GetGadget(int id);
        void CreateGadget(Gadget gadget);
        void SaveGadget();
    }

    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository gadgetsRepository;
        private readonly ICategoryRepository categoriesRepository;
        private readonly IUnitOfWork unitOfWork;
        
        // for di
        public GadgetService(IGadgetRepository _gadgetsRepository, ICategoryRepository _categoriesRepository, IUnitOfWork _unitOfWork)
        {
            gadgetsRepository = _gadgetsRepository;
            categoriesRepository = _categoriesRepository;
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            return gadgetsRepository.GetAll();
        }

        public IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            // this is a very bad code, DO NOT EVEN MIND TO USE IT IN PRODUCTION
            // seriously, bruh, DONT
            return categoriesRepository.GetCategoryByName(categoryName).Gadgets.Where(x => x.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public Gadget GetGadget(int id)
        {
            return gadgetsRepository.GetById(id);
        }

        public void CreateGadget(Gadget gadget)
        {
            gadgetsRepository.Add(gadget);
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }
    }
}
