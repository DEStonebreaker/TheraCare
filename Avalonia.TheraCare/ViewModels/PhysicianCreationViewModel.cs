using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    [ObservableProperty] private string? _updated;
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
            FirstName = string.Empty;
            LastName = string.Empty;
            LicenseNumber = string.Empty;
            GradDate = string.Empty;
            Specialization = string.Empty;
        }
        else
        {
            var Phys = PhysicianFactory.FromArgsUpdater(Id, FirstName, LastName, LicenseNumber, GradDate,
                Specialization);
            PhysicianProxy.Current.UpdatePhysician(Phys);
        }
    }

    [RelayCommand]
    public void GoBack()
    {
        if (updateMode == true)
        {
            updateMode = false;
            WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianManagementViewModel()));
            FirstName = string.Empty;
            LastName = string.Empty;
            LicenseNumber = string.Empty;
            GradDate = string.Empty;
            Specialization = string.Empty;
            return;
        }

        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianViewModel()));
    }
}