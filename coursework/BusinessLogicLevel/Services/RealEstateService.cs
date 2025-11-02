using Coursework.BusinessLevel.DTOs;
using Coursework.DataLevel.Entities;

namespace Coursework.BusinessLevel.Services;

/// <summary>
/// Service for working with real estates
/// </summary>
public sealed class RealEstateService : BaseEntityService<RealEstate,RealEstateDTO> {
	public RealEstateService() : base(RealEstateDTO.FromRealEstate) { }
	public RealEstateService(Dictionary<Guid,RealEstate> estates) : base(estates,RealEstateDTO.FromRealEstate) { }
	public RealEstateService(Dictionary<Guid,RealEstateDTO> estates) : base(estates,RealEstateDTO.FromRealEstate) { }
}