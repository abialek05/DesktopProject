using GalaSoft.MvvmLight.Messaging;
using Project.Helpers;
using Project.ViewModels.Abstract;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class MainWindowViewModel : MainViewModel
    {
        //będzie zawierała kolekcje komend, które pojawiają się w menu lewym oraz kolekcje zakładek 

        #region PolaIWlasciwosci
        private int _SideMenuWidth;
        public int SideMenuWidth
        {
            get
            {
                return _SideMenuWidth;
            }
            set
            {
                if (_SideMenuWidth != value)
                {
                    _SideMenuWidth = value;
                    OnPropertyChanged(() => SideMenuWidth);
                }
            }
        }
        #endregion

        #region Komendy menu i paska narzedzi



        public ICommand NewTowarCommand //ta komenda zostanie podpieta pod menu i pasek narzedzi
          {
              get
              {
                  return new BaseCommand(() => createView(new NewProductViewModel()));//to jest komenda, która wyw. funkcję createTowar
              }
          }
          public ICommand NewInvoiceCommand
          {
              get
              {
                  return new BaseCommand(() => createView(new NewInvoiceViewModel()));
              }
          }
          public ICommand NewClientCommand
          {
              get
              {
                  return new BaseCommand(() => createView(new NewClientViewModel()));
              }
          }
        public ICommand NewCennikCommand
          {
              get
              {
                  return new BaseCommand(() => createView(new NewCennikViewModel()));
              }
          } 
        public ICommand NewMagazynCommand
          {
              get
              {
                  return new BaseCommand(() => createView(new NewMagazynViewModel()));
              }
          }
          public ICommand AllInvoicesCommand
          {
              get
              {
                  return new BaseCommand(showAllInvoices);
              }
          }
          public ICommand AllTowarCommand
          {
              get
              {
                  return new BaseCommand(showAllProducts);
              }
          }
          public ICommand AllClientsCommand
          {
              get
              {
                  return new BaseCommand(showAllClients);
              }

          } 
        public ICommand AllMagazynCommand
          {
              get
              {
                  return new BaseCommand(showAllMagazyn);
              }

          }
          
        public ICommand ShowHideSideMenuAsyncCommand { get { return new BaseCommand(async () => await ShowHideSideMenuAsync()); } }
        public ICommand ShowRaportSprzedazyKontrahentCommand { get; set; }
        public ICommand ShowRaportSprzedazyWszyscyCommand { get; set; }


    #endregion

        #region Przyciski w menu z lewej strony
        private ReadOnlyCollection<CommandViewModel> _Commands;//to jest kolekcja komend w emnu lewym
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)//sprawdzam czy przyciski z lewej strony menu nie zostały zainicjalizowane
                {
                    List<CommandViewModel> cmds = this.CreateCommands();//tworzę listę przyciskow za pomocą funkcji CreateCommands
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);//tę listę przypisuje do ReadOnlyCollection (bo readOnlyCollection można tylko tworzyć, nie można do niej dodawać)
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()//tu decydujemy jakie przyciski są w lewym menu
        {
            Messenger.Default.Register<String>(this, open);
            return new List<CommandViewModel>
            {

                new CommandViewModel("Nowy towar",new BaseCommand(()=>createView(new NewProductViewModel()))),
                new CommandViewModel("Wszystkie towary",new BaseCommand(showAllProducts)),

                new CommandViewModel("Nowy kontrahent",new BaseCommand(()=>createView(new NewClientViewModel()))),
                new CommandViewModel("Wszyscy kontrahenci",new BaseCommand(showAllClients)),

                new CommandViewModel("Raport sprzedaży kontrahenta",new BaseCommand(()=>createView(new RaportSprzedazyKontrahentViewModel()))),
                new CommandViewModel("Raport sprzedaży wszyscy",new BaseCommand(()=>createView(new RaportSprzedazyWszyscyViewModel()))),
                new CommandViewModel("Raport sprzedanych towarów",new BaseCommand(()=>createView(new TowaryWystawioneRaportViewModel()))),

                new CommandViewModel("Nowa faktura",new BaseCommand(()=>createView(new NewInvoiceViewModel()))),
                new CommandViewModel("Wszystie faktury",new BaseCommand(showAllInvoices)),

                new CommandViewModel("Nowy magazyn",new BaseCommand(()=>createView(new NewMagazynViewModel()))),
                new CommandViewModel("Wszystkie magazyny",new BaseCommand(showAllMagazyn)),

                new CommandViewModel("Dodaj typ towaru",new BaseCommand(()=>createView(new NewTypTowaruViewModel()))),
                new CommandViewModel("Typy towaru",new BaseCommand(showTypTowaru)),

                new CommandViewModel("Nowe zamówienie",new BaseCommand(()=>createView(new NewZamowienieViewModel()))),
                new CommandViewModel("Wszystkie zamówienia",new BaseCommand(showAllZamowienia)),

                new CommandViewModel("Dodaj zwrot",new BaseCommand(()=>createView(new NewZwrotViewModel()))),
                new CommandViewModel("Wszystkie zwroty",new BaseCommand(showAllZwrot)),

                new CommandViewModel("Dodaj branżę",new BaseCommand(()=>createView(new NewBranzaViewModel()))),
                new CommandViewModel("Wszystkie branże",new BaseCommand(showBranza)),
               
                new CommandViewModel("Dodaj grupę towaru",new BaseCommand(()=>createView(new NewGrupaTowaruViewModel()))),
                new CommandViewModel("Grupy towaru",new BaseCommand(showGrupaTowaru)),
                
                new CommandViewModel("Dodaj jednostkę podstawową",new BaseCommand(()=>createView(new NewJednostkaPodstawowaViewModel()))),
                new CommandViewModel("Jednostki podstawowe",new BaseCommand(showJednostkaPodstawowa)),

                new CommandViewModel("Dodaj rodzaj działalności",new BaseCommand(()=>createView(new NewRodzajDzialalnosciViewModel()))),
                new CommandViewModel("Rodzaje dzialalnosci",new BaseCommand(showRodzajeDzialalnosci)),

                new CommandViewModel("Dodaj kategorię faktury",new BaseCommand(()=>createView(new NewKategoriaFakturyViewModel()))),
                new CommandViewModel("Kategorie faktury",new BaseCommand(showKategorieFaktury)),

                new CommandViewModel("Dodaj cennik",new BaseCommand(()=>createView(new NewCennikViewModel()))),
                new CommandViewModel("Wszystkie cenniki",new BaseCommand(showAllCennik)), 
                
                new CommandViewModel("Dodaj rodzaj cennika",new BaseCommand(()=>createView(new NewRodzajCennikaViewModel()))),
                new CommandViewModel("Wszystkie rodzaje cenników",new BaseCommand(showAllRodzajCennika)),
                
                new CommandViewModel("Dodaj sposób płatności",new BaseCommand(()=>createView(new NewSposobPlatnosciViewModel()))),
                new CommandViewModel("Sposoby płatności",new BaseCommand(showAllSposobPlatnosci)),
                
                new CommandViewModel("Lista województw",new BaseCommand(showAllWojewodztwa)),

};
        }
        #endregion

        #region Zakładki
        private ObservableCollection<WorkspaceViewModel> _Workspaces; //to jest kolekcja zakładek
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region Funkcje pomocnicze

        private async Task ShowHideSideMenuAsync()
        {

            if (SideMenuWidth > 0)
            {
                while (SideMenuWidth > 0)
                {
                    SideMenuWidth -= 20;
                    await Task.Delay(1);
                }
            }
            else
            {
                while (SideMenuWidth < 300)
                {
                    SideMenuWidth += 20;
                    await Task.Delay(1);
                }
            }
        }

        private void createView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        //to jest funkcja, która otwiera nową zakładke Towar
        //za każdym tworzy nową NOWĄ zakładkę do dodawania towaru
        //private void createTowar()
        //{
        //    //tworzy zakładke NowyTowar (VM)
        //    NowyTowarViewModel workspace=new NowyTowarViewModel();
        //    //dodajmy ją do kolkcji aktywnych zakładek
        //    this.Workspaces.Add(workspace);
        //    this.setActiveWorkspace(workspace);
        //}
        //to jest funkcja, która otwiera zakładke ze wszystkimi towarami
        //za każdym razem sprawdza czy zakladka z towarami jest juz otwarta, jak jest to ja aktywuje, ajk nie ma to tworzy 

        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }


        private void showAllSposobPlatnosci()
        {
            AllSposobPlatnosciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllSposobPlatnosciViewModel) as AllSposobPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new AllSposobPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllWojewodztwa()
        {
            AllWojewodztwaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllWojewodztwaViewModel) as AllWojewodztwaViewModel;
            if (workspace == null)
            {
                workspace = new AllWojewodztwaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showKategorieFaktury()
        {
            KategoriaFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is KategoriaFakturyViewModel) as KategoriaFakturyViewModel;
            if (workspace == null)
            {
                workspace = new KategoriaFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllInvoices()
        {
            AllInvoicesViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllInvoicesViewModel) as AllInvoicesViewModel;
            if (workspace == null)
            {
                workspace = new AllInvoicesViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllCennik()
        {
            CennikAllViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is CennikAllViewModel) as CennikAllViewModel;
            if (workspace == null)
            {
                workspace = new CennikAllViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllZamowienia()
        {
            AllZamowieniaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllZamowieniaViewModel) as AllZamowieniaViewModel;
            if (workspace == null)
            {
                workspace = new AllZamowieniaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllMagazyn()
        {
            AllMagazynViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllMagazynViewModel) as AllMagazynViewModel;
            if (workspace == null)
            {
                workspace = new AllMagazynViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllClients()
        {
            AllClientsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllClientsViewModel) as AllClientsViewModel;
            if (workspace == null)
            {

                workspace = new AllClientsViewModel();
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);
        }

        private void showAllProducts()
        {
            AllProductsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllProductsViewModel) as AllProductsViewModel;
            //jezeli ....
            if (workspace == null)
            {
                workspace = new AllProductsViewModel();
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }

        private void showTypTowaru()
        {
            TypTowaruViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is TypTowaruViewModel) as TypTowaruViewModel;

            if (workspace == null)
            {
                workspace = new TypTowaruViewModel();
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }
        private void showAllZwrot()
        {
            AllZwrotViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllZwrotViewModel) as AllZwrotViewModel;

            if (workspace == null)
            {
                workspace = new AllZwrotViewModel();
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);

        }


        private void showBranza()
        {
            BranzaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is BranzaViewModel) as BranzaViewModel;

            if (workspace == null)
            {
                workspace = new BranzaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }
        private void showGrupaTowaru()
        {
            GrupaTowaruViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is GrupaTowaruViewModel) as GrupaTowaruViewModel;

            if (workspace == null)
            {
                workspace = new GrupaTowaruViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }
        private void showJednostkaPodstawowa()
        {
            JednostkaPodstawowaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is JednostkaPodstawowaViewModel) as JednostkaPodstawowaViewModel;

            if (workspace == null)
            {
                workspace = new JednostkaPodstawowaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }
        private void showRodzajeDzialalnosci()
        {
            RodzajDzialalnosciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is RodzajDzialalnosciViewModel) as RodzajDzialalnosciViewModel;

            if (workspace == null)
            {
                workspace = new RodzajDzialalnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllRodzajCennika()
        {
            AllRodzajCennikaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllRodzajCennikaViewModel) as AllRodzajCennikaViewModel;

            if (workspace == null)
            {
                workspace = new AllRodzajCennikaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void open(String name)
        {
            // jezeli komunikat jest TowaryAdd, to otwieramy okno do dodawania towarow.
            if (name == "WszystkietowaryAdd")
            {
                createView(new NewProductViewModel());
            }
            if (name == "FakturyAdd")
            {
                createView(new NewInvoiceViewModel());
            }
            if (name == "KontrahenciAdd")
            {
                createView(new NewClientViewModel());
            }
            if (name == "MagazynyAdd")
            {
                createView(new NewMagazynViewModel());
            }
            if (name == "CennikiAdd")
            {
                createView(new NewCennikViewModel());
            }
            if (name == "ZamówieniaAdd")
            {
                createView(new NewZamowienieViewModel());
            }
            if (name == "ZwrotyAdd")
            {
                createView(new NewZwrotViewModel());
            } 
            if (name == "BranżeAdd")
            {
                createView(new NewBranzaViewModel());
            } 
            if (name == "GrupytowaruAdd")
            {
                createView(new NewGrupaTowaruViewModel());
            } 
            if (name == "TypytowaruAdd")
            {
                createView(new NewTypTowaruViewModel());
            }
            if (name == "JednostkipodstawoweAdd")
            {
                createView(new NewJednostkaPodstawowaViewModel());
            }
            if (name == "RodzajedziałalnościAdd")
            {
                createView(new NewRodzajDzialalnosciViewModel());
            }
            if (name == "SposobypłatnościAdd")
            {
                createView(new NewSposobPlatnosciViewModel());
            }
            if (name == "KategoriefakturAdd")
            {
                createView(new NewKategoriaFakturyViewModel());
            }
            if (name == "RodzajecennikówAdd")
            {
                createView(new NewRodzajCennikaViewModel());
            }
            
            if (name == "ClientsAll")
            {
                showAllClients();
            }
            if (name == "InvoicesAll")
            {
                showAllInvoices();
            }
            if (name == "ProductsAll")
            {
                showAllProducts();
            }
            if (name == "MagazynAll")
            {
                showAllMagazyn();
            }
            if (name == "CennikAll")
            {
                showAllCennik();
            }
            if (name == "GrupyTowaruAll")
            {
                showGrupaTowaru();
            }
            if (name == "TypyTowaruAll")
            {
                showTypTowaru();
            }
            if (name == "JednostkiAll")
            {
                showJednostkaPodstawowa();
            }
            if (name == "RodzajCennikaAll")
            {
                showAllRodzajCennika();
            }
            if (name == "BranzeAll")
            {
                showBranza();
            }
            if (name == "RodzajeDzialalnosciAll")
            {
                showRodzajeDzialalnosci();
            }            

        }
        #endregion
    }
}
