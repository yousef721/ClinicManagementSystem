﻿using CMS.Models.CuraHub.ClinicSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Access.Layer.Data.Configrations.CuraHubConfigration.ClinicConfigration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {




            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(true);
            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);
            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);
            builder.Property(e => e.Region)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);
            builder.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);


            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(true);
            builder.Property(e => e.BloodType)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(true);

            builder.Property(e => e.ProfilePicture)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(e => e.PersonalNationalIDNumber)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(true);

            builder.Property(e => e.PersonalNationalIDCard)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);
            builder.Property(e => e.MaritalStatus)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);


            

            builder.Property(e => e.MedicalDegree)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);



            builder.Property(e => e.MedicalLicense)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(e => e.MedicalRegistration)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(e => e.MedicalIdentificationCard)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);



            builder.HasMany(e => e.Schedules)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            builder.HasMany(e => e.ClinicReceptionists)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            builder.HasMany(e => e.RequestClinicReceptionists)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            builder.HasMany(e => e.qualifications)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            builder.HasOne(e => e.Specialization)
                .WithMany(e => e.Doctors)
                .HasForeignKey(e => e.SpecializationId);

            builder.HasMany(e => e.QuestionAndAnswers)
               .WithOne(e => e.Doctor)
               .HasForeignKey(e => e.DoctorId);

            builder.ToTable(name: "Doctors", schema: "Clinic");





        }
    }
}
