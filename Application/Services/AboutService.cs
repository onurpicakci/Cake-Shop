using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class AboutService : IAboutService
{
    private readonly IAboutRepository _aboutRepository;

    public AboutService(IAboutRepository aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public List<About> GetAllAbouts()
    {
       return _aboutRepository.GetAllAbouts();
    }

    public void UpdateAbout(About about)
    {
        _aboutRepository.UpdateAbout(about);
    }
}