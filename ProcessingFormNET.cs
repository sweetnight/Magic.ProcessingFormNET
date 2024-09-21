using System.Windows.Forms;
using Magic.FormsNET;

namespace Magic
{
    public partial class ProcessingFormNET : Form
    {
        private readonly DropShadow _dropShadow = new DropShadow();

        private int ParamType { get; set; } = 0;
        public Action? Worker { get; set; }
        public Action<string>? Worker1String { get; set; }
        private string? paramString { get; set; }
        public Action<int>? Worker1Int { get; set; }
        private int paramInt { get; set; }
        public Func<Task>? WorkerAsync { get; set; }

        private static ProcessingFormNET? currentInstance { get; set; }

        private ProcessingFormNET(Action worker)
        {
            InitializeComponent();

            _dropShadow.ApplyShadows(this);

            if (worker == null)
                throw new ArgumentNullException();

            Worker = worker;
        } // end of method

        private ProcessingFormNET(Action<string> worker, string param)
        {
            InitializeComponent();

            _dropShadow.ApplyShadows(this);

            if (worker == null)
                throw new ArgumentNullException();

            Worker1String = worker;
            this.paramString = param;
            ParamType = 1;
        } // end of method

        private ProcessingFormNET(Action<int> worker, int param)
        {
            InitializeComponent();

            _dropShadow.ApplyShadows(this);

            if (worker == null)
                throw new ArgumentNullException();

            Worker1Int = worker;
            this.paramInt = param;
            ParamType = 2;
        } // end of method

        private ProcessingFormNET(Func<Task> worker)
        {
            InitializeComponent();

            _dropShadow.ApplyShadows(this);

            if (worker == null)
                throw new ArgumentNullException();

            WorkerAsync = worker;
            ParamType = 3;
        } // end of method

        private void Start(string message, Form? owner)
        {

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Start(message, owner);
                });
            }
            else
            {
                this.PesanLabel.Text = message;

                if (owner == null)
                {
                    this.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    // Jika owner tidak null, atur posisi window muncul di tengah owner
                    this.TopMost = owner.TopMost;
                    this.StartPosition = FormStartPosition.CenterParent;
                }
                
                this.ShowDialog(owner);
            }


        } // end of method

        public static void Execute(string message, Action someAction)
        {
            // Dapatkan form yang saat ini aktif
            Form? owner = Application.OpenForms.OfType<Form>().LastOrDefault();

            // Buat instance ProcessingForm
            ProcessingFormNET processingForm = new ProcessingFormNET(someAction);

            // Set properti currentInstance
            currentInstance = processingForm;

            // Tampilkan form ProcessingForm
            processingForm.Start(message, owner);
        } // end of method

        public static void Execute(string message, Action<string> someAction, string param)
        {
            // Dapatkan form yang saat ini aktif
            Form? owner = Application.OpenForms.OfType<Form>().LastOrDefault();

            // Buat instance ProcessingForm
            ProcessingFormNET processingForm = new ProcessingFormNET(someAction, param);

            // Set properti currentInstance
            currentInstance = processingForm;

            // Tampilkan form ProcessingForm
            processingForm.Start(message, owner);
        } // end of method

        public static void Execute(string message, Action<int> someAction, int param)
        {
            // Dapatkan form yang saat ini aktif
            Form? owner = Application.OpenForms.OfType<Form>().LastOrDefault();

            // Buat instance ProcessingForm
            ProcessingFormNET processingForm = new ProcessingFormNET(someAction, param);

            // Set properti currentInstance
            currentInstance = processingForm;

            // Tampilkan form ProcessingForm
            processingForm.Start(message, owner);
        } // end of method

        public static async Task ExecuteAsync(string message, Func<Task> someAction)
        {

            // Dapatkan form yang saat ini aktif
            Form? owner = Application.OpenForms.OfType<Form>().LastOrDefault();

            // Buat instance ProcessingForm
            ProcessingFormNET processingForm = new ProcessingFormNET(someAction);

            // Set properti currentInstance
            currentInstance = processingForm;

            // Tampilkan form ProcessingForm secara asinkron
            await Task.Run(() =>
            {
                // Menunggu form ditampilkan dan task di dalamnya selesai
                processingForm.Start(message, owner);
            });

        } // end of method

        public static void UpdateLabel(string message)
        {
            if (currentInstance != null && currentInstance.InvokeRequired)
            {
                currentInstance.Invoke((MethodInvoker)delegate
                {
                    currentInstance.PesanLabel.Text = message;
                });
            }
            else if (currentInstance != null)
            {
                currentInstance.PesanLabel.Text = message;
            }
        } // end of method

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            switch (ParamType)
            {
                case 0:
                default:
                    Task.Factory.StartNew(() =>
                    {
                        Worker!();
                    }).ContinueWith(t =>
                    {
                        this.Close();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case 1:
                    Task.Factory.StartNew(() =>
                    {
                        Worker1String!(paramString!);
                    }).ContinueWith(t =>
                    {
                        this.Close();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case 2:
                    Task.Factory.StartNew(() =>
                    {
                        Worker1Int!(paramInt);
                    }).ContinueWith(t =>
                    {
                        this.Close();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case 3:
                    Task.Run(async () =>
                    {
                        await WorkerAsync!();
                    }).ContinueWith(t =>
                    {
                        this.Close();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
            }

        } // end of method
    } // end of class
} // end of namespace
