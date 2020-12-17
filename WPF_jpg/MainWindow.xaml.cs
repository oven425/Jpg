using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace WPF_jpg
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("pack://application:,,,/photo - 1.jpg", UriKind.Absolute));
            CJpgReader jr = new CJpgReader();
            jr.Parse(sri.Stream);
            this.listview.ItemsSource = jr.Headers;
            string str = this.ToHtmlTable(jr.Headers);
            str = str.Replace("\r\n", "");
        }

        string ToHtmlTable(List<CJpgHear> datas)
        {
            //< style >
            //table, th, td {
            //            border: 1px solid black;
            //                border - collapse: collapse;
            //            }
            //</ style >
            //< table >
            //  < tr >
            //    < th > Firstname </ th >
            //    < th > Lastname </ th >
            //    < th > Age </ th >
            //  </ tr >
            //  < tr >
            //    < td > Jill </ td >
            //    < td > Smith </ td >
            //    < td > 50 </ td >
            //  </ tr >
            //  < tr >
            //    < td > Eve </ td >
            //    < td > Jackson </ td >
            //    < td > 94 </ td >
            //  </ tr >
            //  < tr >
            //    < td > John </ td >
            //    < td > Doe </ td >
            //    < td > 80 </ td >
            //  </ tr >
            //</ table >
            StringBuilder strb = new StringBuilder();
            strb.AppendLine("<style>");
            strb.AppendLine("table, th, td {border: 1px solid black;border - collapse: collapse;}");
            strb.AppendLine("</style>");
            strb.AppendLine("<table>");
            strb.AppendLine("<tr>");
            strb.AppendLine($"<td>Pos</td>");
            strb.AppendLine($"<td>Name</td>");
            strb.AppendLine($"<td>Size</td>");
            strb.AppendLine($"<td>Data</td>");
            strb.AppendLine("</tr>");
            foreach (var oo in datas)
            {
                strb.AppendLine("<tr>");
                strb.AppendLine($"<td>{oo.Pos}</td>");
                strb.AppendLine($"<td>{oo.Name}</td>");
                strb.AppendLine($"<td>{oo.Size}</td>");
                if(string.IsNullOrEmpty(oo.Data)==false)
                {
                    strb.AppendLine($"<td>{oo.Data}</td>");
                }
                
                strb.AppendLine("</tr>");
            }
            strb.AppendLine("</table>");
            return strb.ToString();
        }
    }
}
