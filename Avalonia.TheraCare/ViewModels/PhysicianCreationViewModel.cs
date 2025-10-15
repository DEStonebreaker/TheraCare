using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
    [ObservableProperty] private DateTime? _gradDate;
    [ObservableProperty] private string? _specialization;
    [ObservableProperty] private string? _updated;
    [ObservableProperty] private string? _title = "Physician Creation";
    private bool canSubmit { get; set; } = true;
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
        Title = "Update Physician";
    }


    [RelayCommand]
    public async Task AsyncSubmit()
    {
        await Task.Run(() =>
        {
            if (updateMode == false)
            {
                var Phys = PhysicianFactory.FromArgs(FirstName, LastName, LicenseNumber, GradDate, Specialization);
                PhysicianProxy.Current.CreatePhysician(Phys);
                ClearFields();
            }
            else
            {
                var Phys = PhysicianFactory.FromArgsUpdater(Id, FirstName, LastName, LicenseNumber, GradDate,
                    Specialization);
                PhysicianProxy.Current.UpdatePhysician(Phys);
                Title = "Successfully Updated Physician";
                ClearFields();
                canSubmit = false;
            }
        });
    }

    [RelayCommand]
    public void GoBack()
    {
        if (updateMode == true)
        {
            updateMode = false;
            WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianManagementViewModel()));
            ClearFields();
            return;
        }

        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianViewModel()));
    }

    private void ClearFields()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        LicenseNumber = string.Empty;
        GradDate = null;
        Specialization = string.Empty;
    }
    // [RelayCommand]
    // public void Submit()
    // {
    //     if (updateMode == false)
    //     {
    //         var Phys = PhysicianFactory.FromArgs(FirstName, LastName, LicenseNumber, GradDate, Specialization);
    //         PhysicianProxy.Current.CreatePhysician(Phys);
    //         ClearFields();
    //     }
    //     else
    //     {
    //         var Phys = PhysicianFactory.FromArgsUpdater(Id, FirstName, LastName, LicenseNumber, GradDate,
    //             Specialization);
    //         PhysicianProxy.Current.UpdatePhysician(Phys);
    //         Title = "Successfully Updated Physician";
    //         ClearFields();
    //         canSubmit = false;
    //     }
    // }
}