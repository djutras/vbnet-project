Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Car Loan Calculator"
        Me.Width = 600
        Me.Height = 500
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Create and position controls
        CreateControls()
    End Sub

    Private txtLoanAmount As TextBox
    Private txtInterestRate As TextBox
    Private txtLoanTerm As TextBox
    Private txtDownPayment As TextBox
    Private lblMonthlyPayment As Label
    Private lblTotalPayment As Label
    Private btnCalculate As Button

    Private Sub CreateControls()
        ' Loan Amount
        Dim lblLoanAmount As New Label()
        lblLoanAmount.Text = "Loan Amount ($):"
        lblLoanAmount.Location = New Point(20, 20)
        lblLoanAmount.AutoSize = True
        Me.Controls.Add(lblLoanAmount)

        txtLoanAmount = New TextBox()
        txtLoanAmount.Location = New Point(150, 20)
        txtLoanAmount.Width = 150
        Me.Controls.Add(txtLoanAmount)

        ' Interest Rate
        Dim lblInterestRate As New Label()
        lblInterestRate.Text = "Interest Rate (%):"
        lblInterestRate.Location = New Point(20, 60)
        lblInterestRate.AutoSize = True
        Me.Controls.Add(lblInterestRate)

        txtInterestRate = New TextBox()
        txtInterestRate.Location = New Point(150, 60)
        txtInterestRate.Width = 150
        Me.Controls.Add(txtInterestRate)

        ' Loan Term
        Dim lblLoanTerm As New Label()
        lblLoanTerm.Text = "Loan Term (months):"
        lblLoanTerm.Location = New Point(20, 100)
        lblLoanTerm.AutoSize = True
        Me.Controls.Add(lblLoanTerm)

        txtLoanTerm = New TextBox()
        txtLoanTerm.Location = New Point(150, 100)
        txtLoanTerm.Width = 150
        Me.Controls.Add(txtLoanTerm)

        ' Down Payment
        Dim lblDownPayment As New Label()
        lblDownPayment.Text = "Down Payment ($):"
        lblDownPayment.Location = New Point(20, 140)
        lblDownPayment.AutoSize = True
        Me.Controls.Add(lblDownPayment)

        txtDownPayment = New TextBox()
        txtDownPayment.Location = New Point(150, 140)
        txtDownPayment.Width = 150
        Me.Controls.Add(txtDownPayment)

        ' Calculate Button
        btnCalculate = New Button()
        btnCalculate.Text = "Calculate"
        btnCalculate.Location = New Point(150, 180)
        btnCalculate.Width = 100
        AddHandler btnCalculate.Click, AddressOf CalculatePayment
        Me.Controls.Add(btnCalculate)

        ' Results Labels
        lblMonthlyPayment = New Label()
        lblMonthlyPayment.Text = "Monthly Payment: $0.00"
        lblMonthlyPayment.Location = New Point(20, 220)
        lblMonthlyPayment.AutoSize = True
        lblMonthlyPayment.Font = New Font(lblMonthlyPayment.Font, FontStyle.Bold)
        Me.Controls.Add(lblMonthlyPayment)

        lblTotalPayment = New Label()
        lblTotalPayment.Text = "Total Payment: $0.00"
        lblTotalPayment.Location = New Point(20, 250)
        lblTotalPayment.AutoSize = True
        lblTotalPayment.Font = New Font(lblTotalPayment.Font, FontStyle.Bold)
        Me.Controls.Add(lblTotalPayment)
    End Sub

    Private Sub CalculatePayment(sender As Object, e As EventArgs)
        Try
            ' Get values from textboxes
            Dim loanAmount As Double = Double.Parse(txtLoanAmount.Text)
            Dim interestRate As Double = Double.Parse(txtInterestRate.Text)
            Dim loanTerm As Integer = Integer.Parse(txtLoanTerm.Text)
            Dim downPayment As Double = Double.Parse(txtDownPayment.Text)

            ' Calculate loan
            Dim principal As Double = loanAmount - downPayment
            Dim monthlyRate As Double = (interestRate / 100) / 12
            Dim monthlyPayment As Double = principal * (monthlyRate * (1 + monthlyRate) ^ loanTerm) / ((1 + monthlyRate) ^ loanTerm - 1)
            Dim totalPayment As Double = monthlyPayment * loanTerm

            ' Display results
            lblMonthlyPayment.Text = $"Monthly Payment: {monthlyPayment:C2}"
            lblTotalPayment.Text = $"Total Payment: {totalPayment:C2}"
        Catch ex As Exception
            MessageBox.Show("Please enter valid numbers for all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
