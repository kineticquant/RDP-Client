Imports MSTSCLib

Public Class RDPBase
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        Try

            rdpView.Server = txtServer.Text
            rdpView.UserName = txtUserName.Text

            Dim isSecured As IMsTscNonScriptable =
               DirectCast(rdpView.GetOcx(), IMsTscNonScriptable)

            isSecured.ClearTextPassword = txtPassword.Text

            rdpView.Connect()

        Catch ex As Exception

            MessageBox.Show("Cannot Connect", "Cannot Connect to: " _
               + txtServer.Text + " Reason:  " + ex.Message,
               MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub BtnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Try

            If rdpView.Connected.ToString() = "1" Then

                rdpView.Disconnect()

            End If

        Catch ex As Exception

            MessageBox.Show("Cannot Disconnect",
               "Cannot Disconnect from: " _
               + txtServer.Text + " Reason: " + ex.Message,
               MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
