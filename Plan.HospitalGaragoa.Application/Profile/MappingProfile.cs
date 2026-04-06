using AutoMapper;
using Plan.HospitalGaragoa.Application.DTOs;
using Plan.HospitalGaragoa.Domain.Entities;

namespace Plan.HospitalGaragoa.Application.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Value));

            CreateMap<Doctor, DoctorDto>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Value))
                .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.PhoneNumber.Value));

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            CreateMap<MedicalRecord, MedicalRecordDto>();
        }
    }
}
