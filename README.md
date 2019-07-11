# Trenton Ticketing WebApp

## De Team

Ons team bestaat uit de volgende personen; 

- Johnathan Dall - Full-stack developer/C# developer
- Nick van de Pepel - Teamleider/Scrum master
- Stefan van de Kamp - Front-end developer
- Stevan van Waveren - Front-end developer

## De App

Deze app is schreven voor Trenton. De opdracht die aan ons is gegeven is het moderniseren hun interne ticketing system. Deze was geschreven in de tijd dat <span>ASP. NET</span> Webforms modern was.

## Achterliggend Techniek

### <span>ASP.NET</span> Core

<span>ASP.NET</span> Core is de nieuwste iteratie van de webframework gecreerd door Microsoft. Deze framework is geinspirereert door de oude <span>ASP. NET</span> framework. In tegenstelling tot de oude framework word <span>ASP. NET</span> Core ontwikkeld als een modulair open - source framework die, in de toekomst, zowel voor websites als cross - platform. NET framework applicatie geschreven word.

### MVC

Model View Controller(MVC) MVC is een ontwerppatroon dat wordt gebruikt om gebruikersinterface(weergave), gegevens(model) en toepassingslogica(controller) te ontkoppelen. Dit patroon helpt om zorgen te scheiden.

### Entity Framework Core

Entity Framework(EF) Core is een lichtgewicht en uitbreidbare versie van de populaire Entity Framework - gegevenstoegangstechnologie. EF Core is een object relationele mapper(ORM) waarmee .NET - ontwikkelaars met .NET - objecten kunnen werken met een database.

## Installatie procedure website

Om deze applicatie te draaien in een ontwikkelings situatie moet u .Net core 2.2 of .Net 4.8 hebben, dit kunt u [hier](https://dotnet.microsoft.com/download) downloaden als dit nodig is.

### Procedure (Eerste Build)

Deze website gebruik zoals eerder vermeld Entity Framework Core, om de database te bouwen die hoort bij de webapp moet je, in powershell of Package Manager Console(Visual Studio), de volgende commando's uitvoeren;
<br />
**NOTE: [Tekst hier] Betekend dat u zelf mag invullen wat hierin komt te staan**

- Add-Migration [Tekst hier] -Context TicketAppContext
- Update-Database [Tekst hier] -Context TicketAppContext
- Add-Migration [Tekst hier] -Context TicketSystemContext
- Update-Database [Tekst hier] -Context TicketSystemContext

Na deze commando's uit te voeren heb je een werkend versie van de WebApp. Doordat er geen communicatie met betrekking tot de configuratie van de server is deze op een generieke manier gemaakt. Als deze veranderd moet worden kunt u de configuratie vinden in de Startup.cs bestand onder de variabel connection.
