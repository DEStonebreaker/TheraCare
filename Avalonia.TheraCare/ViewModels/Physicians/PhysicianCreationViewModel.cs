using System;
using System.Threading.Tasks;
using Avalonia.TheraCare.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Library.TheraCare.Models;
using Library.TheraCare.Services.Factories;
using Library.TheraCare.Services.Proxies;

namespace Avalonia.TheraCare.ViewModels.Physicians;

public partial class PhysicianCreationViewModel : ViewModelBase
{
    // Input Capture Properties
    [ObservableProperty] private Guid _id;
    [ObservableProperty] private string? _firstName;
    [ObservableProperty] private string? _lastName;
    [ObservableProperty] private string? _licenseNumber;
    [ObservableProperty] private DateTime? _gradDate;
    [ObservableProperty] private string? _specialization;
    [ObservableProperty] private string? _updated;
    [ObservableProperty] private string? _title = "Physician Creation";
    private bool CanSubmit { get; set; } = true;
    private bool _updateMode;

    // CTORS. Default and Physician Edits.
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
        _updateMode = true;
        Title = "Update Physician";
    }


    [RelayCommand]
    public async Task AsyncSubmit()
    {
        await Task.Run(() =>
        {
            if (_updateMode == false)
            {
                var phys = PhysicianFactory.FromArgs(FirstName, LastName, LicenseNumber, GradDate, Specialization);
                PhysicianProxy.Current.CreatePhysician(phys);
                ClearFields();
            }
            else
            {
                var phys = PhysicianFactory.FromArgsUpdater(Id, FirstName, LastName, LicenseNumber, GradDate,
                    Specialization);
                PhysicianProxy.Current.UpdatePhysician(phys);
                Title = "Successfully Updated Physician";
                ClearFields();
                CanSubmit = false;
            }
        });
    }

    [RelayCommand]
    public void GoBack()
    {
        if (_updateMode)
        {
            _updateMode = false;
            WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianManagementViewModel()));
            ClearFields();
            return;
        }

        WeakReferenceMessenger.Default.Send(new ViewChangeMessage(new PhysicianViewModel()));
    }

    // Helper Functions

    private void ClearFields()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        LicenseNumber = string.Empty;
        GradDate = null;
        Specialization = string.Empty;
    }
}