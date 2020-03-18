using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RisksManagementClient.UI
{
    public class MessageBoxes
    {
        public void ShowOkResult(string msg, string caption = "Результат выполнения операции")
        {
            MessageBox.Show(msg, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowErrorResult(string msg, string caption = "Результат выполнения операции")
        {
            MessageBox.Show(msg, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
