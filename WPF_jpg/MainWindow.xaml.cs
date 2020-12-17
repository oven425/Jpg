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
using System.ComponentModel;

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

        CMinUI m_MainUI;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.m_MainUI == null)
            {
                this.m_MainUI = new CMinUI();
                for(int i=1; i<9; i++)
                {
                    CData dd = new CData();
                    dd.Name = $"photo - {i}";
                    dd.Image = $"pack://application:,,,/{dd.Name}.jpg";
                    StreamResourceInfo sri = Application.GetResourceStream(new Uri(dd.Image, UriKind.Absolute));
                    CJpgReader jr = new CJpgReader();
                    jr.Parse(sri.Stream);
                    switch(jr.Rotate)
                    {
                        case 1:
                        case 2:
                            {
                                dd.Angle = 0;
                            }
                            break;
                        case 3:
                        case 4:
                            {
                                dd.Angle = 180;
                            }
                            break;
                        case 5:
                        case 6:
                            {
                                dd.Angle = 270;
                            }
                            break;
                        case 7:
                        case 8:
                            {
                                dd.Angle = 90;
                            }
                            break;
                    }
                    if(jr.Rotate >=0)
                    {
                        dd.IsMirror = jr.Rotate % 2 == 0 ? -1 : 1;
                    }
                    else
                    {
                        dd.IsMirror = 1;
                    }
                    dd.Headers = jr.Headers;
                    this.m_MainUI.Datas.Add(dd);
                }

                this.DataContext = this.m_MainUI;
            }
        }

        string ToHtmlTable(List<CJpgHear> datas)
        {
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

    public class CMinUI : INotifyPropertyChanged
    {
        public List<CData> Datas { set; get; } = new List<CData>();
        public event PropertyChangedEventHandler PropertyChanged;
        void Update(string name)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class CData
    {
        public string Image { set; get; }
        public string Name { set; get; }
        public List<CJpgHear> Headers { set; get; }
        public int Angle { set; get; }
        public int IsMirror { set; get; }
    }
}
