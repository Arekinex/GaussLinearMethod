pomyliłem kolumny z rzędami i dlatego sumuje kolumny a nie  rzędy w //Generate 
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
            dataGridView1[i - 1, j - 1].Value = Ax.ToString();                  Tutaj
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
