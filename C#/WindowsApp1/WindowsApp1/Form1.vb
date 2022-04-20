Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Public curNum As Integer
    Public dv As DataView
    Public dr As DataRow
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If curNum = 0 Then
            MsgBox("이미 처음 행입니다")
            Exit Sub
        End If
        curNum -= 1

        dr = dv.Item(curNum).Row
        tb_userID.Text = dr.Item("userID")
        tb_name.Text = dr.Item("name")
        tb_mDate.Text = dr.Item("mDate")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If curNum + 1 = dv.Count Then
            MsgBox("마지막 끝 행입니다")
            Exit Sub
        End If
        curNum = curNum + 1

        dr = dv.Item(curNum).Row
        tb_userID.Text = dr.Item("userID")
        tb_name.Text = dr.Item("name")
        tb_mDate.Text = dr.Item("mDate")

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SQL Sever에 접속하는 연결스트링 (DB는 sqlDB, 사용자는 vsUser, 비밀번호는 1234)
        Dim Conn As String = "Server= 210.119.12.70;DataBase=sqlDB;user=vsUser;password=1234"
        Dim sqlCon As New SqlConnection(Conn)
        Dim user_Data = New DataSet()
        sqlCon.Open()

        'userTbl의 아이디, 이름, 가입일 조회
        Dim strSQL As New SqlCommand("SELECT userID,name,mDate from userTbl", sqlCon)
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        da.SelectCommand = strSQL
        da.Fill(user_Data, "userTbl")

        dv = New DataView(user_Data.Tables("userTbl"))

        curNum = 0 ' 현재 행은 가정 첫행(0)을 가르킴

        dr = dv.Item(0).Row
        tb_userID.Text = dr.Item("userID") ' 아이디를 첫 번째 텍스트상자에 입력
        tb_name.Text = dr.Item("name") ' 이름을 두 번째 텍스트상자에 입력
        tb_mDate.Text = dr.Item("mDate") ' 가입일을 세 번째 텍스트상자에 입력

        da.Dispose()
        sqlCon.Close()
    End Sub
End Class
