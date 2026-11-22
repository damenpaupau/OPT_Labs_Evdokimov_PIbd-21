using Autofac;

namespace ITServiceAccounting
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, args) =>
            {
                string message = args.Exception.InnerException?.Message ?? args.Exception.Message;
                MessageBox.Show(
                    $"Ошибка при выполнении операции:\n{message}",
                    "Ошибка приложения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            // Создаём и настраиваем контейнер
            var container = ContainerConfig.Configure();

            // Получаем главную форму из контейнера со всеми готовыми зависимостями
            using (var scope = container.BeginLifetimeScope())
            {
                var mainForm = scope.Resolve<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
}