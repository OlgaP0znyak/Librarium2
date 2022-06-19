﻿<%@ Page Title="Функционал приложения" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reference.aspx.cs" Inherits="Librarium2.Reference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center"><%: Title %></h1>
    <br>
    <br>
    <div class="col-md-4">
        <h3>Ведение справочников</h3>
        <p>
            Приложение предоставляет пользователям возможности для ведения справочников книг и читателей.<br>
            Например, при открытии пользователем справочника книг на форму выводится список всех книг в виде таблицы со следующей информацией:<br>
            –	код книги;<br>
            –	автор;<br>
            –	название.<br>
            При двойном щелчке по любой записи таблицы открывается карточка с подробной информацией о данной книге, доступная для редактирования.
        </p>
    </div>
    <div class="col-md-4">
        <h3><span>Проведение операций движения книг</span></h3>
        <p>В приложении реализован функционал, позволяющий проводить следующие операции:<br>
–	поступление новых книг в библиотеку;<br>
–	списание книг;<br>
–	выдача книги читателю;<br>
–	возврат книги от читателя.<br>
        Например, при открытии пользователем операций Выдачи на форму выводится список всех документов выдачи книг.
            При двойном клике по любому из документов выдачи книг открывается выбранный документ.
            При двойном клике по любому из документов выдачи книг открывается выбранный документ.
            При этом необходимо выбрать читателя путем ввода части его имени или фамилии, затем кликнуть на нужной записи читателя.

</p>        
    </div>
    <div class="col-md-4">
        <h3>Формирование отчетов</h3>
        <p>В приложении реализовано два отчета для получения справочной информации. Это отчеты Остатки и Книги на руках. <br>
Например, отчет Остатки позволяет получить информацию о количестве книг, доступных для выдачи читателям.<br>
При этом с помощью поиска можно получить информацию о конкретной книге.

</p>        
    </div>
</asp:Content>