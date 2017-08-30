Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Core

#End Region

Namespace Repositories.Core.Exceptions

    Public Class DbConstraintViolationException

        Inherits Exception

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Public Sub New(ByVal inner As Exception _
        , ByVal action As EntityState, ByVal lasteExecutedStatement As Statement)

            MyBase.New(GetMesasage(inner, action, lasteExecutedStatement), inner)
        End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
        Private Shared Function ParseInnerExecption(ByVal inner As Exception) As String
            Dim message = Text.RegularExpressions.Regex.Split _
            (inner.InnerException.InnerException.Message, " fails ").Last
            Return message.Replace _
            ("`", "").Replace _
            (" ", "").Replace _
            (",", "").Replace _
            ("(", "|").Replace _
            (")", "").Replace _
            ("CONSTRAINT", "|").Replace _
            ("FOREIGNKEY", "|").Replace _
            ("REFERENCES", "|").Replace _
            ("||", "|").Substring(1)
        End Function

        Private Shared Function GetMesasage(ByVal inner As Exception _
        , ByVal action As EntityState, ByVal lasteExecutedStatement As Statement) As String

            Dim constraintInfo = New List(Of String) _
            (New String() {ParseInnerExecption(inner)}).Select _
            (Function(x) x.Split("|"c)).Select _
            (Function(x) New With {.ReferencedTableName = x(3) _
            , .ReferencedTableFieldName = x(4) _
            , .ForeignKeyTableName = x(0) _
            , .ForeignKeyTableFieldName = x(2) _
            , .ForeignKeyName = x(1)}).FirstOrDefault

            Dim message = String.Format(String.Concat _
            ("DbConstraintViolationException{0}{0}" _
            , "Action: {1}{0}" _
            , "ForeignKeyName: {2}{0}" _
            , "ForeignKeyTableName: {3}{0}" _
            , "ForeignKeyTableFieldName: {4}{0}" _
            , "ReferencedTableName: {5}{0}" _
            , "ReferencedTableFieldName: {6}{0}{0}" _
            , "ExecutedStatment:{0}{7}{0}") _
            , vbCrLf, action.ToString _
            , constraintInfo.ForeignKeyName _
            , constraintInfo.ForeignKeyTableName _
            , constraintInfo.ForeignKeyTableFieldName _
            , constraintInfo.ReferencedTableName _
            , constraintInfo.ReferencedTableFieldName _
            , lasteExecutedStatement.ToString)

            Return message
        End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace
