using Autofac;

namespace ITServiceAccounting
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cоздаем и настраиваем контейнер
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