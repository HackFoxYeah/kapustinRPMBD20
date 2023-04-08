--Создать SQL-запрос для получения следующих Сведений: Наименование 
--региона, Наименование отрасли, Наименование объекта, Год ввода в эксплуатацию.
SELECT RegionName AS [Наименование региона], SectorName AS [Наименование отрасли], BuildingObjectName AS [Наименование объекта], EnterYear AS [Год ввода в эксплуатацию]
FROM dbo.[BuildingObject] INNER JOIN dbo.[Regions] ON Regions.RegionId = BuildingObject.RegionId
INNER JOIN dbo.[Sectors] ON Sectors.SectorId = BuildingObject.SectorId