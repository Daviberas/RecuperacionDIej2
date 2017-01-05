
using RecuperacionDIej2.DAL;
using RecuperacionDIej2.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RecuperacionDIej2.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _listado;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _guardarCommand;
        private DelegateCommand _crearCommand;

        public clsMainPageVM()
        {

            rellenarLista();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            _guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecute);
            _crearCommand = new DelegateCommand(CrearCommand_Executed);
        }

        private async void rellenarLista()
        {
            clsListado lista = new clsListado();
            listado = await lista.getListado();
            NotifyPropertyChanged("listado");
        }

        public clsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                _guardarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }
        public ObservableCollection<clsPersona> listado
        {
            get
            {
                return _listado;
            }
            set
            {
                _listado = value;
                NotifyPropertyChanged("listado");
            }
        }

        public void btnEliminar_Click()
        {
            listado.Remove(personaSeleccionada);
        }

        public DelegateCommand eliminarCommand
        {
            get
            {
                return _eliminarCommand;
            }
        }

        private async void EliminarCommand_Executed()
        {
            ContentDialog dialogo = new ContentDialog();
            dialogo.Title = "Eliminar";
            dialogo.Content = "¿Está seguro de que sea borrar?";
            dialogo.PrimaryButtonText = "Cancelar";
            dialogo.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await dialogo.ShowAsync();

            if (resultado == ContentDialogResult.Secondary)
            {

                ManejadoraPersona mp = new ManejadoraPersona();

                try
                {
                    mp.DeletePersona(personaSeleccionada.Id);
                }
                catch (Exception)
                {

                }
                this.rellenarLista();

                if (Window.Current.Bounds.Width <= 720)
                {
                    ((Frame)Window.Current.Content).GoBack();
                }
            }
        }

        private bool EliminarCommand_CanExecute()
        {
            bool puedeBorrar = false;
            if (personaSeleccionada != null)
                puedeBorrar = true;
            return puedeBorrar;
        }

        public DelegateCommand guardarCommand
        {
            get
            {
                return _guardarCommand;
            }
        }

        private void GuardarCommand_Executed()
        {
            ManejadoraPersona mp = new ManejadoraPersona();
            if (personaSeleccionada.Id == 0)
            {
                mp.SavePersona(personaSeleccionada);
            }
            else
            {
                mp.UpdatePerson(personaSeleccionada);
            }

            personaSeleccionada = null;

            this.rellenarLista();

            if (Window.Current.Bounds.Width <= 720)
            {
                ((Frame)Window.Current.Content).GoBack();
            }
        }

        private bool GuardarCommand_CanExecute()
        {
            bool puedeBorrar = false;
            if (personaSeleccionada != null)
                puedeBorrar = true;
            return puedeBorrar;
        }

        public DelegateCommand crearCommand
        {
            get
            {
                return _crearCommand;
            }
        }

        private void CrearCommand_Executed()
        {
            personaSeleccionada = new clsPersona();
            NotifyPropertyChanged("personaSeleccionada");
        }
    }
}
