using AutoMapper;
using System.Collections.Generic;
using Torqqe.Data.Models;

namespace Torqqe.Functions.Helper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ShopmonkeyApi.Model.Customer, Data.Models.Customer>()
                .ForMember(x => x.Emails, opt => opt.MapFrom<EmailResolver>())
                .ForMember(x => x.Phones, opt => opt.MapFrom<PhoneResolver>());

            CreateMap<ShopmonkeyApi.Model.Vehicle, Data.Models.Vehicle>()
                .ForMember(x => x.VehicleOwners, opt => opt.MapFrom<OwnerResolver>());

            CreateMap<ShopmonkeyApi.Model.Orders, Data.Models.Order>()
                .ForMember(x => x.Tags, opt => opt.MapFrom<TagResolver>())
                //.ForMember(x => x.Customer, opt => opt.Ignore())
                //.ForMember(x => x.Vehicle, opt => opt.Ignore())
                .ForMember(x => x.Jobs, opt => opt.Ignore());

            CreateMap<ShopmonkeyApi.Model.Part, Data.Models.Part>()
                .ForMember(x => x.Job, opt => opt.Ignore());
            CreateMap<ShopmonkeyApi.Model.Subcontract, Data.Models.Subcontract>()
                .ForMember(x => x.Job, opt => opt.Ignore());
            CreateMap<ShopmonkeyApi.Model.Labor, Data.Models.Labor>()
                .ForMember(x => x.Job, opt => opt.Ignore());
            CreateMap<ShopmonkeyApi.Model.Totals, Data.Models.Total>()
                .ForMember(x => x.Job, opt => opt.Ignore());

            CreateMap<ShopmonkeyApi.Model.Jobs, Data.Models.Job>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Totals))
                //.ForMember(x => x.Labors, opt => opt.Ignore())
                //.ForMember(x => x.Parts, opt => opt.Ignore())
                //.ForMember(x => x.Subcontracts, opt => opt.Ignore())
                //.ForMember(x => x.Total, opt => opt.Ignore())
                .ForMember(x => x.Order, opt => opt.Ignore());
        }

        public class EmailResolver : IValueResolver<ShopmonkeyApi.Model.Customer, Data.Models.Customer, ICollection<Email>>
        {
            public ICollection<Email> Resolve(ShopmonkeyApi.Model.Customer source,
                                              Data.Models.Customer destination,
                                              ICollection<Email> destMember,
                                              ResolutionContext context)
            {
                List<Email> emails = new List<Email>();
                if (source.Emails == null)
                    return null;

                foreach (var email in source.Emails)
                {
                    emails.Add(new Email()
                    {
                        CustomerShopmonkeyId = source.ShopmonkeyId,
                        EmailAddress = email
                    });
                }

                return emails;
            }
        }

        public class PhoneResolver : IValueResolver<ShopmonkeyApi.Model.Customer, Data.Models.Customer, ICollection<Phone>>
        {
            public ICollection<Phone> Resolve(ShopmonkeyApi.Model.Customer source,
                                              Data.Models.Customer destination,
                                              ICollection<Phone> destMember,
                                              ResolutionContext context)
            {
                List<Phone> phones = new List<Phone>();

                if (source.Phones == null)
                    return null;

                foreach (var phone in source.Phones)
                {
                    phones.Add(new Phone()
                    {
                        CustomerShopmonkeyId = source.ShopmonkeyId,
                        Phones = phone
                    });
                }

                return phones;
            }
        }

        public class OwnerResolver : IValueResolver<ShopmonkeyApi.Model.Vehicle, Data.Models.Vehicle, ICollection<VehicleOwner>>
        {
            public ICollection<VehicleOwner> Resolve(ShopmonkeyApi.Model.Vehicle source,
                                              Data.Models.Vehicle destination,
                                              ICollection<VehicleOwner> destMember,
                                              ResolutionContext context)
            {
                List<VehicleOwner> vehicleOwner = new List<VehicleOwner>();
                if (source.Owners == null)
                    return null;

                foreach (var owner in source.Owners)
                {
                    vehicleOwner.Add(new VehicleOwner()
                    {
                        CustomerShopmonkeyId = owner.ShopmonkeyId,
                        VehicleShopmonkeyId = source.ShopmonkeyId
                    });
                }

                return vehicleOwner;
            }
        }

        public class TagResolver : IValueResolver<ShopmonkeyApi.Model.Orders, Data.Models.Order, ICollection<Tag>>
        {
            public ICollection<Tag> Resolve(ShopmonkeyApi.Model.Orders source,
                                              Data.Models.Order destination,
                                              ICollection<Tag> destMember,
                                              ResolutionContext context)
            {
                List<Tag> tags = new List<Tag>();
                foreach (var tag in source.Tags)
                {
                    tags.Add(new Tag()
                    {
                        OrderShopmonkeyId = source.ShopmonkeyId,
                        Color = tag.Color,
                        Name = tag.Name
                    });
                }

                return tags;
            }
        }
    }
}
