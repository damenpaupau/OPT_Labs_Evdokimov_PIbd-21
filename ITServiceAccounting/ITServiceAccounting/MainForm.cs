using ITServiceAccounting.interfaces;

namespace ITServiceAccounting
{
    public partial class MainForm : Form
    {
        // Поля для хранения репозиториев
        private readonly IOrganizationRepository _organizationRepo;
        private readonly IExecutorRepository _executorRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IContractRepository _contractRepo;

        // Внедрение зависимостей через конструктор
        public MainForm(
            IOrganizationRepository organizationRepo,
            IExecutorRepository executorRepo,
            IServiceRepository serviceRepo,
            IContractRepository contractRepo)
        {
            InitializeComponent();

            _organizationRepo = organizationRepo;
            _executorRepo = executorRepo;
            _serviceRepo = serviceRepo;
            _contractRepo = contractRepo;
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void договорыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ContractListForm(_contractRepo, _organizationRepo, _executorRepo, _serviceRepo);
            form.ShowDialog();
        }

        private void организацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrganizationListForm(_organizationRepo);
            form.ShowDialog(); 
        }

        private void исполнителииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ExecutorListForm(_executorRepo);
            form.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ServiceListForm(_serviceRepo);
            form.ShowDialog();
        }
    }
}
