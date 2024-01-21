using BibKlas.AlgebraLiniowa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace GaussLinearMethod
{
    public partial class Form1 : Form
    {
        int N;
        int M;
        double[,] A;
        double[] B, X, Test;
        double[,] BB, XX, TEST_X;
        bool IsGenerated = false;
        Complex[,] cA;
        Complex[] cB, cX;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {     
            //N varible set
            N = ( int )numericUpDown1.Value;
            if ( N != 0 )
            {
                SetGrid();
            }                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Generate
            Random random = new Random();
            double Ax;
            double suma = 0;           
            N = ( int )numericUpDown1.Value;
            SetGrid();
            A = new double[ N + 1, N + 1 ];
            B = new double[ N + 1 ];
            X = new double[ N + 1 ];
            Test = new double[ N + 1 ];

            for (int i = 1; i <= N; i++)
            {
                suma = 0;
                for (int j = 1; j <= N; j++)
                {
                    Ax = random.Next(1, 100);
                    dataGridView1[i - 1, j - 1].Value = Ax.ToString();
                    A[i, j] = Ax;
                    suma = suma + Ax;
                    
                }
                Test[i] = suma;
                dataGridView4[0, i - 1].Value = suma.ToString();
                Ax = random.Next(1, 100);
                B[i] = Ax;
                dataGridView3[0, i - 1].Value = Ax;
            }
            IsGenerated = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Test Button
            if (IsGenerated)
            { 
                if (N > 1)
                {
                    MetodaGaussa.RozRowMacGaussa(A, Test, X, 2e-13);
                    ShowColumn(X, dataGridView2);
                }
                else
                {
                    MessageBox.Show("N is less than 2");
                }
                IsGenerated = false;
            }
            else
            {
                MessageBox.Show("Please generate new set");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Solve Button         
            if (IsGenerated)
            {
                if (N > 1)
                {
                    MetodaGaussa.RozRowMacGaussa(A, B, X, 2e-13);
                    ShowColumn(X, dataGridView2);
                }
                else
                {
                    MessageBox.Show("N is less than 2");
                }
                IsGenerated = false;
            }
            else
            {
                MessageBox.Show("Please generate new set");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Genrate higher dimensions
            Random random = new Random();
            double Ax;
            double suma = 0;
            N = (int)numericUpDown1.Value;
            SetGridForMDimentions();
            A = new double[N + 1, N + 1];
            BB = new double[N + 1, M + 1];
            XX = new double[N + 1, M + 1];
            Test = new double[N + 1];

            for (int i = 1; i <= N; i++)
            {
                suma = 0;
                for (int j = 1; j <= N; j++)
                {                   
                    Ax = random.Next(1, 100);
                    dataGridView1[i - 1, j - 1].Value = Ax.ToString();
                    A[i, j] = Ax;
                    if(i == 1)
                    {
                        dataGridView1[i - 1, j - 1].Value = "uuu";
                    }
                    suma += Ax;
                }              
                Test[i] = suma;
                dataGridView4[0, i - 1].Value = suma.ToString();                             
            }
           

            for (int i = 1; i <= N; i++)
            {
                
                for (int k = 1; k <= M; k++)
                {
                    Ax = random.Next(1, 100);
                    dataGridView3[i - 1, k - 1].Value = Ax.ToString();
                    BB[i, k] = Ax;
                }
                Test[i] = suma;
                dataGridView4[0, i - 1].Value = suma;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Solve higher dimensions
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Test higher dimensions
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //M variable set
            M = (int)numericUpDown2.Value;
            SetGridForMDimentions();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Solve Complex
            MetodaGaussa.RozRowMacGaussa(cA, cB, cX, 2e-13);
            for(int i = 1; i <= N; i++)
            {
                dataGridView2[0,i - 1].Value = cX[i].Real.ToString("F3") + "," + cX[i].Imaginary.ToString("F3") + "i";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Generate Complex            
            Random random = new Random();
            double Ax;
            double Bx;          
            N = (int)numericUpDown1.Value;
            SetGrid();
            cA = new Complex[N + 1, N + 1];           
            cB = new Complex[N + 1];
            cX = new Complex[N + 1];
                      
            for (int i = 1; i <= N; i++)
            {               
                for (int j = 1; j <= N; j++)
                {                                       
                    Ax = random.Next(1, 100);
                    Bx = random.Next(1, 100);
                    cA[i,j] = new Complex(Ax, Bx);
                    dataGridView1[i - 1, j - 1].Value = Ax.ToString() +","+ Bx.ToString() +"i";
                }
                Ax = random.Next(1, 100);
                Bx = random.Next(1, 100);
                cB[i] = new Complex(Ax, Bx);
                dataGridView3[0,i - 1].Value = Ax.ToString() + "," + Bx.ToString() +"i";                
            }           
        }

       

        void SetGrid()
        {
            dataGridView1.ColumnCount = N;
            dataGridView1.RowCount = N;
            dataGridView2.RowCount = N;
            dataGridView3.RowCount = N;
            dataGridView4.RowCount = N;
            
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView2.ColumnHeadersHeight = 50;
            dataGridView3.ColumnHeadersHeight = 50;
            dataGridView4.ColumnHeadersHeight = 50;
            dataGridView2.Columns[ 0 ].Width = 95;
            dataGridView3.Columns[ 0 ].Width = 55;
            dataGridView4.Columns[ 0 ].Width = 65;
            for( int i = 0; i < N; i++ )
            {
                dataGridView1.Columns[ i ].Width = 45;
                dataGridView1.Columns[ i ].HeaderText = ( i + 1 ).ToString();
                dataGridView1.Rows[ i ].HeaderCell.Value = ( i + 1 ).ToString();
                dataGridView2.Rows[ i ].HeaderCell.Value = ( i + 1 ).ToString();
                dataGridView3.Rows[ i ].HeaderCell.Value = ( i + 1 ).ToString();
                dataGridView4.Rows[ i ].HeaderCell.Value = ( i + 1 ).ToString();

            }
        }

        void ShowColumn( double[] _X, DataGridView dataGridView )
        {
            for ( int i = 1; i <= N; i++ )
            {
                dataGridView[ 0, i - 1 ].Value = _X[ i ];
            }
        }

        void SetGridForMDimentions()
        {
            dataGridView1.ColumnCount = N;
            dataGridView2.ColumnCount = M;
            dataGridView3.ColumnCount = M;
            
            dataGridView1.RowCount = N;
            dataGridView2.RowCount = N;
            dataGridView3.RowCount = N;
            dataGridView4.RowCount = N;

            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView2.ColumnHeadersHeight = 50;
            dataGridView3.ColumnHeadersHeight = 50;
            dataGridView4.ColumnHeadersHeight = 50;
            dataGridView2.Columns[0].Width = 95;
            dataGridView3.Columns[0].Width = 55;
            dataGridView4.Columns[0].Width = 65;
            for (int i = 0; i < N; i++)
            {
                dataGridView1.Columns[i].Width = 45;
                dataGridView1.Columns[i].HeaderText = (i + 1).ToString();
                
                
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView2.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView3.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dataGridView4.Rows[i].HeaderCell.Value = (i + 1).ToString();

            }
            for(int i = 0; i < M; i++)
            {
                dataGridView2.Columns[i].HeaderText = (i + 1).ToString();
                dataGridView3.Columns[i].HeaderText = (i + 1).ToString();
            }
        }
    }
}
