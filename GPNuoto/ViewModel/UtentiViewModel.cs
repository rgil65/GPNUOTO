using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UtentiViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the UtenteViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;

        public UtentiViewModel(IDataService ds)
        {
            dataservice = ds;
        }


        

        private RelayCommand<bool?> _login;

        /// <summary>
        /// Gets the Login.
        /// </summary>
        public RelayCommand<bool?> Login
        {
            get
            {
                return _login
                    ?? (_login = new RelayCommand<bool?>(
                    p =>
                    {
                        if (p != null && (bool)p)
                        {
                            dataservice.GetUser(SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>());
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ChangeUserLogin>(new ChangeUserLogin());
                            dataservice.GetStatoCassa(SimpleIoc.Default.GetInstance<CassaViewModel>());
                        }
                        else
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowLoginView>(new ShowLoginView());


                    }));
            }
        }


        private RelayCommand  _logout;

        /// <summary>
        /// Gets the Login.
        /// </summary>
        public RelayCommand Logout
        {
            get
            {
                return _logout
                    ?? (_logout = new RelayCommand(
                        ()=>
                    {

                        SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().Logout();
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().Clear.Execute(null);


                    }));
            }
        }
    }
}