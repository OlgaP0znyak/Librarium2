<%@ Page Title="Главная страница" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Librarium2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <br>
    <br>
    <br>
    <br>
    <div style="border: thin solid #3333CC;">
        <p class="text-center" style="font-size: 80px; font-style: italic; color: #3333CC"><b>Либрариум</b></p>
        <p class="text-center" style="font-size: 36px">Либрариум — интерактивное веб-приложение библиотеки</p>        
    </div>
    <br>
    <br>
    <br>
    <div class="row">
        <div class="col-md-4">
            <h2>Справочная информация</h2>
            <p>
                Описание основных блоков веб-приложения, реализованного функционала.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Reference">Подробнее &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>О разработке</h2>
            <p>
               Краткие сведения о разработке и разработчике веб-приложения.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Development">Подробнее &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Контакты</h2>
            <p>
                Контакты для обращений пользоветелей по различным вопросам.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Contact">Подробнее &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
