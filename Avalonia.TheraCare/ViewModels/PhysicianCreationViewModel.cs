using System;
using Avalonia.Platform;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels;

public partial class PhysicianCreationViewModel : ViewModelBase
{
    [ObservableProperty] private Guid _id;
    [ObservableProperty] private string? _firstName;
    [ObservableProperty] private string? _lastName;
    [ObservableProperty] private string? _licenseNumber;
    [ObservableProperty] private string? _gradDate;
    [ObservableProperty] private string? _specialization;
    private bool updateMode = false;

    public PhysicianCreationViewModel()
    {
    }

    public PhysicianCreationViewModel(Physician physician)
    {
        Id = physician.Id;
        FirstName = physician.FirstName;
        LastName = physician.LastName;
        LicenseNumber = physician.LicenseNumber;
        GradDate = physician.GraduationDate;
        Specialization = physician.Specializations;
        updateMode = true;
    }

    [RelayCommand]
    public void Submit()
    {
        if (updateMode == false)
        {
            var Phys = PhysicianFactory.FromArgs(FirstName, LastName, LicenseNumber, GradDate, Specialization);
            PhysicianProxy.Current.CreatePhysician(Phys);
        }
        else
        {
            var Phys = PhysicianFactory.FromArgsUpdater(Id, FirstName, LastName, LicenseNumber, GradDate,
                Specialization);
            PhysicianProxy.Current.UpdatePhysician(Phys);
        }

        FirstName = string.Empty;
        LastName = string.Empty;
        LicenseNumber = string.Empty;
        GradDate = string.Empty;
        Specialization = string.Empty;
        updateMode = false;
    }

    [RelayCommand]
    public void GoBack()
    {
        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianViewModel()));
    }
}