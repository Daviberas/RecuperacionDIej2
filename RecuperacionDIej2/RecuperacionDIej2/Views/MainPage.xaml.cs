using RecuperacionDIej2.Models;
using RecuperacionDIej2.ViewModels;
using RecuperacionDIej2.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RecuperacionDIej2
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = (clsMainPageVM) this.DataContext;
        }

        public clsMainPageVM ViewModel { get; }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            this.txtNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtApellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtFechaNac.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtTelefono.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtDireccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lista.GetBindingExpression(ListView.ItemsSourceProperty).UpdateSource();
        }

        private void lista_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (clsPersona) e.ClickedItem;

            if (AdaptiveStates.CurrentState == pantallaPeque)
            {
                Frame.Navigate(typeof(DetailPage), clickedItem, new DrillInNavigationTransitionInfo());
            }

        }

        private void VisualStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == pantallaPeque;

            clsPersona p = ViewModel.personaSeleccionada;

            if (isNarrow && oldState == pantallaGrande && p != null)
            {
                Frame.Navigate(typeof(DetailPage), p, new SuppressNavigationTransitionInfo());
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(lista, isNarrow);
        }
    }
}
