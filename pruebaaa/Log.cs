using pruebaaa.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaaa
{
    public partial class Log : Form
    {
        Clog log = new Clog();
        public Log()
        {
            InitializeComponent();
            log.mostrarLogs(dgvLog);
        }
    }
}
