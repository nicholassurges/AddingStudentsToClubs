Public Class Form1
    'Declare variables
    'Adding the options in the combo box.
    Private strClubNames() As String = {
            "Honors", "Golden Arrows", "Computers", "Drama"}

    Private studentNames() As String = {
            "Adams, Ben", "Baker, Sally", "Canseco, Juan", "Davis, Sharon",
            "Etienne, Jean", "Gonzalex, Jose", "Johnson, Eric", "Koenig, Joann",
            "Matsunaga, Akiko", "Nakamura, Ken", "Ramirez, Mana", "Nick Surges"}

    'Keep track of the size of each club
    Private intEnrollSizes(strClubNames.Count) As Integer

    'Holds names of enrolled members of all clubs
    Private strEnrollments(0, 0) As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Add the clubNames to the combo box
        For Each clubName In strClubNames
            cboClubs.Items.Add(clubName)
        Next
        'add the student names to the student list box
        For Each studName In studentNames
            lstGeneral.Items.Add(studName)
        Next

        'Initiazlize the Enrollment array
        ReDim strEnrollments(strClubNames.Length, lstGeneral.Items.Count)

    End Sub

    'Function for checking for errors
    Function CheckForInsertErrors() As Boolean

        'check for the combo box selection
        If cboClubs.SelectedIndex = -1 Then
            MessageBox.Show("Select the name of the club")
            Return False
        End If

        'Check the selected index of lstGeneral
        If lstGeneral.SelectedIndex = -1 Then
            MessageBox.Show("Select the student from the studen list
                to add to the club")
            Return False
        End If

        'return true if there are no errors
        Return True

    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add button event to add the student into the club

        'Chek for errors
        If Not CheckForInsertErrors() Then
            Return
        End If

        'get the index of the club
        Dim clubIndex As Integer = cboClubs.SelectedIndex

        'get the index of the student names
        Dim name As String = lstGeneral.SelectedItem.ToString()

        'check to see if the student does not exist in the group
        'then add the student to the list membership intEnroll array
        If Not lstMembers.Items.Contains(name) Then
            lstMembers.Items.Add(lstGeneral.SelectedItem)

            intEnrollSizes(clubIndex) += 1
            lblCount.Text = lstMembers.Items.Count.ToString() & " Members"
        End If

        'Save the names back inot the master array
        For i = 0 To lstMembers.Items.Count - 1
            strEnrollments(clubIndex, i) = lstMembers.Items(i).ToString()
        Next

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'remove button event to remove students from the club member list

        'check selected index
        If lstMembers.SelectedIndex = -1 Then
            Return
        End If

        'get the selected index
        Dim index As Integer = lstMembers.SelectedIndex

        'get the index of the club
        Dim clubIndex As Integer = cboClubs.SelectedIndex

        'if index is not -1 then remove the item from the
        If index <> -1 Then
            lstMembers.Items.RemoveAt(index)
        End If

        'Save the names back into the Master array
        For i = 0 To lstMembers.Items.Count - 1
            strEnrollments(clubIndex, i) = lstMembers.Items(i).ToString()
        Next
        'update the count of the intEnrollSixes
        intEnrollSizes(clubIndex) = lstMembers.Items.Count

        'Display the totatl number of members
        lblCount.Text = lstMembers.Items.Count.ToString() & " Members"

    End Sub

    Private Sub cboClubs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClubs.SelectedIndexChanged
        'combo box selected index event

        'Fill the member list box with the names of pople
        'who belong to the currenlty selected club
        lstMembers.Items.Clear()

        Dim index As Integer = cboClubs.SelectedIndex

        'Copy member names from the enrollments master
        'array into the list box
        For i As Integer = 0 To intEnrollSizes(index) - 1
            lstMembers.Items.Add(strEnrollments(index, i))
        Next

        lblCount.Text = intEnrollSizes(index).ToString() & " Members"

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
